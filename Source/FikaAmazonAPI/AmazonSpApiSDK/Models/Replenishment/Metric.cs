using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// Replenishment metric names. Includes the REVENUE_PENETRATION metric added in the
    /// April 2026 release.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Metric
    {
        SHIPPED_SUBSCRIPTION_UNITS,
        TOTAL_SUBSCRIPTIONS_REVENUE,
        ACTIVE_SUBSCRIPTIONS,
        NOT_DELIVERED_DUE_TO_OOS,
        SUBSCRIBER_NON_SUBSCRIBER_AVERAGE_REVENUE,
        LOST_REVENUE_DUE_TO_OOS,
        SUBSCRIBER_NON_SUBSCRIBER_AVERAGE_REORDERS,
        COUPONS_REVENUE_PENETRATION,
        REVENUE_BY_DELIVERIES,
        SUBSCRIBER_RETENTION,
        REVENUE_PENETRATION_BY_SELLER_FUNDING,
        SHARE_OF_COUPON_SUBSCRIPTIONS,
        SUBSCRIBER_LIFETIME_VALUE_BY_CUSTOMER_SEGMENT,
        SIGNUP_CONVERSION_BY_SELLER_FUNDING,
        REVENUE_PENETRATION
    }
}
