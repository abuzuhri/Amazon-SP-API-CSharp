using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// The expense information related to this specific item.
    /// </summary>
    [DataContract]
    public partial class Expense : IEquatable<Expense>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Expense" /> class.
        /// </summary>
        public Expense() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Expense" /> class.
        /// </summary>
        /// <param name="pointsCost">Information about Amazon Points granted with the purchase of an item, including both quantity and monetary equivalent value.</param>
        public Expense(PointsCost pointsCost = default)
        {
            this.PointsCost = pointsCost;
        }

        /// <summary>
        /// Information about Amazon Points granted with the purchase of an item, including both quantity and monetary equivalent value.
        /// </summary>
        /// <value>Information about Amazon Points granted with the purchase of an item, including both quantity and monetary equivalent value.</value>
        [DataMember(Name = "pointsCost", EmitDefaultValue = false)]
        public PointsCost PointsCost { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Expense {\n");
            sb.Append("  PointsCost: ").Append(PointsCost).Append("\n");
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
            return this.Equals(input as Expense);
        }

        /// <summary>
        /// Returns true if Expense instances are equal
        /// </summary>
        /// <param name="input">Instance of Expense to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Expense input)
        {
            if (input == null)
                return false;

            return
                (
                    this.PointsCost == input.PointsCost ||
                    (this.PointsCost != null &&
                    this.PointsCost.Equals(input.PointsCost))
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
                if (this.PointsCost != null)
                    hashCode = hashCode * 59 + this.PointsCost.GetHashCode();

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