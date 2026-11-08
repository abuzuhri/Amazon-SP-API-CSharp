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
    /// A single event from a chat contact.
    /// </summary>
    [DataContract]
    public partial class ChatEvent :  IEquatable<ChatEvent>, IValidatableObject
    {
        /// <summary>
        /// The type of chat event.
        /// </summary>
        /// <value>The type of chat event.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            
            /// <summary>
            /// Enum MESSAGE for value: MESSAGE
            /// </summary>
            [EnumMember(Value = "MESSAGE")]
            MESSAGE = 1,
            
            /// <summary>
            /// Enum ATTACHMENT for value: ATTACHMENT
            /// </summary>
            [EnumMember(Value = "ATTACHMENT")]
            ATTACHMENT = 2,
            
            /// <summary>
            /// Enum PARTICIPANTJOINED for value: PARTICIPANT_JOINED
            /// </summary>
            [EnumMember(Value = "PARTICIPANT_JOINED")]
            PARTICIPANTJOINED = 3,
            
            /// <summary>
            /// Enum PARTICIPANTLEFT for value: PARTICIPANT_LEFT
            /// </summary>
            [EnumMember(Value = "PARTICIPANT_LEFT")]
            PARTICIPANTLEFT = 4,
            
            /// <summary>
            /// Enum PARTICIPANTIDLE for value: PARTICIPANT_IDLE
            /// </summary>
            [EnumMember(Value = "PARTICIPANT_IDLE")]
            PARTICIPANTIDLE = 5,
            
            /// <summary>
            /// Enum CHATENDED for value: CHAT_ENDED
            /// </summary>
            [EnumMember(Value = "CHAT_ENDED")]
            CHATENDED = 6
        }

        /// <summary>
        /// The type of chat event.
        /// </summary>
        /// <value>The type of chat event.</value>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public TypeEnum Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ChatEvent" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public ChatEvent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ChatEvent" /> class.
        /// </summary>
        /// <param name="timestamp">The time at which the event occurred. (required).</param>
        /// <param name="type">The type of chat event. (required).</param>
        /// <param name="message">The message from the chat event. Only present if the event type is `MESSAGE`..</param>
        /// <param name="participant">The entity that is associated with the event..</param>
        /// <param name="attachments">All attachments included in the event. Only present if the event type is `ATTACHMENT`..</param>
        public ChatEvent(DateTime? timestamp = default(DateTime?), TypeEnum type = default(TypeEnum), string message = default(string), Participant participant = default(Participant), List<Attachment> attachments = default(List<Attachment>))
        {
            // to ensure "timestamp" is required (not null)
            if (timestamp == null)
            {
                throw new InvalidDataException("timestamp is a required property for ChatEvent and cannot be null");
            }
            else
            {
                this.Timestamp = timestamp;
            }
            this.Type = type;
            this.Message = message;
            this.Participant = participant;
            this.Attachments = attachments;
        }
        
        /// <summary>
        /// The time at which the event occurred.
        /// </summary>
        /// <value>The time at which the event occurred.</value>
        [DataMember(Name="timestamp", EmitDefaultValue=false)]
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// The message from the chat event. Only present if the event type is `MESSAGE`.
        /// </summary>
        /// <value>The message from the chat event. Only present if the event type is `MESSAGE`.</value>
        [DataMember(Name="message", EmitDefaultValue=false)]
        public string Message { get; set; }

        /// <summary>
        /// The entity that is associated with the event.
        /// </summary>
        /// <value>The entity that is associated with the event.</value>
        [DataMember(Name="participant", EmitDefaultValue=false)]
        public Participant Participant { get; set; }

        /// <summary>
        /// All attachments included in the event. Only present if the event type is `ATTACHMENT`.
        /// </summary>
        /// <value>All attachments included in the event. Only present if the event type is `ATTACHMENT`.</value>
        [DataMember(Name="attachments", EmitDefaultValue=false)]
        public List<Attachment> Attachments { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ChatEvent {\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  Participant: ").Append(Participant).Append("\n");
            sb.Append("  Attachments: ").Append(Attachments).Append("\n");
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
            return this.Equals(input as ChatEvent);
        }

        /// <summary>
        /// Returns true if ChatEvent instances are equal
        /// </summary>
        /// <param name="input">Instance of ChatEvent to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ChatEvent input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Timestamp == input.Timestamp ||
                    (this.Timestamp != null &&
                    this.Timestamp.Equals(input.Timestamp))
                ) && 
                (
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
                ) && 
                (
                    this.Message == input.Message ||
                    (this.Message != null &&
                    this.Message.Equals(input.Message))
                ) && 
                (
                    this.Participant == input.Participant ||
                    (this.Participant != null &&
                    this.Participant.Equals(input.Participant))
                ) && 
                (
                    this.Attachments == input.Attachments ||
                    this.Attachments != null &&
                    input.Attachments != null &&
                    this.Attachments.SequenceEqual(input.Attachments)
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
                if (this.Timestamp != null)
                    hashCode = hashCode * 59 + this.Timestamp.GetHashCode();
                hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Message != null)
                    hashCode = hashCode * 59 + this.Message.GetHashCode();
                if (this.Participant != null)
                    hashCode = hashCode * 59 + this.Participant.GetHashCode();
                if (this.Attachments != null)
                    hashCode = hashCode * 59 + this.Attachments.GetHashCode();
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
