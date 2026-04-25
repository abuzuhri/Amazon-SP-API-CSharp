using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>Request body for listOfferMetrics.</summary>
    public class ListOfferMetricsRequest
    {
        [JsonProperty("pagination")]
        public ListOfferMetricsRequestPagination Pagination { get; set; }

        [JsonProperty("sort")]
        public ListOfferMetricsRequestSort Sort { get; set; }

        [JsonProperty("filters")]
        public ListOfferMetricsRequestFilters Filters { get; set; }
    }
}
