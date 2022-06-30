using Newtonsoft.Json;

namespace FikaAmazonAPI.NotificationMessages
{
    public abstract class PriceBaseB2B : PriceBase
    {
        /// <summary>
        /// Required. Indicates whether the offer is a B2B offer or a B2C offer. When the offer type is B2C in a quantity discount, the seller is winning the Buy Box because others do not have inventory at that quantity, not because they have a quantity discount on the ASIN.
        /// </summary>
        [JsonProperty("OfferType")]
        public string OfferType { get; set; }

        /// <summary>
        /// Required. The quantity tier for the offer.
        /// </summary>
        [JsonProperty("QuantityTier")]
        public int QuantityTier { get; set; }

        /// <summary>
        /// Optional. Indicates whether the quantity tier is for Quantity Discount or Progressive Discount.
        /// </summary>
        [JsonProperty("DiscountType")]
        public string DiscountType { get; set; }

        /// <summary>
        /// Optional. The seller identifier for the offer.
        /// </summary>
        [JsonProperty("SellerId")]
        public string SellerId { get; set; }
    }
}
