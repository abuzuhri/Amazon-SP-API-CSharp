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

        public RateLimits NextRate()
        {
            if (RequestsSent < 0)
                RequestsSent = 0;

            if (RequestsSent >= Burst)
            {
                int sleepTime = (int)(1 / Rate);
                LastRequest = LastRequest.AddMilliseconds(sleepTime);
                while (LastRequest >= DateTime.UtcNow)
                    Thread.Sleep(100);
            }

            if (RequestsSent + 1 <= Burst)
                RequestsSent += 1;
            LastRequest = DateTime.UtcNow;

            return this;
        }
    }
}
