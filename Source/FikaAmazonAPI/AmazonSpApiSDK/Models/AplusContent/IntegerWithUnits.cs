using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>A whole-number dimension and its unit (e.g., 100 px).</summary>
    public class IntegerWithUnits
    {
        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }
    }
}
