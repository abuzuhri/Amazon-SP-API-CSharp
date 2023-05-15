using System.Collections.Generic;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    public class FeaturedOfferExpectedPriceResponse
    {
        /// <summary>
        /// A mapping of additional HTTP headers to send/receive for an individual request within a batch.
        /// </summary>
        [JsonProperty("headers")]
        public Dictionary<string,string> Headers { get; set; }
        
        /// <summary>
        /// The HTTP status line associated with the response to an individual request within a batch. For more information, consult RFC 2616.
        /// </summary>
        [JsonProperty("status")]
        public HttpStatusLine Status { get; set; }

        /// <summary>
        /// Use these request parameters to map the response back to the request.
        /// </summary>
        [JsonProperty("request")]
        public FeaturedOfferExpectedPriceRequestParams Request { get; set; }

        /// <summary>
        /// The featured offer expected price response data for a requested SKU.
        /// </summary>
        [JsonProperty("body")]
        public FeaturedOfferExpectedPriceResponseBody Body { get; set; }
    }
}