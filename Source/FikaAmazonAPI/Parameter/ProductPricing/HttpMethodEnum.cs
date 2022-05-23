using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.Parameter.ProductPricing
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum HttpMethodEnum
    {
        /// <summary>
        /// GET
        /// </summary>
        [EnumMember(Value = "GET")]
        GET,

        /// <summary>
        /// PUT
        /// </summary>
        [EnumMember(Value = "PUT")]
        PUT,

        /// <summary>
        /// PATCH
        /// </summary>
        [EnumMember(Value = "PATCH")]
        PATCH,

        /// <summary>
        /// DELETE
        /// </summary>
        [EnumMember(Value = "DELETE")]
        DELETE,

        /// <summary>
        /// POST
        /// </summary>
        [EnumMember(Value = "POST")]
        POST,
    }
}
