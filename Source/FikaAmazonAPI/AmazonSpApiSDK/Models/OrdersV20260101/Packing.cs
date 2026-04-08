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
    /// Information related to the packaging process for an order item.
    /// </summary>
    [DataContract]
    public partial class Packing : IEquatable<Packing>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Packing" /> class.
        /// </summary>
        public Packing()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Packing" /> class.
        /// </summary>
        /// <param name="giftOption">Gift wrapping and personalization options selected by the customer for an order item.</param>
        public Packing(GiftOption giftOption = default)
        {
            this.GiftOption = giftOption;
        }

        /// <summary>
        /// Gift wrapping and personalization options selected by the customer for an order item.
        /// </summary>
        /// <value>Gift wrapping and personalization options selected by the customer for an order item.</value>
        [DataMember(Name = "giftOption", EmitDefaultValue = false)]
        public GiftOption GiftOption { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Packing {\n");
            sb.Append("  GiftOption: ").Append(GiftOption).Append("\n");
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
            return this.Equals(input as Packing);
        }

        /// <summary>
        /// Returns true if Packing instances are equal
        /// </summary>
        /// <param name="input">Instance of Packing to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Packing input)
        {
            if (input == null)
                return false;

            return
                (
                    this.GiftOption == input.GiftOption ||
                    (this.GiftOption != null &&
                    this.GiftOption.Equals(input.GiftOption))
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
                if (this.GiftOption != null)
                    hashCode = hashCode * 59 + this.GiftOption.GetHashCode();
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