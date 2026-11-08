/* 
 * The Selling Partner API for Support
 *
 * The Selling Partner API for Support provides programmatic access to information about Selling Partner support.
 *
 * OpenAPI spec version: 2025-02-01
 * Contact: Selling Partner API Developer Support
 * Generated from: https://github.com/amzn/selling-partner-api-models/blob/main/models/support-api-model/support_2025-02-01.json
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Support
{
    /// <summary>
    /// The content of an email contact.
    /// </summary>
    [DataContract]
    public partial class EmailContent :  IEquatable<EmailContent>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailContent" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public EmailContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailContent" /> class.
        /// </summary>
        /// <param name="sender">The entity who sent the contact. (required).</param>
        /// <param name="message">The email body of the contact. (required).</param>
        /// <param name="attachments">All attachments included in the contact..</param>
        public EmailContent(Participant sender = default(Participant), string message = default(string), List<Attachment> attachments = default(List<Attachment>))
        {
            // to ensure "sender" is required (not null)
            if (sender == null)
            {
                throw new InvalidDataException("sender is a required property for EmailContent and cannot be null");
            }
            else
            {
                this.Sender = sender;
            }
            // to ensure "message" is required (not null)
            if (message == null)
            {
                throw new InvalidDataException("message is a required property for EmailContent and cannot be null");
            }
            else
            {
                this.Message = message;
            }
            this.Attachments = attachments;
        }
        
        /// <summary>
        /// The entity who sent the contact.
        /// </summary>
        /// <value>The entity who sent the contact.</value>
        [DataMember(Name="sender", EmitDefaultValue=false)]
        public Participant Sender { get; set; }

        /// <summary>
        /// The email body of the contact.
        /// </summary>
        /// <value>The email body of the contact.</value>
        [DataMember(Name="message", EmitDefaultValue=false)]
        public string Message { get; set; }

        /// <summary>
        /// All attachments included in the contact.
        /// </summary>
        /// <value>All attachments included in the contact.</value>
        [DataMember(Name="attachments", EmitDefaultValue=false)]
        public List<Attachment> Attachments { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EmailContent {\n");
            sb.Append("  Sender: ").Append(Sender).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  Attachments: ").Append(Attachments).Append("\n");
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
            return this.Equals(input as EmailContent);
        }

        /// <summary>
        /// Returns true if EmailContent instances are equal
        /// </summary>
        /// <param name="input">Instance of EmailContent to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EmailContent input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Sender == input.Sender ||
                    (this.Sender != null &&
                    this.Sender.Equals(input.Sender))
                ) && 
                (
                    this.Message == input.Message ||
                    (this.Message != null &&
                    this.Message.Equals(input.Message))
                ) && 
                (
                    this.Attachments == input.Attachments ||
                    this.Attachments != null &&
                    input.Attachments != null &&
                    this.Attachments.SequenceEqual(input.Attachments)
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
                if (this.Sender != null)
                    hashCode = hashCode * 59 + this.Sender.GetHashCode();
                if (this.Message != null)
                    hashCode = hashCode * 59 + this.Message.GetHashCode();
                if (this.Attachments != null)
                    hashCode = hashCode * 59 + this.Attachments.GetHashCode();
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
