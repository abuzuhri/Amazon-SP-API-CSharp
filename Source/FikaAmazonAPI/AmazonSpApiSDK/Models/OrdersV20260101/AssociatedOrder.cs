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
    /// Other order that has a direct relationship to order, such as replacement or exchange order.
    /// </summary>
    [DataContract]
    public partial class AssociatedOrder : IEquatable<AssociatedOrder>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssociatedOrder" /> class.
        /// </summary>
        public AssociatedOrder() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssociatedOrder" /> class.
        /// </summary>
        /// <param name="orderId">The unique identifier of the related order that is associated with the current order.</param>
        /// <param name="associationType">The relationship between the current order and the associated order.</param>
        public AssociatedOrder(string orderId = default, OrderAssociationTypeEnum? associationType = default)
        {
            this.OrderId = orderId;
            this.AssociationType = associationType;
        }


        /// <summary>
        /// The unique identifier of the related order that is associated with the current order.
        /// </summary>
        /// <value>The unique identifier of the related order that is associated with the current order.</value>
        [DataMember(Name = "orderId", EmitDefaultValue = false)]
        public string OrderId { get; set; }

        /// <summary>
        /// The relationship between the current order and the associated order. Possible values: REPLACEMENT_ORIGINAL_ID, EXCHANGE_ORIGINAL_ID
        /// </summary>
        /// <value>The relationship between the current order and the associated order. Possible values: REPLACEMENT_ORIGINAL_ID, EXCHANGE_ORIGINAL_ID</value>
        [DataMember(Name = "associationType", EmitDefaultValue = false)]
        public OrderAssociationTypeEnum? AssociationType { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AssociatedOrder {\n");
            sb.Append("  OrderId: ").Append(OrderId).Append("\n");
            sb.Append("  AssociationType: ").Append(AssociationType).Append("\n");
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
            return this.Equals(input as AssociatedOrder);
        }

        /// <summary>
        /// Returns true if AssociatedOrder instances are equal
        /// </summary>
        /// <param name="input">Instance of AssociatedOrder to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AssociatedOrder input)
        {
            if (input == null)
                return false;

            return
                (
                    this.OrderId == input.OrderId ||
                    (this.OrderId != null &&
                    this.OrderId.Equals(input.OrderId))
                ) &&
                (
                    this.AssociationType == input.AssociationType ||
                    (this.AssociationType != null &&
                    this.AssociationType.Equals(input.AssociationType))
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
                if (this.OrderId != null)
                    hashCode = hashCode * 59 + this.OrderId.GetHashCode();
                if (this.AssociationType != null)
                    hashCode = hashCode * 59 + this.AssociationType.GetHashCode();
             
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