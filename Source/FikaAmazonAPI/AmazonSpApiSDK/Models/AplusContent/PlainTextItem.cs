using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Positional plain text used in collections of brief labels/descriptors.</summary>
    public class PlainTextItem
    {
        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
