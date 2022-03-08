using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Restrictions
{

    /// <summary>
    /// A listing restriction, optionally qualified by a condition, with a list of reasons for the restriction.
    /// </summary>
    [DataContract]
    public class Restriction
    {
        /// <summary>
        /// A marketplace identifier. Identifies the Amazon marketplace where the restriction is enforced.
        /// </summary>
        /// <value>A marketplace identifier. Identifies the Amazon marketplace where the restriction is enforced.</value>
        [DataMember(Name = "marketplaceId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "marketplaceId")]
        public string MarketplaceId { get; set; }

        /// <summary>
        /// The condition that applies to the restriction.
        /// </summary>
        /// <value>The condition that applies to the restriction.</value>
        [DataMember(Name = "conditionType", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "conditionType")]
        public string ConditionType { get; set; }

        /// <summary>
        /// A list of reasons for the restriction.
        /// </summary>
        /// <value>A list of reasons for the restriction.</value>
        [DataMember(Name = "reasons", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "reasons")]
        public List<Reason> Reasons { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Restriction {\n");
            sb.Append("  MarketplaceId: ").Append(MarketplaceId).Append("\n");
            sb.Append("  ConditionType: ").Append(ConditionType).Append("\n");
            sb.Append("  Reasons: ").Append(Reasons).Append("\n");
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
