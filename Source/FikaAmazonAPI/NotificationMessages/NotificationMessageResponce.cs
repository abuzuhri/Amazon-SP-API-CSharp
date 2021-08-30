using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.NotificationMessages
{
    public class NotificationMessageResponce
    {
        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("EventTime")]
        public string EventTime { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("NotificationMetadata")]
        public NotificationMetadata NotificationMetadata { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("NotificationType")]
        public string NotificationType { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("NotificationVersion")]
        public string NotificationVersion { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("Payload")]
        public NotificationPayload Payload { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("PayloadVersion")]
        public string PayloadVersion { get; set; }
    }
}
