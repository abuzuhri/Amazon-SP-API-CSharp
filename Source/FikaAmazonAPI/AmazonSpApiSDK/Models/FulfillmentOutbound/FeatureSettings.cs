using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentOutbound
{
    /// <summary>
    /// A Multi-Channel Fulfillment feature.
    /// </summary>
    [DataContract]
    public partial class FeatureSettings : IEquatable<FeatureSettings>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureSettings" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public FeatureSettings() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureSettings" /> class.
        /// </summary>
        /// <param name="featureName">The feature name. (required).</param>
        /// <param name="featureDescription">The feature description. (required).</param>
        /// <param name="sellerEligible">When true, indicates that the seller is eligible to use the feature..</param>
        public FeatureSettings(string featureName = default(string), FeatureFulfillmentPolicy featureFulfillmentPolicy = default(FeatureFulfillmentPolicy))
        {
            this.FeatureName = featureName;
            this.featureFulfillmentPolicy = featureFulfillmentPolicy;
        }

        /// <summary>
        /// The feature name.
        /// </summary>
        /// <value>The feature name.</value>
        [DataMember(Name = "featureName", EmitDefaultValue = false)]
        public string FeatureName { get; set; }

        /// <summary>
        /// The feature description.
        /// </summary>
        /// <value>The feature description.</value>
        [DataMember(Name = "featureFulfillmentPolicy", EmitDefaultValue = false)]
        public FeatureFulfillmentPolicy featureFulfillmentPolicy { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Feature {\n");
            sb.Append("  FeatureName: ").Append(FeatureName).Append("\n");
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
            return this.Equals(input as FeatureSettings);
        }

        /// <summary>
        /// Returns true if Feature instances are equal
        /// </summary>
        /// <param name="input">Instance of Feature to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FeatureSettings input)
        {
            if (input == null)
                return false;

            return
                (
                    this.FeatureName == input.FeatureName ||
                    (this.FeatureName != null &&
                    this.FeatureName.Equals(input.FeatureName))
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
                if (this.FeatureName != null)
                    hashCode = hashCode * 59 + this.FeatureName.GetHashCode();
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

    /// <summary>
    /// Variant of the image, such as &#x60;MAIN&#x60; or &#x60;PT01&#x60;.
    /// </summary>
    /// <value>Variant of the image, such as &#x60;MAIN&#x60; or &#x60;PT01&#x60;.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeatureFulfillmentPolicy
    {

        /// <summary>
        /// Enum Required for value: Required
        /// </summary>
        [EnumMember(Value = "Required")]
        Required,

        /// <summary>
        /// Enum NotRequired for value: NotRequired
        /// </summary>
        [EnumMember(Value = "NotRequired")]
        NotRequired
    }
}
