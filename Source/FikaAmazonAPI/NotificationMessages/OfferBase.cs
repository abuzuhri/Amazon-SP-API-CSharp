using Newtonsoft.Json;

namespace FikaAmazonAPI.NotificationMessages
{

    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public abstract class OfferBase
    {
        /// <summary>
        /// Required. The seller identifier for the offer.
        /// </summary>
        [JsonProperty("SellerId")]
        public string SellerId { get; set; }

        /// <summary>
        /// Required. The subcondition of the item. For example: New, Mint, Very Good, Good, Acceptable, Poor, Club, OEM, Warranty, Refurbished Warranty, Refurbished, Open Box, or Other.
        /// </summary>
        [JsonProperty("SubCondition")]
        public string SubCondition { get; set; }

        /// <summary>
        /// Optional. Information about the seller's feedback, including the percentage of positive feedback, and the total count of feedback received.
        /// </summary>
        [JsonProperty("SellerFeedbackRating")]
        public SellerFeedbackRating SellerFeedbackRating { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("ShippingTime")]
        public ShippingTime ShippingTime { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("ListingPrice")]
        public MoneyType ListingPrice { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("Shipping")]
        public MoneyType Shipping { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("ShipsFrom")]
        public ShipsFrom ShipsFrom { get; set; }

        /// <summary>
        /// Required. Indicates whether the offer is fulfilled by Amazon.
        /// </summary>
        [JsonProperty("IsFulfilledByAmazon")]
        public bool IsFulfilledByAmazon { get; set; }

        /// <summary>
        /// Optional. Indicates whether the offer is currently in the Buy Box. There can be up to two Buy Box winners at any time per ASIN, one that is eligible for Prime and one that is not eligible for Prime.
        /// </summary>
        [JsonProperty("IsBuyBoxWinner")]
        public bool? IsBuyBoxWinner { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("ConditionNotes")]
        public string ConditionNotes { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("PrimeInformation")]
        public PrimeInformation PrimeInformation { get; set; }

        /// <summary>
        /// Optional. Indicates whether the seller of the item is eligible to win the Buy Box.
        /// </summary>
        [JsonProperty("IsFeaturedMerchant")]
        public bool? IsFeaturedMerchant { get; set; }
    }
}
