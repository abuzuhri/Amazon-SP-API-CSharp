using System.Collections.Generic;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    public class GetFeaturedOfferExpectedPriceBatchResponse
    {
        /// <summary>
        /// A batched list of featured offer expected price responses.
        /// </summary>
        [JsonProperty("responses")]
        public List<FeaturedOfferExpectedPriceResponse> FeaturedOfferExpectedPriceResponseList { get; set; }
    }
}