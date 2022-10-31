using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.EasyShip20220323
{

    /// <summary>
    /// Representation of tracking metadata.
    /// </summary>
    [DataContract]
    public class TrackingDetails
    {
        /// <summary>
        /// The tracking identifier for the scheduled package.
        /// </summary>
        /// <value>The tracking identifier for the scheduled package.</value>
        [DataMember(Name = "trackingId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "trackingId")]
        public string TrackingId { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TrackingDetails {\n");
            sb.Append("  TrackingId: ").Append(TrackingId).Append("\n");
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
