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
    /// Details about any discounts, coupons, or promotional offers applied to this item.
    /// </summary>
    [DataContract]
    public partial class Promotion : IEquatable<Promotion>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Promotion" /> class.
        /// </summary>
        public Promotion()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Promotion" /> class.
        /// </summary>
        /// <param name="breakdowns">A list of promotions applied to the order item.</param>
        public Promotion(List<PromotionBreakdown> breakdowns = default)
        {
            this.Breakdowns = breakdowns;
        }

        /// <summary>
        /// A list of promotions applied to the order item.
        /// </summary>
        /// <value>A list of promotions applied to the order item.</value>
        [DataMember(Name = "breakdowns", EmitDefaultValue = false)]
        public List<PromotionBreakdown> Breakdowns { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Promotion {\n");
            sb.Append("  Breakdowns: ").Append(Breakdowns).Append("\n");
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
            return this.Equals(input as Promotion);
        }

        /// <summary>
        /// Returns true if Promotion instances are equal
        /// </summary>
        /// <param name="input">Instance of Promotion to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Promotion input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Breakdowns == input.Breakdowns ||
                    (this.Breakdowns != null &&
                    this.Breakdowns.SequenceEqual(input.Breakdowns))
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
                if (this.Breakdowns != null)
                    hashCode = hashCode * 59 + this.Breakdowns.GetHashCode();
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