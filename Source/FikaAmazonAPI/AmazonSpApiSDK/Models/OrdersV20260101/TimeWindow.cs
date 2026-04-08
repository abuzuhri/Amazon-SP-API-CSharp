using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Time window during which the location is available for deliveries on the specified day.
    /// </summary>
    [DataContract]
    public partial class TimeWindow : IEquatable<TimeWindow>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeWindow" /> class.
        /// </summary>
        public TimeWindow()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeWindow" /> class.
        /// </summary>
        /// <param name="startTime">The time when the business opens.</param>
        /// <param name="endTime">The time when the business closes.</param>
        public TimeWindow(Time startTime,
                          Time endTime)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

        /// <summary>
        /// The time when the business opens.
        /// </summary>
        /// <value>The time when the business opens.</value>
        [DataMember(Name = "startTime", EmitDefaultValue = false)]
        public Time StartTime { get; set; }

        /// <summary>
        /// The time when the business closes.
        /// </summary>
        /// <value>The time when the business closes.</value>
        [DataMember(Name = "endTime", EmitDefaultValue = false)]
        public Time EndTime { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TimeWindow {\n");
            sb.Append("  StartTime: ").Append(StartTime).Append("\n");
            sb.Append("  EndTime: ").Append(EndTime).Append("\n");
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
            return this.Equals(obj as TimeWindow);
        }

        /// <summary>
        /// Returns true if TimeWindow instances are equal
        /// </summary>
        /// <param name="input">Instance of TimeWindow to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TimeWindow input)
        {
            if (input == null)
                return false;

            return
                (
                    this.StartTime == input.StartTime ||
                    (this.StartTime != null &&
                    this.StartTime.Equals(input.StartTime))
                ) &&
                (
                    this.EndTime == input.EndTime ||
                    (this.EndTime != null &&
                    this.EndTime.Equals(input.EndTime))
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
                if (this.StartTime != null)
                    hashCode = hashCode * 59 + this.StartTime.GetHashCode();
                if (this.EndTime != null)
                    hashCode = hashCode * 59 + this.EndTime.GetHashCode();

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