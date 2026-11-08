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
    /// The content for a phone contact.
    /// </summary>
    [DataContract]
    public partial class PhoneContent :  IEquatable<PhoneContent>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneContent" /> class.
        /// </summary>
        /// <param name="callNotes">Notes that summarize the phone call, provided by Amazon support.</param>
        public PhoneContent(string callNotes = default(string))
        {
            this.CallNotes = callNotes;
        }
        
        /// <summary>
        /// Notes that summarize the phone call, provided by Amazon support
        /// </summary>
        /// <value>Notes that summarize the phone call, provided by Amazon support</value>
        [DataMember(Name="callNotes", EmitDefaultValue=false)]
        public string CallNotes { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PhoneContent {\n");
            sb.Append("  CallNotes: ").Append(CallNotes).Append("\n");
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
            return this.Equals(input as PhoneContent);
        }

        /// <summary>
        /// Returns true if PhoneContent instances are equal
        /// </summary>
        /// <param name="input">Instance of PhoneContent to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PhoneContent input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.CallNotes == input.CallNotes ||
                    (this.CallNotes != null &&
                    this.CallNotes.Equals(input.CallNotes))
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
                if (this.CallNotes != null)
                    hashCode = hashCode * 59 + this.CallNotes.GetHashCode();
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
