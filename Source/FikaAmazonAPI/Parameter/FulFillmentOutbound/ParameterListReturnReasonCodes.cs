using FikaAmazonAPI.Search;

namespace FikaAmazonAPI.Parameter.FulFillmentInbound
{
    public class ParameterListReturnReasonCodes : ParameterBased
    {
        public string SellerSku { get; set; }
        public string MarketplaceId { get; set; }
        public string SellerFulfillmentOrderId { get; set; }
        public string Language { get; set; }
    }
}
