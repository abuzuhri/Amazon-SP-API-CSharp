using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.Utils
{
    internal static class RateLimitsDefinitions
    {
        internal static readonly Dictionary<RateLimitType, RateLimits> RateLimitsTime = new Dictionary<RateLimitType, RateLimits>()
        {
            { RateLimitType.Order,           new RateLimits(0.0055M, 20) },
        };
    }
}
