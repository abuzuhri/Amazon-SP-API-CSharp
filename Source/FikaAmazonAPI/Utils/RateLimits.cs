using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FikaAmazonAPI.Utils
{
    internal class RateLimits
    {
        internal decimal Rate { get; set; }
        internal int Burst { get; set; }
        internal DateTime LastRequest { get; set; }
        internal int RequestsSent { get; set; }

        internal RateLimits(decimal Rate, int Burst)
        {
            this.Rate = Rate;
            this.Burst = Burst;
            this.LastRequest = DateTime.UtcNow;
            this.RequestsSent = 0;
        }
        private int GetRatePeriodMs() { return (int)(((1 / Rate) * 1000)/1); }
        public RateLimits NextRate(RateLimitType rateLimitType)
        {
            if (RequestsSent < 0)
                RequestsSent = 0;


            int ratePeriodMs = GetRatePeriodMs();

//#if DEBUG
            var nextRequestsSent = RequestsSent + 1;
            var nextRequestsSentTxt = (nextRequestsSent > Burst) ? "FULL" : nextRequestsSent.ToString();
            string output = $"[RateLimits ,{rateLimitType,10}]: {DateTime.UtcNow.ToString(),10}\t Request/Burst: {nextRequestsSentTxt}/{Burst}\t Rate: {Rate}/{ratePeriodMs}ms";
            Console.WriteLine(output);
//#endif

            if (RequestsSent >= Burst)
            {
                while (true)
                {
                    LastRequest = LastRequest.AddMilliseconds(ratePeriodMs);
                    if (LastRequest > DateTime.UtcNow)
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
                while (LastRequest >= DateTime.UtcNow) //.AddMilliseconds(-100)
                    Thread.Sleep(100);
            }



            if (RequestsSent + 1 <= Burst)
                RequestsSent += 1;
            LastRequest = DateTime.UtcNow;

            return this;
        }

        internal void SetRateLimit(decimal rate)
        {
            Rate=rate;
        }

        internal void Delay()
        {
            Thread.Sleep(GetRatePeriodMs());
        }
    }
}
