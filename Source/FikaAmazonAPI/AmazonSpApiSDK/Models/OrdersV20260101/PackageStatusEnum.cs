using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Current status and detailed tracking information for a shipping package throughout the delivery process.
    /// </summary>
    /// <value>Current status and detailed tracking information for a shipping package throughout the delivery process.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PackageStatusEnum
    {

        /// <summary>
        /// Package preparation stage before carrier handoff
        /// </summary>
        [EnumMember(Value = "PENDING")]
        PENDING = 1,

        /// <summary>
        /// Package movement phase within carrier network
        /// </summary>
        [EnumMember(Value = "IN_TRANSIT")]
        IN_TRANSIT = 2,

        /// <summary>
        /// Package dispatch confirmation to customer
        /// </summary>
        [EnumMember(Value = "SHIPPED")]
        SHIPPED = 3,

        /// <summary>
        /// Package completion at final destination
        /// </summary>
        [EnumMember(Value = "DELIVERED")]
        DELIVERED = 4,

        /// <summary>
        /// Package shipment termination before delivery
        /// </summary>
        [EnumMember(Value = "CANCELLED")]
        CANCELLED = 5,

        /// <summary>
        /// Package delivery failure
        /// </summary>
        [EnumMember(Value = "UNDELIVERABLE")]
        UNDELIVERABLE = 6,

    }

}
