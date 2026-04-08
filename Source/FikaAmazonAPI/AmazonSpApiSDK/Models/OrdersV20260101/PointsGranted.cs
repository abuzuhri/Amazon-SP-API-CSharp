using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Information about Amazon Points awarded with an item purchase.
    /// </summary>
    [DataContract]
    public partial class PointsGranted : IEquatable<PointsGranted>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PointsGranted" /> class.
        /// </summary>
        public PointsGranted()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PointsGranted" /> class.
        /// </summary>
        /// <param name="pointsNumber">Total number of Amazon Points granted to the customer's account for this item purchase.</param>
        /// <param name="pointsMonetaryValue">An amount of money, including units in the form of currency.</param>
        public PointsGranted(int? pointsNumber = default, Money pointsMonetaryValue = default)
        {
            PointsNumber = pointsNumber;
            PointsMonetaryValue = pointsMonetaryValue;
        }

        /// <summary>
        /// Total number of Amazon Points granted to the customer's account for this item purchase.
        /// </summary>
        /// <value>Total number of Amazon Points granted to the customer's account for this item purchase.</value>
        [DataMember(Name = "pointsNumber", EmitDefaultValue = false)]
        public int? PointsNumber { get; set; }

        /// <summary>
        /// An amount of money, including units in the form of currency.
        /// </summary>
        /// <value>An amount of money, including units in the form of currency.</value>
        [DataMember(Name = "pointsMonetaryValue", EmitDefaultValue = false)]
        public Money PointsMonetaryValue { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PointsGranted {\n");
            sb.Append("  PointsNumber: ").Append(PointsNumber).Append("\n");
            sb.Append("  PointsMonetaryValue: ").Append(PointsMonetaryValue).Append("\n");
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
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as PointsGranted);
        }

        /// <summary>
        /// Returns true if PointsGranted instances are equal
        /// </summary>
        /// <param name="input">Instance of PointsGranted to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PointsGranted input)
        {
            if (input == null)
                return false;

            return
                (
                    this.PointsNumber == input.PointsNumber ||
                    (this.PointsNumber != null &&
                    this.PointsNumber.Equals(input.PointsNumber))
                ) &&
                (
                    this.PointsMonetaryValue == input.PointsMonetaryValue ||
                    (this.PointsMonetaryValue != null &&
                    this.PointsMonetaryValue.Equals(input.PointsMonetaryValue))
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
                if (this.PointsNumber != null)
                    hashCode = hashCode * 59 + this.PointsNumber.GetHashCode();
                if (this.PointsMonetaryValue != null)
                    hashCode = hashCode * 59 + this.PointsMonetaryValue.GetHashCode();
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