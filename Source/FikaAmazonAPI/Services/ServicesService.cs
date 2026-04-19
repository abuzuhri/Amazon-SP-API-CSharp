using Microsoft.Extensions.Logging;

namespace FikaAmazonAPI.Services
{
    public class ServicesService : RequestService
    {
        public ServicesService(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory) : base(amazonCredential, loggerFactory)
        {

        }
    }
}
