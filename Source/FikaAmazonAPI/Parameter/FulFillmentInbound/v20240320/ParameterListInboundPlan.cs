using FikaAmazonAPI.Parameter.FulFillmentInbound;
namespace FikaAmazonAPI.Parameter.FulFillmentInbound.v20240320
{
    public class ParameterListInboundPlan : PaginationParameter
    {
        public string InboundPlanId { get; set; }
        public string PaginationToken { get; set; }
    }
}
