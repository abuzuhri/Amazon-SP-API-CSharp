using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductTypes
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RequirementsEnforcedEnum
    {
        [EnumMember(Value = "ENFORCED")]
        ENFORCED,
        [EnumMember(Value = "NOT_ENFORCED")]
        NOT_ENFORCED
    }
}
