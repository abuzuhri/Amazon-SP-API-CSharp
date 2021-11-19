using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Messaging
{
    [DataContract]
    public partial class Embedded : IEquatable<Embedded>, IValidatableObject
    {
        /// <summary>
        /// Gets or Sets Embedded
        /// </summary>
        [DataMember(Name = "actions", EmitDefaultValue = false)]
        public IList<GetMessagingActionResponse> ActionList { get; set; }

        public Embedded()
        {
            this.ActionList = default(IList<GetMessagingActionResponse>);
        }

        public Embedded(IList<GetMessagingActionResponse> actionList = default(IList<GetMessagingActionResponse>))
        {
            this.ActionList = actionList;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Embedded {\n");
            sb.Append("  actions: ").Append(ActionList).Append("\n");
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
            return this.Equals(input as Embedded);
        }

        /// <summary>
        /// Returns true if GetMessagingActionsForOrderResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of GetMessagingActionsForOrderResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Embedded input)
        {
            if (input == null)
                return false;

            return
                (
                    this.ActionList == input.ActionList ||
                    (this.ActionList != null &&
                    this.ActionList.Equals(input.ActionList))
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
                if (this.ActionList != null)
                    hashCode = hashCode * 59 + this.ActionList.GetHashCode();
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
