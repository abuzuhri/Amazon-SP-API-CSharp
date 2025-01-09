using FikaAmazonAPI.AmazonSpApiSDK.Models.FbaSmallandLight;
using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Configuration;

namespace FikaAmazonAPI.SampleCode
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<Program>()
            .Build();

            var connectionFactory = new AmazonMultithreadedConnectionFactory(
               ClientId: config.GetSection("FikaAmazonAPI:ClientId").Value,
               ClientSecret: config.GetSection("FikaAmazonAPI:ClientSecret").Value,
               RefreshToken: config.GetSection("FikaAmazonAPI:RefreshToken").Value,
               rateLimitingHandler: new RateLimitingHandler());

            var tasks = new[] { 1..80 }.Select(x =>
            Task.Run(() =>
            {
                var amazonConnection = connectionFactory.RequestScopedConnection(
                    marketPlaceId: config.GetSection("FikaAmazonAPI:MarketPlaceID").Value,
                    sellerId: config.GetSection("FikaAmazonAPI:SellerId").Value,
                    credentialConfiguration: cred => 
                    { 
                        cred.IsActiveLimitRate = true;
                        cred.IsDebugMode = true;
                    });

                ReportManagerSample reportManagerSample = new ReportManagerSample(amazonConnection);
                reportManagerSample.CallReport();
            }));

            await Task.WhenAll(tasks);
            
            //var loggingExamples = new SerilogLoggingExamples(config);
            //await loggingExamples.ConsoleLoggerExample();

            Console.ReadLine();

        }






    }
}
