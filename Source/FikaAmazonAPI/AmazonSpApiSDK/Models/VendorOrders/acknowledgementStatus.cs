using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders.Constants;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders
{
    [DataContract]
    public partial class AcknowledgementStatus : IEquatable<AcknowledgementStatus>, IValidatableObject
    {
        [JsonConstructorAttribute]
        public AcknowledgementStatus() { }
        public AcknowledgementStatus(
            ItemConfirmationStatus? confirmationStatus = default(ItemConfirmationStatus?), ItemQuantity acceptedQuantity = default(ItemQuantity), ItemQuantity rejectedQuantity = default(ItemQuantity), 
            List<AcknowledgementStatusDetails> acknowledgementStatusDetails = default(List<AcknowledgementStatusDetails>)
        )
        {
            this.ConfirmationStatus = confirmationStatus;
            this.AcceptedQuantity = acceptedQuantity;
            this.RejectedQuantity = rejectedQuantity;
            this.AcknowledgementStatusDetails = acknowledgementStatusDetails;
        }

        [DataMember(Name = "confirmationStatus", EmitDefaultValue = false)]
        public ItemConfirmationStatus? ConfirmationStatus { get; set; }

        [DataMember(Name = "acceptedQuantity", EmitDefaultValue = false)]
        public ItemQuantity AcceptedQuantity { get; set; }

        [DataMember(Name = "rejectedQuantity", EmitDefaultValue = false)]
        public ItemQuantity RejectedQuantity { get; set; }

        [DataMember(Name = "acknowledgementStatusDetails", EmitDefaultValue = false)]
        public List<AcknowledgementStatusDetails> AcknowledgementStatusDetails { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class acknowledgementStatus {\n");
            sb.Append("  ConfirmationStatus: ").Append(ConfirmationStatus).Append("\n");
            sb.Append("  AcceptedQuantity: ").Append(AcceptedQuantity).Append("\n");
            sb.Append("  RejectedQuantity: ").Append(RejectedQuantity).Append("\n");
            sb.Append("  AcknowledgementStatusDetails: ").Append(AcknowledgementStatusDetails).Append("\n");
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
            return this.Equals(input as AcknowledgementStatus);
        }

        /// <summary>
        /// Returns true if ItemQuantity instances are equal
        /// </summary>
        /// <param name="input">Instance of ItemQuantity to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AcknowledgementStatus input)
        {
            if (input == null)
                return false;

            return
                (
                    this.ConfirmationStatus == input.ConfirmationStatus ||
                    (this.ConfirmationStatus != null &&
                    this.ConfirmationStatus.Equals(input.ConfirmationStatus))
                ) &&
                (
                    this.AcceptedQuantity == input.AcceptedQuantity ||
                    (this.AcceptedQuantity != null &&
                    this.AcceptedQuantity.Equals(input.AcceptedQuantity))
                ) &&
                (
                    this.RejectedQuantity == input.RejectedQuantity ||
                    (this.RejectedQuantity != null &&
                    this.RejectedQuantity.Equals(input.RejectedQuantity))
                ) &&
                (
                    this.AcknowledgementStatusDetails == input.AcknowledgementStatusDetails ||
                    (this.AcknowledgementStatusDetails != null &&
                    this.AcknowledgementStatusDetails.Equals(input.AcknowledgementStatusDetails))
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
                if (this.ConfirmationStatus != null)
                    hashCode = hashCode * 59 + this.ConfirmationStatus.GetHashCode();
                if (this.AcceptedQuantity != null)
                    hashCode = hashCode * 59 + this.AcceptedQuantity.GetHashCode();
                if (this.RejectedQuantity != null)
                    hashCode = hashCode * 59 + this.RejectedQuantity.GetHashCode();
                if (this.AcknowledgementStatusDetails != null)
                    hashCode = hashCode * 59 + this.AcknowledgementStatusDetails.GetHashCode();
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
