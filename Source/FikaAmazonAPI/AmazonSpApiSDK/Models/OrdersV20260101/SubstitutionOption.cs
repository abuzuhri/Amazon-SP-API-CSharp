using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Alternative product that can be substituted for the original item if it becomes unavailable.
    /// </summary>
    [DataContract]
    public partial class SubstitutionOption : IEquatable<SubstitutionOption>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubstitutionOption" /> class.
        /// </summary>
        /// <param name="asin">Amazon Standard Identification Number of the substitute product.</param>
        /// <param name="quantityOrdered">Number of units of the substitute item to be selected if substitution occurs.</param>
        /// <param name="sellerSku">The item's seller stock keeping unit (SKU).</param>
        /// <param name="title">Product name or title of the substitute item as displayed to customers.</param>
        /// <param name="measurement">Specifies the unit of measure and quantity for items that are sold by weight, volume, length, or other measurements rather than simple count.</param>
        public SubstitutionOption(string asin = default,
                                  int? quantityOrdered = default,
                                  string sellerSku = default,
                                  string title = default,
                                  Measurement measurement = default)
        {
            this.Asin = asin;
            this.QuantityOrdered = quantityOrdered;
            this.SellerSku = sellerSku;
            this.Title = title;
            this.Measurement = measurement;
        }

        public SubstitutionOption()
        {
            this.Asin = default;
            this.QuantityOrdered = default;
            this.SellerSku = default;
            this.Title = default;
            this.Measurement = default;
        }

        /// <summary>
        /// Amazon Standard Identification Number of the substitute product.
        /// </summary>
        /// <value>Amazon Standard Identification Number of the substitute product.</value>
        [DataMember(Name = "asin", EmitDefaultValue = false)]
        public string Asin { get; set; }

        /// <summary>
        /// Number of units of the substitute item to be selected if substitution occurs.
        /// </summary>
        /// <value>Number of units of the substitute item to be selected if substitution occurs.</value>
        [DataMember(Name = "quantityOrdered", EmitDefaultValue = false)]
        public int? QuantityOrdered { get; set; }

        /// <summary>
        /// The item's seller stock keeping unit (SKU).
        /// </summary>
        /// <value>The item's seller stock keeping unit (SKU).</value>
        [DataMember(Name = "sellerSku", EmitDefaultValue = false)]
        public string SellerSku { get; set; }

        /// <summary>
        /// Product name or title of the substitute item as displayed to customers.
        /// </summary>
        /// <value>Product name or title of the substitute item as displayed to customers.</value>
        [DataMember(Name = "title", EmitDefaultValue = false)]
        public string Title { get; set; }

        /// <summary>
        /// Specifies the unit of measure and quantity for items that are sold by weight, volume, length, or other measurements rather than simple count.
        /// </summary>
        /// <value>Specifies the unit of measure and quantity for items that are sold by weight, volume, length, or other measurements rather than simple count.</value>
        [DataMember(Name = "measurement", EmitDefaultValue = false)]
        public Measurement Measurement { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SubstitutionOption {\n");
            sb.Append("  Asin: ").Append(Asin).Append("\n");
            sb.Append("  QuantityOrdered: ").Append(QuantityOrdered).Append("\n");
            sb.Append("  SellerSku: ").Append(SellerSku).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Measurement: ").Append(Measurement).Append("\n");
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
            return this.Equals(input as SubstitutionOption);
        }

        /// <summary>
        /// Returns true if SubstitutionOption instances are equal
        /// </summary>
        /// <param name="input">Instance of SubstitutionOption to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SubstitutionOption input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Asin == input.Asin ||
                    (this.Asin != null &&
                    this.Asin.Equals(input.Asin))
                ) &&
                (
                    this.QuantityOrdered == input.QuantityOrdered ||
                    (this.QuantityOrdered != null &&
                    this.QuantityOrdered.Equals(input.QuantityOrdered))
                ) &&
                (
                    this.SellerSku == input.SellerSku ||
                    (this.SellerSku != null &&
                    this.SellerSku.Equals(input.SellerSku))
                ) &&
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) &&
                (
                    this.Measurement == input.Measurement ||
                    (this.Measurement != null &&
                    this.Measurement.Equals(input.Measurement))
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
                if (this.Asin != null)
                    hashCode = hashCode * 59 + this.Asin.GetHashCode();
                if (this.QuantityOrdered != null)
                    hashCode = hashCode * 59 + this.QuantityOrdered.GetHashCode();
                if (this.SellerSku != null)
                    hashCode = hashCode * 59 + this.SellerSku.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.Measurement != null)
                    hashCode = hashCode * 59 + this.Measurement.GetHashCode();
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