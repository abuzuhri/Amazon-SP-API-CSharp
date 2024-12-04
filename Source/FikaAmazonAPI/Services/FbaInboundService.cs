using FikaAmazonAPI.Utils;

namespace FikaAmazonAPI.Services
{
    public class FbaInboundService : RequestService
    {
        public FbaInboundService(AmazonCredential amazonCredential, IRateLimitingHandler rateLimitingHandler = null) : base(amazonCredential, rateLimitingHandler)
        {

        }
    }
}
