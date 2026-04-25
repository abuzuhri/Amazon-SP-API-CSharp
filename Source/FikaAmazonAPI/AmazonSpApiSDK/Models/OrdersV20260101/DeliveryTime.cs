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
    /// Customer-specified time preferences for when deliveries should be attempted at the destination address.
    /// </summary>
    [DataContract]
    public partial class DeliveryTime : IEquatable<DeliveryTime>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryTime" /> class.
        /// </summary>
        public DeliveryTime()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryTime" /> class.
        /// </summary>
        /// <param name="businessHours">Business hours when the business is open for deliveries.</param>
        /// <param name="exceptionDates">Specific dates within the next 30 days when normal business hours do not apply.</param>
        public DeliveryTime(List<BusinessHour> businessHours,
                            List<DeliveryExceptionDate> exceptionDates)
        {
            this.BusinessHours = businessHours;
            this.ExceptionDates = exceptionDates;
        }

        /// <summary>
        /// Business hours when the business is open for deliveries.
        /// </summary>
        /// <value>Business hours when the business is open for deliveries.</value>
        [DataMember(Name = "businessHours", EmitDefaultValue = false)]
        public List<BusinessHour> BusinessHours { get; set; }

        /// <summary>
        /// Specific dates within the next 30 days when normal business hours do not apply.
        /// </summary>
        /// <value>Specific dates within the next 30 days when normal business hours do not apply.</value>
        [DataMember(Name = "exceptionDates", EmitDefaultValue = false)]
        public List<DeliveryExceptionDate> ExceptionDates { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DeliveryTime {\n");
            sb.Append("  BusinessHours: ").Append(BusinessHours).Append("\n");
            sb.Append("  ExceptionDates: ").Append(ExceptionDates).Append("\n");
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
            return this.Equals(obj as DeliveryTime);
        }

        /// <summary>
        /// Returns true if DeliveryTime instances are equal
        /// </summary>
        /// <param name="input">Instance of DeliveryTime to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DeliveryTime input)
        {
            if (input == null)
                return false;

            return
                (
                    this.BusinessHours == input.BusinessHours ||
                    (this.BusinessHours != null &&
                    this.BusinessHours.SequenceEqual(input.BusinessHours))
                ) &&
                (
                    this.ExceptionDates == input.ExceptionDates ||
                    (this.ExceptionDates != null &&
                    this.ExceptionDates.SequenceEqual(input.ExceptionDates))
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
                if (this.BusinessHours != null)
                    hashCode = hashCode * 59 + this.BusinessHours.GetHashCode();
                if (this.ExceptionDates != null)
                    hashCode = hashCode * 59 + this.ExceptionDates.GetHashCode();
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