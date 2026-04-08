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
    /// Order item included in specific package.
    /// </summary>
    [DataContract]
    public partial class PackageItem : IEquatable<PackageItem>, IValidatableObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="PackageItem" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PackageItem() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PackageItem" /> class.
        /// </summary>
        /// <param name="orderItemId">Unique identifier of the order item included in this package. (required)</param>
        /// <param name="quantity">Number of units of this item included in the package shipment. (required)</param>
        /// <param name="transparencyCodes">The transparency codes associated with this item for product authentication.</param>
        public PackageItem(string orderItemId = default,
                           int quantity = default,
                           List<string> transparencyCodes = default)
        {
            // to ensure "orderItemId" is required (not null)
            if (orderItemId == null)
            {
                throw new InvalidDataException("orderItemId is a required property for PackageItem and cannot be null");
            }
            else
            {
                this.OrderItemId = orderItemId;
            }

            // to ensure "quantity" is required (not null)
            if (quantity == null)
            {
                throw new InvalidDataException("quantity is a required property for PackageItem and cannot be null");
            }
            else
            {
                this.Quantity = quantity;
            }

            this.TransparencyCodes = transparencyCodes;
        }

        /// <summary>
        /// Unique identifier of the order item included in this package. (required)
        /// </summary>
        /// <value>Unique identifier of the order item included in this package. (required)</value>
        [DataMember(Name = "orderItemId", EmitDefaultValue = false)]
        public string OrderItemId { get; set; }

        /// <summary>
        /// Number of units of this item included in the package shipment. (required)
        /// </summary>
        /// <value>Number of units of this item included in the package shipment. (required)</value>
        [DataMember(Name = "quantity", EmitDefaultValue = false)]
        public int Quantity { get; set; }

        /// <summary>
        /// The transparency codes associated with this item for product authentication.
        /// </summary>
        /// <value>The transparency codes associated with this item for product authentication.</value>
        [DataMember(Name = "transparencyCodes", EmitDefaultValue = false)]
        public List<string> TransparencyCodes { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PackageItem {\n");
            sb.Append("  OrderItemId: ").Append(OrderItemId).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  TransparencyCodes: ").Append(TransparencyCodes).Append("\n");
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
            return this.Equals(input as PackageItem);
        }

        /// <summary>
        /// Returns true if PackageItem instances are equal
        /// </summary>
        /// <param name="input">Instance of PackageItem to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PackageItem input)
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
                    this.Quantity == input.Quantity ||
                    (this.Quantity != null &&
                    this.Quantity.Equals(input.Quantity))
                ) &&
                (
                    this.TransparencyCodes == input.TransparencyCodes ||
                    (this.TransparencyCodes != null &&
                    this.TransparencyCodes.SequenceEqual(input.TransparencyCodes))
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
                if (this.Quantity != null)
                    hashCode = hashCode * 59 + this.Quantity.GetHashCode();
                if (this.TransparencyCodes != null)
                    hashCode = hashCode * 59 + this.TransparencyCodes.GetHashCode();
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
