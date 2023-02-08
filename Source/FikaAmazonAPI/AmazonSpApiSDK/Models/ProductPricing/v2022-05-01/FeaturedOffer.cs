using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    public class FeaturedOffer
    {
        /// <summary>
        /// An offer identifier used to identify the merchant of the featured offer. Since this may not belong to the requester, the SKU field will be omitted.
        /// </summary>
        [JsonProperty("offerIdentifier")]
        public OfferIdentifier OfferIdentifier { get; set; }
        
        /// <summary>
        /// The item condition.
        /// </summary>
        [JsonProperty("condition")]
        public ConditionType Condition { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }
    }
}