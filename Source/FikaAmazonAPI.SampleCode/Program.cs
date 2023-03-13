using FikaAmazonAPI.Parameter.ProductPricing;
using FikaAmazonAPI.ReportGeneration;
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
                IsDebugMode = true
            });
            FeedsSample feedsSample = new FeedsSample(amazonConnection);
            feedsSample.SubmitFeedDeleteAddProductMessage();

            IList<string> scopes = new List<string> { "jgjhgh" };
            var listww = scopes.Select(s => new ItemOffersRequest
            {
                HttpMethod = HttpMethodEnum.GET,
                QueryParams = new ParameterGetItemOffers
                {
                    Asin = s,
                    CustomerType = CustomerType.Consumer,
                    ItemCondition = ItemCondition.New,
                    MarketplaceId = amazonConnection.GetCurrentMarketplace.ID
                }
            }).ToList();

            var restultt = amazonConnection.ProductPricing.GetItemOffersBatch(new Parameter.ProductPricing.ParameterGetItemOffersBatchRequest
            {
                ParameterGetItemOffers = listww,
            });

            var offers = amazonConnection.ProductPricing.GetItemOffers(new Parameter.ProductPricing.ParameterGetItemOffers
            {
                Asin = "B004Z00S8U",//"B07MW2SSZD",// "B0026XRFY8",
                CustomerType = CustomerType.Consumer,
                ItemCondition = ItemCondition.New,
            });




            //B0026XRFY8

            ReportManager reportManager1 = new ReportManager(amazonConnection);
            var list = await reportManager1.GetLedgerDetailAsync(10);


            //var data2220002 = amazonConnection.Reports.CreateReportAndDownloadFile(
            //    ReportTypes.GET_LEDGER_DETAIL_VIEW_DATA, 
            //    DateTime.UtcNow.AddDays(-10), 
            //    DateTime.UtcNow, null);


            Console.ReadLine();

        }






    }
}
