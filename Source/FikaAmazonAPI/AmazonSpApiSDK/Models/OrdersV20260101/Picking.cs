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
    /// Information related to the warehouse picking process for an order item.
    /// </summary>
    [DataContract]
    public partial class Picking : IEquatable<Picking>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Picking" /> class.
        /// </summary>
        public Picking()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Picking" /> class.
        /// </summary>
        /// <param name="substitutionPreference">Substitution preference for an order item when it becomes unavailable during fulfillment.</param>
        public Picking(SubstitutionPreference substitutionPreference)
        {
            this.SubstitutionPreference = substitutionPreference;
        }

        /// <summary>
        /// Substitution preference for an order item when it becomes unavailable during fulfillment.
        /// </summary>
        /// <value>Substitution preference for an order item when it becomes unavailable during fulfillment.</value>
        [DataMember(Name = "substitutionPreference", EmitDefaultValue = false)]
        public SubstitutionPreference SubstitutionPreference { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Picking {\n");
            sb.Append("  SubstitutionPreference: ").Append(SubstitutionPreference).Append("\n");
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
            return this.Equals(obj as Picking);
        }

        /// <summary>
        /// Returns true if Picking instances are equal
        /// </summary>
        /// <param name="input">Instance of Picking to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Picking input)
        {
            if (input == null)
                return false;

            return
                (
                    this.SubstitutionPreference == input.SubstitutionPreference ||
                    (this.SubstitutionPreference != null &&
                    this.SubstitutionPreference.Equals(input.SubstitutionPreference))
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
                if (this.SubstitutionPreference != null)
                    hashCode = hashCode * 59 + this.SubstitutionPreference.GetHashCode();
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