using Microsoft.Extensions.Logging;

namespace FikaAmazonAPI.Services
{
    public class FbaOutboundService : RequestService
    {
        public FbaOutboundService(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory) : base(amazonCredential, loggerFactory)
        {

        }
    }
}
