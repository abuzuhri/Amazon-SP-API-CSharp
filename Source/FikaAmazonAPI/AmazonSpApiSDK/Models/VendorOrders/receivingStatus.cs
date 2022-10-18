using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders.Constants;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders
{
    [DataContract]
    public partial class receivingStatus : IEquatable<receivingStatus>, IValidatableObject
    {
        [JsonConstructorAttribute]
        public receivingStatus() { }
        public receivingStatus(ItemReceiveStatus? receiveStatus = default(ItemReceiveStatus?), ItemQuantity receivedQuantity = default(ItemQuantity), DateTime? lastReceiveDate = default(DateTime?))
        {
            this.ReceiveStatus = receiveStatus;
            this.ReceivedQuantity = receivedQuantity;
            this.LastReceiveDate = lastReceiveDate;
        }

        [DataMember(Name = "receiveStatus", EmitDefaultValue = false)]
        public ItemReceiveStatus? ReceiveStatus { get; set; }

        [DataMember(Name = "receivedQuantity", EmitDefaultValue = false)]
        public ItemQuantity ReceivedQuantity { get; set; }

        [DataMember(Name = "lastReceiveDate", EmitDefaultValue = false)]
        public DateTime? LastReceiveDate { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class receivingStatus {\n");
            sb.Append("  ReceiveStatus: ").Append(ReceiveStatus).Append("\n");
            sb.Append("  ReceivedQuantity: ").Append(ReceivedQuantity).Append("\n");
            sb.Append("  LastReceiveDate: ").Append(LastReceiveDate).Append("\n");
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
            return this.Equals(input as receivingStatus);
        }

        /// <summary>
        /// Returns true if ItemQuantity instances are equal
        /// </summary>
        /// <param name="input">Instance of ItemQuantity to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(receivingStatus input)
        {
            if (input == null)
                return false;

            return
                (
                    this.ReceiveStatus == input.ReceiveStatus ||
                    (this.ReceiveStatus != null &&
                    this.ReceiveStatus.Equals(input.ReceiveStatus))
                ) &&
                (
                    this.ReceivedQuantity == input.ReceivedQuantity ||
                    (this.ReceivedQuantity != null &&
                    this.ReceivedQuantity.Equals(input.ReceivedQuantity))
                ) &&
                (
                    this.LastReceiveDate == input.LastReceiveDate ||
                    (this.LastReceiveDate != null &&
                    this.LastReceiveDate.Equals(input.LastReceiveDate))
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
                if (this.ReceiveStatus != null)
                    hashCode = hashCode * 59 + this.ReceiveStatus.GetHashCode();
                if (this.ReceivedQuantity != null)
                    hashCode = hashCode * 59 + this.ReceivedQuantity.GetHashCode();
                if (this.LastReceiveDate != null)
                    hashCode = hashCode * 59 + this.LastReceiveDate.GetHashCode();
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
