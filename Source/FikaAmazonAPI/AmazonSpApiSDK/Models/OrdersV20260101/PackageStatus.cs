using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Current status and detailed tracking information for a shipping package throughout the delivery process.
    /// </summary>
    [DataContract]
    public partial class PackageStatus : IEquatable<PackageStatus>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PackageStatus" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public PackageStatus() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PackageStatus" /> class.
        /// </summary>
        /// <param name="status">Primary status classification of the package in the shipping workflow. (required)</param>
        /// <param name="detailedStatus">Granular status information providing specific details about the package's current location and handling stage.</param>

        public PackageStatus(PackageStatusEnum status,
                             PackageDetailedStatusEnum? detailedStatus)
        {
            this.Status = status;
            this.DetailedStatus = detailedStatus;
        }


        /// <summary>
        /// Primary status classification of the package in the shipping workflow. (required)
        /// </summary>
        /// <value>Primary status classification of the package in the shipping workflow. (required)</value>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public PackageStatusEnum Status { get; set; }

        /// <summary>
        /// Granular status information providing specific details about the package's current location and handling stage.
        /// </summary>
        /// <value>Granular status information providing specific details about the package's current location and handling stage.</value>
        [DataMember(Name = "detailedStatus", EmitDefaultValue = false)]
        public PackageDetailedStatusEnum? DetailedStatus { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PackageStatus {\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  DetailedStatus: ").Append(DetailedStatus).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as PackageStatus);
        }

        /// <summary>
        /// Returns true if PackageStatus instances are equal
        /// </summary>
        /// <param name="input">Instance of PackageStatus to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PackageStatus input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
                ) &&
                (
                    this.DetailedStatus == input.DetailedStatus ||
                    (this.DetailedStatus != null &&
                    this.DetailedStatus.Equals(input.DetailedStatus))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.DetailedStatus != null)
                    hashCode = hashCode * 59 + this.DetailedStatus.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}