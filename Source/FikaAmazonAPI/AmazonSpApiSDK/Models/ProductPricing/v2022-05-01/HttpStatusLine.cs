
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    public class HttpStatusLine
    {
        /// <summary>
        /// The HTTP response Status-Code.
        /// Minimum value : 100
        /// Maximum value : 599
        /// </summary>
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        /// <summary>
        /// The HTTP response Reason-Phase.
        /// </summary>
        [JsonProperty("reasonPhrase")]
        public string ReasonPhrase { get; set; }
    }
}