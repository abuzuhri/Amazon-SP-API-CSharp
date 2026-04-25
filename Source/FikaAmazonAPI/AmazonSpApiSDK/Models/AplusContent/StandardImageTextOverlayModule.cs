using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Background image with a floating text box.</summary>
    public class StandardImageTextOverlayModule
    {
        [JsonProperty("overlayColorType")]
        public ColorType? OverlayColorType { get; set; }

        [JsonProperty("block")]
        public StandardImageTextBlock Block { get; set; }
    }
}
