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
    /// Gift wrapping and personalization options selected by the customer for an order item.
    /// </summary>
    [DataContract]
    public partial class GiftOption : IEquatable<GiftOption>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GiftOption" /> class.
        /// </summary>
        public GiftOption()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GiftOption" /> class.
        /// </summary>
        /// <param name="giftMessage">Personal message from the buyer to be included with the gift-wrapped item.</param>
        /// <param name="giftWrapLevel">Type or quality level of gift wrapping service selected by the customer.</param>
        public GiftOption(string giftMessage = default, string giftWrapLevel = default)
        {
            this.GiftMessage = giftMessage;
            this.GiftWrapLevel = giftWrapLevel;
        }

        /// <summary>
        /// Personal message from the buyer to be included with the gift-wrapped item.
        /// </summary>
        /// <value>Personal message from the buyer to be included with the gift-wrapped item.</value>
        [DataMember(Name = "giftMessage", EmitDefaultValue = false)]
        public string GiftMessage { get; set; }

        /// <summary>
        /// Type or quality level of gift wrapping service selected by the customer.
        /// </summary>
        /// <value>Type or quality level of gift wrapping service selected by the customer.</value>
        [DataMember(Name = "giftWrapLevel", EmitDefaultValue = false)]
        public string GiftWrapLevel { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GiftOption {\n");
            sb.Append("  GiftMessage: ").Append(GiftMessage).Append("\n");
            sb.Append("  GiftWrapLevel: ").Append(GiftWrapLevel).Append("\n");
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
            return this.Equals(input as GiftOption);
        }

        /// <summary>
        /// Returns true if GiftOption instances are equal
        /// </summary>
        /// <param name="input">Instance of GiftOption to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GiftOption input)
        {
            if (input == null)
                return false;

            return
                (
                    this.GiftMessage == input.GiftMessage ||
                    (this.GiftMessage != null &&
                    this.GiftMessage.Equals(input.GiftMessage))
                ) &&
                (
                    this.GiftWrapLevel == input.GiftWrapLevel ||
                    (this.GiftWrapLevel != null &&
                    this.GiftWrapLevel.Equals(input.GiftWrapLevel))
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
                if (this.GiftMessage != null)
                    hashCode = hashCode * 59 + this.GiftMessage.GetHashCode();
                if (this.GiftWrapLevel != null)
                    hashCode = hashCode * 59 + this.GiftWrapLevel.GetHashCode();
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