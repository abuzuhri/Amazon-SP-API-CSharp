using System.Globalization;
using System.Text;
using FikaAmazonAPI.ConstructFeed;
using FikaAmazonAPI.ConstructFeed.Messages;
using FikaAmazonAPI.Parameter.FbaInventory;
using FikaAmazonAPI.Parameter.ListingItem;
using FikaAmazonAPI.Parameter.ProductPricing;
using FikaAmazonAPI.Utils;
using Newtonsoft.Json.Linq;

namespace FikaAmazonAPI.SampleCode
{
    /// <summary>
    /// Price-cycle test on one ASIN against one competitor (default B0098TN3NA vs Esthetica):
    ///   - start at the high price (315.00),
    ///   - every 15 minutes go down 0.25,
    ///   - every 4 hours go back up to the high price and wait for the competitor to follow,
    ///   - repeat until stopped (Ctrl+C).
    /// Every 5 minutes it reads the live offers (our offers, the competitor, every FBA offer, the buy box)
    /// and writes everything to a log (readable) and a CSV (one row per reading) to look at later.
    ///
    /// Run:  dotnet run -- pricecycle [asin] [high] [step] [floor]
    ///       e.g. dotnet run -- pricecycle B0098TN3NA 315 0.25 300
    /// Uses the seller account in user secrets (FikaAmazonAPI:SellerId ...) - only that account's SKUs
    /// for the ASIN are changed. Other accounts and the ICANLO repricer must leave the ASIN alone
    /// during the test, or they will move the price too (ConsICANLOapp appsettings "RepricerSkipAsins").
    /// </summary>
    public class PriceCycleTest
    {
        private readonly AmazonConnection amazon;
        private readonly string sellerId;
        private readonly string asin;
        private readonly decimal high;
        private readonly decimal step;
        private readonly decimal floor;
        private readonly string rivalSellerId;
        private readonly TimeSpan stepEvery = TimeSpan.FromMinutes(15);
        private readonly TimeSpan resetEvery = TimeSpan.FromHours(4);
        private readonly TimeSpan readEvery = TimeSpan.FromMinutes(5);
        private readonly string logPath;
        private readonly string csvPath;
        private readonly object logLock = new object();

        public PriceCycleTest(AmazonConnection amazon, string sellerId, string asin = "B0098TN3NA", decimal high = 315.00m,
            decimal step = 0.25m, decimal floor = 300.00m, string rivalSellerId = "A25FNY0Z4NNPEJ")
        {
            this.amazon = amazon;
            this.sellerId = sellerId;
            this.asin = asin;
            this.high = high;
            this.step = step;
            this.floor = floor;
            this.rivalSellerId = rivalSellerId;
            var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "PriceCycleTest");
            Directory.CreateDirectory(dir);
            var stamp = DateTime.UtcNow.ToString("yyyyMMdd-HHmmss");
            logPath = Path.Combine(dir, $"{asin}_{stamp}.log");
            csvPath = Path.Combine(dir, $"{asin}_{stamp}.csv");
        }

