namespace FikaAmazonAPI.Parameter.FulFillmentInbound.v20240320
{
    [CamelCase]
    public class ParameterListInboundPlanBase : PaginationParameter
    {
        public string InboundPlanId { get; set; }
        public string PaginationToken { get; set; }
    }
}
