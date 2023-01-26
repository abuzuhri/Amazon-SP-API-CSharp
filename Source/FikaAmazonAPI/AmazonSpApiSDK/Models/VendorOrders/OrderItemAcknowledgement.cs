using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using System.IO;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders
{
    [DataContract]
    public partial class OrderItemAcknowledgement : IEquatable<OrderItemAcknowledgement>, IValidatableObject
    {
        public OrderItemAcknowledgement() { }
        public OrderItemAcknowledgement(AcknowledgementCode? acknowledgementCode = default(AcknowledgementCode?), ItemQuantity acknowledgedQuantity = default(ItemQuantity), DateTime? scheduledShipDate = default(DateTime?), DateTime? scheduledDeliveryDate = default(DateTime?), RejectionReason? rejectionReason = default(RejectionReason?))
        {
            // to ensure "acknowledgementCode" is required (not null)
            if (acknowledgementCode == null)
            {
                throw new InvalidDataException("acknowledgementCode is a required property for OrderItemAcknowledgement and cannot be null");
            }
            else
            {
                this.AcknowledgementCode = acknowledgementCode;
            }
            // to ensure "acknowledgedQuantity" is required (not null)
            if (acknowledgedQuantity == null)
            {
                throw new InvalidDataException("acknowledgedQuantity is a required property for OrderItemAcknowledgement and cannot be null");
            }
            else
            {
                this.AcknowledgedQuantity = acknowledgedQuantity;
            }
            this.ScheduledShipDate = scheduledShipDate;
            this.ScheduledDeliveryDate = scheduledDeliveryDate;
            this.RejectionReason = rejectionReason;
        }

        [DataMember(Name = "acknowledgementCode", EmitDefaultValue = false)]
        public AcknowledgementCode? AcknowledgementCode { get; set; }

        [DataMember(Name = "acknowledgedQuantity", EmitDefaultValue = false)]
        public ItemQuantity AcknowledgedQuantity { get; set; }

        [DataMember(Name = "scheduledShipDate", EmitDefaultValue = false)]
        public DateTime? ScheduledShipDate { get; set; }

        [DataMember(Name = "scheduledDeliveryDate", EmitDefaultValue = false)]
        public DateTime? ScheduledDeliveryDate { get; set; }

        [DataMember(Name = "rejectionReason", EmitDefaultValue = false)]
        public RejectionReason? RejectionReason { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderItemAcknowledgement {\n");
            sb.Append("  AcknowledgementCode: ").Append(AcknowledgementCode).Append("\n");
            sb.Append("  AcknowledgedQuantity: ").Append(AcknowledgedQuantity).Append("\n");
            sb.Append("  ScheduledShipDate: ").Append(ScheduledShipDate).Append("\n");
            sb.Append("  ScheduledDeliveryDate: ").Append(ScheduledDeliveryDate).Append("\n");
            sb.Append("  RejectionReason: ").Append(RejectionReason).Append("\n");
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
            return this.Equals(input as OrderItemAcknowledgement);
        }

        public bool Equals(OrderItemAcknowledgement input)
        {
            if (input == null)
                return false;

            return
                (
                    this.AcknowledgementCode == input.AcknowledgementCode ||
                    (this.AcknowledgementCode != null &&
                    this.AcknowledgementCode.Equals(input.AcknowledgementCode))
                ) &&
                (
                    this.AcknowledgedQuantity == input.AcknowledgedQuantity ||
                    (this.AcknowledgedQuantity != null &&
                    this.AcknowledgedQuantity.Equals(input.AcknowledgedQuantity))
                ) &&
                (
                    this.ScheduledShipDate == input.ScheduledShipDate ||
                    (this.ScheduledShipDate != null &&
                    this.ScheduledShipDate.Equals(input.ScheduledShipDate))
                ) &&
                (
                    this.ScheduledDeliveryDate == input.ScheduledDeliveryDate ||
                    (this.ScheduledDeliveryDate != null &&
                    this.ScheduledDeliveryDate.Equals(input.ScheduledDeliveryDate))
                ) &&
                (
                    this.RejectionReason == input.RejectionReason ||
                    (this.RejectionReason != null &&
                    this.RejectionReason.Equals(input.RejectionReason))
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
                if (this.AcknowledgementCode != null)
                    hashCode = hashCode * 59 + this.AcknowledgementCode.GetHashCode();
                if (this.AcknowledgedQuantity != null)
                    hashCode = hashCode * 59 + this.AcknowledgedQuantity.GetHashCode();
                if (this.ScheduledShipDate != null)
                    hashCode = hashCode * 59 + this.ScheduledShipDate.GetHashCode();
                if (this.ScheduledDeliveryDate != null)
                    hashCode = hashCode * 59 + this.ScheduledDeliveryDate.GetHashCode();
                if (this.RejectionReason != null)
                    hashCode = hashCode * 59 + this.RejectionReason.GetHashCode();
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
