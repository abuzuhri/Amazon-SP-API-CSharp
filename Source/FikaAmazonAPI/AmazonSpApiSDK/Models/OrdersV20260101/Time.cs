using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// The time when the business opens or closes.
    /// </summary>
    [DataContract]
    public partial class Time : IEquatable<Time>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Time" /> class.
        /// </summary>
        public Time()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Time" /> class.
        /// </summary>
        /// <param name="hour">The hour when the business opens or closes, in 24-hour format (0-23).</param>
        /// <param name="minute">The minute when the business opens or closes.</param>
        public Time(int? hour = default,
                    int? minute = default)
        {
            this.Hour = hour;
            this.Minute = minute;
        }

        /// <summary>
        /// The hour when the business opens or closes, in 24-hour format (0-23).
        /// </summary>
        /// <value>The hour when the business opens or closes, in 24-hour format (0-23).</value>
        [DataMember(Name = "hour", EmitDefaultValue = false)]
        public int? Hour { get; set; }

        /// <summary>
        /// The minute when the business opens or closes.
        /// </summary>
        /// <value>The minute when the business opens or closes.</value>
        [DataMember(Name = "minute", EmitDefaultValue = false)]
        public int? Minute { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Time {\n");
            sb.Append("  Hour: ").Append(Hour).Append("\n");
            sb.Append("  Minute: ").Append(Minute).Append("\n");
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
            return this.Equals(input as Time);
        }

        /// <summary>
        /// Returns true if Time instances are equal
        /// </summary>
        /// <param name="input">Instance of Time to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Time input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Hour == input.Hour ||
                    (this.Hour != null &&
                    this.Hour.Equals(input.Hour))
                ) &&
                (
                    this.Minute == input.Minute ||
                    (this.Minute != null &&
                    this.Minute.Equals(input.Minute))
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
                if (this.Hour != null)
                    hashCode = hashCode * 59 + this.Hour.GetHashCode();
                if (this.Minute != null)
                    hashCode = hashCode * 59 + this.Minute.GetHashCode();

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