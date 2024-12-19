using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Utils
{
    /// <summary>
    /// This is designed to be used as a singleton, for the purposes of coordinating rate limiting between separate concurrent requests
    /// <br/><br/>
    /// See <see href="https://developer-docs.amazon.com/sp-api/docs/usage-plans-and-rate-limits#rate-limiting-algorithm" />
    /// </summary>
    public class RateLimitingHandler : IRateLimitingHandler
    {
        private const string RateLimitLimitHeaderName = "x-amzn-RateLimit-Limit";
        private const int FallbackDefaultBurstRate = 1;

        public async Task<RestResponse<TResponse>> SafelyExecuteRequestAsync<TResponse>(
            IRestClient restClient,
            RestRequest restRequest,
            AmazonCredential credential,
            RateLimitType rateLimitType = RateLimitType.UNSET,
            Action<RestResponse> action = null,
            CancellationToken cancellationToken = default) where TResponse : new()
        {
            await WaitForLimitTypeAsync(credential, rateLimitType, cancellationToken: default);

            var response = await restClient.ExecuteAsync<TResponse>(restRequest, cancellationToken);

            action?.Invoke(response);

            if (response != null && TryGetRateFromHeaders(response.Headers, out var headersRate)) 
            {
                UpdateRateLimitPolicy(credential, rateLimitType, headersRate);
            }

            return response;
        }

        public async Task WaitForLimitTypeAsync(
            AmazonCredential credential,
            RateLimitType rateLimitType,
            CancellationToken cancellationToken = default)
        {
            if (!credential.IsActiveLimitRate)
            {
                return;
            }

            var policies = RateLimitsDefinitions.RateLimitsTimeForCredential(credential);

            if (policies.TryGetValue(rateLimitType, out var policy))
            {
                await policy.WaitForPermittedRequest(cancellationToken, credential.IsDebugMode);
            }
        }

        private void UpdateRateLimitPolicy(AmazonCredential credential, RateLimitType rateLimitType, decimal updatedRateLimit)
        {
            if (updatedRateLimit <= 0)
            {
                return;
            }

            var rateLimitPolicies = RateLimitsDefinitions.RateLimitsTimeForCredential(credential);

            if (!rateLimitPolicies.TryGetValue(rateLimitType, out var planTimings))
            {
                Console.WriteLine(
                    $"No rate limit policy found for {rateLimitType} for seller {credential.SellerID}, will create new policy for seller with default burst rate of {FallbackDefaultBurstRate}");
                rateLimitPolicies.TryAdd(rateLimitType, new RateLimits(Rate: updatedRateLimit, Burst: FallbackDefaultBurstRate, type: rateLimitType));
                return;
            }

            planTimings.SetRateLimit(updatedRateLimit);
        }

        private bool TryGetRateFromHeaders(IEnumerable<RestSharp.Parameter> headers, out decimal rate)
        {
            rate = 0;
            var limitHeader = headers.FirstOrDefault(a => a.Name == RateLimitLimitHeaderName);
            if (limitHeader != null)
            {
                var RateLimitValue = limitHeader.Value.ToString();
                return decimal.TryParse(RateLimitValue, NumberStyles.Any, CultureInfo.InvariantCulture, out rate);
            }

            return false;
        }
    }
}
