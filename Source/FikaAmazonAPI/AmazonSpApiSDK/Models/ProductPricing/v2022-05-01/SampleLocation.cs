using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    /// <summary>
    /// Information about a location. Uses a postal code to identify the location.
    /// </summary>
    public class SampleLocation
    {
        [JsonProperty("postalCode")]
        public PostalCode PostalCode { get; set; }
    }
}
