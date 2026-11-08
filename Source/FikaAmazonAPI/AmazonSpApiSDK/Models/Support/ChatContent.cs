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
    /// The content for a chat contact.
    /// </summary>
    [DataContract]
    public partial class ChatContent :  IEquatable<ChatContent>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChatContent" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public ChatContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ChatContent" /> class.
        /// </summary>
        /// <param name="events">A list of events that make up the chat contact. Not all chat contacts are broken into chat events, and it is recommended to fallback on the `transcript` when `events` is empty. (required).</param>
        /// <param name="transcript">The human-readable transcript of the chat contact. (required).</param>
        public ChatContent(List<ChatEvent> events = default(List<ChatEvent>), string transcript = default(string))
        {
            // to ensure "events" is required (not null)
            if (events == null)
            {
                throw new InvalidDataException("events is a required property for ChatContent and cannot be null");
            }
            else
            {
                this.Events = events;
            }
            // to ensure "transcript" is required (not null)
            if (transcript == null)
            {
                throw new InvalidDataException("transcript is a required property for ChatContent and cannot be null");
            }
            else
            {
                this.Transcript = transcript;
            }
        }
        
        /// <summary>
        /// A list of events that make up the chat contact. Not all chat contacts are broken into chat events, and it is recommended to fallback on the `transcript` when `events` is empty.
        /// </summary>
        /// <value>A list of events that make up the chat contact. Not all chat contacts are broken into chat events, and it is recommended to fallback on the `transcript` when `events` is empty.</value>
        [DataMember(Name="events", EmitDefaultValue=false)]
        public List<ChatEvent> Events { get; set; }

        /// <summary>
        /// The human-readable transcript of the chat contact.
        /// </summary>
        /// <value>The human-readable transcript of the chat contact.</value>
        [DataMember(Name="transcript", EmitDefaultValue=false)]
        public string Transcript { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ChatContent {\n");
            sb.Append("  Events: ").Append(Events).Append("\n");
            sb.Append("  Transcript: ").Append(Transcript).Append("\n");
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
            return this.Equals(input as ChatContent);
        }

        /// <summary>
        /// Returns true if ChatContent instances are equal
        /// </summary>
        /// <param name="input">Instance of ChatContent to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ChatContent input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Events == input.Events ||
                    this.Events != null &&
                    input.Events != null &&
                    this.Events.SequenceEqual(input.Events)
                ) && 
                (
                    this.Transcript == input.Transcript ||
                    (this.Transcript != null &&
                    this.Transcript.Equals(input.Transcript))
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
                if (this.Events != null)
                    hashCode = hashCode * 59 + this.Events.GetHashCode();
                if (this.Transcript != null)
                    hashCode = hashCode * 59 + this.Transcript.GetHashCode();
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
