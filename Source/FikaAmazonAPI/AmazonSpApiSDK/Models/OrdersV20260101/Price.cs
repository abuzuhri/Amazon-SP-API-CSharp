using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Pricing information for the order item.
    /// </summary>
    [DataContract]
    public partial class Price : IEquatable<Price>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Price" /> class.
        /// </summary>
        public Price()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Price" /> class.
        /// </summary>
        /// <param name="unitPrice">An amount of money, including units in the form of currency.</param>
        /// <param name="priceDesignation">Indicates that the selling price is a special price that is only available for Amazon Business orders. For more information about the Amazon Business Seller Program, refer to the Amazon Business website.</param>
        public Price(Money unitPrice, PriceDesignationEnum? priceDesignation)
        {
            this.UnitPrice = unitPrice;
            this.PriceDesignation = priceDesignation;
        }

        /// <summary>
        /// An amount of money, including units in the form of currency.
        /// </summary>
        /// <value>An amount of money, including units in the form of currency.</value>
        [DataMember(Name = "unitPrice", EmitDefaultValue = false)]
        public Money UnitPrice { get; set; }

        /// <summary>
        /// Indicates that the selling price is a special price that is only available for Amazon Business orders. For more information about the Amazon Business Seller Program, refer to the Amazon Business website.
        /// </summary>
        /// <value>Indicates that the selling price is a special price that is only available for Amazon Business orders. For more information about the Amazon Business Seller Program, refer to the Amazon Business website.</value>
        [DataMember(Name = "priceDesignation", EmitDefaultValue = false)]
        public PriceDesignationEnum? PriceDesignation { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Price {\n");
            sb.Append("  UnitPrice: ").Append(UnitPrice).Append("\n");
            sb.Append("  PriceDesignation: ").Append(PriceDesignation).Append("\n");
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
            return this.Equals(obj as Price);
        }

        /// <summary>
        /// Returns true if Price instances are equal
        /// </summary>
        /// <param name="input">Instance of Price to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Price input)
        {
            if (input == null)
                return false;

            return
                (
                    this.UnitPrice == input.UnitPrice ||
                    (this.UnitPrice != null &&
                    this.UnitPrice.Equals(input.UnitPrice))
                ) &&
                (
                    this.PriceDesignation == input.PriceDesignation ||
                    (this.PriceDesignation != null &&
                    this.PriceDesignation.Equals(input.PriceDesignation))
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
                if (this.UnitPrice != null)
                    hashCode = hashCode * 59 + this.UnitPrice.GetHashCode();
                if (this.PriceDesignation != null)
                    hashCode = hashCode * 59 + this.PriceDesignation.GetHashCode();
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