using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    /// <summary>
    /// A similar item for the specified ASIN/marketplaceId combination.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// The Amazon identifier for the item.
        /// </summary>
        [JsonProperty("asin")]
        public string Asin { get; set; }
    }
}
