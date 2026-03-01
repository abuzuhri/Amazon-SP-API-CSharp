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

        /// <summary>
        /// End-to-end SQS notification setup following the documented workflow:
        /// https://developer-docs.amazon.com/sp-api/docs/set-up-notifications-with-amazon-sqs
        ///
        /// Step 1: Grant SP-API permission to write to your SQS queue (done in AWS Console).
        /// Step 2: (Optional) Grant SP-API access to your SSE key via AWS KMS.
        /// Step 3: Create a destination using your SQS ARN.
        /// Step 4: Create a subscription for the desired notification type.
        /// </summary>
        public void SetUpSqsNotifications()
        {
            // Step 3: Create a destination (grantless operation — no seller authorization needed)
            var destination = amazonConnection.Notification.CreateDestination(
                new AmazonSpApiSDK.Models.Notifications.CreateDestinationRequest()
                {
                    Name = "CompanyName_SQS",
                    ResourceSpecification = new AmazonSpApiSDK.Models.Notifications.DestinationResourceSpecification
                    {
                        Sqs = new AmazonSpApiSDK.Models.Notifications.SqsResource("arn:aws:sqs:us-east-2:9999999999999:NAME")
                    }
                });

            if (destination == null)
            {
                Console.WriteLine("Failed to create destination.");
                return;
            }

            Console.WriteLine($"Destination created: {destination.DestinationId}");

            // Step 4: Create a subscription using the destinationId from Step 3.
            //
            // processingDirective is optional and only supported for two notification types:
            //
            // (A) ANY_OFFER_CHANGED — supports:
            //     - MarketplaceIds: limit notifications to specific marketplaces
            //       (useful when you sell in many marketplaces but only track pricing in a few)
            //     - AggregationTimePeriod: FiveMinutes or TenMinutes
            //       (useful for high-volume catalogs to reduce notification flood)
            //
            // (B) ORDER_CHANGE — supports:
            //     - OrderChangeTypes: "BuyerRequestedChange", "OrderStatusChange"
            //       (useful when you only need cancellation requests, not every status update)
            //     - AggregationTimePeriod: FiveMinutes or TenMinutes
            //     - NOTE: MarketplaceIds is NOT supported for ORDER_CHANGE
            //
            // Using processingDirective with any other notification type returns HTTP 400.

            // Example A: ANY_OFFER_CHANGED with marketplace filter + aggregation
            var subscription = amazonConnection.Notification.CreateSubscription(
                new ParameterCreateSubscription()
                {
                    destinationId = destination.DestinationId,
                    notificationType = NotificationType.ANY_OFFER_CHANGED,
                    payloadVersion = "1.0",
                    processingDirective = new AmazonSpApiSDK.Models.Notifications.ProcessingDirective
                    {
                        EventFilter = new AmazonSpApiSDK.Models.Notifications.EventFilter
                        {
                            EventFilterType = "ANY_OFFER_CHANGED",
                            MarketplaceIds = new List<string> { "ATVPDKIKX0DER" },
                            AggregationSettings = new AmazonSpApiSDK.Models.Notifications.AggregationSettings
                            {
                                AggregationTimePeriod = AmazonSpApiSDK.Models.Notifications.AggregationTimePeriod.FiveMinutes
                            }
                        }
                    }
                });

            if (subscription == null)
            {
                Console.WriteLine("Failed to create subscription.");
                return;
            }

            Console.WriteLine($"Subscription created: {subscription.SubscriptionId}");

            // Example B: ORDER_CHANGE filtered to buyer cancellation requests only
            var orderChangeSub = amazonConnection.Notification.CreateSubscription(
                new ParameterCreateSubscription()
                {
                    destinationId = destination.DestinationId,
                    notificationType = NotificationType.ORDER_CHANGE,
                    payloadVersion = "1.0",
                    processingDirective = new AmazonSpApiSDK.Models.Notifications.ProcessingDirective
                    {
                        EventFilter = new AmazonSpApiSDK.Models.Notifications.EventFilter
                        {
                            EventFilterType = "ORDER_CHANGE",
                            OrderChangeTypes = new List<string> { "BuyerRequestedChange" }
                        }
                    }
                });

            if (orderChangeSub != null)
                Console.WriteLine($"ORDER_CHANGE subscription created: {orderChangeSub.SubscriptionId}");
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
                    await FikaAmazonAPI.Services.NotificationService.StartReceivingNotificationMessagesAsync(
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
