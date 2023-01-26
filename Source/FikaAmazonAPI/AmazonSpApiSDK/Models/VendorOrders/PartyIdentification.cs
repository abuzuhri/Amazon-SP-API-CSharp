using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorDirectFulfillmentOrders;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders
{
    /// <summary>
    /// PartyIdentification
    /// </summary>
    [DataContract]
    public partial class PartyIdentification : IEquatable<PartyIdentification>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PartyIdentification" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public PartyIdentification() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PartyIdentification" /> class.
        /// </summary>
        /// <param name="partyId">Assigned identification for the party. For example, warehouse code or vendor code. Please refer to specific party for more details. (required).</param>
        /// <param name="address">Address details of the party..</param>
        /// <param name="taxInfo">Tax registration details of the entity..</param>
        public PartyIdentification(string partyId = default(string), Address address = default(Address), TaxRegistrationDetails taxInfo = default(TaxRegistrationDetails))
        {
            // to ensure "partyId" is required (not null)
            if (partyId == null)
            {
                throw new InvalidDataException("partyId is a required property for PartyIdentification and cannot be null");
            }
            else
            {
                this.PartyId = partyId;
            }
            this.Address = address;
            this.TaxInfo = taxInfo;
        }

        /// <summary>
        /// Assigned identification for the party. For example, warehouse code or vendor code. Please refer to specific party for more details.
        /// </summary>
        /// <value>Assigned identification for the party. For example, warehouse code or vendor code. Please refer to specific party for more details.</value>
        [DataMember(Name = "partyId", EmitDefaultValue = false)]
        public string PartyId { get; set; }

        /// <summary>
        /// Address details of the party.
        /// </summary>
        /// <value>Address details of the party.</value>
        [DataMember(Name = "address", EmitDefaultValue = false)]
        public Address Address { get; set; }

        /// <summary>
        /// Tax registration details of the entity.
        /// </summary>
        /// <value>Tax registration details of the entity.</value>
        [DataMember(Name = "taxInfo", EmitDefaultValue = false)]
        public TaxRegistrationDetails TaxInfo { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PartyIdentification {\n");
            sb.Append("  PartyId: ").Append(PartyId).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  TaxInfo: ").Append(TaxInfo).Append("\n");
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
            return this.Equals(input as PartyIdentification);
        }

        /// <summary>
        /// Returns true if PartyIdentification instances are equal
        /// </summary>
        /// <param name="input">Instance of PartyIdentification to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PartyIdentification input)
        {
            if (input == null)
                return false;

            return
                (
                    this.PartyId == input.PartyId ||
                    (this.PartyId != null &&
                    this.PartyId.Equals(input.PartyId))
                ) &&
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
                ) &&
                (
                    this.TaxInfo == input.TaxInfo ||
                    (this.TaxInfo != null &&
                    this.TaxInfo.Equals(input.TaxInfo))
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
                if (this.PartyId != null)
                    hashCode = hashCode * 59 + this.PartyId.GetHashCode();
                if (this.Address != null)
                    hashCode = hashCode * 59 + this.Address.GetHashCode();
                if (this.TaxInfo != null)
                    hashCode = hashCode * 59 + this.TaxInfo.GetHashCode();
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
