using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    /// <summary>
    /// The competitiveSummary batch request body. 1 to 20 requests per batch.
    /// </summary>
    public class CompetitiveSummaryBatchRequest
    {
        [JsonProperty("requests")]
        public List<CompetitiveSummaryRequest> Requests { get; set; }
    }
}
