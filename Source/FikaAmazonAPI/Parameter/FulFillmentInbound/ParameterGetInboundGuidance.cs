using FikaAmazonAPI.Search;
using System.Collections.Generic;

namespace FikaAmazonAPI.Parameter.FulFillmentInbound
{
    public class ParameterGetInboundGuidance : ParameterBased
    {
        public string MarketplaceId { get; set; }
        public ICollection<string> SellerSKUList { get; set; }
        public ICollection<string> ASINList { get; set; }
    }
}
