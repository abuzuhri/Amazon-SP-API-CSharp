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

            var x = amazonConnection.CatalogItem.GetCatalogItem202204(new FikaAmazonAPI.Parameter.CatalogItems.ParameterGetCatalogItem()
            {
                ASIN = "B01I3JW7PK",
                includedData = new List<IncludedData> {
               IncludedData.summaries,
               IncludedData.identifiers,
               IncludedData.summaries,
               IncludedData.productTypes,
               IncludedData.dimensions,
               IncludedData.images,
               IncludedData.relationships,
               IncludedData.attributes//,
               
               }
            });


            Console.ReadLine();

        }






    }
}
