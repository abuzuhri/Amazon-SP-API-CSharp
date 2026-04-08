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
    /// Information related to the shipping and delivery process for an order item.
    /// </summary>
    [DataContract]
    public partial class Shipping : IEquatable<Shipping>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shipping" /> class.
        /// </summary>
        public Shipping()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Shipping" /> class.
        /// </summary>
        /// <param name="scheduledDeliveryWindow">A time period with start and end boundaries.</param>
        /// <param name="shippingConstraints">Special shipping requirements and restrictions that must be observed when shipping an order item.</param>
        /// <param name="internationalShipping">Additional requirements needed for cross-border shipping of an order item.</param>

        public Shipping(DeliveryWindow scheduledDeliveryWindow = default,
                        ShippingConstraints shippingConstraints = default,
                        InternationalShipping internationalShipping = default)
        {
            this.ScheduledDeliveryWindow = scheduledDeliveryWindow;
            this.ShippingConstraints = shippingConstraints;
            this.InternationalShipping = internationalShipping;
        }

        /// <summary>
        /// A time period with start and end boundaries.
        /// </summary>
        /// <value>A time period with start and end boundaries.</value>
        [DataMember(Name = "scheduledDeliveryWindow", EmitDefaultValue = false)]
        public DeliveryWindow ScheduledDeliveryWindow { get; set; }

        /// <summary>
        /// Special shipping requirements and restrictions that must be observed when shipping an order item.
        /// </summary>
        /// <value>Special shipping requirements and restrictions that must be observed when shipping an order item.</value>
        [DataMember(Name = "shippingConstraints", EmitDefaultValue = false)]
        public ShippingConstraints ShippingConstraints { get; set; }

        /// <summary>
        /// Additional requirements needed for cross-border shipping of an order item.
        /// </summary>
        /// <value>Additional requirements needed for cross-border shipping of an order item.</value>
        [DataMember(Name = "internationalShipping", EmitDefaultValue = false)]
        public InternationalShipping InternationalShipping { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Shipping {\n");
            sb.Append("  ScheduledDeliveryWindow: ").Append(ScheduledDeliveryWindow).Append("\n");
            sb.Append("  ShippingConstraints: ").Append(ShippingConstraints).Append("\n");
            sb.Append("  InternationalShipping: ").Append(InternationalShipping).Append("\n");
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
            return this.Equals(input as Shipping);
        }

        /// <summary>
        /// Returns true if Shipping instances are equal
        /// </summary>
        /// <param name="input">Instance of Shipping to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Shipping input)
        {
            if (input == null)
                return false;

            return
                (
                    this.ScheduledDeliveryWindow == input.ScheduledDeliveryWindow ||
                    (this.ScheduledDeliveryWindow != null &&
                    this.ScheduledDeliveryWindow.Equals(input.ScheduledDeliveryWindow))
                ) &&
                (
                    this.ShippingConstraints == input.ShippingConstraints ||
                    (this.ShippingConstraints != null &&
                    this.ShippingConstraints.Equals(input.ShippingConstraints))
                ) &&
                (
                    this.InternationalShipping == input.InternationalShipping ||
                    (this.InternationalShipping != null &&
                    this.InternationalShipping.Equals(input.InternationalShipping))
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
                if (this.ScheduledDeliveryWindow != null)
                    hashCode = hashCode * 59 + this.ScheduledDeliveryWindow.GetHashCode();
                if (this.ShippingConstraints != null)
                    hashCode = hashCode * 59 + this.ShippingConstraints.GetHashCode();
                if (this.InternationalShipping != null)
                    hashCode = hashCode * 59 + this.InternationalShipping.GetHashCode();

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