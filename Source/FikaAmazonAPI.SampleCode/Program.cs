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



            //var list = amazonConnection.Seller.GetMarketplaceParticipations();


            FeedsSample feedsSample = new FeedsSample(amazonConnection);
            feedsSample.SubmitFeedPRICING_JSONAsync("B09H73T814.259", 112.0M, 53.51M, 112.20M).GetAwaiter().GetResult();


            Console.ReadLine();

        }






    }
}
