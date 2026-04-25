using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    /// <summary>
    /// A shipping option available for an offer.
    /// </summary>
    public class ShippingOption
    {
        [JsonProperty("shippingOptionType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ShippingOptionType ShippingOptionType { get; set; }

        /// <summary>Shipping price for the offer.</summary>
        [JsonProperty("price")]
        public MoneyType Price { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ShippingOptionType
    {
        DEFAULT
    }
}
