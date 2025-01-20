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


            ReportManagerSample reportManagerSample = new ReportManagerSample(amazonConnection);
            reportManagerSample.CallReport();
            //var error = amazonConnection.Reports.CreateReportAndDownloadFile(Utils.Constants.ReportTypes.GET_STRANDED_INVENTORY_UI_DATA);
            //var dddd = amazonConnection.Reports.CreateReportAndDownloadFile(Utils.Constants.ReportTypes.GET_FBA_MYI_ALL_INVENTORY_DATA);
            //var dddd = amazonConnection.Reports.CreateReportAndDownloadFile(Utils.Constants.ReportTypes.GET_FBA_MYI_UNSUPPRESSED_INVENTORY_DATA);
            //ReportManager reportManager = new ReportManager(amazonConnection);

            //var dddddd = reportManager.GetAFNInventoryQtyAsync().ConfigureAwait(false).GetAwaiter().GetResult();

            Console.ReadLine();

        }






    }
}
