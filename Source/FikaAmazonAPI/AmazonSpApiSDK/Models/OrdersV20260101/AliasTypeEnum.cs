using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// The kind of alternative identifier
    /// </summary>
    /// <value>The kind of alternative identifier</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AliasTypeEnum
    {
        /// <summary>
        /// Value for SELLER_ORDER_ID
        /// </summary>
        [EnumMember(Value = "SELLER_ORDER_ID")]
        SELLER_ORDER_ID = 1,

    }
}
