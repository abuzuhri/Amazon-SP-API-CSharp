/* 
 * The Selling Partner API for Finances
 *
 * The Selling Partner API for Finances helps you obtain financial information relevant to a seller's business. You can obtain financial events for a given order or date range without having to wait until a statement period closes.
 *
 * OpenAPI spec version: 2024-06-19
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Finances.Model
{
    /// <summary>
    /// Breakdown provides details regarding the money movement under the financial transaction. Breakdowns get categorized further into breakdown types, breakdown amounts, and further breakdowns into a hierarchical structure.
    /// </summary>
    [DataContract]
    public partial class Breakdown :  IEquatable<Breakdown>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Breakdown" /> class.
        /// </summary>
        /// <param name="breakdownType">The type of charge..</param>
        /// <param name="breakdownAmount">The amount of the charge..</param>
        /// <param name="breakdowns">Further granular breakdowns of the BreakdownType..</param>
        public Breakdown(string breakdownType = default(string), Currency breakdownAmount = default(Currency), Breakdowns breakdowns = default(Breakdowns))
        {
            this.BreakdownType = breakdownType;
            this.BreakdownAmount = breakdownAmount;
            this.Breakdowns = breakdowns;
        }
        
        /// <summary>
        /// The type of charge.
        /// </summary>
        /// <value>The type of charge.</value>
        [DataMember(Name="breakdownType", EmitDefaultValue=false)]
        public string BreakdownType { get; set; }

        /// <summary>
        /// The amount of the charge.
        /// </summary>
        /// <value>The amount of the charge.</value>
        [DataMember(Name="breakdownAmount", EmitDefaultValue=false)]
        public Currency BreakdownAmount { get; set; }

        /// <summary>
        /// Further granular breakdowns of the BreakdownType.
        /// </summary>
        /// <value>Further granular breakdowns of the BreakdownType.</value>
        [DataMember(Name="breakdowns", EmitDefaultValue=false)]
        public Breakdowns Breakdowns { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Breakdown {\n");
            sb.Append("  BreakdownType: ").Append(BreakdownType).Append("\n");
            sb.Append("  BreakdownAmount: ").Append(BreakdownAmount).Append("\n");
            sb.Append("  Breakdowns: ").Append(Breakdowns).Append("\n");
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
            return this.Equals(input as Breakdown);
        }

        /// <summary>
        /// Returns true if Breakdown instances are equal
        /// </summary>
        /// <param name="input">Instance of Breakdown to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Breakdown input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.BreakdownType == input.BreakdownType ||
                    (this.BreakdownType != null &&
                    this.BreakdownType.Equals(input.BreakdownType))
                ) && 
                (
                    this.BreakdownAmount == input.BreakdownAmount ||
                    (this.BreakdownAmount != null &&
                    this.BreakdownAmount.Equals(input.BreakdownAmount))
                ) && 
                (
                    this.Breakdowns == input.Breakdowns ||
                    (this.Breakdowns != null &&
                    this.Breakdowns.Equals(input.Breakdowns))
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
                if (this.BreakdownType != null)
                    hashCode = hashCode * 59 + this.BreakdownType.GetHashCode();
                if (this.BreakdownAmount != null)
                    hashCode = hashCode * 59 + this.BreakdownAmount.GetHashCode();
                if (this.Breakdowns != null)
                    hashCode = hashCode * 59 + this.Breakdowns.GetHashCode();
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
