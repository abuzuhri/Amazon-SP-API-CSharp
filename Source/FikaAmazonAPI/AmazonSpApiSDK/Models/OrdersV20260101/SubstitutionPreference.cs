using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Substitution preference for an order item when it becomes unavailable during fulfillment.
    /// </summary>
    [DataContract]
    public partial class SubstitutionPreference : IEquatable<SubstitutionPreference>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubstitutionPreference" /> class.
        /// </summary>
        public SubstitutionPreference()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubstitutionPreference" /> class.
        /// </summary>
        /// <param name="substitutionType">Source and nature of the substitution preferences for this item. (required)</param>
        /// <param name="substitutionOptions">List of alternative products that can be substituted for the original item if it becomes unavailable.</param>
        public SubstitutionPreference(SubstitutionTypeEnum substitutionType,
                                      List<SubstitutionOption> substitutionOptions)
        {
            this.SubstitutionType = substitutionType;
            this.SubstitutionOptions = substitutionOptions;
        }

        /// <summary>
        /// Source and nature of the substitution preferences for this item. (required)
        /// </summary>
        /// <value>Source and nature of the substitution preferences for this item. (required)</value>
        [DataMember(Name = "substitutionType", EmitDefaultValue = false)]
        public SubstitutionTypeEnum SubstitutionType { get; set; }

        /// <summary>
        /// List of alternative products that can be substituted for the original item if it becomes unavailable.
        /// </summary>
        /// <value>List of alternative products that can be substituted for the original item if it becomes unavailable.</value>
        [DataMember(Name = "substitutionOptions", EmitDefaultValue = false)]
        public List<SubstitutionOption> SubstitutionOptions { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SubstitutionPreference {\n");
            sb.Append("  SubstitutionType: ").Append(SubstitutionType).Append("\n");
            sb.Append("  SubstitutionOptions: ").Append(SubstitutionOptions).Append("\n");
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
            return this.Equals(obj as SubstitutionPreference);
        }

        /// <summary>
        /// Returns true if SubstitutionPreference instances are equal
        /// </summary>
        /// <param name="input">Instance of SubstitutionPreference to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SubstitutionPreference input)
        {
            if (input == null)
                return false;

            return
                (
                    this.SubstitutionType == input.SubstitutionType ||
                    (this.SubstitutionType != null &&
                    this.SubstitutionType.Equals(input.SubstitutionType))
                ) &&
                (
                    this.SubstitutionOptions == input.SubstitutionOptions ||
                    (this.SubstitutionOptions != null &&
                    this.SubstitutionOptions.SequenceEqual(input.SubstitutionOptions))
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
                if (this.SubstitutionType != null)
                    hashCode = hashCode * 59 + this.SubstitutionType.GetHashCode();
                if (this.SubstitutionOptions != null)
                    hashCode = hashCode * 59 + this.SubstitutionOptions.GetHashCode();
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