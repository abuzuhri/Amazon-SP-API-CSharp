using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>
    /// A reference to an image hosted in the A+ Content media library.
    /// <see cref="UploadDestinationId"/> comes from the Uploads API.
    /// </summary>
    public class ImageComponent
    {
        [JsonProperty("uploadDestinationId")]
        public string UploadDestinationId { get; set; }

        [JsonProperty("imageCropSpecification")]
        public ImageCropSpecification ImageCropSpecification { get; set; }

        [JsonProperty("altText")]
        public string AltText { get; set; }
    }
}
