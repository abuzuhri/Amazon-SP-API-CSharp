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
    /// Alternative identifier that can be used to reference order.
    /// </summary>
    [DataContract]
    public partial class OrderAliase : IEquatable<OrderAliase>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderAliase" /> class.
        /// </summary>
        public OrderAliase() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderAliase" /> class.
        /// </summary>
        /// <param name="aliasId">The alternative identifier value that can be used to reference this order. (required)</param>
        /// <param name="aliasType">The kind of alternative identifier this represents. (required)</param>
        public OrderAliase(string aliasId = default, AliasTypeEnum aliasType = default)
        {
            // to ensure "aliasId" is required (not null)
            if (aliasId == null)
            {
                throw new InvalidDataException("aliasId is a required property for OrderAliase and cannot be null");
            }
            else
            {
                this.AliasId = aliasId;
            }
            // to ensure "aliasType" is required (not null)
            if (aliasType == null)
            {
                throw new InvalidDataException("aliasType is a required property for OrderAliase and cannot be null");
            }
            else
            {
                this.AliasType = aliasType;
            }
        }

        /// <summary>
        /// The alternative identifier value that can be used to reference this order.
        /// </summary>
        /// <value>The alternative identifier value that can be used to reference this order.</value>
        [DataMember(Name = "aliasId", EmitDefaultValue = false)]
        public string AliasId { get; set; }

        /// <summary>
        /// The kind of alternative identifier this represents.
        /// </summary>
        /// <value>The kind of alternative identifier this represents.</value>
        [DataMember(Name = "aliasType", EmitDefaultValue = false)]
        public AliasTypeEnum AliasType { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderAliase {\n");
            sb.Append("  AliasId: ").Append(AliasId).Append("\n");
            sb.Append("  AliasType: ").Append(AliasType).Append("\n");
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
            return this.Equals(input as OrderAliase);
        }

        /// <summary>
        /// Returns true if OrderAliase instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderAliase to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderAliase input)
        {
            if (input == null)
                return false;

            return
                (
                    this.AliasId == input.AliasId ||
                    (this.AliasId != null &&
                    this.AliasId.Equals(input.AliasId))
                ) &&
                (
                    this.AliasType == input.AliasType ||
                    (this.AliasType != null &&
                    this.AliasType.Equals(input.AliasType))
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
                if (this.AliasId != null)
                    hashCode = hashCode * 59 + this.AliasId.GetHashCode();
                if (this.AliasType != null)
                    hashCode = hashCode * 59 + this.AliasType.GetHashCode();
             
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