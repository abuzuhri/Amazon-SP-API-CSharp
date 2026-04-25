using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    /// <summary>
    /// The response schema for the competitiveSummaryBatch operation.
    /// </summary>
    public class CompetitiveSummaryBatchResponse
    {
        [JsonProperty("responses")]
        public List<CompetitiveSummaryResponse> Responses { get; set; }
    }
}
