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
    /// Information about any personalization, customization, or special modifications applied to this order item.
    /// </summary>
    [DataContract]
    public partial class OrderItemCustomization : IEquatable<OrderItemCustomization>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItemCustomization" /> class.
        /// </summary>
        public OrderItemCustomization() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItemCustomization" /> class.
        /// </summary>
        /// <param name="customizedUrl">The URL of the customized data for custom orders from the Amazon Custom program.</param>
        public OrderItemCustomization(string customizedUrl)
        {
            this.CustomizedUrl = customizedUrl;
        }


        /// <summary>
        /// The URL of the customized data for custom orders from the Amazon Custom program.
        /// </summary>
        /// <value>The URL of the customized data for custom orders from the Amazon Custom program.</value>
        [DataMember(Name = "customizedUrl", EmitDefaultValue = false)]
        public string CustomizedUrl { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderItemCustomization {\n");
            sb.Append("  CustomizedUrl: ").Append(CustomizedUrl).Append("\n");
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
            return this.Equals(obj as OrderItemCustomization);
        }

        /// <summary>
        /// Returns true if OrderItemCustomization instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderItemCustomization to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderItemCustomization input)
        {
            if (input == null)
                return false;

            return
                (
                    this.CustomizedUrl == input.CustomizedUrl ||
                    (this.CustomizedUrl != null &&
                    this.CustomizedUrl.Equals(input.CustomizedUrl))
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
                if (this.CustomizedUrl != null)
                    hashCode = hashCode * 59 + this.CustomizedUrl.GetHashCode();

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