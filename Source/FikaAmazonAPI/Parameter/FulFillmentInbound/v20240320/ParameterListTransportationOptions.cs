using FikaAmazonAPI.Parameter.FulFillmentInbound;
namespace FikaAmazonAPI.Parameter.FulFillmentInbound.v20240320
{
    public class ParameterListTransportationOptions : PaginationParameter
    {
        public string PlacementOptionId { get; set; }
        public string ShipmentId { get; set; }
        public string PaginationToken { get; set; }
    }
}
