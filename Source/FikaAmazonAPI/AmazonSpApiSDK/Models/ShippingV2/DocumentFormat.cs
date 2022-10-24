using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2 {

    /// <summary>
    /// The file format of the document.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DocumentFormat {

        [EnumMember(Value = "PDF")]
        PDF ,
        [EnumMember(Value = "PNG")]
        PNG ,
        [EnumMember(Value = "ZPL")]
        ZPL 
    }
}
