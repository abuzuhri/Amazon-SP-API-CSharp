using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    /// <summary>
    /// Currency type and monetary value schema (v2022-05-01: camelCase JSON).
    /// Distinct from the v0 PascalCase MoneyType in the parent ProductPricing namespace.
    /// </summary>
    public class MoneyType
    {
        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("amount")]
        public decimal? Amount { get; set; }
    }
}
