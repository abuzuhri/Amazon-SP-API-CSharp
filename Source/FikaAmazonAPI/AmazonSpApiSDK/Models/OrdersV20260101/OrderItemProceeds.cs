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
    /// The money that the seller receives from the sale of this specific item.
    /// </summary>
    [DataContract]
    public partial class OrderItemProceeds : IEquatable<OrderItemProceeds>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItemProceeds" /> class.
        /// </summary>
        public OrderItemProceeds()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItemProceeds" /> class.
        /// </summary>
        /// <param name="proceedsTotal">An amount of money, including units in the form of currency.</param>
        /// <param name="breakdowns">The breakdown of proceeds.</param>
        public OrderItemProceeds(Money proceedsTotal, List<OrderItemProceedsBreakdown> breakdowns)
        {
            this.ProceedsTotal = proceedsTotal;
            this.Breakdowns = breakdowns;
        }

        /// <summary>
        /// An amount of money, including units in the form of currency.
        /// </summary>
        /// <value>An amount of money, including units in the form of currency.</value>
        [DataMember(Name = "proceedsTotal", EmitDefaultValue = false)]
        public Money ProceedsTotal { get; set; }

        /// <summary>
        /// The breakdown of proceeds.
        /// </summary>
        /// <value>The breakdown of proceeds.</value>
        [DataMember(Name = "breakdowns", EmitDefaultValue = false)]
        public List<OrderItemProceedsBreakdown> Breakdowns { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderItemProceeds {\n");
            sb.Append("  ProceedsTotal: ").Append(ProceedsTotal).Append("\n");
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
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as OrderItemProceeds);
        }

        /// <summary>
        /// Returns true if OrderItemProceeds instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderItemProceeds to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderItemProceeds input)
        {
            if (input == null)
                return false;

            return
                (
                    this.ProceedsTotal == input.ProceedsTotal ||
                    (this.ProceedsTotal != null &&
                    this.ProceedsTotal.Equals(input.ProceedsTotal))
                ) &&
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
                if (this.ProceedsTotal != null)
                    hashCode = hashCode * 59 + this.ProceedsTotal.GetHashCode();
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