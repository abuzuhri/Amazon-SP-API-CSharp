using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Special programs associated with order that may affect fulfillment or customer experience.
    /// </summary>
    /// <value>Special programs associated with order that may affect fulfillment or customer experience.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProgramEnum
    {
        /// <summary>
        /// Enum value for type AMAZON_BAZAAR
        /// </summary>
        [EnumMember(Value = "AMAZON_BAZAAR")]
        AMAZON_BAZAAR = 1,

        /// <summary>
        /// Enum value for type AMAZON_BUSINESS
        /// </summary>
        [EnumMember(Value = "AMAZON_BUSINESS")]
        AMAZON_BUSINESS = 2,

        /// <summary>
        /// Enum value for type AMAZON_EASY_SHIP
        /// </summary>
        [EnumMember(Value = "AMAZON_EASY_SHIP")]
        AMAZON_EASY_SHIP = 3,

        /// <summary>
        /// Enum value for type AMAZON_HAUL
        /// </summary>
        [EnumMember(Value = "AMAZON_HAUL")]
        AMAZON_HAUL = 4,

        /// <summary>
        /// Enum value for type DELIVERY_BY_AMAZON
        /// </summary>
        [EnumMember(Value = "DELIVERY_BY_AMAZON")]
        DELIVERY_BY_AMAZON = 5,

        /// <summary>
        /// Enum value for type FBM_SHIP_PLUS
        /// </summary>
        [EnumMember(Value = "FBM_SHIP_PLUS")]
        FBM_SHIP_PLUS = 6,

        /// <summary>
        /// Enum value for type IN_STORE_PICK_UP
        /// </summary>
        [EnumMember(Value = "IN_STORE_PICK_UP")]
        IN_STORE_PICK_UP = 7,

        /// <summary>
        /// Enum value for type PREMIUM
        /// </summary>
        [EnumMember(Value = "PREMIUM")]
        PREMIUM = 8,

        /// <summary>
        /// Enum value for type PREORDER
        /// </summary>
        [EnumMember(Value = "PREORDER")]
        PREORDER = 9,

        /// <summary>
        /// Enum value for type PRIME
        /// </summary>
        [EnumMember(Value = "PRIME")]
        PRIME = 10,
    }

}
