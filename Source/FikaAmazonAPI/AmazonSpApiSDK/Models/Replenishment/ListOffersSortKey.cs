using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>The attribute to use to sort the listOffers results.</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ListOffersSortKey
    {
        ASIN,
        SELLING_PARTNER_FUNDED_BASE_DISCOUNT_PERCENTAGE,
        SELLING_PARTNER_FUNDED_TIERED_DISCOUNT_PERCENTAGE,
        AMAZON_FUNDED_BASE_DISCOUNT_PERCENTAGE,
        AMAZON_FUNDED_TIERED_DISCOUNT_PERCENTAGE,
        INVENTORY,
        PRICE,
        SUBSCRIPTION_COUNT,
        FULFILLMENT_NETWORK_ID_TYPE
    }
}
