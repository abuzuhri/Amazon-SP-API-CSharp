using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    /// <summary>
    /// Error response returned when a request is unsuccessful (v2022-05-01 schema: lowercase JSON).
    /// Distinct from the v0 PascalCase Error in the parent ProductPricing namespace.
    /// </summary>
    public class CompetitiveSummaryError
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }
    }
}
