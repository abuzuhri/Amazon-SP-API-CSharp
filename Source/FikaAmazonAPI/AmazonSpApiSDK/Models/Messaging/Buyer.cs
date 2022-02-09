using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Messaging
{
    /// <summary>
    /// Information about the buyer.
    /// </summary>
    [DataContract]
    public partial class Buyer : IEquatable<Buyer>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Buyer" /> class.
        /// </summary>
        /// <param name="BuyerId">The identifier of the buyer..</param>
        /// <param name="Name">The name of the buyer..</param>
        /// <param name="Phone">The phone number of the buyer..</param>
        /// <param name="IsPrimeMember">When true, the service is for an Amazon Prime buyer..</param>
        public Buyer(string locale = default(string))
        {
            this.locale = locale;
        }

        /// <summary>
        /// The identifier of the buyer.
        /// </summary>
        /// <value>The identifier of the buyer.</value>
        [DataMember(Name = "locale", EmitDefaultValue = false)]
        public string locale { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Buyer {\n");
            sb.Append("  BuyerId: ").Append(locale).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
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
            return this.Equals(input as Buyer);
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
                    this.locale == input.locale ||
                    (this.locale != null &&
                    this.locale.Equals(input.locale))
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
                if (this.locale != null)
                    hashCode = hashCode * 59 + this.locale.GetHashCode();
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
