using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Restrictions
{

    /// <summary>
    /// A reason for the restriction, including path forward links that may allow Selling Partners to remove the restriction, if available.
    /// </summary>
    [DataContract]
    public class Reason
    {
        /// <summary>
        /// A message describing the reason for the restriction.
        /// </summary>
        /// <value>A message describing the reason for the restriction.</value>
        [DataMember(Name = "message", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        /// A code indicating why the listing is restricted.
        /// </summary>
        /// <value>A code indicating why the listing is restricted.</value>
        [DataMember(Name = "reasonCode", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "reasonCode")]
        public string ReasonCode { get; set; }

        /// <summary>
        /// A list of path forward links that may allow Selling Partners to remove the restriction.
        /// </summary>
        /// <value>A list of path forward links that may allow Selling Partners to remove the restriction.</value>
        [DataMember(Name = "links", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "links")]
        public List<Link> Links { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Reason {\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  ReasonCode: ").Append(ReasonCode).Append("\n");
            sb.Append("  Links: ").Append(Links).Append("\n");
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
