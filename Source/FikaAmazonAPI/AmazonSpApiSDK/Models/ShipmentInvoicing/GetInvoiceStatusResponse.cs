using FikaAmazonAPI.AmazonSpApiSDK.Models.Finances;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShipmentInvoicing
{
    public partial class GetInvoiceStatusResponse : IEquatable<GetInvoiceStatusResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetInvoiceStatusResponse" /> class.
        /// </summary>
        /// <param name="Payload">The payload for the getCatalogItem operation..</param>
        /// <param name="Errors">One or more unexpected errors occurred during the getCatalogItem operation..</param>
        public GetInvoiceStatusResponse(ShipmentInvoiceStatusInfo Payload = default(ShipmentInvoiceStatusInfo), ErrorList Errors = default(ErrorList))
        {
            this.Payload = Payload;
            this.Errors = Errors;
        }
        public GetInvoiceStatusResponse()
        {
            this.Payload = default(ShipmentInvoiceStatusInfo);
            this.Errors = default(ErrorList);
        }


        /// <summary>
        /// The payload for the getCatalogItem operation.
        /// </summary>
        /// <value>The payload for the getCatalogItem operation.</value>
        [DataMember(Name = "payload", EmitDefaultValue = false)]
        public ShipmentInvoiceStatusInfo Payload { get; set; }

        /// <summary>
        /// One or more unexpected errors occurred during the getCatalogItem operation.
        /// </summary>
        /// <value>One or more unexpected errors occurred during the getCatalogItem operation.</value>
        [DataMember(Name = "errors", EmitDefaultValue = false)]
        public ErrorList Errors { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetInvoiceStatusResponse {\n");
            sb.Append("  Payload: ").Append(Payload).Append("\n");
            sb.Append("  Errors: ").Append(Errors).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
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
            return this.Equals(input as GetInvoiceStatusResponse);
        }

        /// <summary>
        /// Returns true if GetInvoiceStatusResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of GetInvoiceStatusResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetInvoiceStatusResponse input)
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
