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
    /// A participant for a single-directional communication between a selling partner and Amazon support.
    /// </summary>
    [DataContract]
    public partial class Participant :  IEquatable<Participant>, IValidatableObject
    {
        /// <summary>
        /// The role of the participant.
        /// </summary>
        /// <value>The role of the participant.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RoleEnum
        {
            
            /// <summary>
            /// Enum AMAZON for value: AMAZON
            /// </summary>
            [EnumMember(Value = "AMAZON")]
            AMAZON = 1,
            
            /// <summary>
            /// Enum SELLINGPARTNER for value: SELLING_PARTNER
            /// </summary>
            [EnumMember(Value = "SELLING_PARTNER")]
            SELLINGPARTNER = 2
        }

        /// <summary>
        /// The role of the participant.
        /// </summary>
        /// <value>The role of the participant.</value>
        [DataMember(Name="role", EmitDefaultValue=false)]
        public RoleEnum Role { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Participant" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public Participant() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Participant" /> class.
        /// </summary>
        /// <param name="displayName">The human-readable name of the participant. (required).</param>
        /// <param name="role">The role of the participant. (required).</param>
        public Participant(string displayName = default(string), RoleEnum role = default(RoleEnum))
        {
            // to ensure "displayName" is required (not null)
            if (displayName == null)
            {
                throw new InvalidDataException("displayName is a required property for Participant and cannot be null");
            }
            else
            {
                this.DisplayName = displayName;
            }
            this.Role = role;
        }
        
        /// <summary>
        /// The human-readable name of the participant.
        /// </summary>
        /// <value>The human-readable name of the participant.</value>
        [DataMember(Name="displayName", EmitDefaultValue=false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Participant {\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Role: ").Append(Role).Append("\n");
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
            return this.Equals(input as Participant);
        }

        /// <summary>
        /// Returns true if Participant instances are equal
        /// </summary>
        /// <param name="input">Instance of Participant to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Participant input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.DisplayName == input.DisplayName ||
                    (this.DisplayName != null &&
                    this.DisplayName.Equals(input.DisplayName))
                ) && 
                (
                    this.Role == input.Role ||
                    this.Role.Equals(input.Role)
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
                if (this.DisplayName != null)
                    hashCode = hashCode * 59 + this.DisplayName.GetHashCode();
                hashCode = hashCode * 59 + this.Role.GetHashCode();
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
