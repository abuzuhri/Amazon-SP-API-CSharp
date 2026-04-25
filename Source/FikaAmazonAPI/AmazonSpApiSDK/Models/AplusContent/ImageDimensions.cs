using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    public class ImageDimensions
    {
        [JsonProperty("width")]
        public IntegerWithUnits Width { get; set; }

        [JsonProperty("height")]
        public IntegerWithUnits Height { get; set; }
    }
}
