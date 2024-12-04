using RestSharp;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Utils
{
    /// <summary>
    /// This is designed to be used as a singleton, for the purposes of coordinating rate limiting between separate concurrent requests
    /// <br/><br/>
    /// See <see href="https://developer-docs.amazon.com/sp-api/docs/usage-plans-and-rate-limits#rate-limiting-algorithm" />
    /// </summary>
    public interface IRateLimitingHandler
    {
        Task<RestResponse<TResponse>> SafelyExecuteRequestAsync<TResponse>(
            IRestClient restClient,
            RestRequest restRequest,
            AmazonCredential credential,
            RateLimitType rateLimitType = RateLimitType.UNSET,
            Action<RestResponse> responseCallback = null,
            CancellationToken cancellationToken = default) where TResponse : new();
    }
}
