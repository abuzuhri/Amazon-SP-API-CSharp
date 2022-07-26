using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.EasyShip20220323
{

    /// <summary>
    /// Request to update the time slot of a package.
    /// </summary>
    [DataContract]
    public class UpdatePackageDetails
    {
        /// <summary>
        /// Gets or Sets ScheduledPackageId
        /// </summary>
        [DataMember(Name = "scheduledPackageId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "scheduledPackageId")]
        public ScheduledPackageId ScheduledPackageId { get; set; }

        /// <summary>
        /// Gets or Sets PackageTimeSlot
        /// </summary>
        [DataMember(Name = "packageTimeSlot", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "packageTimeSlot")]
        public TimeSlot PackageTimeSlot { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UpdatePackageDetails {\n");
            sb.Append("  ScheduledPackageId: ").Append(ScheduledPackageId).Append("\n");
            sb.Append("  PackageTimeSlot: ").Append(PackageTimeSlot).Append("\n");
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
