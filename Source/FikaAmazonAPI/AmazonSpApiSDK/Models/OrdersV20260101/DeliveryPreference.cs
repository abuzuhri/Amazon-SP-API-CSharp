using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Contains all delivery instructions that the customer provides for the shipping address.
    /// </summary>
    [DataContract]
    public partial class DeliveryPreference : IEquatable<DeliveryPreference>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryPreference" /> class.
        /// </summary>
        public DeliveryPreference()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryPreference" /> class.
        /// </summary>
        /// <param name="dropOffLocation">The drop-off location selected by the customer.</param>
        /// <param name="addressInstruction">Building instructions, nearby landmark, or navigation instructions.</param>
        /// <param name="deliveryTime">Customer-specified time preferences for when deliveries should be attempted at the destination address.</param>
        /// <param name="deliveryCapabilities">A list of miscellaneous delivery capabilities associated with the shipping address.</param>
        public DeliveryPreference(string dropOffLocation = default,
                                  string addressInstruction = default,
                                  DeliveryTime deliveryTime = default,
                                  List<object> deliveryCapabilities = default)
        {
            this.DropOffLocation = dropOffLocation;
            this.AddressInstruction = addressInstruction;
            this.DeliveryTime = deliveryTime;
            this.DeliveryCapabilities = deliveryCapabilities;
        }

        /// <summary>
        /// The drop-off location selected by the customer.
        /// </summary>
        /// <value>The drop-off location selected by the customer.</value>
        [DataMember(Name = "dropOffLocation", EmitDefaultValue = false)]
        public string DropOffLocation { get; set; }

        /// <summary>
        /// Building instructions, nearby landmark, or navigation instructions.
        /// </summary>
        /// <value>Building instructions, nearby landmark, or navigation instructions.</value>
        [DataMember(Name = "addressInstruction", EmitDefaultValue = false)]
        public string AddressInstruction { get; set; }

        /// <summary>
        /// Customer-specified time preferences for when deliveries should be attempted at the destination address.
        /// </summary>
        /// <value>Customer-specified time preferences for when deliveries should be attempted at the destination address.</value>
        [DataMember(Name = "deliveryTime", EmitDefaultValue = false)]
        public DeliveryTime DeliveryTime { get; set; }

        /// <summary>
        /// A list of miscellaneous delivery capabilities associated with the shipping address.
        /// </summary>
        /// <value>A list of miscellaneous delivery capabilities associated with the shipping address.</value>
        [DataMember(Name = "deliveryCapabilities", EmitDefaultValue = false)]
        public List<object> DeliveryCapabilities { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DeliveryPreference {\n");
            sb.Append("  DropOffLocation: ").Append(DropOffLocation).Append("\n");
            sb.Append("  AddressInstruction: ").Append(AddressInstruction).Append("\n");
            sb.Append("  DeliveryTime: ").Append(DeliveryTime).Append("\n");
            sb.Append("  DeliveryCapabilities: ").Append(DeliveryCapabilities).Append("\n");
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
            return this.Equals(input as DeliveryPreference);
        }

        /// <summary>
        /// Returns true if DeliveryPreference instances are equal
        /// </summary>
        /// <param name="input">Instance of DeliveryPreference to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DeliveryPreference input)
        {
            if (input == null)
                return false;

            return
                (
                    this.DropOffLocation == input.DropOffLocation ||
                    (this.DropOffLocation != null &&
                    this.DropOffLocation.Equals(input.DropOffLocation))
                ) &&
                (
                    this.AddressInstruction == input.AddressInstruction ||
                    (this.AddressInstruction != null &&
                    this.AddressInstruction.Equals(input.AddressInstruction))
                ) &&
                (
                    this.DeliveryTime == input.DeliveryTime ||
                    (this.DeliveryTime != null &&
                    this.DeliveryTime.Equals(input.DeliveryTime))
                ) &&
                (
                    this.DeliveryCapabilities == input.DeliveryCapabilities ||
                    (this.DeliveryCapabilities != null &&
                    this.DeliveryCapabilities.SequenceEqual(input.DeliveryCapabilities))
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
                if (this.DropOffLocation != null)
                    hashCode = hashCode * 59 + this.DropOffLocation.GetHashCode();
                if (this.AddressInstruction != null)
                    hashCode = hashCode * 59 + this.AddressInstruction.GetHashCode();
                if (this.DeliveryTime != null)
                    hashCode = hashCode * 59 + this.DeliveryTime.GetHashCode();
                if (this.DeliveryCapabilities != null)
                    hashCode = hashCode * 59 + this.DeliveryCapabilities.GetHashCode();
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