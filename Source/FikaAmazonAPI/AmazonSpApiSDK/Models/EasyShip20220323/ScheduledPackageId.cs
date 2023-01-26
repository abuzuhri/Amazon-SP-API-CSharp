using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.EasyShip20220323
{

    /// <summary>
    /// Identifies the scheduled package to be updated.
    /// </summary>
    [DataContract]
    public class ScheduledPackageId
    {
        /// <summary>
        /// Gets or Sets AmazonOrderId
        /// </summary>
        [DataMember(Name = "amazonOrderId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "amazonOrderId")]
        public string AmazonOrderId { get; set; }

        /// <summary>
        /// Gets or Sets PackageId
        /// </summary>
        [DataMember(Name = "packageId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "packageId")]
        public string PackageId { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ScheduledPackageId {\n");
            sb.Append("  AmazonOrderId: ").Append(AmazonOrderId).Append("\n");
            sb.Append("  PackageId: ").Append(PackageId).Append("\n");
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
