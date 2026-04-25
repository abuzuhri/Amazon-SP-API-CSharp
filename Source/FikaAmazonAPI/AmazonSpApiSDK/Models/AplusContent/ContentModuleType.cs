using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>
    /// Discriminator for which Standard*Module field on <see cref="ContentModule"/>
    /// is populated. Set this to match the populated module.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ContentModuleType
    {
        STANDARD_COMPANY_LOGO,
        STANDARD_COMPARISON_TABLE,
        STANDARD_FOUR_IMAGE_TEXT,
        STANDARD_FOUR_IMAGE_TEXT_QUADRANT,
        STANDARD_HEADER_IMAGE_TEXT,
        STANDARD_IMAGE_SIDEBAR,
        STANDARD_IMAGE_TEXT_OVERLAY,
        STANDARD_MULTIPLE_IMAGE_TEXT,
        STANDARD_PRODUCT_DESCRIPTION,
        STANDARD_SINGLE_IMAGE_HIGHLIGHTS,
        STANDARD_SINGLE_IMAGE_SPECS_DETAIL,
        STANDARD_SINGLE_SIDE_IMAGE,
        STANDARD_TECH_SPECS,
        STANDARD_TEXT,
        STANDARD_THREE_IMAGE_TEXT
    }
}
