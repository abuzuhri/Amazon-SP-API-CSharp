using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>An ASIN with optional content-management metadata.</summary>
    public class AsinMetadata
    {
        [JsonProperty("asin")]
        public string Asin { get; set; }

        [JsonProperty("badgeSet")]
        public List<AsinBadge> BadgeSet { get; set; }

        [JsonProperty("parent")]
        public string Parent { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("contentReferenceKeySet")]
        public List<string> ContentReferenceKeySet { get; set; }
    }
}
