using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    /// <summary>
    /// The reference price for the specified ASIN/marketplaceId combination.
    /// </summary>
    public class ReferencePrice
    {
        /// <summary>
        /// Reference price type — for example, CompetitivePriceThreshold, WasPrice, CompetitivePrice.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public MoneyType Price { get; set; }
    }
}
