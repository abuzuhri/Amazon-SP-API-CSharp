using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Three images with text, in a single row.</summary>
    public class StandardThreeImageTextModule
    {
        [JsonProperty("headline")]
        public TextComponent Headline { get; set; }

        [JsonProperty("block1")]
        public StandardImageTextBlock Block1 { get; set; }

        [JsonProperty("block2")]
        public StandardImageTextBlock Block2 { get; set; }

        [JsonProperty("block3")]
        public StandardImageTextBlock Block3 { get; set; }
    }
}
