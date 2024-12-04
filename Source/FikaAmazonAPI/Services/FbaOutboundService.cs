using FikaAmazonAPI.Utils;

namespace FikaAmazonAPI.Services
{
    public class FbaOutboundService : RequestService
    {
        public FbaOutboundService(AmazonCredential amazonCredential, IRateLimitingHandler rateLimitingHandler = null) : base(amazonCredential, rateLimitingHandler)
        {

        }
    }
}
