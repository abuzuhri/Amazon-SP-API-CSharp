using FikaAmazonAPI.AmazonSpApiSDK.Models.Services;
using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class ServicesService : RequestService
    {
        public ServicesService(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory) : base(amazonCredential, loggerFactory)
        {

        }

        public ServiceJob GetServiceJobByServiceJobId(string serviceJobId) =>
            Task.Run(() => GetServiceJobByServiceJobIdAsync(serviceJobId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ServiceJob> GetServiceJobByServiceJobIdAsync(string serviceJobId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(serviceJobId))
                throw new InvalidDataException("serviceJobId is a required property and cannot be null or empty");

            await CreateAuthorizedRequestAsync(ServiceApiUrls.GetServiceJobByServiceJobId(serviceJobId), RestSharp.Method.Get, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetServiceJobByServiceJobIdResponse>(RateLimitType.Service_GetServiceJobByServiceJobId, cancellationToken);
            return response?.Payload;
        }
    }
}
