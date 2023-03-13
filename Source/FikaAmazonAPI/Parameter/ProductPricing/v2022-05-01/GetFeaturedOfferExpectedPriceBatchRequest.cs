using System.Collections.Generic;
using Newtonsoft.Json;

namespace FikaAmazonAPI.Parameter.ProductPricing.v2022_05_01
{
    public class GetFeaturedOfferExpectedPriceBatchRequest
    {
        /// <summary>
        /// A batched list of featured offer expected price requests.
        /// </summary>
        [JsonProperty("requests")]
        public List<FeaturedOfferExpectedPriceRequest> FeaturedOfferExpectedPriceRequestLists { get; set; }
    }
}