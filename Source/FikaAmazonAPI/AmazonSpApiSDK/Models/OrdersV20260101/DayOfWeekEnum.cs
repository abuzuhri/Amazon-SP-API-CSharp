using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Day Of Week Enum
    /// </summary>
    /// <value>Day Of Week Enum</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DayOfWeekEnum
    {
        /// <summary>
        /// Value for Sunday
        /// </summary>
        [EnumMember(Value = "SUN")]
        SUN = 1,

        /// <summary>
        /// Value for MON
        /// </summary>
        [EnumMember(Value = "MON")]
        MON = 2,

        /// <summary>
        /// Value for TUE
        /// </summary>
        [EnumMember(Value = "TUE")]
        TUE = 3,

        /// <summary>
        /// Value for WED
        /// </summary>
        [EnumMember(Value = "WED")]
        WED = 4,

        /// <summary>
        /// Value for THU
        /// </summary>
        [EnumMember(Value = "THU")]
        THU = 5,

        /// <summary>
        /// Value for FRI
        /// </summary>
        [EnumMember(Value = "FRI")]
        FRI = 6,

        /// <summary>
        /// Value for SAT
        /// </summary>
        [EnumMember(Value = "SAT")]
        SAT = 7,

    }
}
