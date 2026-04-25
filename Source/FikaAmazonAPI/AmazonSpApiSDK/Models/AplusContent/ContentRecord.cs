using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>A content document with its reference key + metadata, used by getContentDocument.</summary>
    public class ContentRecord
    {
        [JsonProperty("contentReferenceKey")]
        public string ContentReferenceKey { get; set; }

        [JsonProperty("contentMetadata")]
        public ContentMetadata ContentMetadata { get; set; }

        [JsonProperty("contentDocument")]
        public ContentDocument ContentDocument { get; set; }
    }
}
