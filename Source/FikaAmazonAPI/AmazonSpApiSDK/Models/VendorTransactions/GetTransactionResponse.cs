using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorTransactions
{
    /// <summary>
    /// The response schema for the getTransactionResponse operation.
    /// </summary>
    [DataContract]
    public partial class GetTransactionResponse : IEquatable<GetTransactionResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTransactionResponse" /> class.
        /// </summary>
        /// <param name="payload">The payload for the getTransactionResponse operation..</param>
        /// <param name="errors">errors.</param>
        public GetTransactionResponse(Transaction payload = default, ErrorList errors = default)
        {
            Payload = payload;
            Errors = errors;
        }
        public GetTransactionResponse()
        {
            Payload = default;
            Errors = default;
        }
        /// <summary>
        /// The payload for the getTransactionResponse operation.
        /// </summary>
        /// <value>The payload for the getTransactionResponse operation.</value>
        [DataMember(Name = "payload", EmitDefaultValue = false)]
        public Transaction Payload { get; set; }

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
            sb.Append("class GetTransactionResponse {\n");
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
            return Equals(input as GetTransactionResponse);
        }

        /// <summary>
        /// Returns true if GetTransactionResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of GetTransactionResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetTransactionResponse input)
        {
            if (input == null)
                return false;

            return
                (
                    Payload == input.Payload ||
                    Payload != null &&
                    Payload.Equals(input.Payload)
                ) &&
                (
                    Errors == input.Errors ||
                    Errors != null &&
                    Errors.Equals(input.Errors)
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
                if (Payload != null)
                    hashCode = hashCode * 59 + Payload.GetHashCode();
                if (Errors != null)
                    hashCode = hashCode * 59 + Errors.GetHashCode();
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
