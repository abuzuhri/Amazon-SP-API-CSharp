using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2 {

    /// <summary>
    /// The weight.
    /// </summary>
    [DataContract]
    public partial class Weight : IEquatable<Weight>, IValidatableObject
    {
        /// <summary>
        /// The unit of measurement.
        /// </summary>
        /// <value>The unit of measurement.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum UnitEnum
        {

            /// <summary>
            /// Enum G for value: GRAM
            /// </summary>
            [EnumMember(Value = "GRAM")]
            G = 1,

            /// <summary>
            /// Enum Kg for value: KILOGRAM
            /// </summary>
            [EnumMember(Value = "KILOGRAM")]
            Kg = 2,

            /// <summary>
            /// Enum Oz for value: OUNCE
            /// </summary>
            [EnumMember(Value = "OUNCE")]
            Oz = 3,

            /// <summary>
            /// Enum Lb for value: POUND
            /// </summary>
            [EnumMember(Value = "POUND")]
            Lb = 4
        }

        /// <summary>
        /// The unit of measurement.
        /// </summary>
        /// <value>The unit of measurement.</value>
        [DataMember(Name = "unit", EmitDefaultValue = false)]
        public UnitEnum Unit { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Weight" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public Weight() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Weight" /> class.
        /// </summary>
        /// <param name="Unit">The unit of measurement. (required).</param>
        /// <param name="Value">The measurement value. (required).</param>
        public Weight(UnitEnum Unit = default(UnitEnum), decimal? Value = default(decimal?))
        {
            // to ensure "Unit" is required (not null)
            if (Unit == null)
            {
                throw new InvalidDataException("Unit is a required property for Weight and cannot be null");
            }
            else
            {
                this.Unit = Unit;
            }
            // to ensure "Value" is required (not null)
            if (Value == null)
            {
                throw new InvalidDataException("Value is a required property for Weight and cannot be null");
            }
            else
            {
                this.Value = Value;
            }
        }


        /// <summary>
        /// The measurement value.
        /// </summary>
        /// <value>The measurement value.</value>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public decimal? Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Weight {\n");
            sb.Append("  Unit: ").Append(Unit).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Weight);
        }

        /// <summary>
        /// Returns true if Weight instances are equal
        /// </summary>
        /// <param name="input">Instance of Weight to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Weight input)
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
