using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders
{
    [DataContract]
    public partial class DateTimeInterval : IEquatable<DateTimeInterval>, IValidatableObject
    {
        public DateTimeInterval(string dateTimeInterval = default(string))
        {
            dateTimeIntervalStr = dateTimeInterval;
            string intervalWithSpaceDelimiter = dateTimeInterval.Replace("--", " ");
            string[] dateStrings = intervalWithSpaceDelimiter.Split(' ');
            StartDate = DateTime.Parse(dateStrings[0]).ToUniversalTime();
            EndDate = DateTime.Parse(dateStrings[1]).ToUniversalTime();
        }

        private string dateTimeIntervalStr;

        public static explicit operator DateTimeInterval(string interval) => new DateTimeInterval(interval);

        [DataMember(Name = "startDate", EmitDefaultValue = false)]
        public DateTime StartDate { get; set; }

        [DataMember(Name = "endDate", EmitDefaultValue = false)]
        public DateTime EndDate { get; set; }

        public override string ToString()
        {
            return dateTimeIntervalStr;
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
            return this.Equals(input as DateTimeInterval);
        }

        public bool Equals(DateTimeInterval input)
        {
            if (input == null)
                return false;
            return
                (
                    this.dateTimeIntervalStr == input.dateTimeIntervalStr ||
                    (this.dateTimeIntervalStr != null &&
                    this.dateTimeIntervalStr.Equals(input.dateTimeIntervalStr))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return dateTimeIntervalStr.GetHashCode();
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
