using FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound;
using FikaAmazonAPI.ReportGeneration;
using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FikaAmazonAPI.SampleCode
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<Program>()
            .Build();

            var factory = LoggerFactory.Create(builder => builder.AddConsole());

            AmazonConnection amazonConnection = new AmazonConnection(new AmazonCredential()
            {
                ClientId = config.Required("FikaAmazonAPI:ClientId"),
                ClientSecret = config.Required("FikaAmazonAPI:ClientSecret"),
                RefreshToken = config.Required("FikaAmazonAPI:RefreshToken"),
                MarketPlaceID = config.Required("FikaAmazonAPI:MarketPlaceID"),
                SellerID = config.Required("FikaAmazonAPI:SellerId"),
                IsDebugMode = true,
            });

            // dotnet run -- pricecycle [asin] [high] [step] [floor]   (see PriceCycleTest)
            if (args.Length > 0 && args[0].Equals("pricecycle", StringComparison.OrdinalIgnoreCase))
            {
                string Arg(int i, string def) => args.Length > i ? args[i] : def;
                decimal Num(int i, decimal def) => args.Length > i ? decimal.Parse(args[i], System.Globalization.CultureInfo.InvariantCulture) : def;
                using var cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) => { e.Cancel = true; cts.Cancel(); };
                await new PriceCycleTest(amazonConnection, config.Required("FikaAmazonAPI:SellerId"),
                    asin: Arg(1, "B0098TN3NA"), high: Num(2, 315.00m), step: Num(3, 0.25m), floor: Num(4, 300.00m)).RunAsync(cts.Token);
                return;
            }



            ReplenishmentSample replenishmentSample = new ReplenishmentSample(amazonConnection);
            var listAtRiskOffers = await replenishmentSample.ListAtRiskOffersAsync();


            ProductPricingSample productPricingSample = new ProductPricingSample(amazonConnection);
            var ASINs = await productPricingSample.GetCompetitiveSummaryFullAsync("B001F0R64M");

            ReportManager reportManager = new ReportManager(amazonConnection);

            var feedbacks = reportManager.GetFeedbackFromDays(180); //GET_SELLER_FEEDBACK_DATA

            FeedsSample feedsSample = new FeedsSample(amazonConnection);
            await feedsSample.SubmitFeedDELETE_JSONAsync("B07HMBFZCZ .2");


            var aa=amazonConnection.Seller.GetMarketplaceParticipations();

            var plan = amazonConnection.FulFillmentInboundv20240320.ListInboundPlans(new Parameter.FulFillmentInbound.v20240320.ParameterListInboundPlans
            {
                Status = AmazonSpApiSDK.Models.FulfillmentInboundv20240320.InboundPlanStatus.ACTIVE
            });


            //var list = amazonConnection.Seller.GetMarketplaceParticipations();

            var list= amazonConnection.FulFillmentInbound.GetShipments(new Parameter.FulFillmentInbound.ParameterGetShipments()
            {
                MarketplaceId = MarketPlace.UnitedArabEmirates.ID,
                ShipmentStatusList = new List<ShipmentStatus> { ShipmentStatus.WORKING, ShipmentStatus.SHIPPED, ShipmentStatus.RECEIVING }
            });


           // var itemsList=amazonConnection.FulFillmentInbound.GetShipmentItemsByShipmentId("FBA15KBCBMXC");



            //FeedsSample feedsSample = new FeedsSample(amazonConnection);
            //feedsSample.SubmitFeedPRICING_JSONAsync("B09H73T814.259", 112.0M, 53.51M, 112.20M).GetAwaiter().GetResult();


            Console.ReadLine();

        }






    }
}
