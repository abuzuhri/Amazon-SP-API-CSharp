using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Four images with text, in a single row.</summary>
    public class StandardFourImageTextModule
    {
        [JsonProperty("headline")]
        public TextComponent Headline { get; set; }

        [JsonProperty("block1")]
        public StandardImageTextBlock Block1 { get; set; }

        [JsonProperty("block2")]
        public StandardImageTextBlock Block2 { get; set; }

        [JsonProperty("block3")]
        public StandardImageTextBlock Block3 { get; set; }

        [JsonProperty("block4")]
        public StandardImageTextBlock Block4 { get; set; }
    }
}
