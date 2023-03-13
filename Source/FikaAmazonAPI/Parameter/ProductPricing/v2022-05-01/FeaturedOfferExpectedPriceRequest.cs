using System.Collections.Generic;
using FikaAmazonAPI.AmazonSpApiSDK.Services;
using Newtonsoft.Json;

namespace FikaAmazonAPI.Parameter.ProductPricing.v2022_05_01
{
    public class FeaturedOfferExpectedPriceRequest
    {
        /// <summary>
        /// The URI associated with an individual request within a batch. For FeaturedOfferExpectedPrice, this should be '/products/pricing/2022-05-01/offer/featuredOfferExpectedPrice'.
        /// </summary>
        [JsonProperty("uri")] public string Uri => ApiUrls.ProductPricingApiUrls.FeaturedOfferExpectedPriceUri;

        /// <summary>
        /// The HTTP method associated with an individual request within a batch.
        /// </summary>
        [JsonProperty("method")]
        public HttpMethodEnum HttpMethod => HttpMethodEnum.GET;

        /// <summary>
        /// Additional HTTP body information associated with an individual request within a batch.
        /// </summary>
        [JsonProperty("body")]
        public dynamic HttpBody { get; set; }
        
        /// <summary>
        /// A mapping of additional HTTP headers to send/receive for an individual request within a batch.
        /// </summary>
        [JsonProperty("headers")]
        public Dictionary<string,string> HttpHeaders { get; set; }
        
        /// <summary>
        /// A marketplace identifier. Specifies the marketplace for which data is returned.
        /// </summary>
        [JsonProperty("marketplaceId")]
        public string MarketplaceId { get; set; }
        
        /// <summary>
        /// The seller SKU of the item.
        /// </summary>
        [JsonProperty("sku")]
        public string SellerSku { get; set; }
    }
}