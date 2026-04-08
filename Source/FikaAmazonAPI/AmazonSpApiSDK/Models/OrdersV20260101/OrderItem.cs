using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// A single order item.
    /// </summary>
    [DataContract]
    public partial class OrderItem : IEquatable<OrderItem>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItem" /> class.
        /// </summary>
        protected OrderItem() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItem" /> class.
        /// </summary>
        /// <param name="orderItemId">A unique identifier for this specific item within the order. (required)</param>
        /// <param name="quantityOrdered">The number of units of this item that the customer ordered. (required)</param>
        /// <param name="measurement">Specifies the unit of measure and quantity for items that are sold by weight, volume, length, or other measurements rather than simple count.</param>
        /// <param name="programs">Special programs that apply specifically to this item within the order.</param>
        /// <param name="product">Product information for an order item. (required)</param>
        /// <param name="proceeds">The money that the seller receives from the sale of this specific item.</param>
        /// <param name="expense">The expense information related to this specific item.</param>
        /// <param name="promotion">Details about any discounts, coupons, or promotional offers applied to this item.</param>
        /// <param name="cancellation">The cancellation information of the order item.</param>
        /// <param name="fulfillment">Information about how the order item should be processed, packed, and shipped to the customer.</param>
        public OrderItem(string orderItemId,
                         int quantityOrdered,
                         Measurement measurement,
                         List<OrderItemProgramEnum> programs,
                         Product product,
                         OrderItemProceeds proceeds,
                         Expense expense,
                         Promotion promotion,
                         Cancellation cancellation,
                         OrderItemFulfillment fulfillment)
        {
            // to ensure "orderItemId" is required (not null)
            if (orderItemId == null)
            {
                throw new InvalidDataException("orderItemId is a required property for OrderItem and cannot be null");
            }
            else
            {
                this.OrderItemId = orderItemId;
            }

            // to ensure "quantityOrdered" is required (not null)
            if (quantityOrdered == null)
            {
                throw new InvalidDataException("quantityOrdered is a required property for OrderItem and cannot be null");
            }
            else
            {
                this.QuantityOrdered = quantityOrdered;
            }

            // to ensure "product" is required (not null)
            if (product == null)
            {
                throw new InvalidDataException("product is a required property for OrderItem and cannot be null");
            }
            else
            {
                this.Product = product;
            }

            this.Measurement = measurement;
            this.Programs = programs;
            this.Proceeds = proceeds;
            this.Expense = expense;
            this.Promotion = promotion;
            this.Cancellation = cancellation;
            this.Fulfillment = fulfillment;
        }

        /// <summary>
        /// A unique identifier for this specific item within the order. (required)
        /// </summary>
        /// <value>A unique identifier for this specific item within the order. (required)</value>
        [DataMember(Name = "orderItemId", EmitDefaultValue = false)]
        public string OrderItemId { get; set; }

        /// <summary>
        /// The number of units of this item that the customer ordered. (required)
        /// </summary>
        /// <value>The number of units of this item that the customer ordered. (required)</value>
        [DataMember(Name = "quantityOrdered", EmitDefaultValue = false)]
        public int QuantityOrdered { get; set; }

        /// <summary>
        /// Specifies the unit of measure and quantity for items that are sold by weight, volume, length, or other measurements rather than simple count.
        /// </summary>
        /// <value>Specifies the unit of measure and quantity for items that are sold by weight, volume, length, or other measurements rather than simple count.</value>
        [DataMember(Name = "measurement", EmitDefaultValue = false)]
        public Measurement Measurement { get; set; }

        /// <summary>
        /// Special programs that apply specifically to this item within the order.
        /// </summary>
        /// <value>Special programs that apply specifically to this item within the order.</value>
        [DataMember(Name = "programs", EmitDefaultValue = false)]
        public List<OrderItemProgramEnum> Programs { get; set; }

        /// <summary>
        /// Product information for an order item. (required)
        /// </summary>
        /// <value>Product information for an order item. (required)</value>
        [DataMember(Name = "product", EmitDefaultValue = false)]
        public Product Product { get; set; }

        /// <summary>
        /// The money that the seller receives from the sale of this specific item.
        /// </summary>
        /// <value>The money that the seller receives from the sale of this specific item.</value>
        [DataMember(Name = "proceeds", EmitDefaultValue = false)]
        public OrderItemProceeds Proceeds { get; set; }

        /// <summary>
        /// The expense information related to this specific item.
        /// </summary>
        /// <value>The expense information related to this specific item.</value>
        [DataMember(Name = "expense", EmitDefaultValue = false)]
        public Expense Expense { get; set; }

        /// <summary>
        /// Details about any discounts, coupons, or promotional offers applied to this item.
        /// </summary>
        /// <value>Details about any discounts, coupons, or promotional offers applied to this item.</value>
        [DataMember(Name = "promotion", EmitDefaultValue = false)]
        public Promotion Promotion { get; set; }

        /// <summary>
        /// The cancellation information of the order item.
        /// </summary>
        /// <value>The cancellation information of the order item.</value>
        [DataMember(Name = "cancellation", EmitDefaultValue = false)]
        public Cancellation Cancellation { get; set; }

        /// <summary>
        /// Information about how the order item should be processed, packed, and shipped to the customer.
        /// </summary>
        /// <value>Information about how the order item should be processed, packed, and shipped to the customer.</value>
        [DataMember(Name = "fulfillment", EmitDefaultValue = false)]
        public OrderItemFulfillment Fulfillment { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderItem {\n");
            sb.Append("  OrderItemId: ").Append(OrderItemId).Append("\n");
            sb.Append("  QuantityOrdered: ").Append(QuantityOrdered).Append("\n");
            sb.Append("  Measurement: ").Append(Measurement).Append("\n");
            sb.Append("  Programs: ").Append(Programs).Append("\n");
            sb.Append("  Product: ").Append(Product).Append("\n");
            sb.Append("  Proceeds: ").Append(Proceeds).Append("\n");
            sb.Append("  Expense: ").Append(Expense).Append("\n");
            sb.Append("  Promotion: ").Append(Promotion).Append("\n");
            sb.Append("  Cancellation: ").Append(Cancellation).Append("\n");
            sb.Append("  Fulfillment: ").Append(Fulfillment).Append("\n");
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
            return this.Equals(obj as OrderItem);
        }

        /// <summary>
        /// Returns true if OrderItem instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderItem to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderItem input)
        {
            if (input == null)
                return false;

            return
                (
                    this.OrderItemId == input.OrderItemId ||
                    (this.OrderItemId != null &&
                    this.OrderItemId.Equals(input.OrderItemId))
                ) &&
                (
                    this.QuantityOrdered == input.QuantityOrdered ||
                    (this.QuantityOrdered != null &&
                    this.QuantityOrdered.Equals(input.QuantityOrdered))
                ) &&
                (
                    this.Measurement == input.Measurement ||
                    (this.Measurement != null &&
                    this.Measurement.Equals(input.Measurement))
                ) &&
                (
                    this.Programs == input.Programs ||
                    (this.Programs != null &&
                    this.Programs.SequenceEqual(input.Programs))
                ) &&
                (
                    this.Product == input.Product ||
                    (this.Product != null &&
                    this.Product.Equals(input.Product))
                ) &&
                (
                    this.Proceeds == input.Proceeds ||
                    (this.Proceeds != null &&
                    this.Proceeds.Equals(input.Proceeds))
                ) &&
                (
                    this.Expense == input.Expense ||
                    (this.Expense != null &&
                    this.Expense.Equals(input.Expense))
                ) &&
                (
                    this.Promotion == input.Promotion ||
                    (this.Promotion != null &&
                    this.Promotion.Equals(input.Promotion))
                ) &&
                (
                    this.Cancellation == input.Cancellation ||
                    (this.Cancellation != null &&
                    this.Cancellation.Equals(input.Cancellation))
                ) &&
                (
                    this.Fulfillment == input.Fulfillment ||
                    (this.Fulfillment != null &&
                    this.Fulfillment.Equals(input.Fulfillment))
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
                if (this.OrderItemId != null)
                    hashCode = hashCode * 59 + this.OrderItemId.GetHashCode();
                if (this.QuantityOrdered != null)
                    hashCode = hashCode * 59 + this.QuantityOrdered.GetHashCode();
                if (this.Measurement != null)
                    hashCode = hashCode * 59 + this.Measurement.GetHashCode();
                if (this.Programs != null)
                    hashCode = hashCode * 59 + this.Programs.GetHashCode();
                if (this.Product != null)
                    hashCode = hashCode * 59 + this.Product.GetHashCode();
                if (this.Proceeds != null)
                    hashCode = hashCode * 59 + this.Proceeds.GetHashCode();
                if (this.Expense != null)
                    hashCode = hashCode * 59 + this.Expense.GetHashCode();
                if (this.Promotion != null)
                    hashCode = hashCode * 59 + this.Promotion.GetHashCode();
                if (this.Cancellation != null)
                    hashCode = hashCode * 59 + this.Cancellation.GetHashCode();
                if (this.Fulfillment != null)
                    hashCode = hashCode * 59 + this.Fulfillment.GetHashCode();
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
