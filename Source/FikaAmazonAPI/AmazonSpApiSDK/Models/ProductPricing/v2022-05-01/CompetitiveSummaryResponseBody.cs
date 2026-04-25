using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    /// <summary>
    /// The competitiveSummaryResponse body for a requested ASIN and marketplaceId.
    /// </summary>
    public class CompetitiveSummaryResponseBody
    {
        [JsonProperty("asin")]
        public string Asin { get; set; }

        [JsonProperty("marketplaceId")]
        public string MarketplaceId { get; set; }

        /// <summary>Featured buying options for the specified ASIN/marketplaceId combination.</summary>
        [JsonProperty("featuredBuyingOptions")]
        public List<FeaturedBuyingOption> FeaturedBuyingOptions { get; set; }

        /// <summary>Lowest priced offers for the specified ASIN/marketplaceId combination.</summary>
        [JsonProperty("lowestPricedOffers")]
        public List<LowestPricedOffer> LowestPricedOffers { get; set; }

        /// <summary>Reference prices for the specified ASIN/marketplaceId combination.</summary>
        [JsonProperty("referencePrices")]
        public List<ReferencePrice> ReferencePrices { get; set; }

        /// <summary>Similar items for the specified ASIN/marketplaceId combination.</summary>
        [JsonProperty("similarItems")]
        public List<SimilarItems> SimilarItems { get; set; }

        /// <summary>List of errors. Present if the individual request failed.</summary>
        [JsonProperty("errors")]
        public List<CompetitiveSummaryError> Errors { get; set; }
    }
}
