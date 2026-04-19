using Microsoft.Extensions.Logging;

namespace FikaAmazonAPI.Services
{
    public class FbaInboundService : RequestService
    {
        public FbaInboundService(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory) : base(amazonCredential, loggerFactory)
        {

        }
    }
}
