using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AcknowledgementCode
    {
        [EnumMember(Value = "Accepted")]
        Accepted,

        [EnumMember(Value = "Backordered")]
        Backordered,

        [EnumMember(Value = "Rejected")]
        Rejected
    }
}
