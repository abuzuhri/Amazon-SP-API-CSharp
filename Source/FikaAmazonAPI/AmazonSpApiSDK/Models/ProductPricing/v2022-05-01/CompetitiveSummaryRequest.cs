using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    /// <summary>
    /// An individual competitiveSummary request for an ASIN and marketplaceId.
    /// </summary>
    public class CompetitiveSummaryRequest
    {
        [JsonProperty("asin")]
        public string Asin { get; set; }

        [JsonProperty("marketplaceId")]
        public string MarketplaceId { get; set; }

        /// <summary>
        /// The list of requested competitive pricing data for the product.
        /// At least one element required.
        /// </summary>
        [JsonProperty("includedData")]
        public List<CompetitiveSummaryIncludedData> IncludedData { get; set; }

        /// <summary>
        /// Up to 5 LowestPricedOffersInput parameters used to build lowestPricedOffers in the
        /// response. Only valid if lowestPricedOffers is in IncludedData.
        /// </summary>
        [JsonProperty("lowestPricedOffersInputs")]
        public List<LowestPricedOffersInput> LowestPricedOffersInputs { get; set; }

        /// <summary>
        /// HTTP method for the underlying per-item operation. The batch envelope is POSTed, but
        /// each item carries the method of the conceptual single-resource call — for
        /// getCompetitiveSummary that is GET. Sending POST here returns INVALID_METHOD from Amazon.
        /// </summary>
        [JsonProperty("method")]
        public HttpMethod Method { get; set; } = HttpMethod.GET;

        /// <summary>
        /// The URI associated with the individual API. For getCompetitiveSummary this is
        /// /products/pricing/2022-05-01/items/competitiveSummary.
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; set; } = "/products/pricing/2022-05-01/items/competitiveSummary";
    }
}
