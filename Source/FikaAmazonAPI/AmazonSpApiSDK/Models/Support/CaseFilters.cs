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
    /// Optional filters for case search. All filters are optional — when absent, no filtering is applied for that field. Different filters are combined with AND logic, and multiple values of the same field are combined with OR logic.
    /// </summary>
    [DataContract]
    public partial class CaseFilters :  IEquatable<CaseFilters>, IValidatableObject
    {
        /// <summary>
        /// Filter the collection by one or more case statuses.
        /// </summary>
        /// <value>Filter the collection by one or more case statuses.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CaseStatusesEnum
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
        /// Initializes a new instance of the <see cref="CaseFilters" /> class.
        /// </summary>
        /// <param name="caseStatuses">Filter the collection by one or more case statuses..</param>
        /// <param name="createdDate">Filter the collection by case creation date..</param>
        /// <param name="lastOutboundDate">Filter the collection by last outbound contact date..</param>
        /// <param name="resolvedDate">Filter the collection by case resolution date..</param>
        /// <param name="primaryEmails">Filter the collection by primary email address..</param>
        /// <param name="ccEmails">Filter the collection by one or more CC email addresses..</param>
        /// <param name="subjectKeywords">Filter the collection by case subject keywords. Maximum 200 characters..</param>
        public CaseFilters(List<CaseStatusesEnum> caseStatuses = default(List<CaseStatusesEnum>), DateFilter createdDate = default(DateFilter), DateFilter lastOutboundDate = default(DateFilter), DateFilter resolvedDate = default(DateFilter), List<string> primaryEmails = default(List<string>), List<string> ccEmails = default(List<string>), string subjectKeywords = default(string))
        {
            this.CaseStatuses = caseStatuses;
            this.CreatedDate = createdDate;
            this.LastOutboundDate = lastOutboundDate;
            this.ResolvedDate = resolvedDate;
            this.PrimaryEmails = primaryEmails;
            this.CcEmails = ccEmails;
            this.SubjectKeywords = subjectKeywords;
        }
        
        /// <summary>
        /// Filter the collection by one or more case statuses.
        /// </summary>
        /// <value>Filter the collection by one or more case statuses.</value>
        [DataMember(Name="caseStatuses", EmitDefaultValue=false)]
        public List<CaseStatusesEnum> CaseStatuses { get; set; }

        /// <summary>
        /// Filter the collection by case creation date.
        /// </summary>
        /// <value>Filter the collection by case creation date.</value>
        [DataMember(Name="createdDate", EmitDefaultValue=false)]
        public DateFilter CreatedDate { get; set; }

        /// <summary>
        /// Filter the collection by last outbound contact date.
        /// </summary>
        /// <value>Filter the collection by last outbound contact date.</value>
        [DataMember(Name="lastOutboundDate", EmitDefaultValue=false)]
        public DateFilter LastOutboundDate { get; set; }

        /// <summary>
        /// Filter the collection by case resolution date.
        /// </summary>
        /// <value>Filter the collection by case resolution date.</value>
        [DataMember(Name="resolvedDate", EmitDefaultValue=false)]
        public DateFilter ResolvedDate { get; set; }

        /// <summary>
        /// Filter the collection by primary email address.
        /// </summary>
        /// <value>Filter the collection by primary email address.</value>
        [DataMember(Name="primaryEmails", EmitDefaultValue=false)]
        public List<string> PrimaryEmails { get; set; }

        /// <summary>
        /// Filter the collection by one or more CC email addresses.
        /// </summary>
        /// <value>Filter the collection by one or more CC email addresses.</value>
        [DataMember(Name="ccEmails", EmitDefaultValue=false)]
        public List<string> CcEmails { get; set; }

        /// <summary>
        /// Filter the collection by case subject keywords. Maximum 200 characters.
        /// </summary>
        /// <value>Filter the collection by case subject keywords. Maximum 200 characters.</value>
        [DataMember(Name="subjectKeywords", EmitDefaultValue=false)]
        public string SubjectKeywords { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CaseFilters {\n");
            sb.Append("  CaseStatuses: ").Append(CaseStatuses).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  LastOutboundDate: ").Append(LastOutboundDate).Append("\n");
            sb.Append("  ResolvedDate: ").Append(ResolvedDate).Append("\n");
            sb.Append("  PrimaryEmails: ").Append(PrimaryEmails).Append("\n");
            sb.Append("  CcEmails: ").Append(CcEmails).Append("\n");
            sb.Append("  SubjectKeywords: ").Append(SubjectKeywords).Append("\n");
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
            return this.Equals(input as CaseFilters);
        }

        /// <summary>
        /// Returns true if CaseFilters instances are equal
        /// </summary>
        /// <param name="input">Instance of CaseFilters to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CaseFilters input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.CaseStatuses == input.CaseStatuses ||
                    this.CaseStatuses != null &&
                    input.CaseStatuses != null &&
                    this.CaseStatuses.SequenceEqual(input.CaseStatuses)
                ) && 
                (
                    this.CreatedDate == input.CreatedDate ||
                    (this.CreatedDate != null &&
                    this.CreatedDate.Equals(input.CreatedDate))
                ) && 
                (
                    this.LastOutboundDate == input.LastOutboundDate ||
                    (this.LastOutboundDate != null &&
                    this.LastOutboundDate.Equals(input.LastOutboundDate))
                ) && 
                (
                    this.ResolvedDate == input.ResolvedDate ||
                    (this.ResolvedDate != null &&
                    this.ResolvedDate.Equals(input.ResolvedDate))
                ) && 
                (
                    this.PrimaryEmails == input.PrimaryEmails ||
                    this.PrimaryEmails != null &&
                    input.PrimaryEmails != null &&
                    this.PrimaryEmails.SequenceEqual(input.PrimaryEmails)
                ) && 
                (
                    this.CcEmails == input.CcEmails ||
                    this.CcEmails != null &&
                    input.CcEmails != null &&
                    this.CcEmails.SequenceEqual(input.CcEmails)
                ) && 
                (
                    this.SubjectKeywords == input.SubjectKeywords ||
                    (this.SubjectKeywords != null &&
                    this.SubjectKeywords.Equals(input.SubjectKeywords))
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
                if (this.CaseStatuses != null)
                    hashCode = hashCode * 59 + this.CaseStatuses.GetHashCode();
                if (this.CreatedDate != null)
                    hashCode = hashCode * 59 + this.CreatedDate.GetHashCode();
                if (this.LastOutboundDate != null)
                    hashCode = hashCode * 59 + this.LastOutboundDate.GetHashCode();
                if (this.ResolvedDate != null)
                    hashCode = hashCode * 59 + this.ResolvedDate.GetHashCode();
                if (this.PrimaryEmails != null)
                    hashCode = hashCode * 59 + this.PrimaryEmails.GetHashCode();
                if (this.CcEmails != null)
                    hashCode = hashCode * 59 + this.CcEmails.GetHashCode();
                if (this.SubjectKeywords != null)
                    hashCode = hashCode * 59 + this.SubjectKeywords.GetHashCode();
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
            // SubjectKeywords (string) maxLength
            if(this.SubjectKeywords != null && this.SubjectKeywords.Length > 200)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SubjectKeywords, length must be less than 200.", new [] { "SubjectKeywords" });
            }

            // SubjectKeywords (string) minLength
            if(this.SubjectKeywords != null && this.SubjectKeywords.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SubjectKeywords, length must be greater than 1.", new [] { "SubjectKeywords" });
            }

            yield break;
        }
    }

}
