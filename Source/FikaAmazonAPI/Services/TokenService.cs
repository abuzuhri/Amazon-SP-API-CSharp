using FikaAmazonAPI.Utils;

namespace FikaAmazonAPI.Services
{
    public class TokenService : RequestService
    {
        public TokenService(AmazonCredential amazonCredential, IRateLimitingHandler rateLimitingHandler) : base(amazonCredential, rateLimitingHandler)
        {

        }


    }
}
