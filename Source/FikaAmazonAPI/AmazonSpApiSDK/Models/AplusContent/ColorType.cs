using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Relative color scheme of content (used for image-text overlay backgrounds).</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ColorType
    {
        DARK,
        LIGHT
    }
}
