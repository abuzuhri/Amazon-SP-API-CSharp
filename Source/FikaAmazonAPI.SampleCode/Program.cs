using FikaAmazonAPI.ConstructFeed;
using FikaAmazonAPI.ConstructFeed.Messages;
using FikaAmazonAPI.Parameter.Finance;
using FikaAmazonAPI.Parameter.ListingItem;
using FikaAmazonAPI.Parameter.ListingsItems;
using FikaAmazonAPI.ReportGeneration;
using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Configuration;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.ListingsItems.ListingsItemPutRequest;
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
                MarketPlace = MarketPlace.GetMarketPlaceByID(config.GetSection("FikaAmazonAPI:MarketPlaceID").Value),
                IsDebugMode = true
            });

            ReportManager reportManager1 = new ReportManager(amazonConnection);
           var list=await reportManager1.GetLedgerDetailAsync(10);


            //var data2220002 = amazonConnection.Reports.CreateReportAndDownloadFile(
            //    ReportTypes.GET_LEDGER_DETAIL_VIEW_DATA, 
            //    DateTime.UtcNow.AddDays(-10), 
            //    DateTime.UtcNow, null);


            Console.ReadLine();

        }






    }
}
