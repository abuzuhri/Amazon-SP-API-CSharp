using System;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Utils
{
    internal class RateLimits
    {
        private object _locker = new object();
        internal decimal Rate { get; private set; }
        internal int Burst { get; }
        internal DateTime LastRequestReplenished { get; private set; }
        internal int RequestsUsed { get; private set; }
        internal RateLimitType RateLimitType { get; }

        /// <summary>
        /// Constructor for rate limits configuration object
        /// </summary>
        /// <param name="Rate">The number of permitted requests which will be added to the "Token bucket" per second</param>
        /// <param name="Burst">The maximum number of requests which can exist in the "Token bucket" at any time</param>
        /// <param name="type">An enum representing the resource for which the rate limit policy is being set</param>
        internal RateLimits(decimal Rate, int Burst, RateLimitType type)
        {
            this.Rate = Rate;
            this.Burst = Burst;
            this.RateLimitType = type;
            this.LastRequestReplenished = DateTime.UtcNow;
            this.RequestsUsed = 0;
        }

        private int GetRatePeriodMs() { return (int)(((1 / Rate) * 1000) / 1); }

        /// <summary>
        /// Performs a wait based on the Token Bucket rate limiting algorithm described in documentation.
        /// <br/><br/>
        /// See also <see href="https://developer-docs.amazon.com/sp-api/docs/usage-plans-and-rate-limits#rate-limiting-algorithm"/>
        /// </summary>
        /// <param name="rateLimitType">An enum representing the rate limit policy for the resource in use</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task WaitForPermittedRequest(CancellationToken cancellationToken = default, bool debugMode = true)
        {
            if (RequestsUsed < 0)
            {
                RequestsUsed = 0;
            }

            int ratePeriodMs = GetRatePeriodMs();
            var requestsUsedAtOnset = RequestsUsed;

            // when requests used more than zero, replenish according to time elapsed
            var requestsToReplenish = requestsUsedAtOnset == 0 || ratePeriodMs == 0 ? 0 : (DateTime.UtcNow - LastRequestReplenished).Milliseconds / ratePeriodMs;
            if (requestsToReplenish > 0)
            {
                IncrementAvailableTokens(requestsToReplenish, requestsUsedAtOnset);
            }

            var nextRequestsSent = RequestsUsed + 1;
            var nextRequestsSentTxt = (nextRequestsSent > Burst) ? "FULL" : nextRequestsSent.ToString();
            if (debugMode)
            {
                string output = $"[RateLimits ,{this.RateLimitType,15}]: {DateTime.UtcNow.ToString(),10}\t Request/Burst: {nextRequestsSentTxt}/{Burst}\t Rate: {Rate}/{ratePeriodMs}ms";
                Console.WriteLine(output);
            }

            var requestIsPermitted = false;

            while (!requestIsPermitted)
            {
                // if bucket is currently empty, enter wait loop for replenishment
                while (RequestsUsed >= Burst)
                {
                    var currentRequestsUsed = RequestsUsed;
                    // wait until predicted next token available
                    var incomingRequestTokenTime = LastRequestReplenished.AddMilliseconds(ratePeriodMs);
                    if (incomingRequestTokenTime > DateTime.UtcNow)
                    {
                        await Task.Delay(100);
                        continue;
                    }
                    else
                    {
                        // replenish token
                        IncrementAvailableTokens(1, currentRequestsUsed);
                    }

                    if (RequestsUsed <= 0)
                    {
                        RequestsUsed = 0;
                        break;
                    }
                }

                // now remove token from bucket for pending request
                requestIsPermitted = TryDecrementAvailableTokens();
            }
        }

        internal void SetRateLimit(decimal rate)
        {
            Rate = rate;
        }

        // increments available tokens, unless another thread has already incremented them.
        private void IncrementAvailableTokens(int amountToIncrementBy, int initialAmount)
        {
            lock (_locker)
            {
                if (RequestsUsed >= initialAmount)
                {
                    RequestsUsed = Math.Max(RequestsUsed - amountToIncrementBy, 0);
                    LastRequestReplenished = DateTime.UtcNow;
                }
            }
        }

        // will try to decrement available tokens, will fail if another thread has used last of burst quota
        private bool TryDecrementAvailableTokens()
        {
            var succeeded = false;

            lock (_locker) 
            {
                if (RequestsUsed < Burst)
                {
                    RequestsUsed++;
                    succeeded = true;
                } 
            }

            return succeeded;
        }
    }
}
