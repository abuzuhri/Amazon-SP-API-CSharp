using Amazon.SQS;
using Amazon.SQS.Model;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Notifications;
using FikaAmazonAPI.NotificationMessages;
using FikaAmazonAPI.Parameter.Notification;
using FikaAmazonAPI.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.Token.CacheTokenData;
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

        public Subscription GetSubscription(NotificationType notificationType) =>
            GetSubscriptionAsync(notificationType).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Subscription> GetSubscriptionAsync(NotificationType notificationType)
        {
            await CreateAuthorizedRequestAsync(NotificationApiUrls.GetSubscription(notificationType.ToString()), RestSharp.Method.GET);
            var response = await ExecuteRequestAsync<GetSubscriptionResponse>(RateLimitType.Notifications_GetSubscription);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        //createSubscription

        public Destination CreateDestination(CreateDestinationRequest request) =>
            CreateDestinationAsync(request).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Destination> CreateDestinationAsync(CreateDestinationRequest request)
        {
            await CreateAuthorizedRequestAsync(NotificationApiUrls.CreateDestination, RestSharp.Method.POST, postJsonObj: request, tokenDataType: TokenDataType.Grantless);
            var response = await ExecuteRequestAsync<CreateDestinationResponse>(RateLimitType.Notifications_CreateDestination);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public List<Destination> GetDestinations() =>
            GetDestinationsAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<List<Destination>> GetDestinationsAsync()
        {
            await CreateAuthorizedRequestAsync(NotificationApiUrls.GetDestinations, RestSharp.Method.GET, tokenDataType: TokenDataType.Grantless);
            var response = await ExecuteRequestAsync<GetDestinationsResponse>(RateLimitType.Notifications_GetDestinations);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public Destination GetDestination(string destinationId) =>
            GetDestinationAsync(destinationId).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Destination> GetDestinationAsync(string destinationId)
        {
            await CreateAuthorizedRequestAsync(NotificationApiUrls.GetDestination(destinationId), RestSharp.Method.GET, tokenDataType: TokenDataType.Grantless);
            var response = await ExecuteRequestAsync<GetDestinationResponse>(RateLimitType.Notifications_GetDestination);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public bool DeleteDestination(string destinationId) =>
            DeleteDestinationAsync(destinationId).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<bool> DeleteDestinationAsync(string destinationId)
        {
            await CreateAuthorizedRequestAsync(NotificationApiUrls.DeleteDestination(destinationId), RestSharp.Method.DELETE, tokenDataType: TokenDataType.Grantless);
            var response = await ExecuteRequestAsync<DeleteDestinationResponse>(RateLimitType.Notifications_DeleteDestination);
            if (response != null && response.Errors != null)
                return false;
            return true;
        }


        public Subscription CreateSubscription(ParameterCreateSubscription param) =>
            CreateSubscriptionAsync(param).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Subscription> CreateSubscriptionAsync(ParameterCreateSubscription param)
        {
            await CreateAuthorizedRequestAsync(NotificationApiUrls.CreateSubscription(param.notificationType.ToString()), RestSharp.Method.POST, postJsonObj: param);
            var response = await ExecuteRequestAsync<CreateSubscriptionResponse>(RateLimitType.Notifications_CreateSubscription);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public Subscription GetSubscriptionById(NotificationType notificationType, string subscriptionId) =>
            GetSubscriptionByIdAsync(notificationType, subscriptionId).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Subscription> GetSubscriptionByIdAsync(NotificationType notificationType, string subscriptionId)
        {
            await CreateAuthorizedRequestAsync(NotificationApiUrls.GetSubscriptionById(notificationType.ToString(), subscriptionId), RestSharp.Method.GET, tokenDataType: TokenDataType.Grantless);
            var response = await ExecuteRequestAsync<GetSubscriptionByIdResponse>(RateLimitType.Notifications_GetSubscriptionById);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public bool DeleteSubscriptionById(NotificationType notificationType, string subscriptionId) =>
            DeleteSubscriptionByIdAsync(notificationType, subscriptionId).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<bool> DeleteSubscriptionByIdAsync(NotificationType notificationType, string subscriptionId)
        {
            await CreateAuthorizedRequestAsync(NotificationApiUrls.DeleteSubscriptionById(notificationType.ToString(), subscriptionId), RestSharp.Method.DELETE, tokenDataType: TokenDataType.Grantless);
            var response = await ExecuteRequestAsync<DeleteSubscriptionByIdResponse>(RateLimitType.Notifications_DeleteSubscriptionById);
            if (response != null && response.Errors != null)
                return false;
            return true;
        }

        public void StartReceivingNotificationMessages(ParameterMessageReceiver param, IMessageReceiver messageReceiver) =>
            StartReceivingNotificationMessagesAsync(param, messageReceiver).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task StartReceivingNotificationMessagesAsync(ParameterMessageReceiver param, IMessageReceiver messageReceiver)
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
                    var result = await amazonSQSClient.ReceiveMessageAsync(receiveMessageRequest);
                    var Messages = result.Messages;
                    if (Messages.Count > 0)
                    {
                        foreach (var msg in Messages)
                        {
                            try
                            {
                                var data = DeserializeNotification(msg);

                                messageReceiver.NewMessageRevicedTriger(data);
                                await DeleteMessageFromQueueAsync(amazonSQSClient, SQS_URL, msg.ReceiptHandle);
                            }
                            catch (Exception ex)
                            {
                                messageReceiver.ErrorCatch(ex);
                                await DeleteMessageFromQueueAsync(amazonSQSClient, SQS_URL, msg.ReceiptHandle);
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    messageReceiver.ErrorCatch(ex);
                }
            }



        }
        private async Task DeleteMessageFromQueueAsync(AmazonSQSClient sqsClient, string QueueUrl, string ReceiptHandle)
        {
            var deleteMessageRequest = new DeleteMessageRequest() { QueueUrl = QueueUrl, ReceiptHandle = ReceiptHandle };
            _ = await sqsClient.DeleteMessageAsync(deleteMessageRequest);
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
