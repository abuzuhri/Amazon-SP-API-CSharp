using FikaAmazonAPI.Search;
using System.Collections.Generic;

namespace FikaAmazonAPI.Parameter.FulFillmentInbound
{
    public class ParameterGetPrepInstructions : ParameterBased
    {
        public string ShipToCountryCode { get; set; }
        public string MarketplaceId { get; set; }
        public ICollection<string> SellerSKUList { get; set; }
        public ICollection<string> ASINList { get; set; }
    }
}
