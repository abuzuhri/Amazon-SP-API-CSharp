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
    /// The request body for the listCases operation.
    /// </summary>
    [DataContract]
    public partial class ListCasesRequest :  IEquatable<ListCasesRequest>, IValidatableObject
    {
        /// <summary>
        /// The sort direction. Defaults to DESC when absent.
        /// </summary>
        /// <value>The sort direction. Defaults to DESC when absent.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SortOrderEnum
        {
            
            /// <summary>
            /// Enum ASC for value: ASC
            /// </summary>
            [EnumMember(Value = "ASC")]
            ASC = 1,
            
            /// <summary>
            /// Enum DESC for value: DESC
            /// </summary>
            [EnumMember(Value = "DESC")]
            DESC = 2
        }

        /// <summary>
        /// The sort direction. Defaults to DESC when absent.
        /// </summary>
        /// <value>The sort direction. Defaults to DESC when absent.</value>
        [DataMember(Name="sortOrder", EmitDefaultValue=false)]
        public SortOrderEnum? SortOrder { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ListCasesRequest" /> class.
        /// </summary>
        /// <param name="caseFilters">Optional filters to narrow the returned collection. When absent, the operation returns all cases for the requesting identity..</param>
        /// <param name="sortOrder">The sort direction. Defaults to DESC when absent..</param>
        /// <param name="maxResults">Maximum number of results to return..</param>
        /// <param name="nextToken">A token to retrieve the next page of results. The response includes `nextToken` when the number of results exceeds the specified `maxResults` value. To get the next page of results, call the operation with this token and include the same arguments as the call that produced the token. To get a complete list, call this operation until `nextToken` is null. Note that this operation can return empty pages..</param>
        public ListCasesRequest(CaseFilters caseFilters = default(CaseFilters), SortOrderEnum? sortOrder = default(SortOrderEnum?), int? maxResults = default(int?), string nextToken = default(string))
        {
            this.CaseFilters = caseFilters;
            this.SortOrder = sortOrder;
            this.MaxResults = maxResults;
            this.NextToken = nextToken;
        }
        
        /// <summary>
        /// Optional filters to narrow the returned collection. When absent, the operation returns all cases for the requesting identity.
        /// </summary>
        /// <value>Optional filters to narrow the returned collection. When absent, the operation returns all cases for the requesting identity.</value>
        [DataMember(Name="caseFilters", EmitDefaultValue=false)]
        public CaseFilters CaseFilters { get; set; }

        /// <summary>
        /// Maximum number of results to return.
        /// </summary>
        /// <value>Maximum number of results to return.</value>
        [DataMember(Name="maxResults", EmitDefaultValue=false)]
        public int? MaxResults { get; set; }

        /// <summary>
        /// A token to retrieve the next page of results. The response includes `nextToken` when the number of results exceeds the specified `maxResults` value. To get the next page of results, call the operation with this token and include the same arguments as the call that produced the token. To get a complete list, call this operation until `nextToken` is null. Note that this operation can return empty pages.
        /// </summary>
        /// <value>A token to retrieve the next page of results. The response includes `nextToken` when the number of results exceeds the specified `maxResults` value. To get the next page of results, call the operation with this token and include the same arguments as the call that produced the token. To get a complete list, call this operation until `nextToken` is null. Note that this operation can return empty pages.</value>
        [DataMember(Name="nextToken", EmitDefaultValue=false)]
        public string NextToken { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ListCasesRequest {\n");
            sb.Append("  CaseFilters: ").Append(CaseFilters).Append("\n");
            sb.Append("  SortOrder: ").Append(SortOrder).Append("\n");
            sb.Append("  MaxResults: ").Append(MaxResults).Append("\n");
            sb.Append("  NextToken: ").Append(NextToken).Append("\n");
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
            return this.Equals(input as ListCasesRequest);
        }

        /// <summary>
        /// Returns true if ListCasesRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of ListCasesRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ListCasesRequest input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.CaseFilters == input.CaseFilters ||
                    (this.CaseFilters != null &&
                    this.CaseFilters.Equals(input.CaseFilters))
                ) && 
                (
                    this.SortOrder == input.SortOrder ||
                    (this.SortOrder != null &&
                    this.SortOrder.Equals(input.SortOrder))
                ) && 
                (
                    this.MaxResults == input.MaxResults ||
                    (this.MaxResults != null &&
                    this.MaxResults.Equals(input.MaxResults))
                ) && 
                (
                    this.NextToken == input.NextToken ||
                    (this.NextToken != null &&
                    this.NextToken.Equals(input.NextToken))
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
                if (this.CaseFilters != null)
                    hashCode = hashCode * 59 + this.CaseFilters.GetHashCode();
                if (this.SortOrder != null)
                    hashCode = hashCode * 59 + this.SortOrder.GetHashCode();
                if (this.MaxResults != null)
                    hashCode = hashCode * 59 + this.MaxResults.GetHashCode();
                if (this.NextToken != null)
                    hashCode = hashCode * 59 + this.NextToken.GetHashCode();
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
            // MaxResults (int?) maximum
            if(this.MaxResults > (int?)50)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for MaxResults, must be a value less than or equal to 50.", new [] { "MaxResults" });
            }

            // MaxResults (int?) minimum
            if(this.MaxResults < (int?)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for MaxResults, must be a value greater than or equal to 1.", new [] { "MaxResults" });
            }

            yield break;
        }
    }

}
