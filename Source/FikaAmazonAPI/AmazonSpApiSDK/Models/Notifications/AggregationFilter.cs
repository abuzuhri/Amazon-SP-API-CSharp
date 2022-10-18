using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Notifications
{
    /// <summary>
    /// Use this filter to select the aggregation time period at which to send notifications (e.g. limit to one notification every five minutes for high frequency notifications).
    /// </summary>
    [DataContract]
    public class AggregationFilter
    {
        /// <summary>
        /// Gets or Sets AggregationSettings
        /// </summary>
        [DataMember(Name = "aggregationSettings", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "aggregationSettings")]
        public AggregationSettings AggregationSettings { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AggregationFilter {\n");
            sb.Append("  AggregationSettings: ").Append(AggregationSettings).Append("\n");
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
