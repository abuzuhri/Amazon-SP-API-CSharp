using FikaAmazonAPI.Search;

namespace FikaAmazonAPI.Parameter.Authorization
{
    public class ParameterAuthorizationCode : ParameterBased
    {
        public string sellingPartnerId { get; set; }
        public string developerId { get; set; }
        public string mwsAuthToken { get; set; }

    }
}
