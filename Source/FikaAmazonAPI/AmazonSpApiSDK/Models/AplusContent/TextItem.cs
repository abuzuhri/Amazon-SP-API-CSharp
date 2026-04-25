using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Rich positional text — usually presented as a bulleted list entry.</summary>
    public class TextItem
    {
        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("text")]
        public TextComponent Text { get; set; }
    }
}
