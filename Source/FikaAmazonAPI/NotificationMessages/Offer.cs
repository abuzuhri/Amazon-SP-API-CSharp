namespace FikaAmazonAPI.NotificationMessages
{

    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class Offer
    {
        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("SellerId")]
        public string SellerId { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("SubCondition")]
        public string SubCondition { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
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
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("IsFulfilledByAmazon")]
        public bool IsFulfilledByAmazon { get; set; }

        /// <summary>
        /// Indicates if the offer is buy box winner
        /// </summary>
        [JsonProperty("IsBuyBoxWinner")]
        public bool IsBuyBoxWinner { get; set; }

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
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("IsFeaturedMerchant")]
        public bool IsFeaturedMerchant { get; set; }
    }
}
