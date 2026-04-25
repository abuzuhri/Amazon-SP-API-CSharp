using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Standard text-box block: headline + paragraph body.</summary>
    public class StandardTextBlock
    {
        [JsonProperty("headline")]
        public TextComponent Headline { get; set; }

        [JsonProperty("body")]
        public ParagraphComponent Body { get; set; }
    }
}
