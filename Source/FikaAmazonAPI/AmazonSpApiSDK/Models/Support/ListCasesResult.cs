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
    /// A list of support cases.
    /// </summary>
    [DataContract]
    public partial class ListCasesResult :  IEquatable<ListCasesResult>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListCasesResult" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public ListCasesResult() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ListCasesResult" /> class.
        /// </summary>
        /// <param name="nextToken">A token to retrieve the next page of results. The response includes `nextToken` when the number of results exceeds the specified `maxResults` value. To get the next page of results, call the operation with this token and include the same arguments as the call that produced the token. To get a complete list, call this operation until `nextToken` is null. Note that this operation can return empty pages..</param>
        /// <param name="cases">A paginated list of support cases. (required).</param>
        public ListCasesResult(string nextToken = default(string), List<Case> cases = default(List<Case>))
        {
            // to ensure "cases" is required (not null)
            if (cases == null)
            {
                throw new InvalidDataException("cases is a required property for ListCasesResult and cannot be null");
            }
            else
            {
                this.Cases = cases;
            }
            this.NextToken = nextToken;
        }
        
        /// <summary>
        /// A token to retrieve the next page of results. The response includes `nextToken` when the number of results exceeds the specified `maxResults` value. To get the next page of results, call the operation with this token and include the same arguments as the call that produced the token. To get a complete list, call this operation until `nextToken` is null. Note that this operation can return empty pages.
        /// </summary>
        /// <value>A token to retrieve the next page of results. The response includes `nextToken` when the number of results exceeds the specified `maxResults` value. To get the next page of results, call the operation with this token and include the same arguments as the call that produced the token. To get a complete list, call this operation until `nextToken` is null. Note that this operation can return empty pages.</value>
        [DataMember(Name="nextToken", EmitDefaultValue=false)]
        public string NextToken { get; set; }

        /// <summary>
        /// A paginated list of support cases.
        /// </summary>
        /// <value>A paginated list of support cases.</value>
        [DataMember(Name="cases", EmitDefaultValue=false)]
        public List<Case> Cases { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ListCasesResult {\n");
            sb.Append("  NextToken: ").Append(NextToken).Append("\n");
            sb.Append("  Cases: ").Append(Cases).Append("\n");
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
            return this.Equals(input as ListCasesResult);
        }

        /// <summary>
        /// Returns true if ListCasesResult instances are equal
        /// </summary>
        /// <param name="input">Instance of ListCasesResult to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ListCasesResult input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.NextToken == input.NextToken ||
                    (this.NextToken != null &&
                    this.NextToken.Equals(input.NextToken))
                ) && 
                (
                    this.Cases == input.Cases ||
                    this.Cases != null &&
                    input.Cases != null &&
                    this.Cases.SequenceEqual(input.Cases)
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
                if (this.NextToken != null)
                    hashCode = hashCode * 59 + this.NextToken.GetHashCode();
                if (this.Cases != null)
                    hashCode = hashCode * 59 + this.Cases.GetHashCode();
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
