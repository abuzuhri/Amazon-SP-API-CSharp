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
    /// Date within the next 30 days when normal business hours do not apply.
    /// </summary>
    [DataContract]
    public partial class DeliveryExceptionDate : IEquatable<DeliveryExceptionDate>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryExceptionDate" /> class.
        /// </summary>
        public DeliveryExceptionDate()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryExceptionDate" /> class.
        /// </summary>
        /// <param name="exceptionDate">Specific calendar date when normal operating hours do not apply. In ISO 8601 format at day granularity.</param>
        /// <param name="exceptionDateType">Operational status of the business on the specified exception date.</param>
        /// <param name="timeWindows">Alternative operating hours that apply specifically to this exception date.</param>
        public DeliveryExceptionDate(DateTime? exceptionDate,
                                     ExceptionDateTypeEnum? exceptionDateType,
                                     List<TimeWindow> timeWindows)
        {
            this.ExceptionDate = exceptionDate;
            this.ExceptionDateType = exceptionDateType;
            this.TimeWindows = timeWindows;
        }

        /// <summary>
        /// Specific calendar date when normal operating hours do not apply. In ISO 8601 format at day granularity.
        /// </summary>
        /// <value>Specific calendar date when normal operating hours do not apply. In ISO 8601 format at day granularity.</value>
        [DataMember(Name = "exceptionDate", EmitDefaultValue = false)]
        public DateTime? ExceptionDate { get; set; }

        /// <summary>
        /// Operational status of the business on the specified exception date.
        /// </summary>
        /// <value>Operational status of the business on the specified exception date.</value>
        [DataMember(Name = "exceptionDateType", EmitDefaultValue = false)]
        public ExceptionDateTypeEnum? ExceptionDateType { get; set; }

        /// <summary>
        /// Alternative operating hours that apply specifically to this exception date.
        /// </summary>
        /// <value>Alternative operating hours that apply specifically to this exception date.</value>
        [DataMember(Name = "timeWindows", EmitDefaultValue = false)]
        public List<TimeWindow> TimeWindows { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DeliveryExceptionDate {\n");
            sb.Append("  ExceptionDate: ").Append(ExceptionDate).Append("\n");
            sb.Append("  ExceptionDateType: ").Append(ExceptionDateType).Append("\n");
            sb.Append("  TimeWindows: ").Append(TimeWindows).Append("\n");
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
            return this.Equals(obj as DeliveryExceptionDate);
        }

        /// <summary>
        /// Returns true if DeliveryExceptionDate instances are equal
        /// </summary>
        /// <param name="input">Instance of DeliveryExceptionDate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DeliveryExceptionDate input)
        {
            if (input == null)
                return false;

            return
                (
                    this.ExceptionDate == input.ExceptionDate ||
                    (this.ExceptionDate != null &&
                    this.ExceptionDate.Equals(input.ExceptionDate))
                ) &&
                (
                    this.ExceptionDateType == input.ExceptionDateType ||
                    (this.ExceptionDateType != null &&
                    this.ExceptionDateType.Equals(input.ExceptionDateType))
                ) &&
                (
                    this.TimeWindows == input.TimeWindows ||
                    (this.TimeWindows != null &&
                    this.TimeWindows.SequenceEqual(input.TimeWindows))
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
                if (this.ExceptionDate != null)
                    hashCode = hashCode * 59 + this.ExceptionDate.GetHashCode();
                if (this.ExceptionDateType != null)
                    hashCode = hashCode * 59 + this.ExceptionDateType.GetHashCode();
                if (this.TimeWindows != null)
                    hashCode = hashCode * 59 + this.TimeWindows.GetHashCode();

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