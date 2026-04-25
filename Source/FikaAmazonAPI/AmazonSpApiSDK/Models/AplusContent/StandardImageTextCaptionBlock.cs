using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Standard image + text block with a related caption (caption may not show on every device).</summary>
    public class StandardImageTextCaptionBlock
    {
        [JsonProperty("block")]
        public StandardImageTextBlock Block { get; set; }

        [JsonProperty("caption")]
        public TextComponent Caption { get; set; }
    }
}
