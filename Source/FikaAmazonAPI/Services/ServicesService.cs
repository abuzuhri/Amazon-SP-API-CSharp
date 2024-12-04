using FikaAmazonAPI.Utils;

namespace FikaAmazonAPI.Services
{
    public class ServicesService : RequestService
    {
        public ServicesService(AmazonCredential amazonCredential, IRateLimitingHandler rateLimitingHandler) : base(amazonCredential, rateLimitingHandler)
        {

        }
    }
}
