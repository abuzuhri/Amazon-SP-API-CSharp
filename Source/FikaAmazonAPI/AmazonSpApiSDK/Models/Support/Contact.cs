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
    /// A contact.
    /// </summary>
    [DataContract]
    public partial class Contact :  IEquatable<Contact>, IValidatableObject
    {
        /// <summary>
        /// The contact channel for communication between the selling partner and Amazon.
        /// </summary>
        /// <value>The contact channel for communication between the selling partner and Amazon.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ChannelEnum
        {
            
            /// <summary>
            /// Enum PHONE for value: PHONE
            /// </summary>
            [EnumMember(Value = "PHONE")]
            PHONE = 1,
            
            /// <summary>
            /// Enum CHAT for value: CHAT
            /// </summary>
            [EnumMember(Value = "CHAT")]
            CHAT = 2,
            
            /// <summary>
            /// Enum EMAIL for value: EMAIL
            /// </summary>
            [EnumMember(Value = "EMAIL")]
            EMAIL = 3
        }

        /// <summary>
        /// The contact channel for communication between the selling partner and Amazon.
        /// </summary>
        /// <value>The contact channel for communication between the selling partner and Amazon.</value>
        [DataMember(Name="channel", EmitDefaultValue=false)]
        public ChannelEnum Channel { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Contact" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public Contact() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Contact" /> class.
        /// </summary>
        /// <param name="contactId">A unique identifier for the contact (required).</param>
        /// <param name="channel">The contact channel for communication between the selling partner and Amazon. (required).</param>
        /// <param name="emailContent">The content of the contact. Only available if the contact channel is `EMAIL`..</param>
        /// <param name="phoneContent">The content of the contact. Only available if the contact channel is `PHONE`..</param>
        /// <param name="chatContent">The content of the contact. Only available if the contact channel is `CHAT`..</param>
        /// <param name="createdDate">The time at which the contact was created. In [ISO 8601](https://developer-docs.amazon/sp-api/docs/iso-8601) format. (required).</param>
        public Contact(string contactId = default(string), ChannelEnum channel = default(ChannelEnum), EmailContent emailContent = default(EmailContent), PhoneContent phoneContent = default(PhoneContent), ChatContent chatContent = default(ChatContent), DateTime? createdDate = default(DateTime?))
        {
            // to ensure "contactId" is required (not null)
            if (contactId == null)
            {
                throw new InvalidDataException("contactId is a required property for Contact and cannot be null");
            }
            else
            {
                this.ContactId = contactId;
            }
            // to ensure "createdDate" is required (not null)
            if (createdDate == null)
            {
                throw new InvalidDataException("createdDate is a required property for Contact and cannot be null");
            }
            else
            {
                this.CreatedDate = createdDate;
            }
            this.Channel = channel;
            this.EmailContent = emailContent;
            this.PhoneContent = phoneContent;
            this.ChatContent = chatContent;
        }
        
        /// <summary>
        /// A unique identifier for the contact
        /// </summary>
        /// <value>A unique identifier for the contact</value>
        [DataMember(Name="contactId", EmitDefaultValue=false)]
        public string ContactId { get; set; }

        /// <summary>
        /// The content of the contact. Only available if the contact channel is `EMAIL`.
        /// </summary>
        /// <value>The content of the contact. Only available if the contact channel is `EMAIL`.</value>
        [DataMember(Name="emailContent", EmitDefaultValue=false)]
        public EmailContent EmailContent { get; set; }

        /// <summary>
        /// The content of the contact. Only available if the contact channel is `PHONE`.
        /// </summary>
        /// <value>The content of the contact. Only available if the contact channel is `PHONE`.</value>
        [DataMember(Name="phoneContent", EmitDefaultValue=false)]
        public PhoneContent PhoneContent { get; set; }

        /// <summary>
        /// The content of the contact. Only available if the contact channel is `CHAT`.
        /// </summary>
        /// <value>The content of the contact. Only available if the contact channel is `CHAT`.</value>
        [DataMember(Name="chatContent", EmitDefaultValue=false)]
        public ChatContent ChatContent { get; set; }

        /// <summary>
        /// The time at which the contact was created. In [ISO 8601](https://developer-docs.amazon/sp-api/docs/iso-8601) format.
        /// </summary>
        /// <value>The time at which the contact was created. In [ISO 8601](https://developer-docs.amazon/sp-api/docs/iso-8601) format.</value>
        [DataMember(Name="createdDate", EmitDefaultValue=false)]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Contact {\n");
            sb.Append("  ContactId: ").Append(ContactId).Append("\n");
            sb.Append("  Channel: ").Append(Channel).Append("\n");
            sb.Append("  EmailContent: ").Append(EmailContent).Append("\n");
            sb.Append("  PhoneContent: ").Append(PhoneContent).Append("\n");
            sb.Append("  ChatContent: ").Append(ChatContent).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
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
            return this.Equals(input as Contact);
        }

        /// <summary>
        /// Returns true if Contact instances are equal
        /// </summary>
        /// <param name="input">Instance of Contact to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Contact input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ContactId == input.ContactId ||
                    (this.ContactId != null &&
                    this.ContactId.Equals(input.ContactId))
                ) && 
                (
                    this.Channel == input.Channel ||
                    this.Channel.Equals(input.Channel)
                ) && 
                (
                    this.EmailContent == input.EmailContent ||
                    (this.EmailContent != null &&
                    this.EmailContent.Equals(input.EmailContent))
                ) && 
                (
                    this.PhoneContent == input.PhoneContent ||
                    (this.PhoneContent != null &&
                    this.PhoneContent.Equals(input.PhoneContent))
                ) && 
                (
                    this.ChatContent == input.ChatContent ||
                    (this.ChatContent != null &&
                    this.ChatContent.Equals(input.ChatContent))
                ) && 
                (
                    this.CreatedDate == input.CreatedDate ||
                    (this.CreatedDate != null &&
                    this.CreatedDate.Equals(input.CreatedDate))
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
                if (this.ContactId != null)
                    hashCode = hashCode * 59 + this.ContactId.GetHashCode();
                hashCode = hashCode * 59 + this.Channel.GetHashCode();
                if (this.EmailContent != null)
                    hashCode = hashCode * 59 + this.EmailContent.GetHashCode();
                if (this.PhoneContent != null)
                    hashCode = hashCode * 59 + this.PhoneContent.GetHashCode();
                if (this.ChatContent != null)
                    hashCode = hashCode * 59 + this.ChatContent.GetHashCode();
                if (this.CreatedDate != null)
                    hashCode = hashCode * 59 + this.CreatedDate.GetHashCode();
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
