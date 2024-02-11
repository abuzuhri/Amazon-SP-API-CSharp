﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders
{
    /// <summary>
    /// TransactionId
    /// </summary>
    [DataContract]
    public partial class TransactionId : IEquatable<TransactionId>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionId" /> class.
        /// </summary>
        /// <param name="transactionId">GUID assigned by Amazon to identify this transaction. This value can be used with the Transaction Status API to return the status of this transaction..</param>
        public TransactionId(string transactionId = default(string))
        {
            this._TransactionId = transactionId;
        }

        /// <summary>
        /// GUID assigned by Amazon to identify this transaction. This value can be used with the Transaction Status API to return the status of this transaction.
        /// </summary>
        /// <value>GUID assigned by Amazon to identify this transaction. This value can be used with the Transaction Status API to return the status of this transaction.</value>
        [DataMember(Name = "transactionId", EmitDefaultValue = false)]
        public string _TransactionId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TransactionId {\n");
            sb.Append("  _TransactionId: ").Append(_TransactionId).Append("\n");
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
            return this.Equals(input as TransactionId);
        }

        /// <summary>
        /// Returns true if TransactionId instances are equal
        /// </summary>
        /// <param name="input">Instance of TransactionId to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TransactionId input)
        {
            if (input == null)
                return false;

            return
                (
                    this._TransactionId == input._TransactionId ||
                    (this._TransactionId != null &&
                    this._TransactionId.Equals(input._TransactionId))
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
                if (this._TransactionId != null)
                    hashCode = hashCode * 59 + this._TransactionId.GetHashCode();
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
