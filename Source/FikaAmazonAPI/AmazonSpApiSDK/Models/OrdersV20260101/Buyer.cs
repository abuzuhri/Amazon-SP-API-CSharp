using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Information about the customer who purchased the order.
    /// </summary>
    [DataContract]
    public partial class Buyer : IEquatable<Buyer>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Buyer" /> class.
        /// </summary>
        public Buyer() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Buyer" /> class.
        /// </summary>
        /// <param name="buyerName">The full name of the customer who placed the order.</param>
        /// <param name="buyerEmail">The anonymized email address of the buyer. Note: Only available for merchant-fulfilled (FBM) orders.</param>
        /// <param name="buyerCompanyName">The name of the company or organization for a business order.</param>
        /// <param name="buyerPurchaseOrderNumber">The purchase order (PO) number entered by the buyer at checkout. Only returned for orders where the buyer entered a PO number at checkout.</param>
        public Buyer(string buyerName,
                     string buyerEmail,
                     string buyerCompanyName,
                     string buyerPurchaseOrderNumber)
        {
            this.BuyerName = buyerName;
            this.BuyerEmail = buyerEmail;
            this.BuyerCompanyName = buyerCompanyName;
            this.BuyerPurchaseOrderNumber = buyerPurchaseOrderNumber;
        }

        /// <summary>
        /// The full name of the customer who placed the order.
        /// </summary>
        /// <value>The full name of the customer who placed the order.</value>
        [DataMember(Name = "buyerName", EmitDefaultValue = false)]
        public string BuyerName { get; set; }

        /// <summary>
        /// The anonymized email address of the buyer. Note: Only available for merchant-fulfilled (FBM) orders.
        /// </summary>
        /// <value>The anonymized email address of the buyer. Note: Only available for merchant-fulfilled (FBM) orders.</value>
        [DataMember(Name = "buyerEmail", EmitDefaultValue = false)]
        public string BuyerEmail { get; set; }

        /// <summary>
        /// The name of the company or organization for a business order.
        /// </summary>
        /// <value>The name of the company or organization for a business order.</value>
        [DataMember(Name = "buyerCompanyName", EmitDefaultValue = false)]
        public string BuyerCompanyName { get; set; }

        /// <summary>
        /// The purchase order (PO) number entered by the buyer at checkout. Only returned for orders where the buyer entered a PO number at checkout.
        /// </summary>
        /// <value>The purchase order (PO) number entered by the buyer at checkout. Only returned for orders where the buyer entered a PO number at checkout.</value>
        [DataMember(Name = "buyerPurchaseOrderNumber", EmitDefaultValue = false)]
        public string BuyerPurchaseOrderNumber { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Buyer {\n");
            sb.Append("  BuyerName: ").Append(BuyerName).Append("\n");
            sb.Append("  BuyerEmail: ").Append(BuyerEmail).Append("\n");
            sb.Append("  BuyerCompanyName: ").Append(BuyerCompanyName).Append("\n");
            sb.Append("  BuyerPurchaseOrderNumber: ").Append(BuyerPurchaseOrderNumber).Append("\n");
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
            return this.Equals(obj as Buyer);
        }

        /// <summary>
        /// Returns true if Buyer instances are equal
        /// </summary>
        /// <param name="input">Instance of Buyer to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Buyer input)
        {
            if (input == null)
                return false;

            return
                (
                    this.BuyerName == input.BuyerName ||
                    (this.BuyerName != null &&
                    this.BuyerName.Equals(input.BuyerName))
                ) &&
                (
                    this.BuyerEmail == input.BuyerEmail ||
                    (this.BuyerEmail != null &&
                    this.BuyerEmail.Equals(input.BuyerEmail))
                ) &&
                (
                    this.BuyerCompanyName == input.BuyerCompanyName ||
                    (this.BuyerCompanyName != null &&
                    this.BuyerCompanyName.Equals(input.BuyerCompanyName))
                ) &&
                (
                    this.BuyerPurchaseOrderNumber == input.BuyerPurchaseOrderNumber ||
                    (this.BuyerPurchaseOrderNumber != null &&
                    this.BuyerPurchaseOrderNumber.Equals(input.BuyerPurchaseOrderNumber))
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
                if (this.BuyerName != null)
                    hashCode = hashCode * 59 + this.BuyerName.GetHashCode();
                if (this.BuyerEmail != null)
                    hashCode = hashCode * 59 + this.BuyerEmail.GetHashCode();
                if (this.BuyerCompanyName != null)
                    hashCode = hashCode * 59 + this.BuyerCompanyName.GetHashCode();
                if (this.BuyerPurchaseOrderNumber != null)
                    hashCode = hashCode * 59 + this.BuyerPurchaseOrderNumber.GetHashCode();
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