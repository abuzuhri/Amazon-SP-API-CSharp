using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Information about the recipient to whom the order should be delivered.
    /// </summary>
    [DataContract]
    public partial class Recipient : IEquatable<Recipient>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Recipient" /> class.
        /// </summary>
        public Recipient() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Recipient" /> class.
        /// </summary>
        /// <param name="deliveryAddress">The physical address of the customer.</param>
        /// <param name="deliveryPreference">Contains all delivery instructions that the customer provides for the shipping address.</param>
        public Recipient(Address deliveryAddress = default, DeliveryPreference deliveryPreference = default)
        {
            this.DeliveryAddress = deliveryAddress;
            this.DeliveryPreference = deliveryPreference;
        }

        /// <summary>
        /// The physical address of the customer.
        /// </summary>
        /// <value>The physical address of the customer.</value>
        [DataMember(Name = "deliveryAddress", EmitDefaultValue = false)]
        public Address DeliveryAddress { get; set; }

        /// <summary>
        /// Contains all delivery instructions that the customer provides for the shipping address.
        /// </summary>
        /// <value>Contains all delivery instructions that the customer provides for the shipping address.</value>
        [DataMember(Name = "deliveryPreference", EmitDefaultValue = false)]
        public DeliveryPreference DeliveryPreference { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Recipient {\n");
            sb.Append("  DeliveryAddress: ").Append(DeliveryAddress).Append("\n");
            sb.Append("  DeliveryPreference: ").Append(DeliveryPreference).Append("\n");
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
            return this.Equals(input as Recipient);
        }

        /// <summary>
        /// Returns true if Recipient instances are equal
        /// </summary>
        /// <param name="input">Instance of Recipient to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Recipient input)
        {
            if (input == null)
                return false;

            return
                (
                    this.DeliveryAddress == input.DeliveryAddress ||
                    (this.DeliveryAddress != null &&
                    this.DeliveryAddress.Equals(input.DeliveryAddress))
                ) &&
                (
                    this.DeliveryPreference == input.DeliveryPreference ||
                    (this.DeliveryPreference != null &&
                    this.DeliveryPreference.Equals(input.DeliveryPreference))
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
                if (this.DeliveryAddress != null)
                    hashCode = hashCode * 59 + this.DeliveryAddress.GetHashCode();
                if (this.DeliveryPreference != null)
                    hashCode = hashCode * 59 + this.DeliveryPreference.GetHashCode();
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