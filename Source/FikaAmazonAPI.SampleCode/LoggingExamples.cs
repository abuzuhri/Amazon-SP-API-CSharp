using FikaAmazonAPI.Parameter.Order;
using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FikaAmazonAPI.SampleCode;

public class LoggingExamples
{
    private AmazonConnection _amazonConnection;
    public LoggingExamples(IConfigurationRoot config)
    {
        var factory = LoggerFactory.Create(builder => builder.AddConsole());
        
        _amazonConnection = new AmazonConnection(new AmazonCredential()
        {
            //AccessKey = config.GetSection("FikaAmazonAPI:AccessKey").Value,
            //SecretKey = config.GetSection("FikaAmazonAPI:SecretKey").Value,
            //RoleArn = config.GetSection("FikaAmazonAPI:RoleArn").Value,
            ClientId = config.GetSection("FikaAmazonAPI:ClientId").Value,
            ClientSecret = config.GetSection("FikaAmazonAPI:ClientSecret").Value,
            RefreshToken = config.GetSection("FikaAmazonAPI:RefreshToken").Value,
            MarketPlaceID = config.GetSection("FikaAmazonAPI:MarketPlaceID").Value,
            SellerID = config.GetSection("FikaAmazonAPI:SellerId").Value,
            IsDebugMode = true,
            Environment = Constants.Environments.Sandbox
        }, loggerFactory: factory);
    }
    
    public async Task ConsoleLoggerExample()
    {
        var listingItemExample = new ListingsItemsSample(_amazonConnection);
        await listingItemExample.SetListingsItemAttribute("test");
    }
}