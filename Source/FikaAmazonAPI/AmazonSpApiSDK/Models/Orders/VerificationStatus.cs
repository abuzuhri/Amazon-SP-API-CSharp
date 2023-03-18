using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Orders
{
    /// <summary>
    /// The verification status of the order.
    /// </summary>
    /// <value>The verification status of the order.</value>

    [JsonConverter(typeof(StringEnumConverter))]

    public enum VerificationStatus
    {

        /// <summary>
        /// Enum Pending for value: Pending
        /// </summary>
        [EnumMember(Value = "Pending")]
        Pending = 1,

        /// <summary>
        /// Enum Approved for value: Approved
        /// </summary>
        [EnumMember(Value = "Approved")]
        Approved = 2,

        /// <summary>
        /// Enum Rejected for value: Rejected
        /// </summary>
        [EnumMember(Value = "Rejected")]
        Rejected = 3,

        /// <summary>
        /// Enum Expired for value: Expired
        /// </summary>
        [EnumMember(Value = "Expired")]
        Expired = 4,

        /// <summary>
        /// Enum Cancelled for value: Cancelled
        /// </summary>
        [EnumMember(Value = "Cancelled")]
        Cancelled = 5
    }

}
