using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Tests")]
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

            // when requests used more than zero, replenish according to time elapsed
            DecrementRequestsUsed(debugMode);

            var nextRequestsSent = RequestsUsed + 1;
            var nextRequestsSentTxt = (nextRequestsSent > Burst) ? "FULL" : nextRequestsSent.ToString();

            WriteDebug($"[RateLimits ,{this.RateLimitType,15}]: {DateTime.UtcNow.ToString(),10}\t Request/Burst: {nextRequestsSentTxt}/{Burst}\t Rate: {Rate}/{ratePeriodMs}ms", debugMode);

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
                        WriteDebug($"Next token expected at {incomingRequestTokenTime}, waiting", debugMode);
                        await Task.Delay(100);
                        continue;
                    }
                    else
                    {
                        // replenish token
                        DecrementRequestsUsed(debugMode);
                    }

                    if (RequestsUsed <= 0)
                    {
                        RequestsUsed = 0;
                        break;
                    }
                }

                // now remove token from bucket for pending request
                requestIsPermitted = TryIncrementRequestsUsed(debugMode);
            }
        }

        internal void SetRateLimit(decimal rate)
        {
            Rate = rate;
        }

        // increments available tokens, unless another thread has already incremented them.
        private void DecrementRequestsUsed(bool isDebug)
        {
            WriteDebug($"Attempting to increment tokens", isDebug);
            lock (_locker)
            {
                var ratePeriodMilliseconds = GetRatePeriodMs();
                var requestsToReplenish = ratePeriodMilliseconds == 0 ? 0 : (int)((DateTime.UtcNow - LastRequestReplenished).TotalMilliseconds / ratePeriodMilliseconds);
                WriteDebug($"{requestsToReplenish} tokens to replenish since {LastRequestReplenished}", isDebug);
                if (requestsToReplenish == 0 || RequestsUsed == 0)
                {
                    return;
                }

                RequestsUsed = Math.Max(RequestsUsed - requestsToReplenish, 0);
                LastRequestReplenished = DateTime.UtcNow;

                WriteDebug($"Incremented tokens by {requestsToReplenish}", isDebug);
            }
        }

        // will try to decrement available tokens, will fail if another thread has used last of burst quota
        private bool TryIncrementRequestsUsed(bool isDebug)
        {
            var succeeded = false;

            lock (_locker) 
            {
                if (RequestsUsed < Burst)
                {
                    WriteDebug($"Token is available for use, requests used = {RequestsUsed}", isDebug);
                    RequestsUsed++;
                    succeeded = true;
                }
                else
                {
                    WriteDebug($"Caller will need to wait for token, {Burst} requests used", isDebug);
                }
            }

            return succeeded;
        }

        private void WriteDebug(string message, bool isDebug)
        {
            if (isDebug)
            {
                Console.WriteLine(message);
            }
        }
    }
}
