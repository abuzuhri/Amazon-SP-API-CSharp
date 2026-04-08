using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// When a request has results that are not included in the response, pagination occurs. This means the results are divided into individual pages. 
    /// To retrieve a different page, you must pass the token value as the paginationToken query parameter in the subsequent request. 
    /// All other parameters must be provided with the same values that were provided with the request that generated this token, with the exception of maxResultsPerPage and includedData, which can be modified between calls. 
    /// The token will expire after 24 hours. When there are no other pages to fetch, the pagination field will be absent from the response.
    /// </summary>
    [DataContract]
    public partial class Pagination :  IEquatable<Pagination>, IValidatableObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Pagination" /> class.
        /// </summary>
        public Pagination() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pagination" /> class.
        /// </summary>
        /// <param name="nextToken">A token that can be used to fetch the next page of results.</param>
        public Pagination(string nextToken = default)
        {
            NextToken = nextToken;
        }

        /// <summary>
        /// A token that can be used to fetch the next page of results.
        /// </summary>
        /// <value>A token that can be used to fetch the next page of results.</value>
        [DataMember(Name="nextToken", EmitDefaultValue=false)]
        public string NextToken { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Pagination {\n");
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
            return Equals(input as Pagination);
        }

        /// <summary>
        /// Returns true if Pagination instances are equal
        /// </summary>
        /// <param name="input">Instance of Pagination to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Pagination input)
        {
            if (input == null)
                return false;

            return 
                
                    NextToken == input.NextToken ||
                    NextToken != null &&
                    NextToken.Equals(input.NextToken)
                ;
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
                if (NextToken != null)
                    hashCode = hashCode * 59 + NextToken.GetHashCode();
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
            // NextToken (string) maxLength
            if(NextToken != null && NextToken.Length > 1024)
            {
                yield return new ValidationResult("Invalid value for NextToken, length must be less than 1024.", new [] { "NextToken" });
            }

            // NextToken (string) minLength
            if(NextToken != null && NextToken.Length < 1)
            {
                yield return new ValidationResult("Invalid value for NextToken, length must be greater than 1.", new [] { "NextToken" });
            }

            yield break;
        }
    }

}
