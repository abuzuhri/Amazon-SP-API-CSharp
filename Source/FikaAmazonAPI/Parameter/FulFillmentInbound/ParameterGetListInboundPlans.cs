using FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound;

namespace FikaAmazonAPI.Parameter.FulFillmentInbound
{
    public class ParameterGetListInboundPlans : PaginationParameter
    {
        public string PaginationToken { get; set; }
        public Status? Status { get; set; }
        public SortBy? SortBy { get; set; }
        public SortOrder? sortOrder { get; set; }
    }
}
