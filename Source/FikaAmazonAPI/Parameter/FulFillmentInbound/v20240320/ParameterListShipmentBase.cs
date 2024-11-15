namespace FikaAmazonAPI.Parameter.FulFillmentInbound.v20240320
{
    public class ParameterListShipmentBase : PaginationParameter
    { 
        public string InboundPlanId { get; set; }
        public string ShipmentId { get; set; }
        public string paginationToken { get; set; }
    }
}
