using FikaAmazonAPI.Search;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Parameter.ProductPricing
{
    public class ParameterGetListingOffersBatchRequest : ParameterBased
    {
        [JsonProperty("requests")]
        public List<ListingOffersRequest>  ParameterGetListingOffers { get; set; }
    }
}
