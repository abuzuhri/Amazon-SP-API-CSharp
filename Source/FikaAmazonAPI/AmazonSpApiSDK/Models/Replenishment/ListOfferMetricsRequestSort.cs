using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    public class ListOfferMetricsRequestSort
    {
        [JsonProperty("order")]
        public SortOrder Order { get; set; }

        [JsonProperty("key")]
        public ListOfferMetricsSortKey Key { get; set; }
    }
}
