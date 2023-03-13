using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FulfillmentType
    {
        AFN,
        MFN
    }
}