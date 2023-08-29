namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Messaging
{
    using System;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.ComponentModel.DataAnnotations;

    [DataContract]
    public partial class InvoiceRequest : IEquatable<InvoiceRequest>, IValidatableObject
    {
        public InvoiceRequest(List<Attachment> attachments = default(List<Attachment>), DateTime? coverageStartDate = default(DateTime?), DateTime? coverageEndDate = default(DateTime?))
        {
            this.Attachments = attachments;
        }

        [DataMember(Name = "attachments", EmitDefaultValue = false)]
        public List<Attachment> Attachments { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InvoiceRequest {\n");
            sb.Append("  Attachments: ").Append(Attachments).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public override bool Equals(object input)
        {
            return this.Equals(input as InvoiceRequest);
        }

        public bool Equals(InvoiceRequest input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Attachments == input.Attachments ||
                    this.Attachments != null &&
                    this.Attachments.SequenceEqual(input.Attachments)
                );
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Attachments != null)
                    hashCode = hashCode * 59 + this.Attachments.GetHashCode();
                return hashCode;
            }
        }

        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}