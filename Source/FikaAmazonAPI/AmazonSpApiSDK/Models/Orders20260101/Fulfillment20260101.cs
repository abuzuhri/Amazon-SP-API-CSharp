using Newtonsoft.Json;
using System;

/// <summary>
/// Code Generated then Edited from:
/// https://github.com/amzn/selling-partner-api-models/blob/main/models/orders-api-model/orders_2026-01-01.json
/// </summary>

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Orders20260101
{
    /// <summary>
    /// Fulfillment information at the order level.
    /// Requires includedData=FULFILLMENT.
    /// </summary>
    public class OrderFulfillment
    {
        [JsonProperty("fulfillmentStatus")]
        public string FulfillmentStatus { get; set; }

        [JsonProperty("fulfilledBy")]
        public string FulfilledBy { get; set; }

        [JsonProperty("fulfillmentServiceLevel")]
        public string FulfillmentServiceLevel { get; set; }

        [JsonProperty("shipByWindow")]
        public DateTimeWindow ShipByWindow { get; set; }

        [JsonProperty("deliverByWindow")]
        public DateTimeWindow DeliverByWindow { get; set; }
    }

    /// <summary>
    /// Fulfillment information at the order item level.
    /// </summary>
    public class OrderItemFulfillment
    {
        [JsonProperty("quantityFulfilled")]
        public int? QuantityFulfilled { get; set; }

        [JsonProperty("packing")]
        public PackingInfo Packing { get; set; }

        [JsonProperty("shipping")]
        public ShippingInfo Shipping { get; set; }

        [JsonProperty("picking")]
        public PickingInfo Picking { get; set; }
    }

    public class DateTimeWindow
    {
        [JsonProperty("earliestDateTime")]
        public DateTime? EarliestDateTime { get; set; }

        [JsonProperty("latestDateTime")]
        public DateTime? LatestDateTime { get; set; }
    }

    public class PackingInfo
    {
        [JsonProperty("giftOption")]
        public bool? GiftOption { get; set; }

        [JsonProperty("giftMessage")]
        public string GiftMessage { get; set; }

        [JsonProperty("giftWrapLevel")]
        public string GiftWrapLevel { get; set; }
    }

    public class ShippingInfo
    {
        [JsonProperty("scheduledDeliveryWindow")]
        public DateTimeWindow ScheduledDeliveryWindow { get; set; }

        [JsonProperty("internationalShipping")]
        public InternationalShipping InternationalShipping { get; set; }

        [JsonProperty("shippingConstraints")]
        public object ShippingConstraints { get; set; }
    }

    public class InternationalShipping
    {
        [JsonProperty("iossNumber")]
        public string IossNumber { get; set; }
    }

    public class PickingInfo
    {
        [JsonProperty("substitutionPreference")]
        public object SubstitutionPreference { get; set; }
    }
}
