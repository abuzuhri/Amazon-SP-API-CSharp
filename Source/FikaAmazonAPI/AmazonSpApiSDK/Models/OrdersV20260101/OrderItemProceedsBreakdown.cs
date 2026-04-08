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
    /// OrderItemProceedsBreakdown
    /// </summary>
    [DataContract]
    public partial class OrderItemProceedsBreakdown : IEquatable<OrderItemProceedsBreakdown>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItemProceedsBreakdown" /> class.
        /// </summary>
        public OrderItemProceedsBreakdown() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItemProceedsBreakdown" /> class.
        /// </summary>
        /// <param name="type">Category classification of the proceeds breakdown.</param>
        /// <param name="subtotal">An amount of money, including units in the form of currency.</param>
        /// <param name="detailedBreakdowns">Further granular breakdown of the subtotal.</param>
        public OrderItemProceedsBreakdown(ProceedsBreakdownTypeEnum? type,
                                          Money subtotal,
                                          List<OrderItemProceedsDetailedBreakdown> detailedBreakdowns)
        {
            this.Type = type;
            this.Subtotal = subtotal;
            this.DetailedBreakdowns = detailedBreakdowns;
        }

        /// <summary>
        /// Category classification of the proceeds breakdown.
        /// </summary>
        /// <value>Category classification of the proceeds breakdown.</value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public ProceedsBreakdownTypeEnum? Type { get; set; }

        /// <summary>
        /// An amount of money, including units in the form of currency.
        /// </summary>
        /// <value>An amount of money, including units in the form of currency.</value>
        [DataMember(Name = "subtotal", EmitDefaultValue = false)]
        public Money Subtotal { get; set; }

        /// <summary>
        /// Further granular breakdown of the subtotal.
        /// </summary>
        /// <value>Further granular breakdown of the subtotal.</value>
        [DataMember(Name = "detailedBreakdowns", EmitDefaultValue = false)]
        public List<OrderItemProceedsDetailedBreakdown> DetailedBreakdowns { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderItemProceedsBreakdown {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Subtotal: ").Append(Subtotal).Append("\n");
            sb.Append("  DetailedBreakdowns: ").Append(DetailedBreakdowns).Append("\n");
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
            return this.Equals(obj as OrderItemProceedsBreakdown);
        }

        /// <summary>
        /// Returns true if OrderItemProceedsBreakdown instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderItemProceedsBreakdown to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderItemProceedsBreakdown input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) &&
                (
                    this.Subtotal == input.Subtotal ||
                    (this.Subtotal != null &&
                    this.Subtotal.Equals(input.Subtotal))
                ) &&
                (
                    this.DetailedBreakdowns == input.DetailedBreakdowns ||
                    (this.DetailedBreakdowns != null &&
                    this.DetailedBreakdowns.SequenceEqual(input.DetailedBreakdowns))
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
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Subtotal != null)
                    hashCode = hashCode * 59 + this.Subtotal.GetHashCode();
                if (this.DetailedBreakdowns != null)
                    hashCode = hashCode * 59 + this.DetailedBreakdowns.GetHashCode();

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