using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Full context for a single A+ Content publishing event.</summary>
    public class PublishRecord
    {
        [JsonProperty("marketplaceId")]
        public string MarketplaceId { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("asin")]
        public string Asin { get; set; }

        [JsonProperty("contentType")]
        public ContentType ContentType { get; set; }

        [JsonProperty("contentSubType")]
        public string ContentSubType { get; set; }

        [JsonProperty("contentReferenceKey")]
        public string ContentReferenceKey { get; set; }
    }
}
