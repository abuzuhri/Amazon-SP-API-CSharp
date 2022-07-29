using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.EasyShip20220323
{

    /// <summary>
    /// A time window to hand over an Easy Ship package to Amazon Logistics.
    /// </summary>
    [DataContract]
    public class TimeSlot
    {
        /// <summary>
        /// An Amazon-defined identifier for a time slot.
        /// </summary>
        /// <value>An Amazon-defined identifier for a time slot.</value>
        [DataMember(Name = "slotId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "slotId")]
        public string SlotId { get; set; }

        /// <summary>
        /// The start date and time of the time slot.
        /// </summary>
        /// <value>The start date and time of the time slot.</value>
        [DataMember(Name = "startTime", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "startTime")]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// The end date and time of the time slot.
        /// </summary>
        /// <value>The end date and time of the time slot.</value>
        [DataMember(Name = "endTime", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "endTime")]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// The method by which a seller will hand a package over to Amazon Logistics.
        /// </summary>
        /// <value>The method by which a seller will hand a package over to Amazon Logistics.</value>
        [DataMember(Name = "handoverMethod", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "handoverMethod")]
        public HandoverMethod HandoverMethod { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TimeSlot {\n");
            sb.Append("  SlotId: ").Append(SlotId).Append("\n");
            sb.Append("  StartTime: ").Append(StartTime).Append("\n");
            sb.Append("  EndTime: ").Append(EndTime).Append("\n");
            sb.Append("  HandoverMethod: ").Append(HandoverMethod).Append("\n");
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
