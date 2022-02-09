using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using FikaAmazonAPI.Search;

namespace FikaAmazonAPI.Parameter
{
    public class ParameterBasedPII : ParameterBased, IParameterBasedPII
    {
        public bool IsNeedRestrictedDataToken { get; set; }
        public CreateRestrictedDataTokenRequest RestrictedDataTokenRequest { get; set; }
    }
}
