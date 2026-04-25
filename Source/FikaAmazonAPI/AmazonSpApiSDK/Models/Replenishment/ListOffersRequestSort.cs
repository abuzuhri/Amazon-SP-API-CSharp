using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    public class ListOffersRequestSort
    {
        [JsonProperty("order")]
        public SortOrder Order { get; set; }

        [JsonProperty("key")]
        public ListOffersSortKey Key { get; set; }
    }
}
