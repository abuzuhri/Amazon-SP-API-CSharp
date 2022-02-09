using FikaAmazonAPI.Search;
using System.Collections.Generic;

namespace FikaAmazonAPI.Parameter.FulFillmentInbound
{
    public class ParameterGetInboundGuidance : ParameterBased
    {
        public string MarketplaceId { get; set; }
        public IList<string> SellerSKUList { get; set; }
        public IList<string> ASINList { get; set; }
    }
}
