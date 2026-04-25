using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    /// <summary>
    /// The number of Amazon Points offered with the purchase of an item and their monetary value.
    /// Returned only in Japan (JP).
    /// </summary>
    public class Points
    {
        [JsonProperty("pointsNumber")]
        public int? PointsNumber { get; set; }

        [JsonProperty("pointsMonetaryValue")]
        public MoneyType PointsMonetaryValue { get; set; }
    }
}
