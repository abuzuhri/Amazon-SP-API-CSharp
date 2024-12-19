using FikaAmazonAPI.Utils;

namespace FikaAmazonAPI.Services
{

    public class AplusContentService : RequestService
    {

        public AplusContentService(AmazonCredential amazonCredential, IRateLimitingHandler rateLimitingHandler = null) : base(amazonCredential, rateLimitingHandler)
        {

        }
    }
}
