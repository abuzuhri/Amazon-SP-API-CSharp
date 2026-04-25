using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Specifies datasets to include in the response.
    /// </summary>
    /// <value>Specifies datasets to include in the response.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IncludedDataEnum
    {
        /// <summary>
        /// Information about the buyer who purchased the order.
        /// </summary>
        [EnumMember(Value = "BUYER")]
        BUYER = 1,

        /// <summary>
        /// Information about the recipient to whom the order is delivered.
        /// </summary>
        [EnumMember(Value = "RECIPIENT")]
        RECIPIENT = 2,

        /// <summary>
        /// The revenue and financial breakdown for the order and order items.
        /// </summary>
        [EnumMember(Value = "PROCEEDS")]
        PROCEEDS = 3,

        /// <summary>
        /// The cost information about the order and order items.
        /// </summary>
        [EnumMember(Value = "EXPENSE")]
        EXPENSE = 4,

        /// <summary>
        /// The discount and promotional offer details applied to the order and order items.
        /// </summary>
        [EnumMember(Value = "PROMOTION")]
        PROMOTION = 5,

        /// <summary>
        /// Cancellation information applied to the order and order items.
        /// </summary>
        [EnumMember(Value = "CANCELLATION")]
        CANCELLATION = 6,

        /// <summary>
        /// Information about how the order and order items are processed and shipped.
        /// </summary>
        [EnumMember(Value = "FULFILLMENT")]
        FULFILLMENT = 7,

        /// <summary>
        /// Information about shipping packages and tracking.
        /// </summary>
        [EnumMember(Value = "PACKAGES")]
        PACKAGES = 8,

    }

}
