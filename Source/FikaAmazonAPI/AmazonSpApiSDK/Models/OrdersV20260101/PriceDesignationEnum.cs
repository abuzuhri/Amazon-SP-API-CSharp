using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Indicates that the selling price is a special price that is only available for Amazon Business orders. For more information about the Amazon Business Seller Program, refer to the Amazon Business website.
    /// </summary>
    /// <value>Indicates that the selling price is a special price that is only available for Amazon Business orders. For more information about the Amazon Business Seller Program, refer to the Amazon Business website.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PriceDesignationEnum
    {
        /// <summary>
        /// Enum value for type BUSINESS_PRICE
        /// </summary>
        [EnumMember(Value = "BUSINESS_PRICE")]
        BUSINESS_PRICE = 1,
    }

}
