using Amazon.SQS;
using Amazon.SQS.Model;
using AmazonSpApiSDK.Models.Notifications;
using FikaAmazonAPI.NotificationMessages;
using FikaAmazonAPI.Parameter.Notification;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Services
{
    public class NotificationService : RequestService
    {
        public NotificationService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }

        //Read more about grant less opration
        //https://github.com/amzn/selling-partner-api-docs/blob/3fb7fcea1a828d31277a565af20cd4ef996b9dd7/guides/en-US/developer-guide/SellingPartnerApiDeveloperGuide.md#grantless-operations

        public Subscription GetSubscription(NotificationType notificationType)
        {
            CreateAuthorizedRequest(NotificationApiUrls.GetSubscription(notificationType.ToString()), RestSharp.Method.GET);
            var response = ExecuteRequest<GetSubscriptionResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        //createSubscription

        public Destination CreateDestination(CreateDestinationRequest request)
        {
            CreateAuthorizedRequest(NotificationApiUrls.CreateDestination, RestSharp.Method.POST, postJsonObj: request, isGrantless: true);
            var response = ExecuteRequest<CreateDestinationResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public List<Destination> GetDestinations()
        {
            CreateAuthorizedRequest(NotificationApiUrls.GetDestinations, RestSharp.Method.GET,isGrantless:true);
            var response = ExecuteRequest<GetDestinationsResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public Destination GetDestination(string destinationId)
        {
            CreateAuthorizedRequest(NotificationApiUrls.GetDestination(destinationId), RestSharp.Method.GET, isGrantless: true);
            var response = ExecuteRequest<GetDestinationResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public bool DeleteDestination(string destinationId)
        {
            CreateAuthorizedRequest(NotificationApiUrls.DeleteDestination(destinationId), RestSharp.Method.DELETE, isGrantless: true);
            var response = ExecuteRequest<DeleteDestinationResponse>();
            if (response != null && response.Errors != null)
                return false;
            return true;
        }


        public Subscription CreateSubscription(ParameterCreateSubscription param)
        {
            CreateAuthorizedRequest(NotificationApiUrls.CreateSubscription(param.notificationType.ToString()), RestSharp.Method.POST, postJsonObj: param);
            var response = ExecuteRequest<CreateSubscriptionResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public Subscription GetSubscriptionById(NotificationType notificationType,string subscriptionId)
        {
            CreateAuthorizedRequest(NotificationApiUrls.GetSubscriptionById(notificationType.ToString(),subscriptionId), RestSharp.Method.GET,isGrantless:true);
            var response = ExecuteRequest<GetSubscriptionByIdResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public bool DeleteSubscriptionById(NotificationType notificationType, string subscriptionId)
        {
            CreateAuthorizedRequest(NotificationApiUrls.DeleteSubscriptionById(notificationType.ToString(), subscriptionId), RestSharp.Method.DELETE, isGrantless: true);
            var response = ExecuteRequest<DeleteSubscriptionByIdResponse>();
            if (response != null && response.Errors != null)
                return false;
            return true;
        }

        public void StartReceivingNotificationMessages(ParameterMessageReceiver param, IMessageReceiver messageReceiver)
        {
            var awsAccessKeyId = param.awsAccessKeyId;
            var awsSecretAccessKey = param.awsSecretAccessKey;
            var SQS_URL = param.SQS_URL;
            var Region = param.RegionEndpoint;

            var amazonSQSClient = new AmazonSQSClient(awsAccessKeyId, awsSecretAccessKey, Region);

            ReceiveMessageRequest receiveMessageRequest = new ReceiveMessageRequest(SQS_URL);
            receiveMessageRequest.MaxNumberOfMessages = 10;


            while (true)
            {
                try
                {
                    var result = amazonSQSClient.ReceiveMessageAsync(receiveMessageRequest).Result;
                    var Messages = result.Messages;
                    if (Messages.Count > 0)
                    {
                        foreach(var msg in Messages)
                        {
                            try
                            {
                                var data = DeserializeNotification(msg);

                                messageReceiver.NewMessageRevicedTriger(data);
                                DeleteMessageFromQueue(amazonSQSClient, SQS_URL, msg.ReceiptHandle);
                            }
                            catch(Exception ex)
                            {
                                messageReceiver.ErrorCatch(ex);
                                DeleteMessageFromQueue(amazonSQSClient, SQS_URL, msg.ReceiptHandle);
                            }
                            
                        }
                    }
                }
                catch(Exception ex)
                {
                    messageReceiver.ErrorCatch(ex);
                }
            }



        }
        private void DeleteMessageFromQueue(AmazonSQSClient sqsClient,string QueueUrl, string ReceiptHandle)
        {
            var deleteMessageRequest = new DeleteMessageRequest() { QueueUrl = QueueUrl, ReceiptHandle = ReceiptHandle };
            var objDeleteMessageResponse = sqsClient.DeleteMessageAsync(deleteMessageRequest).Result;
        }
        private NotificationMessageResponce DeserializeNotification(Message message)
        {
            
            NotificationMessageResponce notification;

            using (TextReader reader = new StringReader(message.Body))
            {
                notification = JsonConvert.DeserializeObject<NotificationMessageResponce>(message.Body); ;
            }

            return notification;
        }

    }
}
