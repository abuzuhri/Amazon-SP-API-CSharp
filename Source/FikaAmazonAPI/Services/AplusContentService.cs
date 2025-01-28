using Microsoft.Extensions.Logging;

namespace FikaAmazonAPI.Services
{

    public class AplusContentService : RequestService
    {

        public AplusContentService(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory) : base(amazonCredential, loggerFactory)
        {

        }
    }
}
