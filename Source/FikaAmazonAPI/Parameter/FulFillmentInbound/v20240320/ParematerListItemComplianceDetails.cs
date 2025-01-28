using FikaAmazonAPI.Search;
using System.Collections.Generic;

namespace FikaAmazonAPI.Parameter.FulFillmentInbound.v20240320
{
    [CamelCase]
    public class ParematerListItemComplianceDetails : ParameterBased
    {
        public ICollection<string> MSkus { get; set; }
        public string MarketplaceId { get; set; }
    }
}
