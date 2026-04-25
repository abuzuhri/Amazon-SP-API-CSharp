using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>
    /// Image-cropping instructions. To skip cropping, set <see cref="Size"/> to the
    /// original dimensions and leave <see cref="Offset"/> null.
    /// </summary>
    public class ImageCropSpecification
    {
        [JsonProperty("size")]
        public ImageDimensions Size { get; set; }

        [JsonProperty("offset")]
        public ImageOffsets Offset { get; set; }
    }
}
