using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Information about how the order item should be processed, packed, and shipped to the customer.
    /// </summary>
    [DataContract]
    public partial class OrderItemFulfillment : IEquatable<OrderItemFulfillment>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItemFulfillment" /> class.
        /// </summary>
        public OrderItemFulfillment() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItemFulfillment" /> class.
        /// </summary>
        /// <param name="quantityFulfilled">The number of units of this item that have been successfully processed and shipped.</param>
        /// <param name="quantityUnfulfilled">The number of units of this item that remain to be processed and shipped.</param>
        /// <param name="picking">Information related to the warehouse picking process for an order item.</param>
        /// <param name="packing">Information related to the packaging process for an order item.</param>
        /// <param name="shipping">Information related to the shipping and delivery process for an order item.</param>

        public OrderItemFulfillment(int? quantityFulfilled,
                                    int? quantityUnfulfilled,
                                    Picking picking,
                                    Packing packing,
                                    Shipping shipping)
        {
            this.QuantityFulfilled = quantityFulfilled;
            this.QuantityUnfulfilled = quantityUnfulfilled;
            this.Picking = picking;
            this.Packing = packing;
            this.Shipping = shipping;
        }


        /// <summary>
        /// The number of units of this item that have been successfully processed and shipped.
        /// </summary>
        /// <value>The number of units of this item that have been successfully processed and shipped.</value>
        [DataMember(Name = "quantityFulfilled", EmitDefaultValue = false)]
        public int? QuantityFulfilled { get; set; }

        /// <summary>
        /// The number of units of this item that remain to be processed and shipped.
        /// </summary>
        /// <value>The number of units of this item that remain to be processed and shipped.</value>
        [DataMember(Name = "quantityUnfulfilled", EmitDefaultValue = false)]
        public int? QuantityUnfulfilled { get; set; }

        /// <summary>
        /// Information related to the warehouse picking process for an order item.
        /// </summary>
        /// <value>Information related to the warehouse picking process for an order item.</value>
        [DataMember(Name = "picking", EmitDefaultValue = false)]
        public Picking Picking { get; set; }

        /// <summary>
        /// Information related to the packaging process for an order item.
        /// </summary>
        /// <value>Information related to the packaging process for an order item.</value>
        [DataMember(Name = "packing", EmitDefaultValue = false)]
        public Packing Packing { get; set; }

        /// <summary>
        /// Information related to the shipping and delivery process for an order item.
        /// </summary>
        /// <value>Information related to the shipping and delivery process for an order item.</value>
        [DataMember(Name = "shipping", EmitDefaultValue = false)]
        public Shipping Shipping { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderItemFulfillment {\n");
            sb.Append("  QuantityFulfilled: ").Append(QuantityFulfilled).Append("\n");
            sb.Append("  QuantityUnfulfilled: ").Append(QuantityUnfulfilled).Append("\n");
            sb.Append("  Picking: ").Append(Picking).Append("\n");
            sb.Append("  Packing: ").Append(Packing).Append("\n");
            sb.Append("  Shipping: ").Append(Shipping).Append("\n");
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
            return this.Equals(obj as OrderItemFulfillment);
        }

        /// <summary>
        /// Returns true if OrderItemFulfillment instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderItemFulfillment to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderItemFulfillment input)
        {
            if (input == null)
                return false;

            return
                (
                    this.QuantityFulfilled == input.QuantityFulfilled ||
                    (this.QuantityFulfilled != null &&
                    this.QuantityFulfilled.Equals(input.QuantityFulfilled))
                ) &&
                (
                    this.QuantityUnfulfilled == input.QuantityUnfulfilled ||
                    (this.QuantityUnfulfilled != null &&
                    this.QuantityUnfulfilled.Equals(input.QuantityUnfulfilled))
                ) &&
                (
                    this.Picking == input.Picking ||
                    (this.Picking != null &&
                    this.Picking.Equals(input.Picking))
                ) &&
                (
                    this.Packing == input.Packing ||
                    (this.Packing != null &&
                    this.Packing.Equals(input.Packing))
                ) &&
                (
                    this.Shipping == input.Shipping ||
                    (this.Shipping != null &&
                    this.Shipping.Equals(input.Shipping))
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
                if (this.QuantityFulfilled != null)
                    hashCode = hashCode * 59 + this.QuantityFulfilled.GetHashCode();
                if (this.QuantityUnfulfilled != null)
                    hashCode = hashCode * 59 + this.QuantityUnfulfilled.GetHashCode();
                if (this.Picking != null)
                    hashCode = hashCode * 59 + this.Picking.GetHashCode();
                if (this.Packing != null)
                    hashCode = hashCode * 59 + this.Packing.GetHashCode();
                if (this.Shipping != null)
                    hashCode = hashCode * 59 + this.Shipping.GetHashCode();
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