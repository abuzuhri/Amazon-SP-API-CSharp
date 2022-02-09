
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Messaging
{
    public class GetMessagingActionsForOrderResponseLinks : IEquatable<GetMessagingActionsForOrderResponseLinks>, IValidatableObject
    {
        public GetMessagingActionsForOrderResponseLinks(LinkObject self = default(LinkObject), IList<LinkObject> actions = default(IList<LinkObject>))
        {
            this.Self = self;
            this.Actions = actions;
        }
        public GetMessagingActionsForOrderResponseLinks()
        {
            this.Self = default(LinkObject);
            this.Actions = default(IList<LinkObject>);
        }

        /// <summary>
        /// Gets or Sets Links
        /// </summary>
        [DataMember(Name = "self", EmitDefaultValue = false)]
        public LinkObject Self { get; set; }

        /// <summary>
        /// Gets or Sets Embedded
        /// </summary>
        [DataMember(Name = "actions", EmitDefaultValue = false)]
        public IList<LinkObject> Actions { get; set; }
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
            return this.Equals(input as GetMessagingActionsForOrderResponse);
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
                if (this.Self != null)
                    hashCode = hashCode * 59 + this.Self.GetHashCode();
                if (this.Actions != null)
                    hashCode = hashCode * 59 + this.Actions.GetHashCode();
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

        public bool Equals(GetMessagingActionsForOrderResponseLinks input)
        {
            return this.Equals(input);
        }
    }
}
