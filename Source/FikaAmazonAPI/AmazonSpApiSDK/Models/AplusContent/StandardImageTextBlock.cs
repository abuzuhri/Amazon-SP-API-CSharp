using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Standard image + text-box block (headline + body alongside an image).</summary>
    public class StandardImageTextBlock
    {
        [JsonProperty("image")]
        public ImageComponent Image { get; set; }

        [JsonProperty("headline")]
        public TextComponent Headline { get; set; }

        [JsonProperty("body")]
        public ParagraphComponent Body { get; set; }
    }
}
