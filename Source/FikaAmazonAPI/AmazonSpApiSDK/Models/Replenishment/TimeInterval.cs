using Newtonsoft.Json;
using System;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// A date-time interval (ISO 8601) used to compute metrics. Both startDate and endDate are required.
    /// Note: listOfferMetrics requires the interval to span exactly one unit of the aggregation frequency.
    /// </summary>
    public class TimeInterval
    {
        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty("endDate")]
        public DateTime EndDate { get; set; }
    }
}
