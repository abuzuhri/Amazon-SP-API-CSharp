using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>All promotions applied to an offer.</summary>
    public class OfferProgramConfigurationPromotions
    {
        [JsonProperty("sellingPartnerFundedBaseDiscount")]
        public OfferProgramConfigurationPromotionsDiscountFunding SellingPartnerFundedBaseDiscount { get; set; }

        [JsonProperty("sellingPartnerFundedTieredDiscount")]
        public OfferProgramConfigurationPromotionsDiscountFunding SellingPartnerFundedTieredDiscount { get; set; }

        [JsonProperty("amazonFundedBaseDiscount")]
        public OfferProgramConfigurationPromotionsDiscountFunding AmazonFundedBaseDiscount { get; set; }

        [JsonProperty("amazonFundedTieredDiscount")]
        public OfferProgramConfigurationPromotionsDiscountFunding AmazonFundedTieredDiscount { get; set; }
    }
}
