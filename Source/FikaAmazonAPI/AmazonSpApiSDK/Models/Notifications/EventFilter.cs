using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Notifications
{
    /// <summary>
    /// A notificationType specific filter. This object contains all of the currently available filters and properties that you can use to define a notificationType specific filter.
    /// </summary>
    [DataContract]
    public class EventFilter : AggregationFilter
    {
        /// <summary>
        /// Gets or Sets MarketplaceIds
        /// </summary>
        [DataMember(Name = "marketplaceIds", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "marketplaceIds")]
        public IList<string> MarketplaceIds { get; set; }

        /// <summary>
        /// An eventFilterType value that is supported by the specific notificationType. This is used by the subscription service to determine the type of event filter. Refer to the section of the [Notifications Use Case Guide](doc:notifications-api-v1-use-case-guide) that describes the specific notificationType to determine if an eventFilterType is supported.
        /// </summary>
        /// <value>An eventFilterType value that is supported by the specific notificationType. This is used by the subscription service to determine the type of event filter. Refer to the section of the [Notifications Use Case Guide](doc:notifications-api-v1-use-case-guide) that describes the specific notificationType to determine if an eventFilterType is supported.</value>
        [DataMember(Name = "eventFilterType", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "eventFilterType")]
        public string EventFilterType { get; set; }

        /// <summary>
        /// Gets or Sets OrderChangeTypes
        /// </summary>
        [DataMember(Name = "orderChangeTypes", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "orderChangeTypes")]
        public IList<string> OrderChangeTypes { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EventFilter {\n");
            sb.Append("  MarketplaceIds: ").Append(MarketplaceIds).Append("\n");
            sb.Append("  EventFilterType: ").Append(EventFilterType).Append("\n");
            sb.Append("  OrderChangeTypes: ").Append(OrderChangeTypes).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public new string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

    }
}
