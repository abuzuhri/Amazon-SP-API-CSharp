using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>The A+ Content document's metadata.</summary>
    public class ContentMetadata
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("marketplaceId")]
        public string MarketplaceId { get; set; }

        [JsonProperty("status")]
        public ContentStatus Status { get; set; }

        [JsonProperty("badgeSet")]
        public List<ContentBadge> BadgeSet { get; set; }

        [JsonProperty("updateTime")]
        public DateTime UpdateTime { get; set; }
    }
}
