using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Logging;

namespace FikaAmazonAPI.Services
{
    public class TokenService : RequestService
    {
        public TokenService(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory, IRateLimitingHandler rateLimitingHandler = null) : base(amazonCredential, loggerFactory, rateLimitingHandler)
        {

        }


    }
}
