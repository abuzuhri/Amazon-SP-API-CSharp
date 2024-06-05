using FikaAmazonAPI.Search;
using System.Collections.Generic;

namespace FikaAmazonAPI.Parameter.FulFillmentInbound
{
    public class ParematerListItemComplianceDetails : ParameterBased
    {
        public ICollection<string> MSkus { get; set; }
        public string MarketplaceId { get; set; }
    }
}
