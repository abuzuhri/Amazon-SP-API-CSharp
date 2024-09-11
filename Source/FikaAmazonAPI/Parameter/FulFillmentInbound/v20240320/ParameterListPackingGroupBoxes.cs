namespace FikaAmazonAPI.Parameter.FulFillmentInbound.v20240320
{
    public class ParameterListPackingGroupBoxes : PaginationParameter
    { 
        public string InboundPlanId { get; set; }
        public string PackingGroupId { get; set; }
        public string PaginationToken { get; set; }
    }
}