        public async Task RunAsync(CancellationToken ct)
        {
            Log($"START asin={asin} seller={sellerId} high={high} step=-{step} every {stepEvery.TotalMinutes:0} min, back to {high} every {resetEvery.TotalHours:0} h, floor={floor}, rival={rivalSellerId}");
            Log($"log: {logPath}");
            Log($"csv: {csvPath}");
            File.AppendAllText(csvPath, "utc,phase,cycle,our_target,our_live_min,rival_price,rival_is_buybox,buybox_seller,buybox_price,we_have_buybox,fba_offers,all_offers" + Environment.NewLine);

            var skus = await FindSkusAsync(ct);
            if (skus.Count == 0)
            {
                Log("STOP: no SKU of this seller account found for the ASIN (FBA inventory). Nothing changed.");
                return;
            }
            Log("SKUs: " + string.Join(", ", skus));

            var cycle = 0;
            while (!ct.IsCancellationRequested)
            {
                cycle++;
                var cycleStart = DateTime.UtcNow;
                var target = high;
                Log($"CYCLE {cycle}: going UP to {target:0.00} and waiting for {rivalSellerId} to follow");
                await SetPriceAsync(skus, target, $"cycle {cycle} reset up", ct);
                var nextStep = cycleStart + stepEvery;
                var nextRead = DateTime.UtcNow;   // read now, then every readEvery
                decimal? rivalAtStart = null;
                var followedLogged = false;

                while (!ct.IsCancellationRequested && DateTime.UtcNow - cycleStart < resetEvery)
                {
                    if (DateTime.UtcNow >= nextRead)
                    {
                        var snap = await ReadOffersAsync(ct);
                        if (snap != null)
                        {
                            rivalAtStart ??= snap.RivalPrice;
                            WriteSnapshot(snap, DateTime.UtcNow - cycleStart < stepEvery ? "after-up" : "stepping-down", cycle, target);
                            if (!followedLogged && snap.RivalPrice.HasValue && rivalAtStart.HasValue && snap.RivalPrice > rivalAtStart + 0.005m)
                            {
                                Log($"  RIVAL FOLLOWED UP: {rivalAtStart:0.00} -> {snap.RivalPrice:0.00} after {(DateTime.UtcNow - cycleStart).TotalMinutes:0} min");
                                followedLogged = true;
                            }
                        }
                        nextRead = DateTime.UtcNow + readEvery;
                    }

                    if (DateTime.UtcNow >= nextStep)
                    {
                        var down = Math.Round(target - step, 2);
                        if (down < floor)
                        {
                            Log($"  floor {floor:0.00} reached - holding {target:0.00} until the next reset");
                        }
                        else
                        {
                            target = down;
                            await SetPriceAsync(skus, target, $"cycle {cycle} step down", ct);
                        }
                        nextStep += stepEvery;
                    }

                    try { await Task.Delay(TimeSpan.FromSeconds(20), ct); } catch (TaskCanceledException) { break; }
                }
                if (!followedLogged && !ct.IsCancellationRequested)
                    Log($"  cycle {cycle} ended - {rivalSellerId} did not follow above {rivalAtStart:0.00}");
            }
            Log("STOPPED (Ctrl+C). The last price stays on Amazon - the ICANLO repricer takes over once the ASIN is removed from RepricerSkipAsins.");
        }

        // ------------------------------------------------------------------ Amazon calls

        /// <summary>This seller account's SKUs for the ASIN, from the FBA inventory.</summary>
        private async Task<List<string>> FindSkusAsync(CancellationToken ct)
        {
            try
            {
                var list = await amazon.FbaInventory.GetInventorySummariesAsync(new ParameterGetInventorySummaries
                {
                    details = false,
                    granularityType = AmazonSpApiSDK.Models.FbaInventory.Granularity.GranularityTypeEnum.Marketplace,
                    granularityId = amazon.GetCurrentMarketplace.ID,
                    marketplaceIds = new List<string> { amazon.GetCurrentMarketplace.ID },
                }, ct);
                return list.SelectMany(page => page).Where(s => string.Equals(s.Asin, asin, StringComparison.OrdinalIgnoreCase))
                           .Select(s => s.SellerSku).Where(s => !string.IsNullOrEmpty(s)).Distinct().ToList();
            }
            catch (Exception ex)
            {
                Log("ERROR finding SKUs: " + ex.Message);
                return new List<string>();
            }
        }

        private async Task SetPriceAsync(List<string> skus, decimal price, string why, CancellationToken ct)
        {
            if (price < floor)
            {
                Log($"  REFUSED {price:0.00}: under the floor {floor:0.00}");
                return;
            }
            foreach (var sku in skus)
            {
                try
                {
                    // the same patch body the ICANLO repricer sends (ConstructJSONFeedService -> purchasable_offer)
                    var feed = new ConstructJSONFeedService(sellerId);
                    feed.AddPriceMessage(new List<PriceMessage>
                    {
                        new PriceMessage { SKU = sku, StandardPrice = new StandardPrice { currency = amazon.GetCurrentMarketplace.CurrencyCode.ToString(), Value = price } }
                    });
                    var message = JObject.Parse(feed.GetJSON())["messages"]![0]!;
                    var patches = message["patches"]!.Select(p => new PatchOperation
                    {
                        op = (string?)p["op"] == "add" ? Op.add : (string?)p["op"] == "delete" ? Op.delete : Op.replace,
                        path = (string?)p["path"],
                        value = p["value"]!.Select(v => (object)v).ToList(),
                    }).ToList();

                    var resp = await amazon.ListingsItem.PatchListingsItemAsync(new ParameterPatchListingItem
                    {
                        sellerId = sellerId,
                        sku = sku,
                        marketplaceIds = new List<string> { amazon.GetCurrentMarketplace.ID },
                        listingsItemPatchRequest = new ListingsItemPatchRequest { productType = (string?)message["productType"] ?? "PRODUCT", patches = patches },
                    }, ct);
                    var issues = resp?.Issues == null ? "" : string.Join("; ", resp.Issues.Select(i => $"{i.Severity} {i.Code} {i.Message}"));
                    Log($"  PRICE {sku} -> {price:0.00} ({why}): {resp?.Status} {issues}");
                }
                catch (Exception ex)
                {
                    Log($"  PRICE {sku} -> {price:0.00} ({why}) FAILED: {ex.Message}");
                }
            }
        }

