using FikaAmazonAPI.Utils;

namespace FikaAmazonAPI.Services
{
    public class FbaOutboundService : RequestService
    {
        public FbaOutboundService(AmazonCredential amazonCredential, IRateLimitingHandler rateLimitingHandler) : base(amazonCredential, rateLimitingHandler)
        {

        }
    }
}
