using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>Filter object: discount funding percentages to match (1–10 entries, 0–100 each).</summary>
    public class DiscountFunding
    {
        [JsonProperty("percentage")]
        public List<long> Percentage { get; set; }
    }
}
