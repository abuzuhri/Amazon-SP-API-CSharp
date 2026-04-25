using FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01;
using FikaAmazonAPI.Parameter.ProductPricing;
using FikaAmazonAPI.Parameter.ProductPricing.v2022_05_01;
using FikaAmazonAPI.Utils;
using System.Linq;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.SampleCode
{
    public class ProductPricingSample
    {
        AmazonConnection amazonConnection;
        public ProductPricingSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }

        public void GetPricing()
        {
            var data = amazonConnection.ProductPricing.GetPricing(new Parameter.ProductPricing.ParameterGetPricing()
            {
                MarketplaceId = MarketPlace.UnitedArabEmirates.ID,
                Asins = new string[] { "B00CZC5F0G" }
            });
        }


        public void GetCompetitivePricing()
        {
            var data = amazonConnection.ProductPricing.GetCompetitivePricing(new Parameter.ProductPricing.ParameterGetCompetitivePricing()
            {
                MarketplaceId = MarketPlace.UnitedArabEmirates.ID,
                Asins = new string[] { "B00CZC5F0G" },

            });
        }


        public void GetListingOffers()
        {
            var data = amazonConnection.ProductPricing.GetListingOffers(new Parameter.ProductPricing.ParameterGetListingOffers()
            {
                ItemCondition = ItemCondition.New,
                MarketplaceId = MarketPlace.UnitedArabEmirates.ID,
                SellerSKU = "8809647390015"
            });
        }



        public void GetItemOffers()
        {
            var data = amazonConnection.ProductPricing.GetItemOffers(new Parameter.ProductPricing.ParameterGetItemOffers()
            {
                ItemCondition = ItemCondition.New,
                MarketplaceId = MarketPlace.UnitedKingdom.ID,
                Asin = "B00CZC5F0G"
            });
        }

        public async Task GetItemOffersBatch()
        {
            var data = await amazonConnection.ProductPricing.GetItemOffersBatchAsync(new Parameter.ProductPricing.ParameterGetItemOffersBatchRequest
            {
                ParameterGetItemOffers = new List<Parameter.ProductPricing.ItemOffersRequest>
                {
                    new ItemOffersRequest{
                        HttpMethod = HttpMethodEnum.GET,
                        QueryParams = new ParameterGetItemOffers{
                            Asin  = "XXXXXX",
                            CustomerType = CustomerType.Consumer,
                            ItemCondition = ItemCondition.New,
                            MarketplaceId = MarketPlace.UnitedKingdom.ID,
                        }
                    },
                    new ItemOffersRequest{
                        HttpMethod = HttpMethodEnum.GET,
                        QueryParams = new ParameterGetItemOffers{
                            Asin  = "XXXXXXX",
                            CustomerType = CustomerType.Consumer,
                            ItemCondition = ItemCondition.New,
                            MarketplaceId = MarketPlace.UnitedKingdom.ID,
                        }
                    }
                }
            });

            ;

        }


        public async Task GetListingOffersBatch()
        {
            var data = await amazonConnection.ProductPricing.GetListingOffersBatchAsync(new Parameter.ProductPricing.ParameterGetListingOffersBatchRequest
            {
                ParameterGetListingOffers = new List<Parameter.ProductPricing.ListingOffersRequest>
                {
                    new ListingOffersRequest{
                        HttpMethod = HttpMethodEnum.GET,
                        QueryParams = new ParameterGetListingOffers{
                            SellerSKU  = "SellerSKU_01",
                            CustomerType = CustomerType.Consumer,
                            ItemCondition = ItemCondition.New,
                            MarketplaceId = MarketPlace.UnitedKingdom.ID,
                        }
                    },
                    new ListingOffersRequest{
                        HttpMethod = HttpMethodEnum.GET,
                        QueryParams = new ParameterGetListingOffers{
                            SellerSKU  = "SellerSKU_02",
                            CustomerType = CustomerType.Consumer,
                            ItemCondition = ItemCondition.New,
                            MarketplaceId = MarketPlace.UnitedKingdom.ID,
                        }
                    }
                }
            });

            ;

        }
        
        public async Task GetFeaturedOfferExpectedPriceBatch()
        {
            var data = await amazonConnection.ProductPricing.GetFeaturedOfferExpectedPriceBatchAsync(new GetFeaturedOfferExpectedPriceBatchRequest
            {
                FeaturedOfferExpectedPriceRequestLists = new List<FeaturedOfferExpectedPriceRequest>
                {
                    new FeaturedOfferExpectedPriceRequest
                    {
                        SellerSku  = "SellerSKU_01",
                        MarketplaceId = MarketPlace.Germany.ID,
                    },
                    new FeaturedOfferExpectedPriceRequest{
                        SellerSku  = "SellerSKU_02",
                        MarketplaceId = MarketPlace.Germany.ID,
                    }
                }
            });
        }

        /// <summary>
        /// Pulls similar-item ASINs (and other competitive data) for a list of ASINs.
        /// Up to 20 ASIN/marketplace combinations per batch. Rate limit is strict (0.033 req/s).
        /// </summary>
        public async Task<List<string>> GetSimilarAsinsAsync(IList<string> asins, string marketplaceId)
        {
            var batch = new CompetitiveSummaryBatchRequest
            {
                Requests = asins.Select(asin => new CompetitiveSummaryRequest
                {
                    Asin          = asin,
                    MarketplaceId = marketplaceId,
                    IncludedData  = new List<CompetitiveSummaryIncludedData>
                    {
                        CompetitiveSummaryIncludedData.similarItems
                    },
                }).ToList()
            };

            var response = await amazonConnection.ProductPricing.GetCompetitiveSummaryAsync(batch);

            var similar = new List<string>();
            foreach (var r in response?.Responses ?? new List<CompetitiveSummaryResponse>())
            {
                if (r.Body?.SimilarItems == null) continue;
                foreach (var group in r.Body.SimilarItems)
                    foreach (var item in group.Items ?? new List<Item>())
                        similar.Add(item.Asin);
            }
            return similar;
        }

        /// <summary>
        /// Full competitive summary call asking for everything: featured buying options,
        /// reference prices, lowest priced offers, and similar items.
        /// </summary>
        public async Task<CompetitiveSummaryBatchResponse> GetCompetitiveSummaryFullAsync(string asin)
        {
            return await amazonConnection.ProductPricing.GetCompetitiveSummaryAsync(new CompetitiveSummaryBatchRequest
            {
                Requests = new List<CompetitiveSummaryRequest>
                {
                    new CompetitiveSummaryRequest
                    {
                        Asin          = asin,
                        MarketplaceId = amazonConnection.GetCurrentMarketplace.ID,
                        IncludedData = new List<CompetitiveSummaryIncludedData>
                        {
                            CompetitiveSummaryIncludedData.featuredBuyingOptions,
                            CompetitiveSummaryIncludedData.referencePrices,
                            CompetitiveSummaryIncludedData.lowestPricedOffers,
                            CompetitiveSummaryIncludedData.similarItems,
                        },
                        LowestPricedOffersInputs = new List<LowestPricedOffersInput>
                        {
                            new LowestPricedOffersInput
                            {
                                ItemCondition = Condition.New,
                                OfferType     = LowestPricedOffersOfferType.Consumer,
                            }
                        }
                    }
                }
            });
        }
    }
}
