using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    /// <summary>
    /// The response for an individual competitiveSummary request inside a batch operation.
    /// </summary>
    public class CompetitiveSummaryResponse
    {
        [JsonProperty("status")]
        public HttpStatusLine Status { get; set; }

        [JsonProperty("body")]
        public CompetitiveSummaryResponseBody Body { get; set; }
    }
}
