using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace FikaAmazonAPI.SampleCode;

public class SerilogLoggingExamples
{
    private AmazonConnection _amazonConnection;
    
    public SerilogLoggingExamples(IConfigurationRoot config)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
        var factory = LoggerFactory.Create(c => c.AddSerilog());
        
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