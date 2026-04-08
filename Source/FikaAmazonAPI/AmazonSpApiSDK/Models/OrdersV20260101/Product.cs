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
    /// Product information for an order item.
    /// </summary>
    [DataContract]
    public partial class Product : IEquatable<Product>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product" /> class.
        /// </summary>
        public Product() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product" /> class.
        /// </summary>
        /// <param name="asin">The Amazon Standard Identification Number (ASIN), which uniquely identifies a product (catalog item).</param>
        /// <param name="title">The product name or title as displayed to customers in the marketplace.</param>
        /// <param name="sellerSku">The seller SKU of a product (catalog item). This is a unique number assigned by the seller when listing an item.</param>
        /// <param name="condition">Detailed information about the physical condition and quality state of the item being sold.</param>
        /// <param name="price">Pricing information for the order item.</param>
        /// <param name="serialNumbers">Unique serial numbers for products that require individual tracking, typically provided for FBA orders.</param>
        /// <param name="customization">Information about any personalization, customization, or special modifications applied to this order item.</param>
        public Product(string asin,
                       string title,
                       string sellerSku,
                       Condition condition,
                       Price price,
                       List<string> serialNumbers,
                       OrderItemCustomization customization)
        {
            this.Asin = asin;
            this.Title = title;
            this.SellerSku = sellerSku;
            this.Condition = condition;
            this.Price = price;
            this.SerialNumbers = serialNumbers;
            this.Customization = customization;
        }


        /// <summary>
        /// The Amazon Standard Identification Number (ASIN), which uniquely identifies a product (catalog item).
        /// </summary>
        /// <value>The Amazon Standard Identification Number (ASIN), which uniquely identifies a product (catalog item).</value>
        [DataMember(Name = "asin", EmitDefaultValue = false)]
        public string Asin { get; set; }

        /// <summary>
        /// The product name or title as displayed to customers in the marketplace.
        /// </summary>
        /// <value>The product name or title as displayed to customers in the marketplace.</value>
        [DataMember(Name = "title", EmitDefaultValue = false)]
        public string Title { get; set; }

        /// <summary>
        /// The seller SKU of a product (catalog item). This is a unique number assigned by the seller when listing an item.
        /// </summary>
        /// <value>The seller SKU of a product (catalog item). This is a unique number assigned by the seller when listing an item.</value>
        [DataMember(Name = "sellerSku", EmitDefaultValue = false)]
        public string SellerSku { get; set; }

        /// <summary>
        /// Detailed information about the physical condition and quality state of the item being sold.
        /// </summary>
        /// <value>Detailed information about the physical condition and quality state of the item being sold.</value>
        [DataMember(Name = "condition", EmitDefaultValue = false)]
        public Condition Condition { get; set; }

        /// <summary>
        /// Pricing information for the order item.
        /// </summary>
        /// <value>Pricing information for the order item.</value>
        [DataMember(Name = "price", EmitDefaultValue = false)]
        public Price Price { get; set; }

        /// <summary>
        /// Unique serial numbers for products that require individual tracking, typically provided for FBA orders.
        /// </summary>
        /// <value>Unique serial numbers for products that require individual tracking, typically provided for FBA orders.</value>
        [DataMember(Name = "serialNumbers", EmitDefaultValue = false)]
        public List<string> SerialNumbers { get; set; }

        /// <summary>
        /// Information about any personalization, customization, or special modifications applied to this order item.
        /// </summary>
        /// <value>Information about any personalization, customization, or special modifications applied to this order item.</value>
        [DataMember(Name = "customization", EmitDefaultValue = false)]
        public OrderItemCustomization Customization { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Product {\n");
            sb.Append("  Asin: ").Append(Asin).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  SellerSku: ").Append(SellerSku).Append("\n");
            sb.Append("  Condition: ").Append(Condition).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  SerialNumbers: ").Append(SerialNumbers).Append("\n");
            sb.Append("  Customization: ").Append(Customization).Append("\n");
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
            return this.Equals(obj as Product);
        }

        /// <summary>
        /// Returns true if Product instances are equal
        /// </summary>
        /// <param name="input">Instance of Product to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Product input)
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
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) &&
                (
                    this.SellerSku == input.SellerSku ||
                    (this.SellerSku != null &&
                    this.SellerSku.Equals(input.SellerSku))
                ) &&
                (
                    this.Condition == input.Condition ||
                    (this.Condition != null &&
                    this.Condition.Equals(input.Condition))
                ) &&
                (
                    this.Price == input.Price ||
                    (this.Price != null &&
                    this.Price.Equals(input.Price))
                ) &&
                (
                    this.SerialNumbers == input.SerialNumbers ||
                    (this.SerialNumbers != null &&
                    this.SerialNumbers.SequenceEqual(input.SerialNumbers))
                ) &&
                (
                    this.Customization == input.Customization ||
                    (this.Customization != null &&
                    this.Customization.Equals(input.Customization))
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
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.SellerSku != null)
                    hashCode = hashCode * 59 + this.SellerSku.GetHashCode();
                if (this.Condition != null)
                    hashCode = hashCode * 59 + this.Condition.GetHashCode();
                if (this.Price != null)
                    hashCode = hashCode * 59 + this.Price.GetHashCode();
                if (this.SerialNumbers != null)
                    hashCode = hashCode * 59 + this.SerialNumbers.GetHashCode();
                if (this.Customization != null)
                    hashCode = hashCode * 59 + this.Customization.GetHashCode();

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