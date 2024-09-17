namespace FikaAmazonAPI.Parameter.FulFillmentInbound.v20240320
{
    public class ParameterListInboundPlanBase : PaginationParameter
    {
        public string InboundPlanId { get; set; }
        public string PaginationToken { get; set; }
    }
}
