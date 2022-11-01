using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2 {

    /// <summary>
    /// The type of shipping document.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DocumentType
    {
        [EnumMember(Value = "PACKSLIP")]
        PACKSLIP,
        [EnumMember(Value = "LABEL")]
        LABEL,
        [EnumMember(Value = "RECEIPT")]
        RECEIPT,
        [EnumMember(Value = "CUSTOM_FORM")]
        CUSTOM_FORM    
    }
}
