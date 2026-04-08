using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Special shipping requirements and restrictions that must be observed when shipping an order item.
    /// </summary>
    [DataContract]
    public partial class ShippingConstraints : IEquatable<ShippingConstraints>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShippingConstraints" /> class.
        /// </summary>
        public ShippingConstraints()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShippingConstraints" /> class.
        /// </summary>
        /// <param name="palletDelivery">Classification of the enforcement level required for shipping and delivery constraints.</param>
        /// <param name="cashOnDelivery">Classification of the enforcement level required for shipping and delivery constraints.</param>
        /// <param name="signatureConfirmation">Classification of the enforcement level required for shipping and delivery constraints.</param>
        /// <param name="recipientIdentityVerification">Classification of the enforcement level required for shipping and delivery constraints.</param>
        /// <param name="recipientAgeVerification">Classification of the enforcement level required for shipping and delivery constraints.</param>
        public ShippingConstraints(EnforcementLevelEnum? palletDelivery = default,
                                   EnforcementLevelEnum? cashOnDelivery = default,
                                   EnforcementLevelEnum? signatureConfirmation = default,
                                   EnforcementLevelEnum? recipientIdentityVerification = default,
                                   EnforcementLevelEnum? recipientAgeVerification = default)
        {
            this.PalletDelivery = palletDelivery;
            this.CashOnDelivery = cashOnDelivery;
            this.SignatureConfirmation = signatureConfirmation;
            this.RecipientIdentityVerification = recipientIdentityVerification;
            this.RecipientAgeVerification = recipientAgeVerification;
        }

        /// <summary>
        /// Classification of the enforcement level required for shipping and delivery constraints.
        /// </summary>
        /// <value>Classification of the enforcement level required for shipping and delivery constraints.</value>
        [DataMember(Name = "palletDelivery", EmitDefaultValue = false)]
        public EnforcementLevelEnum? PalletDelivery { get; set; }

        /// <summary>
        /// Classification of the enforcement level required for shipping and delivery constraints.
        /// </summary>
        /// <value>Classification of the enforcement level required for shipping and delivery constraints.</value>
        [DataMember(Name = "cashOnDelivery", EmitDefaultValue = false)]
        public EnforcementLevelEnum? CashOnDelivery { get; set; }

        /// <summary>
        /// Classification of the enforcement level required for shipping and delivery constraints.
        /// </summary>
        /// <value>Classification of the enforcement level required for shipping and delivery constraints.</value>
        [DataMember(Name = "signatureConfirmation", EmitDefaultValue = false)]
        public EnforcementLevelEnum? SignatureConfirmation { get; set; }

        /// <summary>
        /// Classification of the enforcement level required for shipping and delivery constraints.
        /// </summary>
        /// <value>Classification of the enforcement level required for shipping and delivery constraints.</value>
        [DataMember(Name = "recipientIdentityVerification", EmitDefaultValue = false)]
        public EnforcementLevelEnum? RecipientIdentityVerification { get; set; }

        /// <summary>
        /// Classification of the enforcement level required for shipping and delivery constraints.
        /// </summary>
        /// <value>Classification of the enforcement level required for shipping and delivery constraints.</value>
        [DataMember(Name = "recipientAgeVerification", EmitDefaultValue = false)]
        public EnforcementLevelEnum? RecipientAgeVerification { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ShippingConstraints {\n");
            sb.Append("  PalletDelivery: ").Append(PalletDelivery).Append("\n");
            sb.Append("  CashOnDelivery: ").Append(CashOnDelivery).Append("\n");
            sb.Append("  SignatureConfirmation: ").Append(SignatureConfirmation).Append("\n");
            sb.Append("  RecipientIdentityVerification: ").Append(RecipientIdentityVerification).Append("\n");
            sb.Append("  RecipientAgeVerification: ").Append(RecipientAgeVerification).Append("\n");
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
            return this.Equals(input as ShippingConstraints);
        }

        /// <summary>
        /// Returns true if ShippingConstraints instances are equal
        /// </summary>
        /// <param name="input">Instance of ShippingConstraints to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ShippingConstraints input)
        {
            if (input == null)
                return false;

            return
                (
                    this.PalletDelivery == input.PalletDelivery ||
                    (this.PalletDelivery != null &&
                    this.PalletDelivery.Equals(input.PalletDelivery))
                ) &&
                (
                    this.CashOnDelivery == input.CashOnDelivery ||
                    (this.CashOnDelivery != null &&
                    this.CashOnDelivery.Equals(input.CashOnDelivery))
                ) &&
                (
                    this.SignatureConfirmation == input.SignatureConfirmation ||
                    (this.SignatureConfirmation != null &&
                    this.SignatureConfirmation.Equals(input.SignatureConfirmation))
                ) &&
                (
                    this.RecipientIdentityVerification == input.RecipientIdentityVerification ||
                    (this.RecipientIdentityVerification != null &&
                    this.RecipientIdentityVerification.Equals(input.RecipientIdentityVerification))
                ) &&
                (
                    this.RecipientAgeVerification == input.RecipientAgeVerification ||
                    (this.RecipientAgeVerification != null &&
                    this.RecipientAgeVerification.Equals(input.RecipientAgeVerification))
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
                if (this.PalletDelivery != null)
                    hashCode = hashCode * 59 + this.PalletDelivery.GetHashCode();
                if (this.CashOnDelivery != null)
                    hashCode = hashCode * 59 + this.CashOnDelivery.GetHashCode();
                if (this.SignatureConfirmation != null)
                    hashCode = hashCode * 59 + this.SignatureConfirmation.GetHashCode();
                if (this.RecipientIdentityVerification != null)
                    hashCode = hashCode * 59 + this.RecipientIdentityVerification.GetHashCode();
                if (this.RecipientAgeVerification != null)
                    hashCode = hashCode * 59 + this.RecipientAgeVerification.GetHashCode();

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