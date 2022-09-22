using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2
{

    /// <summary>
    /// The payload for the getTracking operation.
    /// </summary>
    [DataContract]
    public class GetTrackingResult
    {
        /// <summary>
        /// Gets or Sets TrackingId
        /// </summary>
        [DataMember(Name = "trackingId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "trackingId")]
        public string TrackingId { get; set; }

        /// <summary>
        /// Gets or Sets AlternateLegTrackingId
        /// </summary>
        [DataMember(Name = "alternateLegTrackingId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "alternateLegTrackingId")]
        public string AlternateLegTrackingId { get; set; }

        /// <summary>
        /// A list of tracking events.
        /// </summary>
        /// <value>A list of tracking events.</value>
        [DataMember(Name = "eventHistory", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "eventHistory")]
        public List<Event> EventHistory { get; set; }

        /// <summary>
        /// The date and time by which the shipment is promised to be delivered.
        /// </summary>
        /// <value>The date and time by which the shipment is promised to be delivered.</value>
        [DataMember(Name = "promisedDeliveryDate", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "promisedDeliveryDate")]
        public DateTime? PromisedDeliveryDate { get; set; }

        /// <summary>
        /// Gets or Sets Summary
        /// </summary>
        [DataMember(Name = "summary", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "summary")]
        public TrackingSummary Summary { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetTrackingResult {\n");
            sb.Append("  TrackingId: ").Append(TrackingId).Append("\n");
            sb.Append("  AlternateLegTrackingId: ").Append(AlternateLegTrackingId).Append("\n");
            sb.Append("  EventHistory: ").Append(EventHistory).Append("\n");
            sb.Append("  PromisedDeliveryDate: ").Append(PromisedDeliveryDate).Append("\n");
            sb.Append("  Summary: ").Append(Summary).Append("\n");
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
