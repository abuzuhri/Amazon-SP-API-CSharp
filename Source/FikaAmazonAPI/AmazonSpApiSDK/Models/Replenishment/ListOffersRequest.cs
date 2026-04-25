using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>Request body for listOffers.</summary>
    public class ListOffersRequest
    {
        [JsonProperty("pagination")]
        public ListOffersRequestPagination Pagination { get; set; }

        [JsonProperty("filters")]
        public ListOffersRequestFilters Filters { get; set; }

        [JsonProperty("sort")]
        public ListOffersRequestSort Sort { get; set; }
    }
}
