using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Configuration;
using static FikaAmazonAPI.Utils.Constants;

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


            AmazonConnection amazonConnection = new AmazonConnection(new AmazonCredential()
            {
                AccessKey = config.GetSection("FikaAmazonAPI:AccessKey").Value,
                SecretKey = config.GetSection("FikaAmazonAPI:SecretKey").Value,
                RoleArn = config.GetSection("FikaAmazonAPI:RoleArn").Value,
                ClientId = config.GetSection("FikaAmazonAPI:ClientId").Value,
                ClientSecret = config.GetSection("FikaAmazonAPI:ClientSecret").Value,
                RefreshToken = config.GetSection("FikaAmazonAPI:RefreshToken").Value,
                MarketPlaceID = config.GetSection("FikaAmazonAPI:MarketPlaceID").Value,
                SellerID = config.GetSection("FikaAmazonAPI:SellerId").Value,
                IsDebugMode = true
            });


            //FeedsSample feedsSample = new FeedsSample(amazonConnection);
            //feedsSample.SubmitFeedPRICING(69.3F, "8809606851663");

            var feeds = amazonConnection.Feed.GetFeeds(new Parameter.Feed.ParameterGetFeed()
            {
                processingStatuses = ProcessingStatuses.IN_QUEUE,
                pageSize = 100,
                feedTypes = new List<FeedType> { FeedType.POST_PRODUCT_PRICING_DATA },
                marketplaceIds = new List<string> { MarketPlace.UnitedArabEmirates.ID }
            });

            foreach (var feed in feeds)
            {
                Console.WriteLine("FeedId " + feed.FeedId);
                //var result = amazonConnection.Feed.CancelFeed(feed.FeedId);
            }



            Console.ReadLine();

        }






    }
}
