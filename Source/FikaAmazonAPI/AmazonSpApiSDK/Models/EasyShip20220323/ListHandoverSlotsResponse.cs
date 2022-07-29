using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.EasyShip20220323
{

    /// <summary>
    /// The response schema for the &#x60;listHandoverSlots&#x60; operation.
    /// </summary>
    [DataContract]
    public class ListHandoverSlotsResponse
    {
        /// <summary>
        /// Gets or Sets AmazonOrderId
        /// </summary>
        [DataMember(Name = "amazonOrderId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "amazonOrderId")]
        public string AmazonOrderId { get; set; }

        /// <summary>
        /// Gets or Sets TimeSlots
        /// </summary>
        [DataMember(Name = "timeSlots", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "timeSlots")]
        public TimeSlots TimeSlots { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ListHandoverSlotsResponse {\n");
            sb.Append("  AmazonOrderId: ").Append(AmazonOrderId).Append("\n");
            sb.Append("  TimeSlots: ").Append(TimeSlots).Append("\n");
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
