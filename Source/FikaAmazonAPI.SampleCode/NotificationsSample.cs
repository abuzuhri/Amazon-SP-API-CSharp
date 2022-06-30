using FikaAmazonAPI.NotificationMessages;
using FikaAmazonAPI.Parameter.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.SampleCode
{
    public class NotificationsSample
    {
        AmazonConnection amazonConnection;
        public NotificationsSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }


        public void GetSubscription()
        {
            var data = amazonConnection.Notification.GetSubscription(NotificationType.ANY_OFFER_CHANGED);
        }

        public void GetDestinations()
        {
            var data = amazonConnection.Notification.GetDestinations();
        }


        public void DeleteDestination()
        {
            var data = amazonConnection.Notification.DeleteDestination("99999999-999-4699-999-9999999999999");
        }


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


        public void CreateSubscription()
        {
            //SQS
            var result = amazonConnection.Notification.CreateSubscription(
                new ParameterCreateSubscription()
                {
                    destinationId = "xxxxxxxxxxxxxxx", // take this from CreateDestination or GetDestinations response 
                    notificationType = NotificationType.ANY_OFFER_CHANGED, // or B2B_ANY_OFFER_CHANGED for B2B prices
                    payloadVersion = "1.0"
                });
        }


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
