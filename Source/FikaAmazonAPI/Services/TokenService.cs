using Microsoft.Extensions.Logging;

namespace FikaAmazonAPI.Services
{
    public class TokenService : RequestService
    {
        public TokenService(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory) : base(amazonCredential, loggerFactory)
        {

        }


    }
}
