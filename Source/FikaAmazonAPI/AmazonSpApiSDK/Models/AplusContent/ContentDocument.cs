using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>
    /// An A+ Content document — the enhanced content that gets published to product detail pages.
    /// </summary>
    public class ContentDocument
    {
        /// <summary>Document name (1–100 chars).</summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("contentType")]
        public ContentType ContentType { get; set; }

        /// <summary>Optional subtype; when used, see Amazon docs for valid values.</summary>
        [JsonProperty("contentSubType")]
        public string ContentSubType { get; set; }

        /// <summary>IETF language tag (pattern: <c>^[a-z]{2,}-[A-Z0-9]{2,}$</c>), e.g. <c>en-US</c>.</summary>
        [JsonProperty("locale")]
        public string Locale { get; set; }

        /// <summary>1–100 content modules.</summary>
        [JsonProperty("contentModuleList")]
        public List<ContentModule> ContentModuleList { get; set; }
    }
}
