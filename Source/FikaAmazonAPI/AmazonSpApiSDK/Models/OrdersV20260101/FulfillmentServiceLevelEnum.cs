using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// The category of the shipping speed option selected by the customer at checkout.
    /// </summary>
    /// <value>The category of the shipping speed option selected by the customer at checkout.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FulfillmentServiceLevelEnum
    {
        /// <summary>
        /// Enum value for EXPEDITED
        /// </summary>
        [EnumMember(Value = "EXPEDITED")]
        EXPEDITED = 1,

        /// <summary>
        /// Enum value for FREE_ECONOMY
        /// </summary>
        [EnumMember(Value = "FREE_ECONOMY")]
        FREE_ECONOMY = 2,

        /// <summary>
        /// Enum value for NEXT_DAY
        /// </summary>
        [EnumMember(Value = "NEXT_DAY")]
        NEXT_DAY = 3,

        /// <summary>
        /// Enum value for PRIORITY
        /// </summary>
        [EnumMember(Value = "PRIORITY")]
        PRIORITY = 4,

        /// <summary>
        /// Enum value for SAME_DAY
        /// </summary>
        [EnumMember(Value = "SAME_DAY")]
        SAME_DAY = 5,

        /// <summary>
        /// Enum value for SECOND_DAY
        /// </summary>
        [EnumMember(Value = "SECOND_DAY")]
        SECOND_DAY = 6,

        /// <summary>
        /// Enum value for SCHEDULED
        /// </summary>
        [EnumMember(Value = "SCHEDULED")]
        SCHEDULED = 7,

        /// <summary>
        /// Enum value for STANDARD
        /// </summary>
        [EnumMember(Value = "STANDARD")]
        STANDARD = 8,
    }

}
