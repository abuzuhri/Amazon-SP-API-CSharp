using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Headline + body text with a side image.</summary>
    public class StandardSingleSideImageModule
    {
        [JsonProperty("imagePositionType")]
        public PositionType? ImagePositionType { get; set; }

        [JsonProperty("block")]
        public StandardImageTextBlock Block { get; set; }
    }
}
