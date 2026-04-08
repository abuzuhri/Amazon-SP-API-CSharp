using FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// A time period with start and end boundaries.
    /// </summary>
    [DataContract]
    public partial class DeliveryWindow : IEquatable<DeliveryWindow>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryWindow" /> class.
        /// </summary>
        public DeliveryWindow()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryWindow" /> class.
        /// </summary>
        /// <param name="earliestDateTime">The beginning of the time period, in ISO 8601 format.</param>
        /// <param name="latestDateTime">The end of the time period, in ISO 8601 format.</param>
        public DeliveryWindow(DateTime? earliestDateTime = default,
                              DateTime? latestDateTime = default)
        {
            this.EarliestDateTime = earliestDateTime;
            this.LatestDateTime = latestDateTime;
        }

        /// <summary>
        /// The beginning of the time period, in ISO 8601 format.
        /// </summary>
        /// <value>The beginning of the time period, in ISO 8601 format.</value>
        [DataMember(Name = "earliestDateTime", EmitDefaultValue = false)]
        public DateTime? EarliestDateTime { get; set; }

        /// <summary>
        /// The end of the time period, in ISO 8601 format.
        /// </summary>
        /// <value>The end of the time period, in ISO 8601 format.</value>
        [DataMember(Name = "latestDateTime", EmitDefaultValue = false)]
        public DateTime? LatestDateTime { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DeliveryWindow {\n");
            sb.Append("  EarliestDateTime: ").Append(EarliestDateTime).Append("\n");
            sb.Append("  LatestDateTime: ").Append(LatestDateTime).Append("\n");
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
            return this.Equals(input as DeliveryWindow);
        }

        /// <summary>
        /// Returns true if DeliveryWindow instances are equal
        /// </summary>
        /// <param name="input">Instance of DeliveryWindow to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DeliveryWindow input)
        {
            if (input == null)
                return false;

            return
                (
                    this.EarliestDateTime == input.EarliestDateTime ||
                    (this.EarliestDateTime != null &&
                    this.EarliestDateTime.Equals(input.EarliestDateTime))
                ) &&
                (
                    this.LatestDateTime == input.LatestDateTime ||
                    (this.LatestDateTime != null &&
                    this.LatestDateTime.Equals(input.LatestDateTime))
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
                if (this.EarliestDateTime != null)
                    hashCode = hashCode * 59 + this.EarliestDateTime.GetHashCode();
                if (this.LatestDateTime != null)
                    hashCode = hashCode * 59 + this.LatestDateTime.GetHashCode();

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