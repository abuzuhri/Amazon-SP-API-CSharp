using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Contextual flag on an ASIN — changes per request.</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AsinBadge
    {
        BRAND_NOT_ELIGIBLE,
        CATALOG_NOT_FOUND,
        CONTENT_NOT_PUBLISHED,
        CONTENT_PUBLISHED
    }
}
