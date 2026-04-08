using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// The primary condition category that broadly describes the item's state.
    /// </summary>
    /// <value>The primary condition category that broadly describes the item's state.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ConditionTypeEnum
    {
        /// <summary>
        /// Value for NEW
        /// </summary>
        [EnumMember(Value = "NEW")]
        NEW = 1,

        /// <summary>
        /// Value for USED
        /// </summary>
        [EnumMember(Value = "USED")]
        USED = 2,

        /// <summary>
        /// Value for COLLECTIBLE
        /// </summary>
        [EnumMember(Value = "COLLECTIBLE")]
        COLLECTIBLE = 3,

        /// <summary>
        /// Value for REFURBISHED
        /// </summary>
        [EnumMember(Value = "REFURBISHED")]
        REFURBISHED = 4,

        /// <summary>
        /// Value for PREORDER
        /// </summary>
        [EnumMember(Value = "PREORDER")]
        PREORDER = 5,

        /// <summary>
        /// Value for CLUB
        /// </summary>
        [EnumMember(Value = "CLUB")]
        CLUB = 6,
    }
}
