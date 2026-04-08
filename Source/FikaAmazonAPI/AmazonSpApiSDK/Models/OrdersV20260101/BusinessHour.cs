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
    /// Business hours when the business is open for deliveries.
    /// </summary>
    [DataContract]
    public partial class BusinessHour : IEquatable<BusinessHour>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessHour" /> class.
        /// </summary>
        public BusinessHour()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessHour" /> class.
        /// </summary>
        /// <param name="dayOfWeek">Specific day of the week for which operating hours are being defined.</param>
        /// <param name="timeWindows">Collection of time windows during which the location is available for deliveries on the specified day.</param>
        public BusinessHour(DayOfWeekEnum? dayOfWeek = default,
                            List<TimeWindow> timeWindows = default)
        {
            this.DayOfWeek = dayOfWeek;
            this.TimeWindows = timeWindows;
        }

        /// <summary>
        /// Specific day of the week for which operating hours are being defined.
        /// </summary>
        /// <value>Specific day of the week for which operating hours are being defined.</value>
        [DataMember(Name = "dayOfWeek", EmitDefaultValue = false)]
        public DayOfWeekEnum? DayOfWeek { get; set; }

        /// <summary>
        /// Collection of time windows during which the location is available for deliveries on the specified day.
        /// </summary>
        /// <value>Collection of time windows during which the location is available for deliveries on the specified day.</value>
        [DataMember(Name = "timeWindows", EmitDefaultValue = false)]
        public List<TimeWindow> TimeWindows { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BusinessHour {\n");
            sb.Append("  DayOfWeek: ").Append(DayOfWeek).Append("\n");
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
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as BusinessHour);
        }

        /// <summary>
        /// Returns true if BusinessHour instances are equal
        /// </summary>
        /// <param name="input">Instance of BusinessHour to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BusinessHour input)
        {
            if (input == null)
                return false;

            return
                (
                    this.DayOfWeek == input.DayOfWeek ||
                    (this.DayOfWeek != null &&
                    this.DayOfWeek.Equals(input.DayOfWeek))
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
                if (this.DayOfWeek != null)
                    hashCode = hashCode * 59 + this.DayOfWeek.GetHashCode();
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