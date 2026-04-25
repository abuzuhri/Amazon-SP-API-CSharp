using FikaAmazonAPI.NotificationMessages;
using System;

namespace FikaAmazonAPI.Parameter.Notification
{
    /// <summary>
    /// An <see cref="IMessageReceiverWithResult"/> wrapper that auto-applies a rotated LWA
    /// client secret to a live <see cref="AmazonCredential"/> when an
    /// APPLICATION_OAUTH_CLIENT_NEW_SECRET notification is received, then forwards the
    /// message to an inner receiver as normal.
    ///
    /// <para>Use this when you call
    /// <c>NotificationService.StartReceivingNotificationMessages*(...)</c> against a queue
    /// that may carry rotation notifications — your existing receiver keeps doing what it
    /// did before, and rotated secrets land on your credential automatically.</para>
    ///
    /// <para>The caller is still responsible for persisting the new secret to durable
    /// storage so the next process start can use it; the wrapper invokes the optional
    /// <c>onRotated</c> callback so persistence can be hooked there.</para>
    /// </summary>
    public class RotationApplyingMessageReceiver : IMessageReceiverWithResult
    {
        private readonly IMessageReceiverWithResult _inner;
        private readonly AmazonCredential _credentials;
        private readonly Action<ApplicationOAuthClientNewSecretNotification> _onRotated;

        /// <summary>
        /// Wrap an existing <see cref="IMessageReceiverWithResult"/>.
        /// </summary>
        /// <param name="inner">The original receiver. Receives every message, including the rotation one (after the secret has been applied).</param>
        /// <param name="credentials">The credential bag to mutate. Pass <c>amazonConnection.Credentials</c>.</param>
        /// <param name="onRotated">Optional callback invoked after the new secret is applied — wire your secret-store persistence here.</param>
        public RotationApplyingMessageReceiver(
            IMessageReceiverWithResult inner,
            AmazonCredential credentials,
            Action<ApplicationOAuthClientNewSecretNotification> onRotated = null)
        {
            _inner = inner ?? throw new ArgumentNullException(nameof(inner));
            _credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
            _onRotated = onRotated;
        }

        /// <summary>
        /// Convenience overload that takes the simpler <see cref="IMessageReceiver"/>
        /// (no return value) and adapts it. The wrapped receiver always returns true so
        /// the SQS message is deleted after each successful invocation.
        /// </summary>
        public RotationApplyingMessageReceiver(
            IMessageReceiver inner,
            AmazonCredential credentials,
            Action<ApplicationOAuthClientNewSecretNotification> onRotated = null)
            : this(new VoidToBoolAdapter(inner), credentials, onRotated)
        {
        }

        public bool NewMessageRevicedTriger(NotificationMessageResponce message)
        {
            var newSecret = message?.Payload?.ApplicationOAuthClientNewSecret;
            if (newSecret != null && !string.IsNullOrEmpty(newSecret.NewClientSecret))
            {
                _credentials.ClientSecret = newSecret.NewClientSecret;
                _onRotated?.Invoke(newSecret);
            }
            return _inner.NewMessageRevicedTriger(message);
        }

        public void ErrorCatch(Exception ex) => _inner.ErrorCatch(ex);

        private sealed class VoidToBoolAdapter : IMessageReceiverWithResult
        {
            private readonly IMessageReceiver _inner;
            public VoidToBoolAdapter(IMessageReceiver inner) => _inner = inner ?? throw new ArgumentNullException(nameof(inner));
            public bool NewMessageRevicedTriger(NotificationMessageResponce m) { _inner.NewMessageRevicedTriger(m); return true; }
            public void ErrorCatch(Exception ex) => _inner.ErrorCatch(ex);
        }
    }
}
