using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>A decorator applied to a content string to create rich text.</summary>
    public class Decorator
    {
        [JsonProperty("type")]
        public DecoratorType? Type { get; set; }

        [JsonProperty("offset")]
        public int? Offset { get; set; }

        [JsonProperty("length")]
        public int? Length { get; set; }

        [JsonProperty("depth")]
        public int? Depth { get; set; }
    }
}
