using FikaAmazonAPI.NotificationMessages;
using FikaAmazonAPI.Parameter.Notification;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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


        public async Task StartReceivingNotificationMessagesAsync(CancellationToken cancellationToken)
        {
            // Prevent unobserved task exceptions from crashing the process.
            // The library fires off ProcessAnyOfferChangedMessage without await,
            // so any exception in that path becomes an unobserved task exception.
            TaskScheduler.UnobservedTaskException += (sender, e) =>
            {
                Console.WriteLine($"Unobserved task exception caught: {e.Exception?.Message}");
                e.SetObserved();
            };

            var SQS_URL = Environment.GetEnvironmentVariable("SQS_URL");
            var param = new ParameterMessageReceiver(
                Environment.GetEnvironmentVariable("AccessKey"),
                Environment.GetEnvironmentVariable("SecretKey"),
                SQS_URL,
                Amazon.RegionEndpoint.USEast2,
                WaitTimeSeconds: 20); // Enable SQS long polling to reduce empty receives and cost

            var messageReceiver = new CustomMessageReceiver();

            // Wrap in a restart loop so the listener recovers from any fatal error
            // (e.g. network drop, SQS client disposed, transient AWS failures)
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    await amazonConnection.Notification.StartReceivingNotificationMessagesAsync(
                        param, messageReceiver, cancellationToken: cancellationToken);
                }
                catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                {
                    // Graceful shutdown requested
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Notification listener crashed, restarting in 10s: {ex.Message}");
                    try
                    {
                        await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                }
            }
        }
        public class CustomMessageReceiver : IMessageReceiver
        {
            // Track processed notification IDs to handle SQS duplicate delivery.
            // Use a queue to cap memory — keep only the most recent IDs.
            private readonly ConcurrentDictionary<string, byte> _processedNotificationIds = new();
            private readonly ConcurrentQueue<string> _idQueue = new();
            private const int MaxTrackedIds = 10_000;

            public void ErrorCatch(Exception ex)
            {
                Console.WriteLine($"Notification error: {ex.Message}");
            }

            public void NewMessageRevicedTriger(NotificationMessageResponce message)
            {
                // Deduplicate: SQS standard queues may deliver the same message more than once
                var notificationId = message?.NotificationMetadata?.NotificationId;
                if (notificationId != null && !_processedNotificationIds.TryAdd(notificationId, 0))
                    return;

                // Cap the dedup cache so it doesn't grow forever
                if (notificationId != null)
                {
                    _idQueue.Enqueue(notificationId);
                    while (_idQueue.Count > MaxTrackedIds && _idQueue.TryDequeue(out var oldId))
                        _processedNotificationIds.TryRemove(oldId, out _);
                }

                //Your Code here
            }
        }
    }
}
