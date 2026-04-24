using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using static FikaAmazonAPI.AmazonSpApiSDK.Services.ApiUrls;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Parameter.ProductPricing
{
    public class ListingOffersRequest
    {
        /// <summary>
        /// The full URI corresponding to the API intended for request, including path parameter substitutions.
        /// </summary>
        [JsonProperty("uri")]
        public string Uri
        {
            get
            {
                return ProductPricingApiUrls.GetListingOffers(this.QueryParams.SellerSKU);
            }
        }

        /// <summary>
        /// The HTTP method associated with the individual APIs being called as part of the batch request.
        /// </summary>
        [JsonProperty("method")]
        public HttpMethodEnum HttpMethod { get; set; }

        // Amazon changed their batch API contract: query params must be serialized at the top level, not nested under "queryParams".
        [JsonIgnore]
        public ParameterGetListingOffers QueryParams { get; set; }

        [JsonProperty("MarketplaceId")]
        public string MarketplaceId => QueryParams?.MarketplaceId;

        [JsonProperty("ItemCondition")]
        public ItemCondition ItemCondition => QueryParams?.ItemCondition ?? default;

        [JsonProperty("CustomerType")]
        public CustomerType? CustomerType => QueryParams?.CustomerType;
    }
}
