using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// Per-offer metrics. As of April 2026 these are returned at the offer level (not ASIN level)
    /// and include the SKU and FulfillmentChannelType fields for sellers.
    /// </summary>
    public class ListOfferMetricsResponseOffer
    {
        [JsonProperty("asin")]
        public string Asin { get; set; }

        /// <summary>SKU. Sellers only. Added in the April 2026 release.</summary>
        [JsonProperty("sku")]
        public string Sku { get; set; }

        /// <summary>Fulfillment channel type. Sellers only. Added in the April 2026 release.</summary>
        [JsonProperty("fulfillmentChannelType")]
        public FulfillmentChannelType? FulfillmentChannelType { get; set; }

        [JsonProperty("notDeliveredDueToOOS")]
        public double? NotDeliveredDueToOOS { get; set; }

        [JsonProperty("totalSubscriptionsRevenue")]
        public double? TotalSubscriptionsRevenue { get; set; }

        [JsonProperty("shippedSubscriptionUnits")]
        public long? ShippedSubscriptionUnits { get; set; }

        [JsonProperty("activeSubscriptions")]
        public long? ActiveSubscriptions { get; set; }

        /// <summary>Percentage of total program revenue out of total product revenue.</summary>
        [JsonProperty("revenuePenetration")]
        public double? RevenuePenetration { get; set; }

        [JsonProperty("lostRevenueDueToOOS")]
        public double? LostRevenueDueToOOS { get; set; }

        [JsonProperty("couponsRevenuePenetration")]
        public double? CouponsRevenuePenetration { get; set; }

        [JsonProperty("shareOfCouponSubscriptions")]
        public double? ShareOfCouponSubscriptions { get; set; }

        [JsonProperty("next30DayTotalSubscriptionsRevenue")]
        public double? Next30DayTotalSubscriptionsRevenue { get; set; }

        [JsonProperty("next60DayTotalSubscriptionsRevenue")]
        public double? Next60DayTotalSubscriptionsRevenue { get; set; }

        [JsonProperty("next90DayTotalSubscriptionsRevenue")]
        public double? Next90DayTotalSubscriptionsRevenue { get; set; }

        [JsonProperty("next30DayShippedSubscriptionUnits")]
        public long? Next30DayShippedSubscriptionUnits { get; set; }

        [JsonProperty("next60DayShippedSubscriptionUnits")]
        public long? Next60DayShippedSubscriptionUnits { get; set; }

        [JsonProperty("next90DayShippedSubscriptionUnits")]
        public long? Next90DayShippedSubscriptionUnits { get; set; }

        [JsonProperty("timeInterval")]
        public TimeInterval TimeInterval { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }
    }
}
