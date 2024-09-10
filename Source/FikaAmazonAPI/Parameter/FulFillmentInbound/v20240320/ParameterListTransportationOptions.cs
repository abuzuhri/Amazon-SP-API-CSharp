namespace FikaAmazonAPI.Parameter.FulFillmentInbound.v20240320
{
    public class ParameterListTransportationOptions : PaginationParameter
    {
        public string placementOptionId { get; set; }
        public string shipmentId { get; set; }
        public string PaginationToken { get; set; }
    }
}
