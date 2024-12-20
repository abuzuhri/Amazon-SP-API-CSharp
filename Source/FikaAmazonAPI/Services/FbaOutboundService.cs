using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Logging;

namespace FikaAmazonAPI.Services
{
    public class FbaOutboundService : RequestService
    {
        public FbaOutboundService(AmazonCredential amazonCredential,ILoggerFactory? loggerFactory, IRateLimitingHandler rateLimitingHandler = null) : base(amazonCredential, loggerFactory, rateLimitingHandler)
        {

        }
    }
}
