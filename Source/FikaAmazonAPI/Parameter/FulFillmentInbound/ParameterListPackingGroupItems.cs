using FikaAmazonAPI.Search;

namespace FikaAmazonAPI.Parameter.FulFillmentInbound
{
    public class ParameterListPackingGroupItems : PaginationParameter
    { 
        public string InboundPlanId { get; set; }
        public string PackingOptionId { get; set; }
        public string PackingGroupId { get; set; }
        public string PaginationToken { get; set; }
    }
}
