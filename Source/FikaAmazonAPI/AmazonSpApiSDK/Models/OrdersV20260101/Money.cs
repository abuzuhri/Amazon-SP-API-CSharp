using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// An amount of money, including units in the form of currency.
    /// </summary>
    [DataContract]
    public partial class Money : IEquatable<Money>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Money" /> class.
        /// </summary>
        /// <param name="amount">A decimal number with no loss of precision. Follows RFC 7159 for number representation. (required)</param>
        /// <param name="currencyCode">The three-letter currency code that identifies the currency type, following ISO 4217 international standards. (required)</param>

        public Money(decimal amount, string currencyCode)
        {
            this.Amount = amount;

            //ensure "currencyCode" is required (not null)
            if (currencyCode == null)
            {
                throw new ArgumentNullException("currencyCode is a required property for Money and cannot be null");
            }
            else
            {
                this.CurrencyCode = currencyCode;
            }
        }

        /// <summary>
        /// A decimal number with no loss of precision. Follows RFC 7159 for number representation.
        /// </summary>
        /// <value>A decimal number with no loss of precision. Follows RFC 7159 for number representation.</value>
        [DataMember(Name = "amount", EmitDefaultValue = false)]
        public decimal Amount { get; set; }

        /// <summary>
        /// The three-letter currency code that identifies the currency type, following ISO 4217 international standards.
        /// </summary>
        /// <value>The three-letter currency code that identifies the currency type, following ISO 4217 international standards.</value>
        [DataMember(Name = "currencyCode", EmitDefaultValue = false)]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Money {\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  CurrencyCode: ").Append(CurrencyCode).Append("\n");
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
            return this.Equals(obj as Money);
        }

        /// <summary>
        /// Returns true if Money instances are equal
        /// </summary>
        /// <param name="input">Instance of Money to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Money input)
        {
            if (input == null)
                return false;

            return
                (
                    this.CurrencyCode == input.CurrencyCode ||
                    (this.CurrencyCode != null &&
                    this.CurrencyCode.Equals(input.CurrencyCode))
                ) &&
                (
                    this.Amount == input.Amount ||
                    (this.Amount != null &&
                    this.Amount.Equals(input.Amount))
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
                if (this.Amount != null)
                    hashCode = hashCode * 59 + this.Amount.GetHashCode();
                if (this.CurrencyCode != null)
                    hashCode = hashCode * 59 + this.CurrencyCode.GetHashCode();
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