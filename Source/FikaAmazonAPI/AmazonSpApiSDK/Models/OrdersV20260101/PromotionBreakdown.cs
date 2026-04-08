using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Promotion applied to the order item.
    /// </summary>
    [DataContract]
    public partial class PromotionBreakdown : IEquatable<PromotionBreakdown>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PromotionBreakdown" /> class.
        /// </summary>
        public PromotionBreakdown()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PromotionBreakdown" /> class.
        /// </summary>
        /// <param name="promotionId">Unique identifier for the promotion applied to this item.</param>
        public PromotionBreakdown(string promotionId = default)
        {
            this.PromotionId = promotionId;
        }

        /// <summary>
        /// Unique identifier for the promotion applied to this item.
        /// </summary>
        /// <value>Unique identifier for the promotion applied to this item.</value>
        [DataMember(Name = "promotionId", EmitDefaultValue = false)]
        public string PromotionId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PromotionBreakdown {\n");
            sb.Append("  PromotionId: ").Append(PromotionId).Append("\n");
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
            return this.Equals(input as PromotionBreakdown);
        }

        /// <summary>
        /// Returns true if PromotionBreakdown instances are equal
        /// </summary>
        /// <param name="input">Instance of PromotionBreakdown to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PromotionBreakdown input)
        {
            if (input == null)
                return false;

            return
                (
                    this.PromotionId == input.PromotionId ||
                    (this.PromotionId != null &&
                    this.PromotionId.Equals(input.PromotionId))
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
                if (this.PromotionId != null)
                    hashCode = hashCode * 59 + this.PromotionId.GetHashCode();

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