using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;

namespace FikaAmazonAPI.Search
{
    public interface IParameterBasedPII
    {
        public bool IsNeedRestrictedDataToken { get; set; }
        public CreateRestrictedDataTokenRequest RestrictedDataTokenRequest { get; set; }
    }
}
