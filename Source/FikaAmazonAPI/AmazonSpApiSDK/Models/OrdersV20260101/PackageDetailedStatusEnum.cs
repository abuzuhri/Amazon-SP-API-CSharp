using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Granular status information providing specific details about the package's current location and handling stage.
    /// </summary>
    /// <value>Granular status information providing specific details about the package's current location and handling stage.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PackageDetailedStatusEnum
    {

        /// <summary>
        /// Package awaiting pickup scheduling
        /// </summary>
        [EnumMember(Value = "PENDING_SCHEDULE")]
        PENDING_SCHEDULE = 1,

        /// <summary>
        /// Package ready for carrier collection from seller
        /// </summary>
        [EnumMember(Value = "PENDING_PICK_UP")]
        PENDING_PICK_UP = 2,

        /// <summary>
        /// Package awaiting seller delivery to carrier
        /// </summary>
        [EnumMember(Value = "PENDING_DROP_OFF")]
        PENDING_DROP_OFF = 3,

        /// <summary>
        /// Shipping label canceled by seller
        /// </summary>
        [EnumMember(Value = "LABEL_CANCELLED")]
        LABEL_CANCELLED = 4,

        /// <summary>
        /// Package collected by carrier from seller location
        /// </summary>
        [EnumMember(Value = "PICKED_UP")]
        PICKED_UP = 5,

        /// <summary>
        /// Package delivered to carrier by seller
        /// </summary>
        [EnumMember(Value = "DROPPED_OFF")]
        DROPPED_OFF = 6,

        /// <summary>
        /// Package at originating fulfillment center
        /// </summary>
        [EnumMember(Value = "AT_ORIGIN_FC")]
        AT_ORIGIN_FC = 7,

        /// <summary>
        /// Package at destination fulfillment center
        /// </summary>
        [EnumMember(Value = "AT_DESTINATION_FC")]
        AT_DESTINATION_FC = 8,

        /// <summary>
        /// Package successfully delivered to recipient
        /// </summary>
        [EnumMember(Value = "DELIVERED")]
        DELIVERED = 9,

        /// <summary>
        /// Package refused by intended recipient
        /// </summary>
        [EnumMember(Value = "REJECTED_BY_BUYER")]
        REJECTED_BY_BUYER = 10,

        /// <summary>
        /// Package cannot be delivered due to address or access issues
        /// </summary>
        [EnumMember(Value = "UNDELIVERABLE")]
        UNDELIVERABLE = 11,

        /// <summary>
        /// Package in transit back to seller
        /// </summary>
        [EnumMember(Value = "RETURNING_TO_SELLER")]
        RETURNING_TO_SELLER = 12,

        /// <summary>
        /// Package successfully returned to seller
        /// </summary>
        [EnumMember(Value = "RETURNED_TO_SELLER")]
        RETURNED_TO_SELLER = 13,

        /// <summary>
        /// Package location unknown or confirmed lost
        /// </summary>
        [EnumMember(Value = "LOST")]
        LOST = 14,

        /// <summary>
        /// Package on delivery vehicle for final delivery
        /// </summary>
        [EnumMember(Value = "OUT_FOR_DELIVERY")]
        OUT_FOR_DELIVERY = 15,

        /// <summary>
        /// Package damaged during transit
        /// </summary>
        [EnumMember(Value = "DAMAGED")]
        DAMAGED = 16,
    }

}
