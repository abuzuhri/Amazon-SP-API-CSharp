using FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound;
using FikaAmazonAPI.Utils;
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
            await feedsSample.SubmitFeedDELETE_JSONAsync("B07HMBFZCZ .2");


            var aa=amazonConnection.Seller.GetMarketplaceParticipations();

            var plan = amazonConnection.FulFillmentInboundv20240320.ListInboundPlans(new Parameter.FulFillmentInbound.v20240320.ParameterListInboundPlans
            {
                Status = AmazonSpApiSDK.Models.FulfillmentInboundv20240320.InboundPlanStatus.ACTIVE
            });


            //var list = amazonConnection.Seller.GetMarketplaceParticipations();

            var list= amazonConnection.FulFillmentInbound.GetShipments(new Parameter.FulFillmentInbound.ParameterGetShipments()
            {
                MarketplaceId = MarketPlace.UnitedArabEmirates.ID,
                ShipmentStatusList = new List<ShipmentStatus> { ShipmentStatus.WORKING, ShipmentStatus.SHIPPED, ShipmentStatus.RECEIVING }
            });


           // var itemsList=amazonConnection.FulFillmentInbound.GetShipmentItemsByShipmentId("FBA15KBCBMXC");



            //FeedsSample feedsSample = new FeedsSample(amazonConnection);
            //feedsSample.SubmitFeedPRICING_JSONAsync("B09H73T814.259", 112.0M, 53.51M, 112.20M).GetAwaiter().GetResult();


            Console.ReadLine();

        }






    }
}
