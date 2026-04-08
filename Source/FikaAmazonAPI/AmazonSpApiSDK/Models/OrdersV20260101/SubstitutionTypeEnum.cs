using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Source and nature of the substitution preferences for this item.
    /// </summary>
    /// <value>Source and nature of the substitution preferences for this item.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SubstitutionTypeEnum
    {
        /// <summary>
        /// Substitution preferences defined by the customer
        /// </summary>
        [EnumMember(Value = "CUSTOMER_PREFERENCE")]
        CUSTOMER_PREFERENCE = 1,

        /// <summary>
        /// Substitution options suggested by Amazon's system
        /// </summary>
        [EnumMember(Value = "AMAZON_RECOMMENDED")]
        AMAZON_RECOMMENDED = 2,

        /// <summary>
        /// Prohibition against any item substitutions
        /// </summary>
        [EnumMember(Value = "DO_NOT_SUBSTITUTE")]
        DO_NOT_SUBSTITUTE = 3,
    }

}
