using FikaAmazonAPI.Utils;

namespace FikaAmazonAPI.Services
{
    public class TokenService : RequestService
    {
        public TokenService(AmazonCredential amazonCredential, IRateLimitingHandler rateLimitingHandler = null) : base(amazonCredential, rateLimitingHandler)
        {

        }


    }
}
