using RestSharp;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Utils
{
    /// <summary>
    /// This is designed to be used as a singleton, for the purposes of coordinating rate limiting between separate concurrent requests
    /// </summary>
    public interface IRateLimitingHandler
    {
        Task<RestResponse> SafelyExecuteRequestAsync<TResult>(
            IRestClient restClient,
            RestRequest restRequest,
            AmazonCredential credential,
            RateLimitType rateLimitType = RateLimitType.UNSET,
            CancellationToken cancellationToken = default) where TResult : class;
    }
}
