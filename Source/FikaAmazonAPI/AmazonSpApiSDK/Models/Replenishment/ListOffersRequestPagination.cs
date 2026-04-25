using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>Pagination for listOffers (limit 1–100, offset 0–9000).</summary>
    public class ListOffersRequestPagination
    {
        [JsonProperty("limit")]
        public long Limit { get; set; } = 100;

        [JsonProperty("offset")]
        public long Offset { get; set; } = 0;
    }
}
