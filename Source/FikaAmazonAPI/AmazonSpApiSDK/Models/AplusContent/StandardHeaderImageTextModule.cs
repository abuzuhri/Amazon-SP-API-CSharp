using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Headline + image + body text.</summary>
    public class StandardHeaderImageTextModule
    {
        [JsonProperty("headline")]
        public TextComponent Headline { get; set; }

        [JsonProperty("block")]
        public StandardImageTextBlock Block { get; set; }
    }
}
