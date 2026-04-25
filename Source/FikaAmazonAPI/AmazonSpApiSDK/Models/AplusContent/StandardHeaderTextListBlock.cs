using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Standard fixed-length list of text with a related headline.</summary>
    public class StandardHeaderTextListBlock
    {
        [JsonProperty("headline")]
        public TextComponent Headline { get; set; }

        [JsonProperty("block")]
        public StandardTextListBlock Block { get; set; }
    }
}
