using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// The name of the sales platform or channel where the customer placed this order.
    /// </summary>
    /// <value>The name of the sales platform or channel where the customer placed this order.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ChannelTypeEnum
    {
        /// <summary>
        /// Value for AMAZON
        /// </summary>
        [EnumMember(Value = "AMAZON")]
        AMAZON = 1,

        /// <summary>
        /// Value for NON_AMAZON
        /// </summary>
        [EnumMember(Value = "NON_AMAZON")]
        NON_AMAZON = 2,
    }
}
