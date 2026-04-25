using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Document metadata paired with its reference key.</summary>
    public class ContentMetadataRecord
    {
        [JsonProperty("contentReferenceKey")]
        public string ContentReferenceKey { get; set; }

        [JsonProperty("contentMetadata")]
        public ContentMetadata ContentMetadata { get; set; }
    }
}
