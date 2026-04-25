using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Standard image + caption block.</summary>
    public class StandardImageCaptionBlock
    {
        [JsonProperty("image")]
        public ImageComponent Image { get; set; }

        [JsonProperty("caption")]
        public TextComponent Caption { get; set; }
    }
}
