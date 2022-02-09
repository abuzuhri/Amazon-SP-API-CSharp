using FikaAmazonAPI.Search;
using System.Collections.Generic;

namespace FikaAmazonAPI.Parameter.FulFillmentInbound
{
    public class ParameterGetPrepInstructions : ParameterBased
    {
        public string ShipToCountryCode { get; set; }
        public string MarketplaceId { get; set; }
        public IList<string> SellerSKUList { get; set; }
        public IList<string> ASINList { get; set; }
    }
}
