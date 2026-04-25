using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>Response schema for listOffers.</summary>
    public class ListOffersResponse
    {
        [JsonProperty("offers")]
        public List<ListOffersResponseOffer> Offers { get; set; }

        [JsonProperty("pagination")]
        public PaginationResponse Pagination { get; set; }
    }
}
