namespace FikaAmazonAPI.Parameter.FulFillmentInbound
{
    public class ParameterListPackingGroupBoxes : PaginationParameter
    {
        public string InboundPlanId { get; set; }
        public string PackingGroupId { get; set; }
        public string PaginationToken { get; set; }
    }

}
