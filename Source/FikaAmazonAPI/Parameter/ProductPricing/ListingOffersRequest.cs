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

        //[JsonProperty("headers")]
        //public Dictionary<string, string> Headers { get; set; }

        [JsonProperty("queryParams")]
        public ParameterGetListingOffers QueryParams { get; set; }
    }
}
