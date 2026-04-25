using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    /// <summary>
    /// The summary of similar items for the specified ASIN/marketplaceId combination.
    /// </summary>
    public class SimilarItems
    {
        /// <summary>A list of similar items for the specified ASIN/marketplaceId combination.</summary>
        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }
}
