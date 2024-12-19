namespace FikaAmazonAPI.Parameter.FulFillmentInbound.v20240320
{
    [CamelCase]
    public class ParameterListTransportationOptions : PaginationParameter
    {
        public string PlacementOptionId { get; set; }
        public string ShipmentId { get; set; }
        public string PaginationToken { get; set; }
    }
}
