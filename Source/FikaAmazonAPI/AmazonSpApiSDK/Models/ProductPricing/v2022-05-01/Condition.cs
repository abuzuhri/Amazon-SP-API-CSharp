using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    /// <summary>
    /// The condition of the item. Used by Offer and LowestPricedOffersInput.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Condition
    {
        New,
        Used,
        Collectible,
        Refurbished,
        Club
    }
}
