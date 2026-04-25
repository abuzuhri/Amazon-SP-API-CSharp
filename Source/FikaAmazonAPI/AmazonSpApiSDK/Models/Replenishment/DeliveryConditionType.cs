using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// The condition type of upcoming deliveries for an offer. Used by both DeliveriesCondition.condition
    /// and the deliveriesConditions filter on listOffers.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DeliveryConditionType
    {
        NEXT_30_DAYS_DELIVERIES_PAUSED_PRICING,
        NEXT_30_DAYS_DELIVERIES_PAUSED_NON_BUYABLE,
        NEXT_30_DAYS_DELIVERIES_AT_LOW_INVENTORY_RISK_ONLY,
        NEXT_30_DAYS_DELIVERIES_AT_LOW_INVENTORY_RISK,
        NO_ISSUES_FOR_NEXT_30_DAYS_DELIVERIES
    }
}
