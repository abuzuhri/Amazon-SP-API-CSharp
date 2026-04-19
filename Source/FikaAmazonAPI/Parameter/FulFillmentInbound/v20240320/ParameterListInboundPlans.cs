using static FikaAmazonAPI.Utils.Constants;
using FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInboundv20240320;

namespace FikaAmazonAPI.Parameter.FulFillmentInbound.v20240320
{
    [CamelCase]
    public class ParameterListInboundPlans : PaginationParameter
    {
        public string PaginationToken { get; set; }
        public InboundPlanStatus? Status { get; set; }
        public SortBy? SortBy { get; set; }
        public SortOrderEnum? SortOrder { get; set; }
    }
}