        private class Snapshot
        {
            public decimal? OurLiveMin;
            public decimal? RivalPrice;
            public bool RivalIsBuyBox;
            public string? BuyBoxSeller;
            public decimal? BuyBoxPrice;
            public bool WeHaveBuyBox;
            public string FbaOffers = "";
            public string AllOffers = "";
        }

        private async Task<Snapshot?> ReadOffersAsync(CancellationToken ct)
        {
            try
            {
                var r = await amazon.ProductPricing.GetItemOffersAsync(new ParameterGetItemOffers
                {
                    ItemCondition = Constants.ItemCondition.New,
                    MarketplaceId = amazon.GetCurrentMarketplace.ID,
                    Asin = asin,
                }, ct);
                var offers = r?.Offers ?? new List<AmazonSpApiSDK.Models.ProductPricing.OfferDetail>();
                decimal Landed(AmazonSpApiSDK.Models.ProductPricing.OfferDetail o) => (o.ListingPrice?.Amount ?? 0) + (o.Shipping?.Amount ?? 0);
                string Tag(AmazonSpApiSDK.Models.ProductPricing.OfferDetail o) =>
                    $"{(o.MyOffer == true ? "US" : o.SellerId == rivalSellerId ? "RIVAL" : o.SellerId)}{(o.IsBuyBoxWinner == true ? "*" : "")}:{Landed(o).ToString("0.00", CultureInfo.InvariantCulture)}{(o.IsFulfilledByAmazon == true ? "" : "m")}";

                var ours = offers.Where(o => o.MyOffer == true).ToList();
                var rival = offers.Where(o => o.SellerId == rivalSellerId).ToList();
                var bb = offers.FirstOrDefault(o => o.IsBuyBoxWinner == true);
                return new Snapshot
                {
                    OurLiveMin = ours.Count > 0 ? ours.Min(Landed) : null,
                    RivalPrice = rival.Count > 0 ? rival.Min(Landed) : null,
                    RivalIsBuyBox = rival.Any(o => o.IsBuyBoxWinner == true),
                    BuyBoxSeller = bb == null ? null : bb.MyOffer == true ? "US" : bb.SellerId == rivalSellerId ? "RIVAL" : bb.SellerId,
                    BuyBoxPrice = bb == null ? null : Landed(bb),
                    WeHaveBuyBox = ours.Any(o => o.IsBuyBoxWinner == true),
                    FbaOffers = string.Join(" ", offers.Where(o => o.IsFulfilledByAmazon == true).OrderBy(Landed).Select(Tag)),
                    AllOffers = string.Join(" ", offers.OrderBy(Landed).Select(Tag)),
                };
            }
            catch (Exception ex)
            {
                Log("  ERROR reading offers: " + ex.Message);
                return null;
            }
        }

        // ------------------------------------------------------------------ log

        private void WriteSnapshot(Snapshot s, string phase, int cycle, decimal target)
        {
            string D(decimal? v) => v.HasValue ? v.Value.ToString("0.00", CultureInfo.InvariantCulture) : "";
            Log($"  READ target {target:0.00} | us {D(s.OurLiveMin)} | rival {D(s.RivalPrice)}{(s.RivalIsBuyBox ? " (BUY BOX)" : "")} | buy box {s.BuyBoxSeller ?? "none"} {D(s.BuyBoxPrice)} | {s.AllOffers}");
            var csv = string.Join(",", new[]
            {
                DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"), phase, cycle.ToString(), D(target), D(s.OurLiveMin), D(s.RivalPrice),
                s.RivalIsBuyBox ? "1" : "0", s.BuyBoxSeller ?? "", D(s.BuyBoxPrice), s.WeHaveBuyBox ? "1" : "0",
                "\"" + s.FbaOffers + "\"", "\"" + s.AllOffers + "\"",
            });
            lock (logLock) File.AppendAllText(csvPath, csv + Environment.NewLine, Encoding.UTF8);
        }

        private void Log(string line)
        {
            var text = $"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC  {line}";
            Console.WriteLine(text);
            lock (logLock) File.AppendAllText(logPath, text + Environment.NewLine, Encoding.UTF8);
        }
    }
}
