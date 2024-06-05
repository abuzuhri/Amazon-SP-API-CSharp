namespace FikaAmazonAPI.Parameter.FulFillmentInbound
{
    public class ParameterListTransportationOptions : PaginationParameter
    {
        public string PlacementOptionId { get; set; }
        public string ShipmentId { get; set; }
        public string PaginationToken { get; set; }
    }
}
