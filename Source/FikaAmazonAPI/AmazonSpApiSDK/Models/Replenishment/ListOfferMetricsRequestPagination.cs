using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>Pagination for listOfferMetrics (limit 1–500, offset 0–9000).</summary>
    public class ListOfferMetricsRequestPagination
    {
        [JsonProperty("limit")]
        public long Limit { get; set; } = 500;

        [JsonProperty("offset")]
        public long Offset { get; set; } = 0;
    }
}
