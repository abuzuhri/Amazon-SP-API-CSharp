using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Additional address components that provide more detailed location information, helping with precise delivery routing.
    /// </summary>
    [DataContract]
    public partial class AddressExtendedFields : IEquatable<AddressExtendedFields>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressExtendedFields" /> class.
        /// </summary>
        public AddressExtendedFields() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressExtendedFields" /> class.
        /// </summary>
        /// <param name="streetName">The name of the street.</param>
        /// <param name="streetNumber">The house, building, or property number associated with the location's street address.</param>
        /// <param name="complement">The floor number / unit number.</param>
        /// <param name="neighborhood">The neighborhood. This value is only used in some countries (such as Brazil).</param>
        public AddressExtendedFields(string streetName,
                                     string streetNumber,
                                     string complement,
                                     string neighborhood)
        {
            this.StreetName = streetName;
            this.StreetNumber = streetNumber;
            this.Complement = complement;
            this.Neighborhood = neighborhood;
        }

        /// <summary>
        /// The name of the street.
        /// </summary>
        /// <value>The name of the street.</value>
        [DataMember(Name = "streetName", EmitDefaultValue = false)]
        public string StreetName { get; set; }

        /// <summary>
        /// The house, building, or property number associated with the location's street address.
        /// </summary>
        /// <value>The house, building, or property number associated with the location's street address.</value>
        [DataMember(Name = "streetNumber", EmitDefaultValue = false)]
        public string StreetNumber { get; set; }

        /// <summary>
        /// The floor number / unit number.
        /// </summary>
        /// <value>The floor number / unit number.</value>
        [DataMember(Name = "complement", EmitDefaultValue = false)]
        public string Complement { get; set; }

        /// <summary>
        /// The neighborhood. This value is only used in some countries (such as Brazil).
        /// </summary>
        /// <value>The neighborhood. This value is only used in some countries (such as Brazil).</value>
        [DataMember(Name = "neighborhood", EmitDefaultValue = false)]
        public string Neighborhood { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AddressExtendedFields {\n");
            sb.Append("  StreetName: ").Append(StreetName).Append("\n");
            sb.Append("  StreetNumber: ").Append(StreetNumber).Append("\n");
            sb.Append("  Complement: ").Append(Complement).Append("\n");
            sb.Append("  Neighborhood: ").Append(Neighborhood).Append("\n");
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
            return this.Equals(obj as AddressExtendedFields);
        }

        /// <summary>
        /// Returns true if AddressExtendedFields instances are equal
        /// </summary>
        /// <param name="input">Instance of AddressExtendedFields to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AddressExtendedFields input)
        {
            if (input == null)
                return false;

            return
                (
                    this.StreetName == input.StreetName ||
                    (this.StreetName != null &&
                    this.StreetName.Equals(input.StreetName))
                ) &&
                (
                    this.StreetNumber == input.StreetNumber ||
                    (this.StreetNumber != null &&
                    this.StreetNumber.Equals(input.StreetNumber))
                ) &&
                (
                    this.Complement == input.Complement ||
                    (this.Complement != null &&
                    this.Complement.Equals(input.Complement))
                ) &&
                (
                    this.Neighborhood == input.Neighborhood ||
                    (this.Neighborhood != null &&
                    this.Neighborhood.Equals(input.Neighborhood))
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
                if (this.StreetName != null)
                    hashCode = hashCode * 59 + this.StreetName.GetHashCode();
                if (this.StreetNumber != null)
                    hashCode = hashCode * 59 + this.StreetNumber.GetHashCode();
                if (this.Complement != null)
                    hashCode = hashCode * 59 + this.Complement.GetHashCode();
                if (this.Neighborhood != null)
                    hashCode = hashCode * 59 + this.Neighborhood.GetHashCode();
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