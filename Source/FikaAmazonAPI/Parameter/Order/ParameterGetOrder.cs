using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using FikaAmazonAPI.Search;

namespace FikaAmazonAPI.Parameter.Order
{
    public class ParameterGetOrder : ParameterBased, IParameterBasedPII
    {
        public string OrderId { get; set; }
        public bool IsNeedRestrictedDataToken { get; set; }
        public CreateRestrictedDataTokenRequest RestrictedDataTokenRequest { get; set; }
    }
}
