using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>Response schema for getSellingPartnerMetrics.</summary>
    public class GetSellingPartnerMetricsResponse
    {
        [JsonProperty("metrics")]
        public List<GetSellingPartnerMetricsResponseMetric> Metrics { get; set; }
    }
}
