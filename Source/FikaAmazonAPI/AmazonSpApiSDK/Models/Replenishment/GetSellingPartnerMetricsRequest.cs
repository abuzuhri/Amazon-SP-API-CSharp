using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>Request body for getSellingPartnerMetrics.</summary>
    public class GetSellingPartnerMetricsRequest
    {
        [JsonProperty("aggregationFrequency")]
        public AggregationFrequency? AggregationFrequency { get; set; }

        [JsonProperty("timeInterval")]
        public TimeInterval TimeInterval { get; set; }

        /// <summary>If null, all metrics are returned.</summary>
        [JsonProperty("metrics")]
        public List<Metric> Metrics { get; set; }

        [JsonProperty("timePeriodType")]
        public TimePeriodType TimePeriodType { get; set; }

        [JsonProperty("marketplaceId")]
        public string MarketplaceId { get; set; }

        [JsonProperty("programTypes")]
        public List<ProgramType> ProgramTypes { get; set; }
    }
}
