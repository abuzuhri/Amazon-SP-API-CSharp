using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DecoratorType
    {
        LIST_ITEM,
        LIST_ORDERED,
        LIST_UNORDERED,
        STYLE_BOLD,
        STYLE_ITALIC,
        STYLE_LINEBREAK,
        STYLE_PARAGRAPH,
        STYLE_UNDERLINE
    }
}
