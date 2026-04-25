using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>The enrollment method used to enroll the offer into the program.</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EnrollmentMethod
    {
        MANUAL,
        AUTOMATIC
    }
}
