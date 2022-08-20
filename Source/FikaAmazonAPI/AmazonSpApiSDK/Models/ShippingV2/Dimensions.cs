using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Converters;
using System.IO;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2 {

    /// <summary>
    /// A set of measurements for a three-dimensional object.
    /// </summary>
    [DataContract]
    public partial class Dimensions : IEquatable<Dimensions>, IValidatableObject
    {
        /// <summary>
        /// The unit of these measurements.
        /// </summary>
        /// <value>The unit of these measurements.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum UnitEnum
        {

            /// <summary>
            /// Enum IN for value: INCH
            /// </summary>
            [EnumMember(Value = "INCH")]
            IN = 1,

            /// <summary>
            /// Enum CM for value: CENTIMETER
            /// </summary>
            [EnumMember(Value = "CENTIMETER")]
            CM = 2
        }

        /// <summary>
        /// The unit of these measurements.
        /// </summary>
        /// <value>The unit of these measurements.</value>
        [DataMember(Name = "unit", EmitDefaultValue = false)]
        public UnitEnum Unit { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Dimensions" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public Dimensions() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Dimensions" /> class.
        /// </summary>
        /// <param name="Length">The length of the container. (required).</param>
        /// <param name="Width">The width of the container. (required).</param>
        /// <param name="Height">The height of the container. (required).</param>
        /// <param name="Unit">The unit of these measurements. (required).</param>
        public Dimensions(decimal? Length = default(decimal?), decimal? Width = default(decimal?), decimal? Height = default(decimal?), UnitEnum Unit = default(UnitEnum))
        {
            // to ensure "Length" is required (not null)
            if (Length == null)
            {
                throw new InvalidDataException("Length is a required property for Dimensions and cannot be null");
            }
            else
            {
                this.Length = Length;
            }
            // to ensure "Width" is required (not null)
            if (Width == null)
            {
                throw new InvalidDataException("Width is a required property for Dimensions and cannot be null");
            }
            else
            {
                this.Width = Width;
            }
            // to ensure "Height" is required (not null)
            if (Height == null)
            {
                throw new InvalidDataException("Height is a required property for Dimensions and cannot be null");
            }
            else
            {
                this.Height = Height;
            }
            // to ensure "Unit" is required (not null)
            if (Unit == null)
            {
                throw new InvalidDataException("Unit is a required property for Dimensions and cannot be null");
            }
            else
            {
                this.Unit = Unit;
            }
        }

        /// <summary>
        /// The length of the container.
        /// </summary>
        /// <value>The length of the container.</value>
        [DataMember(Name = "length", EmitDefaultValue = false)]
        public decimal? Length { get; set; }

        /// <summary>
        /// The width of the container.
        /// </summary>
        /// <value>The width of the container.</value>
        [DataMember(Name = "width", EmitDefaultValue = false)]
        public decimal? Width { get; set; }

        /// <summary>
        /// The height of the container.
        /// </summary>
        /// <value>The height of the container.</value>
        [DataMember(Name = "height", EmitDefaultValue = false)]
        public decimal? Height { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Dimensions {\n");
            sb.Append("  Length: ").Append(Length).Append("\n");
            sb.Append("  Width: ").Append(Width).Append("\n");
            sb.Append("  Height: ").Append(Height).Append("\n");
            sb.Append("  Unit: ").Append(Unit).Append("\n");
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
            return this.Equals(input as Dimensions);
        }

        /// <summary>
        /// Returns true if Dimensions instances are equal
        /// </summary>
        /// <param name="input">Instance of Dimensions to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Dimensions input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Length == input.Length ||
                    (this.Length != null &&
                    this.Length.Equals(input.Length))
                ) &&
                (
                    this.Width == input.Width ||
                    (this.Width != null &&
                    this.Width.Equals(input.Width))
                ) &&
                (
                    this.Height == input.Height ||
                    (this.Height != null &&
                    this.Height.Equals(input.Height))
                ) &&
                (
                    this.Unit == input.Unit ||
                    (this.Unit != null &&
                    this.Unit.Equals(input.Unit))
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
                if (this.Length != null)
                    hashCode = hashCode * 59 + this.Length.GetHashCode();
                if (this.Width != null)
                    hashCode = hashCode * 59 + this.Width.GetHashCode();
                if (this.Height != null)
                    hashCode = hashCode * 59 + this.Height.GetHashCode();
                if (this.Unit != null)
                    hashCode = hashCode * 59 + this.Unit.GetHashCode();
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
