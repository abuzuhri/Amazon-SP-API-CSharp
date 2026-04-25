using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// Metric data for a selling partner. Most fields are PERFORMANCE-only; totalSubscriptionsRevenue
    /// and shippedSubscriptionUnits are also returned for FORECAST.
    /// </summary>
    public class GetSellingPartnerMetricsResponseMetric
    {
        [JsonProperty("notDeliveredDueToOOS")]
        public double? NotDeliveredDueToOOS { get; set; }

        [JsonProperty("totalSubscriptionsRevenue")]
        public double? TotalSubscriptionsRevenue { get; set; }

        [JsonProperty("shippedSubscriptionUnits")]
        public long? ShippedSubscriptionUnits { get; set; }

        [JsonProperty("activeSubscriptions")]
        public long? ActiveSubscriptions { get; set; }

        [JsonProperty("subscriberAverageRevenue")]
        public double? SubscriberAverageRevenue { get; set; }

        [JsonProperty("nonSubscriberAverageRevenue")]
        public double? NonSubscriberAverageRevenue { get; set; }

        [JsonProperty("lostRevenueDueToOOS")]
        public double? LostRevenueDueToOOS { get; set; }

        [JsonProperty("subscriberAverageReorders")]
        public double? SubscriberAverageReorders { get; set; }

        [JsonProperty("nonSubscriberAverageReorders")]
        public double? NonSubscriberAverageReorders { get; set; }

        [JsonProperty("couponsRevenuePenetration")]
        public double? CouponsRevenuePenetration { get; set; }

        [JsonProperty("revenueFromSubscriptionsWithMultipleDeliveries")]
        public double? RevenueFromSubscriptionsWithMultipleDeliveries { get; set; }

        [JsonProperty("revenueFromActiveSubscriptionsWithSingleDelivery")]
        public double? RevenueFromActiveSubscriptionsWithSingleDelivery { get; set; }

        [JsonProperty("revenueFromCancelledSubscriptionsAfterSingleDelivery")]
        public double? RevenueFromCancelledSubscriptionsAfterSingleDelivery { get; set; }

        [JsonProperty("subscriberRetentionFor30Days")]
        public double? SubscriberRetentionFor30Days { get; set; }

        [JsonProperty("subscriberRetentionFor90Days")]
        public double? SubscriberRetentionFor90Days { get; set; }

        [JsonProperty("revenuePenetrationFor0PercentSellerFunding")]
        public double? RevenuePenetrationFor0PercentSellerFunding { get; set; }

        /// <summary>Sellers only.</summary>
        [JsonProperty("revenuePenetrationFor5PercentSellerFunding")]
        public double? RevenuePenetrationFor5PercentSellerFunding { get; set; }

        /// <summary>Sellers only.</summary>
        [JsonProperty("revenuePenetrationFor10PercentSellerFunding")]
        public double? RevenuePenetrationFor10PercentSellerFunding { get; set; }

        /// <summary>Vendors only.</summary>
        [JsonProperty("revenuePenetrationFor5PlusPercentSellerFunding")]
        public double? RevenuePenetrationFor5PlusPercentSellerFunding { get; set; }

        [JsonProperty("shareOfCouponSubscriptions")]
        public double? ShareOfCouponSubscriptions { get; set; }

        [JsonProperty("nonSubscriberLifeTimeValueFromOTP")]
        public double? NonSubscriberLifeTimeValueFromOTP { get; set; }

        [JsonProperty("lostSubscriberLifeTimeValueFromOTP")]
        public double? LostSubscriberLifeTimeValueFromOTP { get; set; }

        [JsonProperty("lostSubscriberLifeTimeValueFromSNS")]
        public double? LostSubscriberLifeTimeValueFromSNS { get; set; }

        [JsonProperty("growingSubscriberLifeTimeValueFromOTP")]
        public double? GrowingSubscriberLifeTimeValueFromOTP { get; set; }

        [JsonProperty("growingSubscriberLifeTimeValueFromSNS")]
        public double? GrowingSubscriberLifeTimeValueFromSNS { get; set; }

        [JsonProperty("establishedSubscriberLifeTimeValueFromOTP")]
        public double? EstablishedSubscriberLifeTimeValueFromOTP { get; set; }

        [JsonProperty("establishedSubscriberLifeTimeValueFromSNS")]
        public double? EstablishedSubscriberLifeTimeValueFromSNS { get; set; }

        [JsonProperty("signupConversionFor0PercentSellerFunding")]
        public double? SignupConversionFor0PercentSellerFunding { get; set; }

        /// <summary>Sellers only.</summary>
        [JsonProperty("signupConversionFor5PercentSellerFunding")]
        public double? SignupConversionFor5PercentSellerFunding { get; set; }

        /// <summary>Sellers only.</summary>
        [JsonProperty("signupConversionFor10PercentSellerFunding")]
        public double? SignupConversionFor10PercentSellerFunding { get; set; }

        /// <summary>Vendors only.</summary>
        [JsonProperty("signupConversionFor5PlusPercentSellerFunding")]
        public double? SignupConversionFor5PlusPercentSellerFunding { get; set; }

        /// <summary>Percentage of total program revenue out of total product revenue. Added April 2026.</summary>
        [JsonProperty("revenuePenetration")]
        public double? RevenuePenetration { get; set; }

        [JsonProperty("timeInterval")]
        public TimeInterval TimeInterval { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }
    }
}
