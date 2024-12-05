using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Utils
{
    /// <summary>
    /// This is designed to be used as a singleton, for the purposes of coordinating rate limiting between separate concurrent requests
    /// <br/><br/>
    /// See <see href="https://developer-docs.amazon.com/sp-api/docs/usage-plans-and-rate-limits#rate-limiting-algorithm" />
    /// </summary>
    internal class RateLimitingHandler : IRateLimitingHandler
    {
        private const string RateLimitLimitHeaderName = "x-amzn-RateLimit-Limit";

        public async Task<RestResponse<TResponse>> SafelyExecuteRequestAsync<TResponse>(
            IRestClient restClient,
            RestRequest restRequest,
            AmazonCredential credential,
            RateLimitType rateLimitType = RateLimitType.UNSET,
            Action<RestResponse> action = null,
            CancellationToken cancellationToken = default) where TResponse : new()
        {
            await SleepForRateLimit(credential, rateLimitType, cancellationToken: default);

            var response = await restClient.ExecuteAsync<TResponse>(restRequest, cancellationToken);

            action?.Invoke(response);

            await SleepForRateLimit(credential, rateLimitType, cancellationToken: cancellationToken);

            return response;
        }

        private async Task SleepForRateLimit(
            AmazonCredential credential,
            RateLimitType rateLimitType = RateLimitType.UNSET,
            decimal updatedLimitRate = default,
            CancellationToken cancellationToken = default)
        {
            if (credential.IsActiveLimitRate)
            {
                var rateLimitPolicies = RateLimitsDefinitions.RateLimitsTimeForCredential(credential);

                if (rateLimitType == RateLimitType.UNSET
                    || !rateLimitPolicies.TryGetValue(rateLimitType, out var planTimings))
                {
                    if (updatedLimitRate > 0)
                    {
                        int sleepTime = (int)(1 / updatedLimitRate * 1000);
                        await Task.Delay(sleepTime, cancellationToken);
                    }
                }
                else
                {
                    if (updatedLimitRate > 0)
                    {
                        planTimings.SetRateLimit(updatedLimitRate);
                    }

                    await planTimings.WaitForPermittedRequest(cancellationToken);
                }
            }
        }

        private void UpdateRateLimitPolicy(AmazonCredential credential, RateLimitType rateLimitType, decimal updatedRateLimit)
        {
            if (updatedRateLimit <= 0)
            {
                return;
            }

            var rateLimitPolicies = RateLimitsDefinitions.RateLimitsTimeForCredential(credential);

            if (rateLimitType == RateLimitType.UNSET
                || !rateLimitPolicies.TryGetValue(rateLimitType, out var planTimings))
            {
                Console.WriteLine($"No rate limit policy found for {rateLimitType} for seller {credential.SellerID}");
                return;
            }

            planTimings.SetRateLimit(updatedRateLimit);
        }

        private decimal GetRateFromHeaders(IEnumerable<RestSharp.Parameter> headers)
        {
            decimal rate = 0;
            var limitHeader = headers.FirstOrDefault(a => a.Name == RateLimitLimitHeaderName);
            if (limitHeader != null)
            {
                var RateLimitValue = limitHeader.Value.ToString();
                decimal.TryParse(RateLimitValue, NumberStyles.Any, CultureInfo.InvariantCulture, out rate);
            }

            return rate;
        }
    }
}
