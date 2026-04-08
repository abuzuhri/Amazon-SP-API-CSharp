using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// The money that the seller receives from the sale of the order.
    /// </summary>
    [DataContract]
    public partial class OrderProceeds : IEquatable<OrderProceeds>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderProceeds" /> class.
        /// </summary>
        public OrderProceeds()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderProceeds" /> class.
        /// </summary>
        /// <param name="grandTotal">An amount of money, including units in the form of currency.</param>
        public OrderProceeds(Money grandTotal = default)
        {
            this.GrandTotal = grandTotal;
        }

        /// <summary>
        /// An amount of money, including units in the form of currency.
        /// </summary>
        /// <value>An amount of money, including units in the form of currency.</value>
        [DataMember(Name = "grandTotal", EmitDefaultValue = false)]
        public Money GrandTotal { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderProceeds {\n");
            sb.Append("  GrandTotal: ").Append(GrandTotal).Append("\n");
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
            return this.Equals(input as OrderProceeds);
        }

        /// <summary>
        /// Returns true if OrderProceeds instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderProceeds to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderProceeds input)
        {
            if (input == null)
                return false;

            return
                (
                    this.GrandTotal == input.GrandTotal ||
                    (this.GrandTotal != null &&
                    this.GrandTotal.Equals(input.GrandTotal))
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
                if (this.GrandTotal != null)
                    hashCode = hashCode * 59 + this.GrandTotal.GetHashCode();
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