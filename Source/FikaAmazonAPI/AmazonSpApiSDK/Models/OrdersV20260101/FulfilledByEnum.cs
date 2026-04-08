using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Specifies whether Amazon or the merchant is responsible for fulfilling this order.
    /// </summary>
    /// <value>Specifies whether Amazon or the merchant is responsible for fulfilling this order.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FulfilledByEnum
    {
        /// <summary>
        /// Fulfilled by AMAZON
        /// </summary>
        [EnumMember(Value = "AMAZON")]
        AMAZON = 1,

        /// <summary>
        /// Fulfilled by MERCHANT
        /// </summary>
        [EnumMember(Value = "MERCHANT")]
        MERCHANT = 2,
    }

}
