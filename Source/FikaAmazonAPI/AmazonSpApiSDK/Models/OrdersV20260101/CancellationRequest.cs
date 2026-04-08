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
    /// Detailed information about a cancellation request submitted for a specific order item.
    /// </summary>
    [DataContract]
    public partial class CancellationRequest : IEquatable<CancellationRequest>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CancellationRequest" /> class.
        /// </summary>
        public CancellationRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CancellationRequest" /> class.
        /// </summary>
        /// <param name="requester">Entity that initiated the cancellation request for this item.</param>
        /// <param name="cancelReason">Explanation provided for why the cancellation was requested.</param>
        public CancellationRequest(CancellationRequesterEnum? requester = default, string cancelReason = default)
        {
            this.Requester = requester;
            this.CancelReason = cancelReason;
        }

        /// <summary>
        /// Entity that initiated the cancellation request for this item.
        /// </summary>
        /// <value>Entity that initiated the cancellation request for this item.</value>
        [DataMember(Name = "requester", EmitDefaultValue = false)]
        public CancellationRequesterEnum? Requester { get; set; }

        /// <summary>
        /// Explanation provided for why the cancellation was requested.
        /// </summary>
        /// <value>Explanation provided for why the cancellation was requested.</value>
        [DataMember(Name = "cancelReason", EmitDefaultValue = false)]
        public string CancelReason { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CancellationRequest {\n");
            sb.Append("  Requester: ").Append(Requester).Append("\n");
            sb.Append("  CancelReason: ").Append(CancelReason).Append("\n");
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
            return this.Equals(input as CancellationRequest);
        }

        /// <summary>
        /// Returns true if CancellationRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CancellationRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CancellationRequest input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Requester == input.Requester ||
                    (this.Requester != null &&
                    this.Requester.Equals(input.Requester))
                ) &&
                (
                    this.CancelReason == input.CancelReason ||
                    (this.CancelReason != null &&
                    this.CancelReason.Equals(input.CancelReason))
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
                if (this.Requester != null)
                    hashCode = hashCode * 59 + this.Requester.GetHashCode();
                if (this.CancelReason != null)
                    hashCode = hashCode * 59 + this.CancelReason.GetHashCode();
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