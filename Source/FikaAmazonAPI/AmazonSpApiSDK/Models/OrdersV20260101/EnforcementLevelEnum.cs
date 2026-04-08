using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Classification of the enforcement level required for shipping and delivery constraints.
    /// </summary>
    /// <value>Classification of the enforcement level required for shipping and delivery constraints.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EnforcementLevelEnum
    {
        /// <summary>
        /// Constraint that must be strictly enforced for delivery.
        /// </summary>
        [EnumMember(Value = "MANDATORY")]
        MANDATORY = 1,

    }

}
