using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// Filters for listOfferMetrics. timeInterval, timePeriodType, programTypes, and marketplaceId are required.
    /// </summary>
    public class ListOfferMetricsRequestFilters
    {
        [JsonProperty("aggregationFrequency")]
        public AggregationFrequency? AggregationFrequency { get; set; }

        [JsonProperty("timeInterval")]
        public TimeInterval TimeInterval { get; set; }

        [JsonProperty("timePeriodType")]
        public TimePeriodType TimePeriodType { get; set; }

        [JsonProperty("marketplaceId")]
        public string MarketplaceId { get; set; }

        [JsonProperty("programTypes")]
        public List<ProgramType> ProgramTypes { get; set; }

        /// <summary>1–20 ASINs.</summary>
        [JsonProperty("asins")]
        public List<string> Asins { get; set; }
    }
}
