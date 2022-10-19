using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders
{
    [DataContract]
    public partial class orderedQuantity : IEquatable<orderedQuantity>, IValidatableObject
    {
        [JsonConstructorAttribute]
        public orderedQuantity() { }
        public orderedQuantity(ItemQuantity orderedQuantity = default(ItemQuantity), List<OrderedQuantityDetails> orderedQuantityDetails = default(List<OrderedQuantityDetails>))
        {
            this.OrderedQuantity = orderedQuantity;
            this.OrderedQuantityDetails = orderedQuantityDetails;
        }

        [DataMember(Name = "orderedQuantity", EmitDefaultValue = false)]
        public ItemQuantity OrderedQuantity { get; set; }

        [DataMember(Name = "orderedQuantityDetails", EmitDefaultValue = false)]
        public List<OrderedQuantityDetails> OrderedQuantityDetails { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class orderedQuantity {\n");
            sb.Append("  OrderedQuantity: ").Append(OrderedQuantity).Append("\n");
            sb.Append("  OrderedQuantityDetails: ").Append(OrderedQuantityDetails).Append("\n");
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
            return this.Equals(input as orderedQuantity);
        }

        /// <summary>
        /// Returns true if ItemQuantity instances are equal
        /// </summary>
        /// <param name="input">Instance of ItemQuantity to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(orderedQuantity input)
        {
            if (input == null)
                return false;

            return
                (
                    this.OrderedQuantity == input.OrderedQuantity ||
                    (this.OrderedQuantity != null &&
                    this.OrderedQuantity.Equals(input.OrderedQuantity))
                ) &&
                (
                    this.OrderedQuantityDetails == input.OrderedQuantityDetails ||
                    (this.OrderedQuantityDetails != null &&
                    this.OrderedQuantityDetails.Equals(input.OrderedQuantityDetails))
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
                if (this.OrderedQuantity != null)
                    hashCode = hashCode * 59 + this.OrderedQuantity.GetHashCode();
                if (this.OrderedQuantityDetails != null)
                    hashCode = hashCode * 59 + this.OrderedQuantityDetails.GetHashCode();
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
