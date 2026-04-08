using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// The current fulfillment status of an order, indicating where the order is in the fulfillment process from placement to handover to carrier.
    /// </summary>
    /// <value>The current fulfillment status of an order, indicating where the order is in the fulfillment process from placement to handover to carrier.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FulfillmentStatusEnum
    {

        /// <summary>
        /// This status is available for pre-orders only. The order has been placed, payment has not been authorized, and the release date of the item is in the future. The order is not ready for shipment.
        /// </summary>
        [EnumMember(Value = "PENDING_AVAILABILITY")]
        PENDING_AVAILABILITY = 1,

        /// <summary>
        /// The order has been placed but is not ready for shipment. Note that for standard orders, the initial order status is PENDING. For pre-orders, the initial order status is PENDING_AVAILABILITY, and the order passes into the PENDING status when payment authorization begins.
        /// </summary>
        [EnumMember(Value = "PENDING")]
        PENDING = 2,

        /// <summary>
        /// The order is ready for shipment, but no items in the order have been shipped.
        /// </summary>
        [EnumMember(Value = "UNSHIPPED")]
        UNSHIPPED = 3,

        /// <summary>
        /// One or more (but not all) items in the order have been shipped.
        /// </summary>
        [EnumMember(Value = "PARTIALLY_SHIPPED")]
        PARTIALLY_SHIPPED = 4,

        /// <summary>
        /// All items have been shipped to the customer.
        /// </summary>
        [EnumMember(Value = "SHIPPED")]
        SHIPPED = 5,

        /// <summary>
        /// The order has been canceled and will not be fulfilled.
        /// </summary>
        [EnumMember(Value = "CANCELLED")]
        CANCELLED = 6,

        /// <summary>
        /// The order cannot be fulfilled. This state applies only to Amazon-fulfilled orders that were not placed on Amazon's retail web site.
        /// </summary>
        [EnumMember(Value = "UNFULFILLABLE")]
        UNFULFILLABLE = 7,


    }

}
