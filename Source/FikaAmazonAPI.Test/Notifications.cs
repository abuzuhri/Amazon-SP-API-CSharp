using FikaAmazonAPI.NotificationMessages;
using FikaAmazonAPI.Parameter.Notification;
using FikaAmazonAPI.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Test
{
    [TestClass]
    public class Notifications
    {
        AmazonConnection amazonConnection;
        public Notifications()
        {
            amazonConnection = new AmazonConnection(new AmazonCredential()
            {
                AccessKey = Environment.GetEnvironmentVariable("AccessKey"),
                SecretKey = Environment.GetEnvironmentVariable("SecretKey"),
                RoleArn = Environment.GetEnvironmentVariable("RoleArn"),
                ClientId = Environment.GetEnvironmentVariable("ClientId"),
                ClientSecret = Environment.GetEnvironmentVariable("ClientSecret"),
                RefreshToken = Environment.GetEnvironmentVariable("RefreshToken"),
                MarketPlace = MarketPlace.UnitedArabEmirates

            });

        }

        [TestMethod]
        public void GetSubscription()
        {
            var data = amazonConnection.Notification.GetSubscription(NotificationType.ANY_OFFER_CHANGED);
        }
        [TestMethod]
        public void GetDestinations()
        {
            var data = amazonConnection.Notification.GetDestinations();
        }

        [TestMethod]
        public void DeleteDestination()
        {
            var data = amazonConnection.Notification.DeleteDestination("99999999-999-4699-999-9999999999999");
        }

        [TestMethod]
        public void CreateDestination()
        {
            //EventBridge
            var data = amazonConnection.Notification.CreateDestination(new AmazonSpApiSDK.Models.Notifications.CreateDestinationRequest()
            {
                Name = "CompanyName",
                ResourceSpecification = new AmazonSpApiSDK.Models.Notifications.DestinationResourceSpecification()
                {
                    EventBridge = new AmazonSpApiSDK.Models.Notifications.EventBridgeResourceSpecification("us-east-2", "999999999")
                }
            });

            //SQS
            var dataSqs = amazonConnection.Notification.CreateDestination(new AmazonSpApiSDK.Models.Notifications.CreateDestinationRequest()
            {
                Name = "CompanyName_AE",
                ResourceSpecification = new AmazonSpApiSDK.Models.Notifications.DestinationResourceSpecification
                {
                    Sqs = new AmazonSpApiSDK.Models.Notifications.SqsResource("arn:aws:sqs:us-east-2:9999999999999:NAME")
                }
            });

        }

        [TestMethod]
        public void StartReceivingNotificationMessages()
        {
            var SQL_URL = "https://sqs.us-east-2.amazonaws.com/239917024027/ICANL_SQS";
            ParameterMessageReceiver param = new ParameterMessageReceiver(Environment.GetEnvironmentVariable("AccessKey"), Environment.GetEnvironmentVariable("SecretKey"), SQL_URL, Amazon.RegionEndpoint.USEast2);

            CustomMessageReceiver messageReceiver = new CustomMessageReceiver();


            amazonConnection.Notification.StartReceivingNotificationMessages(param, messageReceiver);
        }
        public class CustomMessageReceiver : IMessageReceiver
        {

            public void ErrorCatch(Exception ex)
            {
                //Your code here
            }

            public void NewMessageRevicedTriger(NotificationMessageResponce message)
            {
                //Your Code here
            }
        }

    }
}
