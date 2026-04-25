using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>Response schema for listOfferMetrics.</summary>
    public class ListOfferMetricsResponse
    {
        [JsonProperty("offers")]
        public List<ListOfferMetricsResponseOffer> Offers { get; set; }

        [JsonProperty("pagination")]
        public PaginationResponse Pagination { get; set; }
    }
}
