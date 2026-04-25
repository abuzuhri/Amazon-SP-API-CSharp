using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Standard label + description pair (used in tech-spec tables).</summary>
    public class StandardTextPairBlock
    {
        [JsonProperty("label")]
        public TextComponent Label { get; set; }

        [JsonProperty("description")]
        public TextComponent Description { get; set; }
    }
}
