using Newtonsoft.Json;
using System;

namespace FikaAmazonAPI.NotificationMessages
{
    public class ApplicationOAuthClientNotification
    {
        [JsonProperty("clientId")]
        public string ClientId { get; set; }
    }

    public class ApplicationOAuthClientSecretExpiryNotification : ApplicationOAuthClientNotification
    {
        [JsonProperty("clientSecretExpiryTime")]
        public DateTimeOffset ClientSecretExpiryTime { get; set; }

        [JsonProperty("clientSecretExpiryReason")]
        public string ClientSecretExpiryReason { get; set; }
    }

    public class ApplicationOAuthClientNewSecretNotification : ApplicationOAuthClientNotification
    {
        [JsonProperty("newClientSecret")]
        public string NewClientSecret { get; set; }

        [JsonProperty("newClientSecretExpiryTime")]
        public DateTimeOffset NewClientSecretExpiryTime { get; set; }

        [JsonProperty("oldClientSecretExpiryTime")]
        public DateTimeOffset OldClientSecretExpiryTime { get; set; }
    }
}
