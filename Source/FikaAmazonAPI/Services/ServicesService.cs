using FikaAmazonAPI.AmazonSpApiSDK.Models.Services;
using FikaAmazonAPI.Parameter.Service;
using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
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

        public IList<ServiceJob> GetServiceJobs(ParameterGetServiceJobs parameter) =>
            Task.Run(() => GetServiceJobsAsync(parameter)).ConfigureAwait(false).GetAwaiter().GetResult();

        /// <summary>
        /// Returns a paged list of service jobs across the supplied filters. Pages are fetched
        /// internally; callers receive a flat <see cref="IList{ServiceJob}"/> spanning every page.
        /// </summary>
        public async Task<IList<ServiceJob>> GetServiceJobsAsync(ParameterGetServiceJobs parameter, CancellationToken cancellationToken = default)
        {
            if (parameter == null)
                throw new InvalidDataException("parameter is a required argument and cannot be null");
            if (parameter.marketplaceIds == null || parameter.marketplaceIds.Count == 0)
            {
                parameter.marketplaceIds = new List<string> { AmazonCredential.MarketPlace.ID };
            }

            var jobs = new List<ServiceJob>();
            string nextPageToken = null;

            do
            {
                if (nextPageToken != null) parameter.pageToken = nextPageToken;
                var queryParameters = parameter.getParameters();

                await CreateAuthorizedRequestAsync(ServiceApiUrls.GetServiceJobs, RestSharp.Method.Get, queryParameters, cancellationToken: cancellationToken);
                var response = await ExecuteRequestAsync<GetServiceJobsResponse>(RateLimitType.Service_GetServiceJobs, cancellationToken);

                if (response?.Payload?.Jobs != null)
                    jobs.AddRange(response.Payload.Jobs);

                nextPageToken = response?.Payload?.NextPageToken;
            }
            while (!string.IsNullOrEmpty(nextPageToken));

            return jobs;
        }

        public bool CancelServiceJobByServiceJobId(string serviceJobId, string cancellationReasonCode) =>
            Task.Run(() => CancelServiceJobByServiceJobIdAsync(serviceJobId, cancellationReasonCode)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<bool> CancelServiceJobByServiceJobIdAsync(string serviceJobId, string cancellationReasonCode, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(serviceJobId))
                throw new InvalidDataException("serviceJobId is a required property and cannot be null or empty");
            if (string.IsNullOrEmpty(cancellationReasonCode))
                throw new InvalidDataException("cancellationReasonCode is a required property and cannot be null or empty");

            var queryParameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("cancellationReasonCode", cancellationReasonCode)
            };

            await CreateAuthorizedRequestAsync(ServiceApiUrls.CancelServiceJobByServiceJobId(serviceJobId), RestSharp.Method.Put, queryParameters, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<CancelServiceJobByServiceJobIdResponse>(RateLimitType.Service_CancelServiceJobByServiceJobId, cancellationToken);
            return response?.Errors == null || response.Errors.Count == 0;
        }

        public bool CompleteServiceJobByServiceJobId(string serviceJobId) =>
            Task.Run(() => CompleteServiceJobByServiceJobIdAsync(serviceJobId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<bool> CompleteServiceJobByServiceJobIdAsync(string serviceJobId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(serviceJobId))
                throw new InvalidDataException("serviceJobId is a required property and cannot be null or empty");

            await CreateAuthorizedRequestAsync(ServiceApiUrls.CompleteServiceJobByServiceJobId(serviceJobId), RestSharp.Method.Put, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<CompleteServiceJobByServiceJobIdResponse>(RateLimitType.Service_CompleteServiceJobByServiceJobId, cancellationToken);
            return response?.Errors == null || response.Errors.Count == 0;
        }
    }
}
