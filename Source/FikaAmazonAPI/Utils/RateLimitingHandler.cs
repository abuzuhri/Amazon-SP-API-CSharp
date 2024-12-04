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
            var response = await restClient.ExecuteAsync<TResponse>(restRequest, cancellationToken);

            action?.Invoke(response);

            await SleepForRateLimit(response.Headers, credential, rateLimitType, cancellationToken);

            return response;
        }

        private async Task SleepForRateLimit(
            IReadOnlyCollection<RestSharp.Parameter> headers,
            AmazonCredential credential,
            RateLimitType rateLimitType = RateLimitType.UNSET,
            CancellationToken cancellationToken = default)
        {
            try
            {
                decimal rate = 0;
                var limitHeader = headers.FirstOrDefault(a => a.Name == RateLimitLimitHeaderName);
                if (limitHeader != null)
                {
                    var RateLimitValue = limitHeader.Value.ToString();
                    decimal.TryParse(RateLimitValue, NumberStyles.Any, CultureInfo.InvariantCulture, out rate);
                }

                if (credential.IsActiveLimitRate)
                {
                    if (rateLimitType == RateLimitType.UNSET
                        || !credential.UsagePlansTimings.TryGetValue(rateLimitType, out var planTimings))
                    {
                        if (rate > 0)
                        {
                            int sleepTime = (int)(1 / rate * 1000);
                            await Task.Delay(sleepTime, cancellationToken);
                        }
                    }
                    else
                    {
                        if (rate > 0)
                        {
                            planTimings.SetRateLimit(rate);
                        }

                        await planTimings.NextRate(rateLimitType);
                    }
                }
            }
            catch (Exception e)
            {
                // not a big fan of this...
            }
        }
    }
}
