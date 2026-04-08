using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Detailed information about the physical condition and quality state of the item being sold.
    /// </summary>
    [DataContract]
    public partial class Condition : IEquatable<Condition>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Condition" /> class.
        /// </summary>
        public Condition()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Condition" /> class.
        /// </summary>
        /// <param name="conditionType">The primary condition category that broadly describes the item's state.</param>
        /// <param name="conditionSubtype">A more specific condition classification that provides additional detail about the item's quality within the main condition type.</param>
        /// <param name="conditionNote">Additional details provided by the seller to describe the specific condition of this particular item.</param>
        public Condition(ConditionTypeEnum? conditionType,
                         ConditionSubtypeEnum? conditionSubtype,
                         string conditionNote)
        {
            this.ConditionType = conditionType;
            this.ConditionSubtype = conditionSubtype;
            this.ConditionNote = conditionNote;
        }

        /// <summary>
        /// The primary condition category that broadly describes the item's state.
        /// </summary>
        /// <value>The primary condition category that broadly describes the item's state.</value>
        [DataMember(Name = "conditionType", EmitDefaultValue = false)]
        public ConditionTypeEnum? ConditionType { get; set; }

        /// <summary>
        /// A more specific condition classification that provides additional detail about the item's quality within the main condition type.
        /// </summary>
        /// <value>A more specific condition classification that provides additional detail about the item's quality within the main condition type.</value>
        [DataMember(Name = "conditionSubtype", EmitDefaultValue = false)]
        public ConditionSubtypeEnum? ConditionSubtype { get; set; }

        /// <summary>
        /// Additional details provided by the seller to describe the specific condition of this particular item.
        /// </summary>
        /// <value>Additional details provided by the seller to describe the specific condition of this particular item.</value>
        [DataMember(Name = "conditionNote", EmitDefaultValue = false)]
        public string ConditionNote { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Condition {\n");
            sb.Append("  ConditionType: ").Append(ConditionType).Append("\n");
            sb.Append("  ConditionSubtype: ").Append(ConditionSubtype).Append("\n");
            sb.Append("  ConditionNote: ").Append(ConditionNote).Append("\n");
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
            return this.Equals(obj as Condition);
        }

        /// <summary>
        /// Returns true if Condition instances are equal
        /// </summary>
        /// <param name="input">Instance of Condition to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Condition input)
        {
            if (input == null)
                return false;

            return
                (
                    this.ConditionType == input.ConditionType ||
                    (this.ConditionType != null &&
                    this.ConditionType.Equals(input.ConditionType))
                ) &&
                (
                    this.ConditionSubtype == input.ConditionSubtype ||
                    (this.ConditionSubtype != null &&
                    this.ConditionSubtype.Equals(input.ConditionSubtype))
                ) &&
                (
                    this.ConditionNote == input.ConditionNote ||
                    (this.ConditionNote != null &&
                    this.ConditionNote.Equals(input.ConditionNote))
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
                if (this.ConditionType != null)
                    hashCode = hashCode * 59 + this.ConditionType.GetHashCode();
                if (this.ConditionSubtype != null)
                    hashCode = hashCode * 59 + this.ConditionSubtype.GetHashCode();
                if (this.ConditionNote != null)
                    hashCode = hashCode * 59 + this.ConditionNote.GetHashCode();
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