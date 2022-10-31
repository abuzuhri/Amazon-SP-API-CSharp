using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.EasyShip20220323
{

    /// <summary>
    /// Package details. Includes &#x60;packageItems&#x60;, &#x60;packageTimeSlot&#x60;, and &#x60;packageIdentifier&#x60;.
    /// </summary>
    [DataContract]
    public class PackageDetails
    {
        /// <summary>
        /// Gets or Sets PackageItems
        /// </summary>
        [DataMember(Name = "packageItems", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "packageItems")]
        public Items PackageItems { get; set; }

        /// <summary>
        /// Gets or Sets PackageTimeSlot
        /// </summary>
        [DataMember(Name = "packageTimeSlot", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "packageTimeSlot")]
        public TimeSlot PackageTimeSlot { get; set; }

        /// <summary>
        /// Gets or Sets PackageIdentifier
        /// </summary>
        [DataMember(Name = "packageIdentifier", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "packageIdentifier")]
        public string PackageIdentifier { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PackageDetails {\n");
            sb.Append("  PackageItems: ").Append(PackageItems).Append("\n");
            sb.Append("  PackageTimeSlot: ").Append(PackageTimeSlot).Append("\n");
            sb.Append("  PackageIdentifier: ").Append(PackageIdentifier).Append("\n");
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
