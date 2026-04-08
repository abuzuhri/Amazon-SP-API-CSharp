using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Additional requirements needed for cross-border shipping of an order item.
    /// </summary>
    [DataContract]
    public partial class InternationalShipping : IEquatable<InternationalShipping>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InternationalShipping" /> class.
        /// </summary>
        public InternationalShipping() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InternationalShipping" /> class.
        /// </summary>
        /// <param name="iossNumber">Import One-Stop Shop registration number required for EU VAT compliance when shipping from outside the European Union. Sellers shipping to the EU from outside the EU must provide this IOSS number to their carrier when Amazon has collected the VAT on the sale.</param>
        public InternationalShipping(string iossNumber)
        {
            this.IossNumber = iossNumber;
        }

        /// <summary>
        /// Import One-Stop Shop registration number required for EU VAT compliance when shipping from outside the European Union. Sellers shipping to the EU from outside the EU must provide this IOSS number to their carrier when Amazon has collected the VAT on the sale.
        /// </summary>
        /// <value>Import One-Stop Shop registration number required for EU VAT compliance when shipping from outside the European Union. Sellers shipping to the EU from outside the EU must provide this IOSS number to their carrier when Amazon has collected the VAT on the sale.</value>
        [DataMember(Name = "iossNumber", EmitDefaultValue = false)]
        public string IossNumber { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InternationalShipping {\n");
            sb.Append("  IossNumber: ").Append(IossNumber).Append("\n");
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
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as InternationalShipping);
        }

        /// <summary>
        /// Returns true if InternationalShipping instances are equal
        /// </summary>
        /// <param name="input">Instance of InternationalShipping to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InternationalShipping input)
        {
            if (input == null)
                return false;

            return
                (
                    this.IossNumber == input.IossNumber ||
                    (this.IossNumber != null &&
                    this.IossNumber.Equals(input.IossNumber))
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
                if (this.IossNumber != null)
                    hashCode = hashCode * 59 + this.IossNumber.GetHashCode();
             
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