using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AmazonSpApiSDK.Api.Sellers;
using AmazonSpApiSDK.Clients;
using FikaAmazonAPI;
using FikaAmazonAPI.Parameter;
using FikaAmazonAPI.Parameter.Notification;
using FikaAmazonAPI.Parameter.Order;
using FikaAmazonAPI.Parameter.Report;
using FikaAmazonAPI.Utils;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {



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

            var SQL_URL = "https://sqs.us-east-2.amazonaws.com/239917024027/ICANL_SQS";
            ParameterMessageReceiver param = new ParameterMessageReceiver(Environment.GetEnvironmentVariable("AccessKey"), Environment.GetEnvironmentVariable("SecretKey"), SQL_URL, Amazon.RegionEndpoint.USEast2);

            CustomMessageReceiver messageReceiver = new CustomMessageReceiver();


            amazonConnection.Notification.StartReceivingNotificationMessages(param, messageReceiver);

            Console.ReadLine();
            
        }
    }
}
