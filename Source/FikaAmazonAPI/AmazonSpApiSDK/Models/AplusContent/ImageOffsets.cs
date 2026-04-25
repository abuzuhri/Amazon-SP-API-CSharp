using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Top-left corner of a cropped image, in original-image coords.</summary>
    public class ImageOffsets
    {
        [JsonProperty("x")]
        public IntegerWithUnits X { get; set; }

        [JsonProperty("y")]
        public IntegerWithUnits Y { get; set; }
    }
}
