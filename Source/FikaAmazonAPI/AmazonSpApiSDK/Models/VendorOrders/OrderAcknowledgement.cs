using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders
{
    [DataContract]
    public partial class OrderAcknowledgement : IEquatable<OrderAcknowledgement>, IValidatableObject
    {
        [JsonConstructorAttribute]
        public OrderAcknowledgement() { }
        public OrderAcknowledgement(string purchaseOrderNumber = default(string), PartyIdentification sellingParty = default(PartyIdentification), DateTime? acknowledgementDate = default(DateTime?), List<OrderAcknowledgementItem> items = default(List<OrderAcknowledgementItem>))
        {
            // to ensure "purchaseOrderNumber" is required (not null)
            if (purchaseOrderNumber == null)
            {
                throw new InvalidDataException("purchaseOrderNumber is a required property for OrderAcknowledgement and cannot be null");
            }
            else
            {
                this.PurchaseOrderNumber = purchaseOrderNumber;
            }
            // to ensure "sellingParty" is required (not null)
            if (sellingParty == null)
            {
                throw new InvalidDataException("sellingParty is a required property for OrderAcknowledgement and cannot be null");
            }
            else
            {
                this.SellingParty = sellingParty;
            }
            // to ensure "acknowledgementDate" is required (not null)
            if (acknowledgementDate == null)
            {
                throw new InvalidDataException("acknowledgementDate is a required property for OrderAcknowledgement and cannot be null");
            }
            else
            {
                this.AcknowledgementDate = acknowledgementDate;
            }
            Items = items;
        }

        /// <summary>
        /// The purchase order number for this order. Formatting Notes: alpha-numeric code.
        /// </summary>
        /// <value>The purchase order number for this order. Formatting Notes: alpha-numeric code.</value>
        [DataMember(Name = "purchaseOrderNumber", EmitDefaultValue = false)]
        public string PurchaseOrderNumber { get; set; }

        [DataMember(Name = "sellingParty", EmitDefaultValue = false)]
        public PartyIdentification SellingParty { get; set; }

        [DataMember(Name = "acknowledgementDate", EmitDefaultValue = false)]
        public DateTime? AcknowledgementDate { get; set; }
        
        [DataMember(Name = "items", EmitDefaultValue = false)]
        public List<OrderAcknowledgementItem> Items { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderAcknowledgement {\n");
            sb.Append("  PurchaseOrderNumber: ").Append(PurchaseOrderNumber).Append("\n");
            sb.Append("  SellingParty: ").Append(SellingParty).Append("\n");
            sb.Append("  AcknowledgementDate: ").Append(AcknowledgementDate).Append("\n");
            sb.Append("  Items: ").Append(Items).Append("\n");
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
            return this.Equals(input as OrderAcknowledgement);
        }

        public bool Equals(OrderAcknowledgement input)
        {
            if (input == null)
                return false;

            return
                (
                    this.PurchaseOrderNumber == input.PurchaseOrderNumber ||
                    (this.PurchaseOrderNumber != null &&
                    this.PurchaseOrderNumber.Equals(input.PurchaseOrderNumber))
                ) &&
                (
                    this.SellingParty == input.SellingParty ||
                    (this.SellingParty != null &&
                    this.SellingParty.Equals(input.SellingParty))
                ) &&
                (
                    this.AcknowledgementDate == input.AcknowledgementDate ||
                    (this.AcknowledgementDate != null &&
                    this.AcknowledgementDate.Equals(input.AcknowledgementDate))
                ) &&
                (
                    this.Items == input.Items ||
                    (this.Items != null &&
                    this.Items.Equals(input.Items))
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
                if (this.PurchaseOrderNumber != null)
                    hashCode = hashCode * 59 + this.PurchaseOrderNumber.GetHashCode();
                if (this.SellingParty != null)
                    hashCode = hashCode * 59 + this.SellingParty.GetHashCode();
                if (this.AcknowledgementDate != null)
                    hashCode = hashCode * 59 + this.AcknowledgementDate.GetHashCode();
                if (this.Items != null)
                    hashCode = hashCode * 59 + this.Items.GetHashCode();
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
