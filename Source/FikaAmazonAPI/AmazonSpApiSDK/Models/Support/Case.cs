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
    /// The support case.
    /// </summary>
    [DataContract]
    public partial class Case :  IEquatable<Case>, IValidatableObject
    {
        /// <summary>
        /// The current status of the case.
        /// </summary>
        /// <value>The current status of the case.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            
            /// <summary>
            /// Enum RESOLVED for value: RESOLVED
            /// </summary>
            [EnumMember(Value = "RESOLVED")]
            RESOLVED = 1,
            
            /// <summary>
            /// Enum TRANSFERRED for value: TRANSFERRED
            /// </summary>
            [EnumMember(Value = "TRANSFERRED")]
            TRANSFERRED = 2,
            
            /// <summary>
            /// Enum PENDINGMERCHANTACTION for value: PENDING_MERCHANT_ACTION
            /// </summary>
            [EnumMember(Value = "PENDING_MERCHANT_ACTION")]
            PENDINGMERCHANTACTION = 3,
            
            /// <summary>
            /// Enum PENDINGAMAZONACTION for value: PENDING_AMAZON_ACTION
            /// </summary>
            [EnumMember(Value = "PENDING_AMAZON_ACTION")]
            PENDINGAMAZONACTION = 4
        }

        /// <summary>
        /// The current status of the case.
        /// </summary>
        /// <value>The current status of the case.</value>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public StatusEnum Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Case" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public Case() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Case" /> class.
        /// </summary>
        /// <param name="caseId">A globally unique identifier for the case (required).</param>
        /// <param name="status">The current status of the case. (required).</param>
        /// <param name="subject">The subject of the case. (required).</param>
        /// <param name="primaryEmail">The primary email associated with the case. (required).</param>
        /// <param name="ccEmails">Additional emails that are attached to the case. (required).</param>
        /// <param name="appointments">All appointments for the case..</param>
        /// <param name="createdDate">The time when the case was created. In [ISO 8601](https://developer-docs.amazon/sp-api/docs/iso-8601) format. (required).</param>
        /// <param name="lastUpdatedDate">The time when the case was last updated, which includes updates to the case details and new contacts added to the case. In [ISO 8601](https://developer-docs.amazon/sp-api/docs/iso-8601) format. (required).</param>
        /// <param name="resolvedDate">The time when the case was resolved. In [ISO 8601](https://developer-docs.amazon/sp-api/docs/iso-8601) format..</param>
        public Case(string caseId = default(string), StatusEnum status = default(StatusEnum), string subject = default(string), string primaryEmail = default(string), List<string> ccEmails = default(List<string>), List<Appointment> appointments = default(List<Appointment>), DateTime? createdDate = default(DateTime?), DateTime? lastUpdatedDate = default(DateTime?), DateTime? resolvedDate = default(DateTime?))
        {
            // to ensure "caseId" is required (not null)
            if (caseId == null)
            {
                throw new InvalidDataException("caseId is a required property for Case and cannot be null");
            }
            else
            {
                this.CaseId = caseId;
            }
            // to ensure "subject" is required (not null)
            if (subject == null)
            {
                throw new InvalidDataException("subject is a required property for Case and cannot be null");
            }
            else
            {
                this.Subject = subject;
            }
            // to ensure "primaryEmail" is required (not null)
            if (primaryEmail == null)
            {
                throw new InvalidDataException("primaryEmail is a required property for Case and cannot be null");
            }
            else
            {
                this.PrimaryEmail = primaryEmail;
            }
            // to ensure "ccEmails" is required (not null)
            if (ccEmails == null)
            {
                throw new InvalidDataException("ccEmails is a required property for Case and cannot be null");
            }
            else
            {
                this.CcEmails = ccEmails;
            }
            // to ensure "createdDate" is required (not null)
            if (createdDate == null)
            {
                throw new InvalidDataException("createdDate is a required property for Case and cannot be null");
            }
            else
            {
                this.CreatedDate = createdDate;
            }
            // to ensure "lastUpdatedDate" is required (not null)
            if (lastUpdatedDate == null)
            {
                throw new InvalidDataException("lastUpdatedDate is a required property for Case and cannot be null");
            }
            else
            {
                this.LastUpdatedDate = lastUpdatedDate;
            }
            this.Status = status;
            this.Appointments = appointments;
            this.ResolvedDate = resolvedDate;
        }
        
        /// <summary>
        /// A globally unique identifier for the case
        /// </summary>
        /// <value>A globally unique identifier for the case</value>
        [DataMember(Name="caseId", EmitDefaultValue=false)]
        public string CaseId { get; set; }

        /// <summary>
        /// The subject of the case.
        /// </summary>
        /// <value>The subject of the case.</value>
        [DataMember(Name="subject", EmitDefaultValue=false)]
        public string Subject { get; set; }

        /// <summary>
        /// The primary email associated with the case.
        /// </summary>
        /// <value>The primary email associated with the case.</value>
        [DataMember(Name="primaryEmail", EmitDefaultValue=false)]
        public string PrimaryEmail { get; set; }

        /// <summary>
        /// Additional emails that are attached to the case.
        /// </summary>
        /// <value>Additional emails that are attached to the case.</value>
        [DataMember(Name="ccEmails", EmitDefaultValue=false)]
        public List<string> CcEmails { get; set; }

        /// <summary>
        /// All appointments for the case.
        /// </summary>
        /// <value>All appointments for the case.</value>
        [DataMember(Name="appointments", EmitDefaultValue=false)]
        public List<Appointment> Appointments { get; set; }

        /// <summary>
        /// The time when the case was created. In [ISO 8601](https://developer-docs.amazon/sp-api/docs/iso-8601) format.
        /// </summary>
        /// <value>The time when the case was created. In [ISO 8601](https://developer-docs.amazon/sp-api/docs/iso-8601) format.</value>
        [DataMember(Name="createdDate", EmitDefaultValue=false)]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// The time when the case was last updated, which includes updates to the case details and new contacts added to the case. In [ISO 8601](https://developer-docs.amazon/sp-api/docs/iso-8601) format.
        /// </summary>
        /// <value>The time when the case was last updated, which includes updates to the case details and new contacts added to the case. In [ISO 8601](https://developer-docs.amazon/sp-api/docs/iso-8601) format.</value>
        [DataMember(Name="lastUpdatedDate", EmitDefaultValue=false)]
        public DateTime? LastUpdatedDate { get; set; }

        /// <summary>
        /// The time when the case was resolved. In [ISO 8601](https://developer-docs.amazon/sp-api/docs/iso-8601) format.
        /// </summary>
        /// <value>The time when the case was resolved. In [ISO 8601](https://developer-docs.amazon/sp-api/docs/iso-8601) format.</value>
        [DataMember(Name="resolvedDate", EmitDefaultValue=false)]
        public DateTime? ResolvedDate { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Case {\n");
            sb.Append("  CaseId: ").Append(CaseId).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Subject: ").Append(Subject).Append("\n");
            sb.Append("  PrimaryEmail: ").Append(PrimaryEmail).Append("\n");
            sb.Append("  CcEmails: ").Append(CcEmails).Append("\n");
            sb.Append("  Appointments: ").Append(Appointments).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  LastUpdatedDate: ").Append(LastUpdatedDate).Append("\n");
            sb.Append("  ResolvedDate: ").Append(ResolvedDate).Append("\n");
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
            return this.Equals(input as Case);
        }

        /// <summary>
        /// Returns true if Case instances are equal
        /// </summary>
        /// <param name="input">Instance of Case to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Case input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.CaseId == input.CaseId ||
                    (this.CaseId != null &&
                    this.CaseId.Equals(input.CaseId))
                ) && 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
                ) && 
                (
                    this.Subject == input.Subject ||
                    (this.Subject != null &&
                    this.Subject.Equals(input.Subject))
                ) && 
                (
                    this.PrimaryEmail == input.PrimaryEmail ||
                    (this.PrimaryEmail != null &&
                    this.PrimaryEmail.Equals(input.PrimaryEmail))
                ) && 
                (
                    this.CcEmails == input.CcEmails ||
                    this.CcEmails != null &&
                    input.CcEmails != null &&
                    this.CcEmails.SequenceEqual(input.CcEmails)
                ) && 
                (
                    this.Appointments == input.Appointments ||
                    this.Appointments != null &&
                    input.Appointments != null &&
                    this.Appointments.SequenceEqual(input.Appointments)
                ) && 
                (
                    this.CreatedDate == input.CreatedDate ||
                    (this.CreatedDate != null &&
                    this.CreatedDate.Equals(input.CreatedDate))
                ) && 
                (
                    this.LastUpdatedDate == input.LastUpdatedDate ||
                    (this.LastUpdatedDate != null &&
                    this.LastUpdatedDate.Equals(input.LastUpdatedDate))
                ) && 
                (
                    this.ResolvedDate == input.ResolvedDate ||
                    (this.ResolvedDate != null &&
                    this.ResolvedDate.Equals(input.ResolvedDate))
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
                if (this.CaseId != null)
                    hashCode = hashCode * 59 + this.CaseId.GetHashCode();
                hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.Subject != null)
                    hashCode = hashCode * 59 + this.Subject.GetHashCode();
                if (this.PrimaryEmail != null)
                    hashCode = hashCode * 59 + this.PrimaryEmail.GetHashCode();
                if (this.CcEmails != null)
                    hashCode = hashCode * 59 + this.CcEmails.GetHashCode();
                if (this.Appointments != null)
                    hashCode = hashCode * 59 + this.Appointments.GetHashCode();
                if (this.CreatedDate != null)
                    hashCode = hashCode * 59 + this.CreatedDate.GetHashCode();
                if (this.LastUpdatedDate != null)
                    hashCode = hashCode * 59 + this.LastUpdatedDate.GetHashCode();
                if (this.ResolvedDate != null)
                    hashCode = hashCode * 59 + this.ResolvedDate.GetHashCode();
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
