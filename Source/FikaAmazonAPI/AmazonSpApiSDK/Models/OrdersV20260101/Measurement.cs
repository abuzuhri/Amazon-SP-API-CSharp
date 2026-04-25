using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Specifies the unit of measure and quantity for items that are sold by weight, volume, length, or other measurements rather than simple count.
    /// </summary>
    [DataContract]
    public partial class Measurement : IEquatable<Measurement>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Measurement" /> class.
        /// </summary>
        public Measurement() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Measurement" /> class.
        /// </summary>
        /// <param name="unit">The specific unit of measurement used to quantify this item. (required)</param>
        /// <param name="value">The numerical quantity or amount being measured in the specified unit. (required)</param>
        public Measurement(UnitEnum unit, decimal value)
        {
            this.Unit = unit;
            this.Value = value;
        }

        /// <summary>
        /// The specific unit of measurement used to quantify this item. (required)
        /// </summary>
        /// <value>The specific unit of measurement used to quantify this item. (required)</value>
        [DataMember(Name = "unit", EmitDefaultValue = false)]
        public UnitEnum Unit { get; set; }

        /// <summary>
        /// The numerical quantity or amount being measured in the specified unit. (required)
        /// </summary>
        /// <value>The numerical quantity or amount being measured in the specified unit. (required)</value>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public decimal Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Measurement {\n");
            sb.Append("  Unit: ").Append(Unit).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
            return this.Equals(obj as Measurement);
        }

        /// <summary>
        /// Returns true if Measurement instances are equal
        /// </summary>
        /// <param name="input">Instance of Measurement to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Measurement input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Unit == input.Unit ||
                    (this.Unit != null &&
                    this.Unit.Equals(input.Unit))
                ) &&
                (
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
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
                if (this.Unit != null)
                    hashCode = hashCode * 59 + this.Unit.GetHashCode();
                if (this.Value != null)
                    hashCode = hashCode * 59 + this.Value.GetHashCode();
             
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