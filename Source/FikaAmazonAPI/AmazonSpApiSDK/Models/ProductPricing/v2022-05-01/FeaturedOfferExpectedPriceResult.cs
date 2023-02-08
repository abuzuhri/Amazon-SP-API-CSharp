using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    public class FeaturedOfferExpectedPriceResult
    {
        /// <summary>
        /// The item price at or below which the target offer may be featured.
        /// </summary>
        [JsonProperty("featuredOfferExpectedPrice")]
        public FeaturedOfferExpectedPrice FeaturedOfferExpectedPrice { get; set; }

        /// <summary>
        /// The status of the featured offer expected price computation. Possible values include VALID_FOEP, NO_COMPETING_OFFER, OFFER_NOT_ELIGIBLE, OFFER_NOT_FOUND.
        /// </summary>
        [JsonProperty("resultStatus")]
        public string ResultStatus { get; set; }

        /// <summary>
        /// The offer that will likely be the featured offer if the target offer is priced above its featured offer expected price. If the target offer is currently the featured offer, this property will be different than currentFeaturedOffer.
        /// </summary>
        [JsonProperty("competingFeaturedOffer")]
        public FeaturedOffer CompetingFeaturedOffer { get; set; }
        
        /// <summary>
        /// The offer that is currently the featured offer. If the target offer is not currently featured, this property will be equal to competingFeaturedOffer.
        /// </summary>
        [JsonProperty("currentFeaturedOffer")]
        public FeaturedOffer CurrentFeaturedOffer { get; set; }
    }
}