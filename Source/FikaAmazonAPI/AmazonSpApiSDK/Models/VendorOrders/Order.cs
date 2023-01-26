using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders
{
    /// <summary>
    /// Order
    /// </summary>
    [DataContract]
    public partial class Order : IEquatable<Order>, IValidatableObject
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum PurchaseOrderStateEnum
        {
            [EnumMember(Value = "New")]
            New,

            [EnumMember(Value = "Acknowledged")]
            Acknowledged,

            [EnumMember(Value = "Closed")]
            Closed
        }

        /// <summary>
        /// Current state of the purchase order.
        /// </summary>
        /// <value>Current state of the purchase order.</value>
        [DataMember(Name = "purchaseOrderState", EmitDefaultValue = false)]
        public PurchaseOrderStateEnum? PurchaseOrderState { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public Order() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Order" /> class.
        /// </summary>
        /// <param name="purchaseOrderNumber">The purchase order number for this order. Formatting Notes: alpha-numeric code. (required).</param>
        /// <param name="orderDetails">Purchase order details..</param>
        public Order(string purchaseOrderNumber = default(string), OrderDetails orderDetails = default(OrderDetails), PurchaseOrderStateEnum? purchaseOrderState = default(PurchaseOrderStateEnum?))
        {
            // to ensure "purchaseOrderNumber" is required (not null)
            if (purchaseOrderNumber == null)
            {
                throw new InvalidDataException("purchaseOrderNumber is a required property for Order and cannot be null");
            }
            else
            {
                this.PurchaseOrderNumber = purchaseOrderNumber;
            }
            this.PurchaseOrderState = purchaseOrderState;
            this.OrderDetails = orderDetails;
        }

        /// <summary>
        /// The purchase order number for this order. Formatting Notes: alpha-numeric code.
        /// </summary>
        /// <value>The purchase order number for this order. Formatting Notes: alpha-numeric code.</value>
        [DataMember(Name = "purchaseOrderNumber", EmitDefaultValue = false)]
        public string PurchaseOrderNumber { get; set; }

        /// <summary>
        /// Purchase order details.
        /// </summary>
        /// <value>Purchase order details.</value>
        [DataMember(Name = "orderDetails", EmitDefaultValue = false)]
        public OrderDetails OrderDetails { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Order {\n");
            sb.Append("  PurchaseOrderNumber: ").Append(PurchaseOrderNumber).Append("\n");
            sb.Append("  PurchaseOrderState: ").Append(PurchaseOrderState).Append("\n");
            sb.Append("  OrderDetails: ").Append(OrderDetails).Append("\n");
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
            return this.Equals(input as Order);
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
                    this.PurchaseOrderNumber == input.PurchaseOrderNumber ||
                    (this.PurchaseOrderNumber != null &&
                    this.PurchaseOrderNumber.Equals(input.PurchaseOrderNumber))
                ) &&
                (
                    this.PurchaseOrderState == input.PurchaseOrderState ||
                    (this.PurchaseOrderState != null &&
                    this.PurchaseOrderState.Equals(input.PurchaseOrderState))
                ) &&
                (
                    this.OrderDetails == input.OrderDetails ||
                    (this.OrderDetails != null &&
                    this.OrderDetails.Equals(input.OrderDetails))
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
                if (this.PurchaseOrderNumber != null)
                    hashCode = hashCode * 59 + this.PurchaseOrderNumber.GetHashCode();
                if (this.PurchaseOrderState != null)
                    hashCode = hashCode * 59 + this.PurchaseOrderState.GetHashCode();
                if (this.OrderDetails != null)
                    hashCode = hashCode * 59 + this.OrderDetails.GetHashCode();
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
