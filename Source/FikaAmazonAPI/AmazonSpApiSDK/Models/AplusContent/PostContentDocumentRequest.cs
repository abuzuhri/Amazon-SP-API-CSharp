using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Body for create / update / validate-asin-relations.</summary>
    public class PostContentDocumentRequest
    {
        [JsonProperty("contentDocument")]
        public ContentDocument ContentDocument { get; set; }
    }
}
