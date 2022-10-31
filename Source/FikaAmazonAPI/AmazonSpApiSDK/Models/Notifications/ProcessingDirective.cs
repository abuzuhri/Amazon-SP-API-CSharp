using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Notifications
{
    /// <summary>
    /// Additional information passed to the subscription to control the processing of notifications. For example, you can use an eventFilter to customize your subscription to send notifications for only the specified marketplaceId&#39;s, or select the aggregation time period at which to send notifications (e.g. limit to one notification every five minutes for high frequency notifications). The specific features available vary depending on the notificationType.  This feature is limited to specific notificationTypes and is currently only supported by the ANY_OFFER_CHANGED notificationType.
    /// </summary>
    [DataContract]
    public class ProcessingDirective
    {
        /// <summary>
        /// A notificationType specific filter.
        /// </summary>
        /// <value>A notificationType specific filter.</value>
        [DataMember(Name = "eventFilter", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "eventFilter")]
        public EventFilter EventFilter { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProcessingDirective {\n");
            sb.Append("  EventFilter: ").Append(EventFilter).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

    }
}
