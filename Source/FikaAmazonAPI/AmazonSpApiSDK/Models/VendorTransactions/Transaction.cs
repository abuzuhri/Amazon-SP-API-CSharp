using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorTransactions
{
    /// <summary>
    /// Transaction
    /// </summary>
    [DataContract]
    public partial class Transaction : IEquatable<Transaction>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionId" /> class.
        /// </summary>
        /// <param name="transactionId">GUID assigned by Amazon to identify this transaction. This value can be used with the Transaction Status API to return the status of this transaction..</param>
        public Transaction(TransactionStatus transactionStatus = default)
        {
            TransactionStatus = transactionStatus;
        }

        /// <summary>
        /// GUID assigned by Amazon to identify this transaction. This value can be used with the Transaction Status API to return the status of this transaction.
        /// </summary>
        /// <value>GUID assigned by Amazon to identify this transaction. This value can be used with the Transaction Status API to return the status of this transaction.</value>
        [DataMember(Name = "transactionStatus", EmitDefaultValue = false)]
        public TransactionStatus TransactionStatus { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Transaction {\n");
            sb.Append("  TransactionStatus: ").Append(TransactionStatus).Append("\n");
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
            return Equals(input as Transaction);
        }

        /// <summary>
        /// Returns true if TransactionId instances are equal
        /// </summary>
        /// <param name="input">Instance of TransactionId to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Transaction input)
        {
            if (input == null)
                return false;

            return

                    TransactionStatus == input.TransactionStatus ||
                    TransactionStatus != null &&
                    TransactionStatus.Equals(input.TransactionStatus)
                ;
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
                if (TransactionStatus != null)
                    hashCode = hashCode * 59 + TransactionStatus.GetHashCode();
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
