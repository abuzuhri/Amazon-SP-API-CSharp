using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Standard table of technical-feature names and definitions.</summary>
    public class StandardTechSpecsModule
    {
        [JsonProperty("headline")]
        public TextComponent Headline { get; set; }

        [JsonProperty("specificationList")]
        public List<StandardTextPairBlock> SpecificationList { get; set; }

        [JsonProperty("tableCount")]
        public int? TableCount { get; set; }
    }
}
