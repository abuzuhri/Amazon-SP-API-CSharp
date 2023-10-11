using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorTransactions
{
    /// <summary>
    /// TransactionStatus
    /// </summary>
    [DataContract]
    public partial class TransactionStatus : IEquatable<TransactionStatus>, IValidatableObject
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TransactionStatusEnum
        {
            [EnumMember(Value = "Failure")]
            Failure,

            [EnumMember(Value = "Processing")]
            Processing,

            [EnumMember(Value = "Success")]
            Success
        }

        /// <summary>
        /// Current status of the transaction.
        /// </summary>
        /// <value>Current status of the transaction.</value>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public TransactionStatusEnum? Status { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionStatus" /> class.
        /// </summary>
        //[JsonConstructorAttribute]
        //public TransactionStatus() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="VendorOrders.TransactionStatus" /> class.
        /// </summary>
        /// <param name="transactionId">GUID assigned by Amazon to identify this transaction. This value can be used with the Transaction Status API to return the status of this transaction..</param>
        /// <param name="status">Transaction status</param>
        public TransactionStatus(string transactionId = default, TransactionStatusEnum? status = default)
        {
            TransactionId = transactionId;
            Status = status;
        }

        /// <summary>
        /// GUID assigned by Amazon to identify this transaction. This value can be used with the Transaction Status API to return the status of this transaction.
        /// </summary>
        /// <value>GUID assigned by Amazon to identify this transaction. This value can be used with the Transaction Status API to return the status of this transaction.</value>
        [DataMember(Name = "transactionId", EmitDefaultValue = false)]
        public string TransactionId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TransactionStatus {\n");
            sb.Append("  TransactionId: ").Append(TransactionId).Append("\n");
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
            return Equals(input as TransactionStatus);
        }

        /// <summary>
        /// Returns true if TransactionId instances are equal
        /// </summary>
        /// <param name="input">Instance of TransactionId to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TransactionStatus input)
        {
            if (input == null)
                return false;

            return
                (
                    TransactionId == input.TransactionId ||
                    TransactionId != null &&
                    TransactionId.Equals(input.TransactionId)
                ) &&
                (
                    Status == input.Status ||
                    Status != null &&
                    Status.Equals(input.Status)
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
                if (TransactionId != null)
                    hashCode = hashCode * 59 + TransactionId.GetHashCode();
                if (Status != null)
                    hashCode = hashCode * 59 + Status.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
