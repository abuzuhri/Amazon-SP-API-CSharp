using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>Offer promotions to include in the listOffers result filter criteria.</summary>
    public class Promotion
    {
        [JsonProperty("sellingPartnerFundedBaseDiscount")]
        public DiscountFunding SellingPartnerFundedBaseDiscount { get; set; }

        [JsonProperty("sellingPartnerFundedTieredDiscount")]
        public DiscountFunding SellingPartnerFundedTieredDiscount { get; set; }

        [JsonProperty("amazonFundedBaseDiscount")]
        public DiscountFunding AmazonFundedBaseDiscount { get; set; }

        [JsonProperty("amazonFundedTieredDiscount")]
        public DiscountFunding AmazonFundedTieredDiscount { get; set; }
    }
}
