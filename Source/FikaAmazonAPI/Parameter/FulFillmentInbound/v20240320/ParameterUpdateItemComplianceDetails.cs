using FikaAmazonAPI.Search;

namespace FikaAmazonAPI.Parameter.FulFillmentInbound.v20240320
{
    [CamelCase]
    public class ParameterUpdateItemComplianceDetails : ParameterBased
    {
        public string MarketplaceId { get; set; }
    }
}
