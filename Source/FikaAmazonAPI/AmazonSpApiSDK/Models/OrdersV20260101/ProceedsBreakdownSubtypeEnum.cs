using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Specific classification of the further granular breakdown.
    /// </summary>
    /// <value>Specific classification of the further granular breakdown.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProceedsBreakdownSubtypeEnum
    {
        /// <summary>
        /// Enum value for type ITEM
        /// </summary>
        [EnumMember(Value = "ITEM")]
        ITEM = 1,

        /// <summary>
        /// Enum value for type SHIPPING
        /// </summary>
        [EnumMember(Value = "SHIPPING")]
        SHIPPING = 2,

        /// <summary>
        /// Enum value for type GIFT_WRAP
        /// </summary>
        [EnumMember(Value = "GIFT_WRAP")]
        GIFT_WRAP = 3,

        /// <summary>
        /// Enum value for type COD_FEE
        /// </summary>
        [EnumMember(Value = "COD_FEE")]
        COD_FEE = 4,

        /// <summary>
        /// Enum value for type OTHER
        /// </summary>
        [EnumMember(Value = "OTHER")]
        OTHER = 5,

        /// <summary>
        /// Enum value for type DISCOUNT
        /// </summary>
        [EnumMember(Value = "DISCOUNT")]
        DISCOUNT = 6,
    }

}
