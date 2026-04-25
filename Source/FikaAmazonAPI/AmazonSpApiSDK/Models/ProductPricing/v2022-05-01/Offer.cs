using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    /// <summary>
    /// The offer data of a product (v2022-05-01 schema for getCompetitiveSummary).
    /// </summary>
    public class Offer
    {
        [JsonProperty("sellerId")]
        public string SellerId { get; set; }

        [JsonProperty("condition")]
        public Condition Condition { get; set; }

        [JsonProperty("subCondition")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SubCondition? SubCondition { get; set; }

        [JsonProperty("fulfillmentType")]
        public FulfillmentType FulfillmentType { get; set; }

        [JsonProperty("listingPrice")]
        public MoneyType ListingPrice { get; set; }

        [JsonProperty("shippingOptions")]
        public List<ShippingOption> ShippingOptions { get; set; }

        [JsonProperty("points")]
        public Points Points { get; set; }

        [JsonProperty("primeDetails")]
        public PrimeDetails PrimeDetails { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum SubCondition
    {
        New,
        Mint,
        VeryGood,
        Good,
        Acceptable,
        Poor,
        Club,
        OEM,
        Warranty,
        RefurbishedWarranty,
        Refurbished,
        OpenBox,
        Other
    }
}
