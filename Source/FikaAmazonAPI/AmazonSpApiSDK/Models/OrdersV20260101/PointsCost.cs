using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Information about Amazon Points granted with the purchase of an item, including both quantity and monetary equivalent value.
    /// </summary>
    [DataContract]
    public partial class PointsCost : IEquatable<PointsCost>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PointsCost" /> class.
        /// </summary>
        public PointsCost()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PointsCost" /> class.
        /// </summary>
        /// <param name="pointsGranted">Information about Amazon Points awarded with an item purchase.</param>

        public PointsCost(PointsGranted pointsGranted = default)
        {
            this.PointsGranted = pointsGranted;
        }

        /// <summary>
        /// Information about Amazon Points awarded with an item purchase.
        /// </summary>
        /// <value>Information about Amazon Points awarded with an item purchase.</value>
        [DataMember(Name = "pointsGranted", EmitDefaultValue = false)]
        public PointsGranted PointsGranted { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PointsCost {\n");
            sb.Append("  PointsGranted: ").Append(PointsGranted).Append("\n");
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
            return this.Equals(input as PointsCost);
        }

        /// <summary>
        /// Returns true if PointsCost instances are equal
        /// </summary>
        /// <param name="input">Instance of PointsCost to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PointsCost input)
        {
            if (input == null)
                return false;

            return
                (
                    this.PointsGranted == input.PointsGranted ||
                    (this.PointsGranted != null &&
                    this.PointsGranted.Equals(input.PointsGranted))
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
                if (this.PointsGranted != null)
                    hashCode = hashCode * 59 + this.PointsGranted.GetHashCode();
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