using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// A more specific condition classification that provides additional detail about the item's quality within the main condition type.
    /// </summary>
    /// <value>A more specific condition classification that provides additional detail about the item's quality within the main condition type.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ConditionSubtypeEnum
    {
        /// <summary>
        /// Value for NEW
        /// </summary>
        [EnumMember(Value = "NEW")]
        NEW = 1,

        /// <summary>
        /// Value for MINT
        /// </summary>
        [EnumMember(Value = "MINT")]
        MINT = 2,

        /// <summary>
        /// Value for VERY_GOOD
        /// </summary>
        [EnumMember(Value = "VERY_GOOD")]
        VERY_GOOD = 3,

        /// <summary>
        /// Value for GOOD
        /// </summary>
        [EnumMember(Value = "GOOD")]
        GOOD = 4,

        /// <summary>
        /// Value for ACCEPTABLE
        /// </summary>
        [EnumMember(Value = "ACCEPTABLE")]
        ACCEPTABLE = 5,

        /// <summary>
        /// Value for POOR
        /// </summary>
        [EnumMember(Value = "POOR")]
        POOR = 6,

        /// <summary>
        /// Value for CLUB
        /// </summary>
        [EnumMember(Value = "CLUB")]
        CLUB = 7,

        /// <summary>
        /// Value for OEM
        /// </summary>
        [EnumMember(Value = "OEM")]
        OEM = 8,

        /// <summary>
        /// Value for WARRANTY
        /// </summary>
        [EnumMember(Value = "WARRANTY")]
        WARRANTY = 9,

        /// <summary>
        /// Value for REFURBISHED_WARRANTY
        /// </summary>
        [EnumMember(Value = "REFURBISHED_WARRANTY")]
        REFURBISHED_WARRANTY = 10,

        /// <summary>
        /// Value for REFURBISHED
        /// </summary>
        [EnumMember(Value = "REFURBISHED")]
        REFURBISHED = 11,

        /// <summary>
        /// Value for OPEN_BOX
        /// </summary>
        [EnumMember(Value = "OPEN_BOX")]
        OPEN_BOX = 12,

        /// <summary>
        /// Value for ANY
        /// </summary>
        [EnumMember(Value = "ANY")]
        ANY = 13,

        /// <summary>
        /// Value for OTHER
        /// </summary>
        [EnumMember(Value = "OTHER")]
        OTHER = 14,
    }
}
