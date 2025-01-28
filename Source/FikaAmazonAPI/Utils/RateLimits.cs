using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Tests")]
namespace FikaAmazonAPI.Utils
{
    internal class RateLimits
    {
        internal decimal Rate { get; set; }
        internal int Burst { get; set; }
        internal DateTime LastRequest { get; set; }
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
            this.LastRequest = DateTime.UtcNow;
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
        public async Task<RateLimits> NextRate(RateLimitType rateLimitType)
        {
            if (RequestsSent < 0)
                RequestsSent = 0;

            int ratePeriodMs = GetRatePeriodMs();

            var nextRequestsSent = RequestsSent + 1;
            var nextRequestsSentTxt = (nextRequestsSent > Burst) ? "FULL" : nextRequestsSent.ToString();
            if (AmazonCredential.DebugMode)
            {
                string output = $"[RateLimits ,{rateLimitType,15}]: {DateTime.UtcNow.ToString(),10}\t Request/Burst: {nextRequestsSentTxt}/{Burst}\t Rate: {Rate}/{ratePeriodMs}ms";
                Console.WriteLine(output);
            }

            if (RequestsSent >= Burst)
            {
                var LastRequestTime = LastRequest;
                while (true)
                {
                    LastRequestTime = LastRequestTime.AddMilliseconds(ratePeriodMs);
                    if (LastRequestTime > DateTime.UtcNow)
                        break;
                    else
                        RequestsSent -= 1;
                    if (RequestsSent <= 0)
                    {
                        RequestsSent = 0;
                        break;
                    }
                }
            }

            if (RequestsSent >= Burst)
            {
                LastRequest = LastRequest.AddMilliseconds(ratePeriodMs);
                var TempLastRequest = LastRequest;
                while (TempLastRequest >= DateTime.UtcNow) //.AddMilliseconds(-100)
                    await Task.Delay(100);

            }

            if (RequestsSent + 1 <= Burst)
                RequestsSent += 1;
            LastRequest = DateTime.UtcNow;

            return this;
        }

        internal void SetRateLimit(decimal rate)
        {
            Rate = rate;

        }

        internal Task Delay()
        {
            return Task.Delay(GetRatePeriodMs());
        }
    }
}