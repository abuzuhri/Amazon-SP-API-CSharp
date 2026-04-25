using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Special programs that apply specifically to this item within the order.
    /// </summary>
    /// <value>Special programs that apply specifically to this item within the order.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderItemProgramEnum
    {
        /// <summary>
        /// Enum value for type TRANSPARENCY
        /// </summary>
        [EnumMember(Value = "TRANSPARENCY")]
        TRANSPARENCY = 1,

        /// <summary>
        /// Enum value for type SUBSCRIBE_AND_SAVE
        /// </summary>
        [EnumMember(Value = "SUBSCRIBE_AND_SAVE")]
        SUBSCRIBE_AND_SAVE = 2,

    }

}
