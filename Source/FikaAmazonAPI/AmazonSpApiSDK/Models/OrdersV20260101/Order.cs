using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Comprehensive information about a customer order.
    /// </summary>
    [DataContract]
    public partial class Order : IEquatable<Order>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Order" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public Order() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order" /> class.
        /// </summary>
        /// <param name="orderId">An Amazon-defined order identifier. (required)</param>
        /// <param name="orderAliases">Alternative identifiers that can be used to reference this order, such as seller-defined order numbers.</param>
        /// <param name="createdTime">The time when the customer placed the order. In ISO 8601 format.(required)</param>
        /// <param name="lastUpdatedTime">The most recent time when any aspect of this order was modified by Amazon or the seller. In ISO 8601 format.(required)</param>
        /// <param name="programs">Special programs associated with this order that may affect fulfillment or customer experience.</param>
        /// <param name="associatedOrders">Other orders that have a direct relationship to this order, such as replacement or exchange orders.</param>
        /// <param name="salesChannel">Information about where the customer placed this order. (required)</param>
        /// <param name="buyer">Information about the customer who purchased the order.</param>
        /// <param name="recipient">Information about the recipient to whom the order should be delivered.</param>
        /// <param name="proceeds">The money that the seller receives from the sale of the order.</param>
        /// <param name="fulfillment">Information about how the order is being processed, packed, and shipped to the customer.</param>
        /// <param name="orderItems">The list of all order items included in this order. (required)</param>
        /// <param name="packages">Shipping packages created for this order, including tracking information. Note: Only available for merchant-fulfilled (FBM) orders.</param>
        public Order(string orderId = default,
                     List<OrderAliase> orderAliases = default,
                     DateTime createdTime = default,
                     DateTime lastUpdatedTime = default,
                     List<ProgramEnum> programs = default,
                     List<AssociatedOrder> associatedOrders = default,
                     SalesChannel salesChannel = default,
                     Buyer buyer = default,
                     Recipient recipient = default,
                     OrderProceeds proceeds = default,
                     OrderFulfillment fulfillment = default,
                     List<OrderItem> orderItems = default,
                     List<Package> packages = default)
        {
            // to ensure "orderId" is required (not null)
            if (orderId == null)
            {
                throw new InvalidDataException("orderId is a required property for Order and cannot be null");
            }
            else
            {
                this.OrderId = orderId;
            }

            // to ensure "createdTime" is required (not null)
            if (createdTime == null)
            {
                throw new InvalidDataException("createdTime is a required property for Order and cannot be null");
            }
            else
            {
                this.CreatedTime = createdTime;
            }

            // to ensure "lastUpdatedTime" is required (not null)
            if (lastUpdatedTime == null)
            {
                throw new InvalidDataException("lastUpdatedTime is a required property for Order and cannot be null");
            }
            else
            {
                this.LastUpdatedTime = lastUpdatedTime;
            }

            // to ensure "salesChannel" is required (not null)
            if (salesChannel == null)
            {
                throw new InvalidDataException("salesChannel is a required property for Order and cannot be null");
            }
            else
            {
                this.SalesChannel = salesChannel;
            }

            // to ensure "orderItems" is required (not null)
            if (orderItems == null)
            {
                throw new InvalidDataException("orderItems is a required property for Order and cannot be null");
            }
            else
            {
                this.OrderItems = orderItems;
            }

            this.OrderAliases = orderAliases;
            this.Programs = programs;
            this.AssociatedOrders = associatedOrders;
            this.Buyer = buyer;
            this.Recipient = recipient;
            this.Proceeds = proceeds;
            this.Fulfillment = fulfillment;
            this.Packages = packages;
        }

        /// <summary>
        /// An Amazon-defined order identifier. (required)
        /// </summary>
        /// <value>An Amazon-defined order identifier. (required)</value>
        [DataMember(Name = "orderId", EmitDefaultValue = false)]
        public string OrderId { get; set; }

        /// <summary>
        /// Alternative identifiers that can be used to reference this order, such as seller-defined order numbers.
        /// </summary>
        /// <value>Alternative identifiers that can be used to reference this order, such as seller-defined order numbers.</value>
        [DataMember(Name = "orderAliases", EmitDefaultValue = false)]
        public List<OrderAliase> OrderAliases { get; set; }

        /// <summary>
        ///The time when the customer placed the order. In ISO 8601 format.(required)
        /// </summary>
        /// <value>The time when the customer placed the order. In ISO 8601 format.(required)</value>
        [DataMember(Name = "createdTime", EmitDefaultValue = false)]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// The most recent time when any aspect of this order was modified by Amazon or the seller. In ISO 8601 format.(required)
        /// </summary>
        /// <value>The most recent time when any aspect of this order was modified by Amazon or the seller. In ISO 8601 format.(required)</value>
        [DataMember(Name = "lastUpdatedTime", EmitDefaultValue = false)]
        public DateTime LastUpdatedTime { get; set; }

        /// <summary>
        /// Special programs associated with this order that may affect fulfillment or customer experience.
        /// </summary>
        /// <value>Special programs associated with this order that may affect fulfillment or customer experience.</value>
        [DataMember(Name = "programs", EmitDefaultValue = false)]
        public List<ProgramEnum> Programs { get; set; }

        /// <summary>
        /// Other orders that have a direct relationship to this order, such as replacement or exchange orders.
        /// </summary>
        /// <value>Other orders that have a direct relationship to this order, such as replacement or exchange orders.</value>
        [DataMember(Name = "associatedOrders", EmitDefaultValue = false)]
        public List<AssociatedOrder> AssociatedOrders { get; set; }

        /// <summary>
        /// Information about where the customer placed this order. (required)
        /// </summary>
        /// <value>Information about where the customer placed this order. (required)</value>
        [DataMember(Name = "salesChannel", EmitDefaultValue = false)]
        public SalesChannel SalesChannel { get; set; }

        /// <summary>
        /// Information about the customer who purchased the order.
        /// </summary>
        /// <value>Information about the customer who purchased the order.</value>
        [DataMember(Name = "buyer", EmitDefaultValue = false)]
        public Buyer Buyer { get; set; }

        /// <summary>
        /// Information about the recipient to whom the order should be delivered.
        /// </summary>
        /// <value>Information about the recipient to whom the order should be delivered.</value>
        [DataMember(Name = "recipient", EmitDefaultValue = false)]
        public Recipient Recipient { get; set; }

        /// <summary>
        /// The money that the seller receives from the sale of the order.
        /// </summary>
        /// <value>The money that the seller receives from the sale of the order.</value>
        [DataMember(Name = "proceeds", EmitDefaultValue = false)]
        public OrderProceeds Proceeds { get; set; }

        /// <summary>
        /// Information about how the order is being processed, packed, and shipped to the customer.
        /// </summary>
        /// <value>Information about how the order is being processed, packed, and shipped to the customer.</value>
        [DataMember(Name = "fulfillment", EmitDefaultValue = false)]
        public OrderFulfillment Fulfillment { get; set; }

        /// <summary>
        /// The list of all order items included in this order. (required)
        /// </summary>
        /// <value>The list of all order items included in this order. (required)</value>
        [DataMember(Name = "orderItems", EmitDefaultValue = false)]
        public List<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// Shipping packages created for this order, including tracking information. Note: Only available for merchant-fulfilled (FBM) orders.
        /// </summary>
        /// <value>Shipping packages created for this order, including tracking information. Note: Only available for merchant-fulfilled (FBM) orders.</value>
        [DataMember(Name = "packages", EmitDefaultValue = false)]
        public List<Package> Packages { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Order {\n");
            sb.Append("  OrderId: ").Append(OrderId).Append("\n");
            sb.Append("  OrderAliases: ").Append(OrderAliases).Append("\n");
            sb.Append("  CreatedTime: ").Append(CreatedTime).Append("\n");
            sb.Append("  LastUpdatedTime: ").Append(LastUpdatedTime).Append("\n");
            sb.Append("  Programs: ").Append(Programs).Append("\n");
            sb.Append("  AssociatedOrders: ").Append(AssociatedOrders).Append("\n");
            sb.Append("  SalesChannel: ").Append(SalesChannel).Append("\n");
            sb.Append("  Buyer: ").Append(Buyer).Append("\n");
            sb.Append("  Recipient: ").Append(Recipient).Append("\n");
            sb.Append("  Proceeds: ").Append(Proceeds).Append("\n");
            sb.Append("  Fulfillment: ").Append(Fulfillment).Append("\n");
            sb.Append("  OrderItems: ").Append(OrderItems).Append("\n");
            sb.Append("  Packages: ").Append(Packages).Append("\n");
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
            return Equals(input as Order);
        }

        /// <summary>
        /// Returns true if Order instances are equal
        /// </summary>
        /// <param name="input">Instance of Order to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Order input)
        {
            if (input == null)
                return false;

            return
                (
                    OrderId == input.OrderId ||
                    OrderId != null &&
                    OrderId.Equals(input.OrderId)
                ) &&
                (
                    OrderAliases == input.OrderAliases ||
                    OrderAliases != null &&
                    OrderAliases.SequenceEqual(input.OrderAliases)
                ) &&
                (
                    CreatedTime == input.CreatedTime ||
                    CreatedTime != null &&
                    CreatedTime.Equals(input.CreatedTime)
                ) &&
                (
                    LastUpdatedTime == input.LastUpdatedTime ||
                    LastUpdatedTime != null &&
                    LastUpdatedTime.Equals(input.LastUpdatedTime)
                ) &&
                (
                    Programs == input.Programs ||
                    Programs != null &&
                    Programs.SequenceEqual(input.Programs)
                ) &&
                (
                    AssociatedOrders == input.AssociatedOrders ||
                    AssociatedOrders != null &&
                    AssociatedOrders.SequenceEqual(input.AssociatedOrders)
                ) &&
                (
                    SalesChannel == input.SalesChannel ||
                    SalesChannel != null &&
                    SalesChannel.Equals(input.SalesChannel)
                ) &&
                (
                    Buyer == input.Buyer ||
                    Buyer != null &&
                    Buyer.Equals(input.Buyer)
                ) &&
                (
                    Recipient == input.Recipient ||
                    Recipient != null &&
                    Recipient.Equals(input.Recipient)
                ) &&
                (
                    Proceeds == input.Proceeds ||
                    Proceeds != null &&
                    Proceeds.Equals(input.Proceeds)
                ) &&
                (
                    Fulfillment == input.Fulfillment ||
                    Fulfillment != null &&
                    Fulfillment.Equals(input.Fulfillment)
                ) &&
                (
                    OrderItems == input.OrderItems ||
                    OrderItems != null &&
                    OrderItems.SequenceEqual(input.OrderItems)
                ) &&
                (
                    Packages == input.Packages ||
                    Packages != null &&
                    Packages.SequenceEqual(input.Packages)
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
                if (OrderId != null)
                    hashCode = hashCode * 59 + OrderId.GetHashCode();
                if (OrderAliases != null)
                    hashCode = hashCode * 59 + OrderAliases.GetHashCode();
                if (CreatedTime != null)
                    hashCode = hashCode * 59 + CreatedTime.GetHashCode();
                if (LastUpdatedTime != null)
                    hashCode = hashCode * 59 + LastUpdatedTime.GetHashCode();
                if (Programs != null)
                    hashCode = hashCode * 59 + Programs.GetHashCode();
                if (AssociatedOrders != null)
                    hashCode = hashCode * 59 + AssociatedOrders.GetHashCode();
                if (SalesChannel != null)
                    hashCode = hashCode * 59 + SalesChannel.GetHashCode();
                if (Buyer != null)
                    hashCode = hashCode * 59 + Buyer.GetHashCode();
                if (Recipient != null)
                    hashCode = hashCode * 59 + Recipient.GetHashCode();
                if (Proceeds != null)
                    hashCode = hashCode * 59 + Proceeds.GetHashCode();
                if (Fulfillment != null)
                    hashCode = hashCode * 59 + Fulfillment.GetHashCode();
                if (OrderItems != null)
                    hashCode = hashCode * 59 + OrderItems.GetHashCode();
                if (Packages != null)
                    hashCode = hashCode * 59 + Packages.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}