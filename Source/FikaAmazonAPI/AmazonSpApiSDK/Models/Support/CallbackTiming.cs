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
    /// The time window for an appointment callback
    /// </summary>
    [DataContract]
    public partial class CallbackTiming :  IEquatable<CallbackTiming>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallbackTiming" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public CallbackTiming() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CallbackTiming" /> class.
        /// </summary>
        /// <param name="earliestCallbackTime">The earliest time at which to call the selling partner. (required).</param>
        /// <param name="latestCallbackTime">The latest time at which to call the selling partner. (required).</param>
        public CallbackTiming(DateTime? earliestCallbackTime = default(DateTime?), DateTime? latestCallbackTime = default(DateTime?))
        {
            // to ensure "earliestCallbackTime" is required (not null)
            if (earliestCallbackTime == null)
            {
                throw new InvalidDataException("earliestCallbackTime is a required property for CallbackTiming and cannot be null");
            }
            else
            {
                this.EarliestCallbackTime = earliestCallbackTime;
            }
            // to ensure "latestCallbackTime" is required (not null)
            if (latestCallbackTime == null)
            {
                throw new InvalidDataException("latestCallbackTime is a required property for CallbackTiming and cannot be null");
            }
            else
            {
                this.LatestCallbackTime = latestCallbackTime;
            }
        }
        
        /// <summary>
        /// The earliest time at which to call the selling partner.
        /// </summary>
        /// <value>The earliest time at which to call the selling partner.</value>
        [DataMember(Name="earliestCallbackTime", EmitDefaultValue=false)]
        public DateTime? EarliestCallbackTime { get; set; }

        /// <summary>
        /// The latest time at which to call the selling partner.
        /// </summary>
        /// <value>The latest time at which to call the selling partner.</value>
        [DataMember(Name="latestCallbackTime", EmitDefaultValue=false)]
        public DateTime? LatestCallbackTime { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallbackTiming {\n");
            sb.Append("  EarliestCallbackTime: ").Append(EarliestCallbackTime).Append("\n");
            sb.Append("  LatestCallbackTime: ").Append(LatestCallbackTime).Append("\n");
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
            return this.Equals(input as CallbackTiming);
        }

        /// <summary>
        /// Returns true if CallbackTiming instances are equal
        /// </summary>
        /// <param name="input">Instance of CallbackTiming to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallbackTiming input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.EarliestCallbackTime == input.EarliestCallbackTime ||
                    (this.EarliestCallbackTime != null &&
                    this.EarliestCallbackTime.Equals(input.EarliestCallbackTime))
                ) && 
                (
                    this.LatestCallbackTime == input.LatestCallbackTime ||
                    (this.LatestCallbackTime != null &&
                    this.LatestCallbackTime.Equals(input.LatestCallbackTime))
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
                if (this.EarliestCallbackTime != null)
                    hashCode = hashCode * 59 + this.EarliestCallbackTime.GetHashCode();
                if (this.LatestCallbackTime != null)
                    hashCode = hashCode * 59 + this.LatestCallbackTime.GetHashCode();
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
