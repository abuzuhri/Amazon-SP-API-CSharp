using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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

            var factory = LoggerFactory.Create(builder => builder.AddConsole());

            AmazonConnection amazonConnection = new AmazonConnection(new AmazonCredential()
            {
                ClientId = config.GetSection("FikaAmazonAPI:ClientId").Value,
                ClientSecret = config.GetSection("FikaAmazonAPI:ClientSecret").Value,
                RefreshToken = config.GetSection("FikaAmazonAPI:RefreshToken").Value,
                MarketPlaceID = config.GetSection("FikaAmazonAPI:MarketPlaceID").Value,
                SellerID = config.GetSection("FikaAmazonAPI:SellerId").Value,
                IsDebugMode = true
            }, loggerFactory: factory);

            FeedsSample feedsSample = new FeedsSample(amazonConnection);
            // _ = feedsSample.SubmitFeedPRICING_JSONAsync("B087YHP3HQ.151", 131.77M, 67.70M, 131.77M);


            Console.ReadLine();

        }






    }
}
