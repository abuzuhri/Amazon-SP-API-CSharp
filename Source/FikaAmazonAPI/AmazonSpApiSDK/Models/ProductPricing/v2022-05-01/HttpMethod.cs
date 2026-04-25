using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    /// <summary>
    /// The HTTP method associated with an individual request within a batch.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum HttpMethod
    {
        GET,
        PUT,
        PATCH,
        DELETE,
        POST
    }
}
