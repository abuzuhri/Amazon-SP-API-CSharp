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
    /// OrderItemProceedsDetailedBreakdown
    /// </summary>
    [DataContract]
    public partial class OrderItemProceedsDetailedBreakdown : IEquatable<OrderItemProceedsDetailedBreakdown>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItemProceedsDetailedBreakdown" /> class.
        /// </summary>
        public OrderItemProceedsDetailedBreakdown() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItemProceedsDetailedBreakdown" /> class.
        /// </summary>
        /// <param name="subtype">Specific classification of the further granular breakdown.</param>
        /// <param name="value">An amount of money, including units in the form of currency.</param>
        public OrderItemProceedsDetailedBreakdown(ProceedsBreakdownSubtypeEnum? subtype, Money value)
        {
            this.Subtype = subtype;
            this.Value = value;
        }

        /// <summary>
        /// Specific classification of the further granular breakdown.
        /// </summary>
        /// <value>Specific classification of the further granular breakdown.</value>
        [DataMember(Name = "subtype", EmitDefaultValue = false)]
        public ProceedsBreakdownSubtypeEnum? Subtype { get; set; }

        /// <summary>
        /// An amount of money, including units in the form of currency.
        /// </summary>
        /// <value>An amount of money, including units in the form of currency.</value>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public Money Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderItemProceedsDetailedBreakdown {\n");
            sb.Append("  Subtype: ").Append(Subtype).Append("\n");
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
            return this.Equals(obj as OrderItemProceedsDetailedBreakdown);
        }

        /// <summary>
        /// Returns true if OrderItemProceedsDetailedBreakdown instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderItemProceedsDetailedBreakdown to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderItemProceedsDetailedBreakdown input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Subtype == input.Subtype ||
                    (this.Subtype != null &&
                    this.Subtype.Equals(input.Subtype))
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
                if (this.Subtype != null)
                    hashCode = hashCode * 59 + this.Subtype.GetHashCode();
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