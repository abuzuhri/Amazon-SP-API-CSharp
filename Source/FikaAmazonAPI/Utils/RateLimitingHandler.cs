using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Utils
{
    /// <summary>
    /// This is designed to be used as a singleton, for the purposes of coordinating rate limiting between separate concurrent requests
    /// </summary>
    internal class RateLimitingHandler : IRateLimitingHandler
    {
        public Task<RestResponse> SafelyExecuteRequestAsync<TResult>(IRestClient restClient, RestRequest restRequest, AmazonCredential credential, RateLimitType rateLimitType = RateLimitType.UNSET, CancellationToken cancellationToken = default) where TResult : class
        {
            throw new NotImplementedException();
        }
    }
}
