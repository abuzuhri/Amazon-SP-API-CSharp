using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// The type of location.
    /// </summary>
    /// <value>The type of location.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AddressTypeEnum
    {
        /// <summary>
        /// Value for RESIDENTIAL
        /// </summary>
        [EnumMember(Value = "RESIDENTIAL")]
        RESIDENTIAL = 1,

        /// <summary>
        /// Value for COMMERCIAL
        /// </summary>
        [EnumMember(Value = "COMMERCIAL")]
        COMMERCIAL = 2,

        /// <summary>
        /// Value for PICKUP_POINT
        /// </summary>
        [EnumMember(Value = "PICKUP_POINT")]
        PICKUP_POINT = 3,

    }
}
