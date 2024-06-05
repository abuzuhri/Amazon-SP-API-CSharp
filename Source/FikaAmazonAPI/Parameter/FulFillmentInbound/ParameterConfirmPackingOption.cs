using FikaAmazonAPI.Search;

namespace FikaAmazonAPI.Parameter.FulFillmentInbound
{
    public class ParameterConfirmPackingOption : ParameterBased 
    {
        public string InboundPlanId { get; set; }
        public string PackingOptionId { get; set; }
    }
}
