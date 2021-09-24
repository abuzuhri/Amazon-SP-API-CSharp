using FikaAmazonAPI.Search;
using System;
using System.Collections.Generic;
using System.Text;

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
