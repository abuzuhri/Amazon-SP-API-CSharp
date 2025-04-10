using Microsoft.Extensions.Logging;

namespace FikaAmazonAPI.Services
{
    public class ExternalFulfillmentService : RequestService
    {
        public ExternalFulfillmentService(AmazonCredential amazonCredential, ILoggerFactory loggerFactory) : base(amazonCredential, loggerFactory)
        {
        }


    }
}
