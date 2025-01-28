using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Authorization;
using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorTransactions;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders
{
    /// <summary>
    /// The response schema for the submitAcknowledgement operation.
    /// </summary>
    [DataContract]
    public partial class SubmitAcknowledgementResponse : IEquatable<SubmitAcknowledgementResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubmitAcknowledgementResponse" /> class.
        /// </summary>
        /// <param name="payload">The payload for the submitAcknowledgement operation..</param>
        /// <param name="errors">errors.</param>
        public SubmitAcknowledgementResponse(TransactionId payload = default(TransactionId), ErrorList errors = default(ErrorList))
        {
            this.Payload = payload;
            this.Errors = errors;
        }
        public SubmitAcknowledgementResponse()
        {
            this.Payload = default(TransactionId);
            this.Errors = default(ErrorList);
        }
        /// <summary>
        /// The payload for the submitAcknowledgement operation.
        /// </summary>
        /// <value>The payload for the submitAcknowledgement operation.</value>
        [DataMember(Name = "payload", EmitDefaultValue = false)]
        public TransactionId Payload { get; set; }

        /// <summary>
        /// Gets or Sets Errors
        /// </summary>
        [DataMember(Name = "errors", EmitDefaultValue = false)]
        public ErrorList Errors { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SubmitAcknowledgementResponse {\n");
            sb.Append("  Payload: ").Append(Payload).Append("\n");
            sb.Append("  Errors: ").Append(Errors).Append("\n");
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
            return this.Equals(input as SubmitAcknowledgementResponse);
        }

        /// <summary>
        /// Returns true if SubmitAcknowledgementResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of SubmitAcknowledgementResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SubmitAcknowledgementResponse input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Payload == input.Payload ||
                    (this.Payload != null &&
                    this.Payload.Equals(input.Payload))
                ) &&
                (
                    this.Errors == input.Errors ||
                    (this.Errors != null &&
                    this.Errors.Equals(input.Errors))
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
                if (this.Payload != null)
                    hashCode = hashCode * 59 + this.Payload.GetHashCode();
                if (this.Errors != null)
                    hashCode = hashCode * 59 + this.Errors.GetHashCode();
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
