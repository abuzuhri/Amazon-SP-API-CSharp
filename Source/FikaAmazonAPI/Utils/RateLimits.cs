using System;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Utils
{
    internal struct RateLimits
    {
        internal decimal Rate { get; set; }
        internal int Burst { get; set; }
        internal DateTime LastRequestReplenished { get; set; }
        internal int RequestsSent { get; set; }

        /// <summary>
        /// Constructor for rate limits configuration object
        /// </summary>
        /// <param name="Rate">The number of permitted requests which will be added to the "Token bucket" per second</param>
        /// <param name="Burst">The maximum number of requests which can exist in the "Token bucket" at any time</param>
        internal RateLimits(decimal Rate, int Burst)
        {
            this.Rate = Rate;
            this.Burst = Burst;
            this.LastRequestReplenished = DateTime.UtcNow;
            this.RequestsSent = 0;
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
        public async Task WaitForPermittedRequest(RateLimitType rateLimitType, CancellationToken cancellationToken = default, bool debugMode = true)
        {
            if (RequestsSent < 0)
            {
                RequestsSent = 0;
            }

            int ratePeriodMs = GetRatePeriodMs();

            var nextRequestsSent = RequestsSent + 1;
            var nextRequestsSentTxt = (nextRequestsSent > Burst) ? "FULL" : nextRequestsSent.ToString();
            if (debugMode)
            {
                string output = $"[RateLimits ,{rateLimitType,15}]: {DateTime.UtcNow.ToString(),10}\t Request/Burst: {nextRequestsSentTxt}/{Burst}\t Rate: {Rate}/{ratePeriodMs}ms";
                Console.WriteLine(output);
            }

            // if bucket is currently empty, enter wait loop for replenishment
            while (RequestsSent >= Burst)
            {
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
                    LastRequestReplenished = incomingRequestTokenTime;
                    RequestsSent -= 1;
                }

                if (RequestsSent <= 0)
                {
                    RequestsSent = 0;
                    break;
                }
            }

            // now remove token from bucket for pending request
            if (RequestsSent + 1 <= Burst)
            {
                RequestsSent += 1;
            }

            // can't hurt to have this, will probably make the algorithm a little more conservative in practice
            LastRequestReplenished = DateTime.UtcNow;
        }

        internal void SetRateLimit(decimal rate)
        {
            Rate = rate;
        }
    }
}
