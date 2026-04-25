using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    /// <summary>
    /// The input required for building LowestPricedOffers data in the response.
    /// </summary>
    public class LowestPricedOffersInput
    {
        /// <summary>The itemCondition of the offer requested for LowestPricedOffers. Default: New.</summary>
        [JsonProperty("itemCondition")]
        public Condition ItemCondition { get; set; } = Condition.New;

        /// <summary>The type of offers requested. Default: Consumer.</summary>
        [JsonProperty("offerType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LowestPricedOffersOfferType OfferType { get; set; } = LowestPricedOffersOfferType.Consumer;
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum LowestPricedOffersOfferType
    {
        Consumer
    }
}
