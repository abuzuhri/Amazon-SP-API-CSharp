using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders
{
    [DataContract]
    public partial class OrderedQuantityDetails : IEquatable<OrderedQuantityDetails>, IValidatableObject
    {
        [JsonConstructorAttribute]
        public OrderedQuantityDetails() { }
        public OrderedQuantityDetails(DateTime? updatedDate = default(DateTime?), ItemQuantity orderedQuantity = default(ItemQuantity), ItemQuantity cancelledQuantity = default(ItemQuantity))
        {
            this.UpdatedDate = updatedDate;
            this.OrderedQuantity = orderedQuantity;
            this.CancelledQuantity = cancelledQuantity;
        }

        [DataMember(Name = "updatedDate", EmitDefaultValue = false)]
        public DateTime? UpdatedDate { get; set; }

        [DataMember(Name = "orderedQuantity", EmitDefaultValue = false)]
        public ItemQuantity OrderedQuantity { get; set; }

        [DataMember(Name = "cancelledQuantity", EmitDefaultValue = false)]
        public ItemQuantity CancelledQuantity { get; set; }



        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderedQuantityDetails {\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
            sb.Append("  OrderedQuantity: ").Append(OrderedQuantity).Append("\n");
            sb.Append("  CancelledQuantity: ").Append(CancelledQuantity).Append("\n");
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
        public bool Equals(OrderedQuantityDetails input)
        {
            if (input == null)
                return false;

            return
                (
                    this.UpdatedDate == input.UpdatedDate ||
                    (this.UpdatedDate != null &&
                    this.UpdatedDate.Equals(input.UpdatedDate))
                ) &&
                (
                    this.OrderedQuantity == input.OrderedQuantity ||
                    (this.OrderedQuantity != null &&
                    this.OrderedQuantity.Equals(input.OrderedQuantity))
                ) &&
                (
                    this.CancelledQuantity == input.CancelledQuantity ||
                    (this.CancelledQuantity != null &&
                    this.CancelledQuantity.Equals(input.CancelledQuantity))
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
                if (this.UpdatedDate != null)
                    hashCode = hashCode * 59 + this.UpdatedDate.GetHashCode();
                if (this.OrderedQuantity != null)
                    hashCode = hashCode * 59 + this.OrderedQuantity.GetHashCode();
                if (this.CancelledQuantity != null)
                    hashCode = hashCode * 59 + this.CancelledQuantity.GetHashCode();
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
