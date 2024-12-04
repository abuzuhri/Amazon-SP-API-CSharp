using FikaAmazonAPI.Utils;

namespace FikaAmazonAPI.Services
{

    public class AplusContentService : RequestService
    {

        public AplusContentService(AmazonCredential amazonCredential, IRateLimitingHandler rateLimitingHandler) : base(amazonCredential, rateLimitingHandler)
        {

        }
    }
}
