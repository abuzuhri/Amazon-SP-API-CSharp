using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Orders
{
    [JsonConverter(typeof(StringEnumConverter))]

    public enum ElectronicInvoiceStatus
    {

        /// <summary>
        /// Enum NotRequired for value: NotRequired
        /// </summary>
        [EnumMember(Value = "NotRequired")]
        NotRequired = 1,

        /// <summary>
        /// Enum NotFound for value: NotFound
        /// </summary>
        [EnumMember(Value = "NotFound")]
        NotFound = 2,

        /// <summary>
        /// Enum Processing for value: Processing
        /// </summary>
        [EnumMember(Value = "Processing")]
        Processing = 3,

        /// <summary>
        /// Enum Errored for value: Errored
        /// </summary>
        [EnumMember(Value = "Errored")]
        Errored = 4,

        /// <summary>
        /// Enum Accepted for value: Accepted
        /// </summary>
        [EnumMember(Value = "Accepted")]
        Accepted = 5
    }
}
