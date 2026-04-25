using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    public class PaginationResponse
    {
        /// <summary>Total number of results matching the given filter criteria.</summary>
        [JsonProperty("totalResults")]
        public long? TotalResults { get; set; }
    }
}
