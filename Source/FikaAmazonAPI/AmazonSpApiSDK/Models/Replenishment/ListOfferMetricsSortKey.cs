using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>The attribute to use to sort the listOfferMetrics results.</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ListOfferMetricsSortKey
    {
        SHIPPED_SUBSCRIPTION_UNITS,
        TOTAL_SUBSCRIPTIONS_REVENUE,
        ACTIVE_SUBSCRIPTIONS,
        NEXT_90DAYS_SHIPPED_SUBSCRIPTION_UNITS,
        NEXT_60DAYS_SHIPPED_SUBSCRIPTION_UNITS,
        NEXT_30DAYS_SHIPPED_SUBSCRIPTION_UNITS,
        NEXT_90DAYS_TOTAL_SUBSCRIPTIONS_REVENUE,
        NEXT_60DAYS_TOTAL_SUBSCRIPTIONS_REVENUE,
        NEXT_30DAYS_TOTAL_SUBSCRIPTIONS_REVENUE
    }
}
