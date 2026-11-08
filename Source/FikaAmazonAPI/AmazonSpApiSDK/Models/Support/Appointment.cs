/* 
 * The Selling Partner API for Support
 *
 * The Selling Partner API for Support provides programmatic access to information about Selling Partner support.
 *
 * OpenAPI spec version: 2025-02-01
 * Contact: Selling Partner API Developer Support
 * Generated from: https://github.com/amzn/selling-partner-api-models/blob/main/models/support-api-model/support_2025-02-01.json
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Support
{
    /// <summary>
    /// An appointment for a contact at a future date.
    /// </summary>
    [DataContract]
    public partial class Appointment :  IEquatable<Appointment>, IValidatableObject
    {
        /// <summary>
        /// The person who is expected to answer the call.
        /// </summary>
        /// <value>The person who is expected to answer the call.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum AnsweringPartyEnum
        {
            
            /// <summary>
            /// Enum RECEPTIONIST for value: RECEPTIONIST
            /// </summary>
            [EnumMember(Value = "RECEPTIONIST")]
            RECEPTIONIST = 1
        }

        /// <summary>
        /// The person who is expected to answer the call.
        /// </summary>
        /// <value>The person who is expected to answer the call.</value>
        [DataMember(Name="answeringParty", EmitDefaultValue=false)]
        public AnsweringPartyEnum? AnsweringParty { get; set; }
        /// <summary>
        /// The appointment status.
        /// </summary>
        /// <value>The appointment status.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            
            /// <summary>
            /// Enum SCHEDULED for value: SCHEDULED
            /// </summary>
            [EnumMember(Value = "SCHEDULED")]
            SCHEDULED = 1,
            
            /// <summary>
            /// Enum CANCELLED for value: CANCELLED
            /// </summary>
            [EnumMember(Value = "CANCELLED")]
            CANCELLED = 2,
            
            /// <summary>
            /// Enum MISSED for value: MISSED
            /// </summary>
            [EnumMember(Value = "MISSED")]
            MISSED = 3,
            
            /// <summary>
            /// Enum COMPLETED for value: COMPLETED
            /// </summary>
            [EnumMember(Value = "COMPLETED")]
            COMPLETED = 4
        }

        /// <summary>
        /// The appointment status.
        /// </summary>
        /// <value>The appointment status.</value>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public StatusEnum Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Appointment" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public Appointment() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Appointment" /> class.
        /// </summary>
        /// <param name="appointmentId">The unique identifier for the scheduled appointment. (required).</param>
        /// <param name="phoneNumber">The selling partner&#39;s phone number. (required).</param>
        /// <param name="answeringParty">The person who is expected to answer the call..</param>
        /// <param name="callbackTiming">The time window during which the appointment is scheduled. (required).</param>
        /// <param name="status">The appointment status. (required).</param>
        public Appointment(string appointmentId = default(string), PhoneNumber phoneNumber = default(PhoneNumber), AnsweringPartyEnum? answeringParty = default(AnsweringPartyEnum?), CallbackTiming callbackTiming = default(CallbackTiming), StatusEnum status = default(StatusEnum))
        {
            // to ensure "appointmentId" is required (not null)
            if (appointmentId == null)
            {
                throw new InvalidDataException("appointmentId is a required property for Appointment and cannot be null");
            }
            else
            {
                this.AppointmentId = appointmentId;
            }
            // to ensure "phoneNumber" is required (not null)
            if (phoneNumber == null)
            {
                throw new InvalidDataException("phoneNumber is a required property for Appointment and cannot be null");
            }
            else
            {
                this.PhoneNumber = phoneNumber;
            }
            // to ensure "callbackTiming" is required (not null)
            if (callbackTiming == null)
            {
                throw new InvalidDataException("callbackTiming is a required property for Appointment and cannot be null");
            }
            else
            {
                this.CallbackTiming = callbackTiming;
            }
            this.AnsweringParty = answeringParty;
            this.Status = status;
        }
        
        /// <summary>
        /// The unique identifier for the scheduled appointment.
        /// </summary>
        /// <value>The unique identifier for the scheduled appointment.</value>
        [DataMember(Name="appointmentId", EmitDefaultValue=false)]
        public string AppointmentId { get; set; }

        /// <summary>
        /// The selling partner&#39;s phone number.
        /// </summary>
        /// <value>The selling partner&#39;s phone number.</value>
        [DataMember(Name="phoneNumber", EmitDefaultValue=false)]
        public PhoneNumber PhoneNumber { get; set; }

        /// <summary>
        /// The time window during which the appointment is scheduled.
        /// </summary>
        /// <value>The time window during which the appointment is scheduled.</value>
        [DataMember(Name="callbackTiming", EmitDefaultValue=false)]
        public CallbackTiming CallbackTiming { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Appointment {\n");
            sb.Append("  AppointmentId: ").Append(AppointmentId).Append("\n");
            sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append("\n");
            sb.Append("  AnsweringParty: ").Append(AnsweringParty).Append("\n");
            sb.Append("  CallbackTiming: ").Append(CallbackTiming).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
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
            return this.Equals(input as Appointment);
        }

        /// <summary>
        /// Returns true if Appointment instances are equal
        /// </summary>
        /// <param name="input">Instance of Appointment to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Appointment input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.AppointmentId == input.AppointmentId ||
                    (this.AppointmentId != null &&
                    this.AppointmentId.Equals(input.AppointmentId))
                ) && 
                (
                    this.PhoneNumber == input.PhoneNumber ||
                    (this.PhoneNumber != null &&
                    this.PhoneNumber.Equals(input.PhoneNumber))
                ) && 
                (
                    this.AnsweringParty == input.AnsweringParty ||
                    (this.AnsweringParty != null &&
                    this.AnsweringParty.Equals(input.AnsweringParty))
                ) && 
                (
                    this.CallbackTiming == input.CallbackTiming ||
                    (this.CallbackTiming != null &&
                    this.CallbackTiming.Equals(input.CallbackTiming))
                ) && 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
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
                if (this.AppointmentId != null)
                    hashCode = hashCode * 59 + this.AppointmentId.GetHashCode();
                if (this.PhoneNumber != null)
                    hashCode = hashCode * 59 + this.PhoneNumber.GetHashCode();
                if (this.AnsweringParty != null)
                    hashCode = hashCode * 59 + this.AnsweringParty.GetHashCode();
                if (this.CallbackTiming != null)
                    hashCode = hashCode * 59 + this.CallbackTiming.GetHashCode();
                hashCode = hashCode * 59 + this.Status.GetHashCode();
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
