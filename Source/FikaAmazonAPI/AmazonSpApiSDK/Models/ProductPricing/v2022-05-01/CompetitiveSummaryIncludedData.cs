using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    /// <summary>
    /// The supported data types in the getCompetitiveSummary API.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CompetitiveSummaryIncludedData
    {
        featuredBuyingOptions,
        referencePrices,
        lowestPricedOffers,
        similarItems
    }
}
