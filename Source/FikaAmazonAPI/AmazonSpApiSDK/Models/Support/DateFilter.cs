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
    /// A date range filter with optional before and after bounds. Dates must be in &lt;a href=&#39;https://developer-docs.amazon.com/sp-api/docs/iso-8601&#39;&gt;ISO 8601&lt;/a&gt; format.
    /// </summary>
    [DataContract]
    public partial class DateFilter :  IEquatable<DateFilter>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateFilter" /> class.
        /// </summary>
        /// <param name="after">Include results with timestamps strictly after this value (exclusive)..</param>
        /// <param name="before">Include results with timestamps strictly before this value (exclusive)..</param>
        public DateFilter(DateTime? after = default(DateTime?), DateTime? before = default(DateTime?))
        {
            this.After = after;
            this.Before = before;
        }
        
        /// <summary>
        /// Include results with timestamps strictly after this value (exclusive).
        /// </summary>
        /// <value>Include results with timestamps strictly after this value (exclusive).</value>
        [DataMember(Name="after", EmitDefaultValue=false)]
        public DateTime? After { get; set; }

        /// <summary>
        /// Include results with timestamps strictly before this value (exclusive).
        /// </summary>
        /// <value>Include results with timestamps strictly before this value (exclusive).</value>
        [DataMember(Name="before", EmitDefaultValue=false)]
        public DateTime? Before { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DateFilter {\n");
            sb.Append("  After: ").Append(After).Append("\n");
            sb.Append("  Before: ").Append(Before).Append("\n");
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
            return this.Equals(input as DateFilter);
        }

        /// <summary>
        /// Returns true if DateFilter instances are equal
        /// </summary>
        /// <param name="input">Instance of DateFilter to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DateFilter input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.After == input.After ||
                    (this.After != null &&
                    this.After.Equals(input.After))
                ) && 
                (
                    this.Before == input.Before ||
                    (this.Before != null &&
                    this.Before.Equals(input.Before))
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
                if (this.After != null)
                    hashCode = hashCode * 59 + this.After.GetHashCode();
                if (this.Before != null)
                    hashCode = hashCode * 59 + this.Before.GetHashCode();
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
