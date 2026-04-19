using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Restrictions;
using System.Text;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.CatalogItems.V20220401
{
    [DataContract]
    public class ItemContributor : IEquatable<ItemContributor>, IValidatableObject
    {
        [JsonConstructorAttribute]
        protected ItemContributor() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemContributor" /> class.
        /// </summary>
        /// <param name="value">The Value of the contribotor</param>
        /// <param name="itemContributorRole">The role of the contributor</param>
        public ItemContributor(string value = default(string), ItemContributorRole itemContributorRole = default)
        {
            Role = new ItemContributorRole();
        }


        /// <summary>
        /// Contributor Role
        /// </summary>
        /// <value>Contributor Role.</value>
        [DataMember(Name = "role", EmitDefaultValue = false)]
        public ItemContributorRole Role { get; set; }

        /// <summary>
        /// Contributor Value
        /// </summary>
        /// <value>Contributor VAlue.</value>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public string Value { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ItemContributor {\n");
            sb.Append("  ItemContributorRole: ").Append(Role).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
            return this.Equals(input as ItemContributor);
        }

        /// <summary>
        /// Returns true if ItemContributor instances are equal
        /// </summary>
        /// <param name="input">Instance of ItemContributor to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ItemContributor input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
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
                if (this.Value != null)
                    hashCode = hashCode * 59 + this.Value.GetHashCode();
                if (this.Role != null)
                    hashCode = hashCode * 59 + this.Role.GetHashCode();
                return hashCode;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}