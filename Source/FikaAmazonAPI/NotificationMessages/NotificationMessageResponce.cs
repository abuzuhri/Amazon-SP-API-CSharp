using Newtonsoft.Json;

namespace FikaAmazonAPI.NotificationMessages
{
    public class NotificationMessageResponce
    {
        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("eventTime")]
        public string EventTime { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("notificationMetadata")]
        public NotificationMetadata NotificationMetadata { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("notificationType")]
        public string NotificationType { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("notificationVersion")]
        public string NotificationVersion { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("payload")]
        public NotificationPayload Payload { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("payloadVersion")]
        public string PayloadVersion { get; set; }
    }
}
