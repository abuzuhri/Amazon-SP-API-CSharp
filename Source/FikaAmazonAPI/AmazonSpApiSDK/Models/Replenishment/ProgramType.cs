using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>The replenishment program type.</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProgramType
    {
        SUBSCRIBE_AND_SAVE
    }
}
