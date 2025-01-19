using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class RateLimitsTests
    {
        [Test]
        [TestCase(0.1, 1, 3, 20000)]
        [TestCase(0.5, 1, 3, 4000)]
        [TestCase(1, 5, 10, 5000)]
        public async Task WaitForPermittedRequest_WaitsExpectedLengthOfTime(decimal rate, int burst, int numberRequests, int expectedWaitMilliseconds)
        {
            // Arrange
            var rateLimit = new RateLimits(rate, burst, RateLimitType.UNSET);

            var stopwatch = new Stopwatch();
            var cancellationToken = new CancellationToken();

            // Act
            stopwatch.Start();
            for (int i = 0; i < numberRequests; i++)
            {
                await rateLimit.WaitForPermittedRequest(cancellationToken, debugMode: true);
            }
            stopwatch.Stop();

            // Assert
            Assert.That(stopwatch.ElapsedMilliseconds, Is.GreaterThanOrEqualTo(expectedWaitMilliseconds));
            // allow a second for additional time taken by the test to run
            Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThanOrEqualTo(expectedWaitMilliseconds + 1000));
        }
    }
}
