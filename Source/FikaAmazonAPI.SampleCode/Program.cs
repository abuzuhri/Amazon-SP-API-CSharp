using FikaAmazonAPI.ReportGeneration;
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
                //AccessKey = config.GetSection("FikaAmazonAPI:AccessKey").Value,
                //SecretKey = config.GetSection("FikaAmazonAPI:SecretKey").Value,
                //RoleArn = config.GetSection("FikaAmazonAPI:RoleArn").Value,
                ClientId = config.GetSection("FikaAmazonAPI:ClientId").Value,
                ClientSecret = config.GetSection("FikaAmazonAPI:ClientSecret").Value,
                RefreshToken = config.GetSection("FikaAmazonAPI:RefreshToken").Value,
                MarketPlaceID = config.GetSection("FikaAmazonAPI:MarketPlaceID").Value,
                SellerID = config.GetSection("FikaAmazonAPI:SellerId").Value,
                IsDebugMode = true
            });


            ReportManager reportManager = new ReportManager(amazonConnection);
            //var datadddd = reportManager.GetFbaEstimateFeeData(DateTime.UtcNow.AddDays(-30), DateTime.UtcNow);
            var dataddd222d = reportManager.GetReferralFeeReportData(DateTime.UtcNow.AddDays(-30), DateTime.UtcNow);



            var file22227 = amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_REFERRAL_FEE_PREVIEW_REPORT, DateTime.UtcNow.AddDays(-3), DateTime.UtcNow);


            var file3337 = amazonConnection.Reports.GetReports(new Parameter.Report.ParameterReportList()
            {
                reportTypes = new ReportTypes[] { ReportTypes.GET_REFERRAL_FEE_PREVIEW_REPORT },
            });

            var sss = amazonConnection.Reports.GetReport("784871019793");


            var file = amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_FBA_ESTIMATED_FBA_FEES_TXT_DATA, DateTime.UtcNow.AddDays(-30), DateTime.UtcNow);






            //var feedTypes = new ParameterGetFeed { feedTypes = { FeedType.POST_PRODUCT_PRICING_DATA }, processingStatuses = ProcessingStatuses.IN_PROGRESS };

            //var feeds = amazonConnection.Feed.GetFeeds(feedTypes);


            //FeedsSample feedsSample = new FeedsSample(amazonConnection);
            //feedsSample.SubmitFeedPRICING(69.3F, "8809606851663");

            var feeds = amazonConnection.Feed.GetFeeds(new Parameter.Feed.ParameterGetFeed()
            {
                processingStatuses = ProcessingStatuses.IN_PROGRESS,//ProcessingStatuses.IN_QUEUE,
                pageSize = 100,
                feedTypes = new List<FeedType> { FeedType.POST_PRODUCT_PRICING_DATA },
                marketplaceIds = new List<string> { MarketPlace.UnitedArabEmirates.ID }
            });

            var feeds2 = amazonConnection.Feed.GetFeeds(new Parameter.Feed.ParameterGetFeed()
            {
                processingStatuses = ProcessingStatuses.IN_PROGRESS,//ProcessingStatuses.IN_PROGRESS,
                pageSize = 100,
                feedTypes = new List<FeedType> { FeedType.POST_INVENTORY_AVAILABILITY_DATA },
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
