using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Standard headline + body text.</summary>
    public class StandardTextModule
    {
        [JsonProperty("headline")]
        public TextComponent Headline { get; set; }

        [JsonProperty("body")]
        public ParagraphComponent Body { get; set; }
    }
}
