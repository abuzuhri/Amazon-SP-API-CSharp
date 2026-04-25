using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>A promotional percentage discount applied to the offer (0–100).</summary>
    public class OfferProgramConfigurationPromotionsDiscountFunding
    {
        [JsonProperty("percentage")]
        public long? Percentage { get; set; }
    }
}
