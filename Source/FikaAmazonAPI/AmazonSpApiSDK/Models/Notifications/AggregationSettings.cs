using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Notifications
{
    // <summary>
    /// A container that holds all of the necessary properties to configure the aggregation of notifications.
    /// </summary>
    [DataContract]
    public class AggregationSettings
    {
        /// <summary>
        /// The supported time period to use to perform marketplace-ASIN level aggregation.
        /// </summary>
        /// <value>The supported time period to use to perform marketplace-ASIN level aggregation.</value>
        [DataMember(Name = "aggregationTimePeriod", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "aggregationTimePeriod")]
        public AggregationTimePeriod AggregationTimePeriod { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AggregationSettings {\n");
            sb.Append("  AggregationTimePeriod: ").Append(AggregationTimePeriod).Append("\n");
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
