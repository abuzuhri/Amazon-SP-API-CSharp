using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>One column of a standard comparison-table module.</summary>
    public class StandardComparisonProductBlock
    {
        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("image")]
        public ImageComponent Image { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("asin")]
        public string Asin { get; set; }

        [JsonProperty("highlight")]
        public bool? Highlight { get; set; }

        [JsonProperty("metrics")]
        public List<PlainTextItem> Metrics { get; set; }
    }
}
