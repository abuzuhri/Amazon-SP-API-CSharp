using FikaAmazonAPI.Utils;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Parameter.FulFillmentInbound.v20240320
{
    public class ParameterGetListInboundPlans : PaginationParameter
    {
        public string PaginationToken { get; set; }
        public FullFillmentInboundPlanStatus? Status { get; set; }
        public FullFillmentInboundSortBy? SortBy { get; set; }
        public SortOrderEnum? sortOrder { get; set; }
    }
}
