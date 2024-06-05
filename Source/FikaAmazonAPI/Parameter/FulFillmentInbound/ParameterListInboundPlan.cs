namespace FikaAmazonAPI.Parameter.FulFillmentInbound
{
    public class ParameterListInboundPlan : PaginationParameter
    {
        public string InboundPlanId { get; set; }
        public string PaginationToken { get; set; }
    }
}
