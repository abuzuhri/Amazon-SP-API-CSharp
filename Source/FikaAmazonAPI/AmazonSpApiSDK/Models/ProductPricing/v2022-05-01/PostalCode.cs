using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    /// <summary>
    /// Postal code value with country code.
    /// </summary>
    public class PostalCode
    {
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
