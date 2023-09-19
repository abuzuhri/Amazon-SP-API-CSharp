namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Messaging
{
    using System;
    using System.Text;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.ComponentModel.DataAnnotations;

    [DataContract]
    public partial class InvoiceResponse : IEquatable<InvoiceResponse>, IValidatableObject
    {
        public InvoiceResponse(ErrorList errors = default(ErrorList))
        {
            this.Errors = errors;
        }

        public InvoiceResponse()
        {
            this.Errors = default(ErrorList);
        }

        [DataMember(Name = "errors", EmitDefaultValue = false)]
        public ErrorList Errors { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InvoiceResponse {\n");
            sb.Append("  Errors: ").Append(Errors).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public override bool Equals(object input)
        {
            return this.Equals(input as InvoiceResponse);
        }

        public bool Equals(InvoiceResponse input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Errors == input.Errors ||
                    (this.Errors != null &&
                    this.Errors.Equals(input.Errors))
                );
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 41;
                if (this.Errors != null)
                    hashCode = hashCode * 59 + this.Errors.GetHashCode();
                return hashCode;
            }
        }

        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}