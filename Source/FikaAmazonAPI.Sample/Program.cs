using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FikaAmazonAPI.AmazonSpApiSDK.Api.Sellers;
using FikaAmazonAPI.AmazonSpApiSDK.Clients;
using FikaAmazonAPI;
using FikaAmazonAPI.ConstructFeed;
using FikaAmazonAPI.ConstructFeed.Messages;
using FikaAmazonAPI.Parameter;
using FikaAmazonAPI.Parameter.Notification;
using FikaAmazonAPI.Parameter.Order;
using FikaAmazonAPI.Parameter.Report;
using FikaAmazonAPI.Utils;
using static FikaAmazonAPI.ConstructFeed.BaseXML;
using static FikaAmazonAPI.Utils.Constants;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using FikaAmazonAPI.AmazonSpApiSDK.Services;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.Token.RestrictedResource;

namespace FikaAmazonAPI.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
nment.SetEnvironmentVariable("RefreshToken", "Atzr|IwEBIB_EWhQekUsF08ZtXWccm5chfM8K7t6Cw_U6G5YtEvJ2ZQmCV_r8jcr_4htXf64mBG1pXxDShTydP3vyRyTdAaXctrj5Kf1LWBVJdlOh05TPWgGbqag-GU1_IAqp0dQ4hG6jrTc30B1n7pzIX2boXyFejZprrldZWbgXmC5yEHue9_-_Qdv7CBQmeWDYeOALvx2s2ZmJqNw_q6IvIUttSeE5cbgNJ3nqxtfzlnJxAu928NQnBN_8t3RJ6r1gRDE6bDgpDOOL_uxB3fN9KAmKPfoa3eRDAPjiivuM81TgIvwYFtcUiuGWnqYhlYKs6gxpxfk");


            AmazonConnection amazonConnection = new AmazonConnection(new AmazonCredential()
            {
                AccessKey = Environment.GetEnvironmentVariable("AccessKey"),
                SecretKey = Environment.GetEnvironmentVariable("SecretKey"),
                RoleArn = Environment.GetEnvironmentVariable("RoleArn"),
                ClientId = Environment.GetEnvironmentVariable("ClientId"),
                ClientSecret = Environment.GetEnvironmentVariable("ClientSecret"),
                RefreshToken = Environment.GetEnvironmentVariable("RefreshToken"),
                MarketPlace = MarketPlace.UnitedArabEmirates

            });


            OrdersSample ordersSample = new OrdersSample(amazonConnection);

            ordersSample.GetOrders();


            Console.ReadLine();
            
        }



    }
}
