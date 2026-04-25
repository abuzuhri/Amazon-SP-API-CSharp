using Amazon;
using FikaAmazonAPI.AmazonSpApiSDK.Models.ApplicationManagement;
using FikaAmazonAPI.NotificationMessages;
using FikaAmazonAPI.Parameter.Notification;
using FikaAmazonAPI.Services;
using System;
using System.Threading.Tasks;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.SampleCode
{
    public class ApplicationManagementSample
    {
        AmazonConnection amazonConnection;
        public ApplicationManagementSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }

        /// <summary>
        /// One-time setup: subscribe to the notifications that deliver the rotated client secret
        /// and the upcoming-expiry warning. Returns the two subscription IDs.
        ///
        /// Prerequisite: <paramref name="destinationId"/> must already exist (created via
        /// <c>amazonConnection.Notification.CreateDestination(...)</c> against an SQS queue
        /// you control). The new secret will be POSTed to that queue when rotation completes.
        /// </summary>
        public async Task<(string newSecretSubId, string expirySubId)> SubscribeToSecretRotationNotificationsAsync(string destinationId)
        {
            var newSecretSub = await amazonConnection.Notification.CreateSubscriptionAsync(new ParameterCreateSubscription
            {
                notificationType = NotificationType.APPLICATION_OAUTH_CLIENT_NEW_SECRET,
                destinationId    = destinationId,
                payloadVersion   = "1.0",
            });
            var expirySub = await amazonConnection.Notification.CreateSubscriptionAsync(new ParameterCreateSubscription
            {
                notificationType = NotificationType.APPLICATION_OAUTH_CLIENT_SECRET_EXPIRY,
                destinationId    = destinationId,
                payloadVersion   = "1.0",
            });
            return (newSecretSub.SubscriptionId, expirySub.SubscriptionId);
        }

        /// <summary>
        /// Trigger an LWA client-secret rotation. The HTTP response carries no useful body —
        /// the new secret is delivered asynchronously to the SQS queue subscribed to
        /// APPLICATION_OAUTH_CLIENT_NEW_SECRET.
        /// </summary>
        public async Task<RotateApplicationClientSecretResponse> RotateAsync()
        {
            return await amazonConnection.ApplicationManagement.RotateApplicationClientSecretAsync();
        }

        /// <summary>
        /// Auto-apply rotated client secrets while consuming any other notifications you
        /// already process. Wraps <paramref name="myReceiver"/> in a
        /// <see cref="RotationApplyingMessageReceiver"/> so a rotation notification updates
        /// <c>amazonConnection.Credentials.ClientSecret</c> transparently before being
        /// forwarded to your receiver.
        ///
        /// Pass <paramref name="store"/> to persist the rotated secret to your database so
        /// the next process start picks it up — updating the running
        /// <see cref="AmazonCredential"/> only fixes the current process.
        /// </summary>
        public Task StartReceivingWithRotationApplyAsync(
            IMessageReceiver myReceiver,
            string sqsUrl,
            string awsAccessKeyId,
            string awsSecretAccessKey,
            RegionEndpoint region,
            IClientSecretStore store = null)
        {
            // The onRotated callback fires AFTER the secret has been applied to the live
            // AmazonCredential, so the running connection already uses the new secret by
            // the time we persist. Wrap the IO call so a DB outage doesn't kill the SQS
            // consumer loop — the SDK has already kept the in-memory credential current.
            Action<ApplicationOAuthClientNewSecretNotification> persist = null;
            if (store != null)
            {
                persist = payload =>
                {
                    try
                    {
                        store.SaveRotatedSecret(
                            clientId:                 payload.ClientId,
                            newClientSecret:          payload.NewClientSecret,
                            newClientSecretExpiresAt: payload.NewClientSecretExpiryTime,
                            oldClientSecretExpiresAt: payload.OldClientSecretExpiryTime);
                    }
                    catch (Exception ex)
                    {
                        // Don't let a transient DB failure break the SQS pump. Log and
                        // continue — operator can re-run rotation if persistence fails,
                        // and the running process is fine because the credential was
                        // updated in place by RotationApplyingMessageReceiver.
                        Console.Error.WriteLine($"[rotation] persist failed for clientId={payload.ClientId}: {ex.Message}");
                    }
                };
            }

            var wrapped = new RotationApplyingMessageReceiver(myReceiver, amazonConnection.Credentials, persist);
            var param   = new ParameterMessageReceiver(awsAccessKeyId, awsSecretAccessKey, sqsUrl, region);
            return NotificationService.StartReceivingNotificationMessagesAsync(param, wrapped);
        }

        /// <summary>
        /// What you implement to persist a rotated client secret. The SDK only mutates the
        /// in-memory <see cref="AmazonCredential"/>; durable storage is your responsibility,
        /// because the next process start has to read the new secret from somewhere.
        ///
        /// Persist all four fields:
        /// <list type="bullet">
        /// <item><description><c>clientId</c> — the application ID, useful as the row key.</description></item>
        /// <item><description><c>newClientSecret</c> — store this securely (Key Vault / KMS / encrypted column / etc.).</description></item>
        /// <item><description><c>newClientSecretExpiresAt</c> — when this secret itself expires; schedule the next rotation before this.</description></item>
        /// <item><description><c>oldClientSecretExpiresAt</c> — deadline to complete the cutover. Until this passes, both secrets work; after it, only the new one does.</description></item>
        /// </list>
        /// </summary>
        public interface IClientSecretStore
        {
            void SaveRotatedSecret(
                string clientId,
                string newClientSecret,
                DateTimeOffset newClientSecretExpiresAt,
                DateTimeOffset oldClientSecretExpiresAt);
        }

        /// <summary>
        /// Stub implementation. Replace the body with whatever your project uses to persist
        /// to a database (Dapper / EF / ADO.NET / etc.) — the only requirement is that the
        /// secret is stored encrypted at rest.
        /// </summary>
        public class SampleClientSecretStore : IClientSecretStore
        {
            public void SaveRotatedSecret(
                string clientId,
                string newClientSecret,
                DateTimeOffset newClientSecretExpiresAt,
                DateTimeOffset oldClientSecretExpiresAt)
            {
                // TODO: save the four values to your database. NewClientSecret must be
                // encrypted at rest. Example column layout:
                //   ClientId (PK), ClientSecret (encrypted), NewClientSecretExpiresAt,
                //   OldClientSecretExpiresAt, UpdatedAt.
                Console.WriteLine($"[rotation] persisted clientId={clientId}, newExpiresAt={newClientSecretExpiresAt:u}, cutoverDeadline={oldClientSecretExpiresAt:u}");
            }
        }
    }
}
