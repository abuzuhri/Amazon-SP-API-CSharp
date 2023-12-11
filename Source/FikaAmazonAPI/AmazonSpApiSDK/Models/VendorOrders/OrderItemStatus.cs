using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Sales;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders
{
    [DataContract]
    public partial class OrderItemStatus : IEquatable<OrderItemStatus>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItem" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public OrderItemStatus() { }
        public OrderItemStatus(
            string itemSequenceNumber = default(string), string buyerProductIdentifier = default(string), string vendorProductIdentifier = default(string), Money netCost = default(Money), Money listPrice = default(Money), 
            orderedQuantity orderedQuantity = default(orderedQuantity), AcknowledgementStatus acknowledgementStatus = default(AcknowledgementStatus)
        )
        {
            if (itemSequenceNumber == null)
            {
                throw new InvalidDataException("itemSequenceNumber is a required property for OrderItemStatus and cannot be null");
            }
            else
            {
                this.ItemSequenceNumber = itemSequenceNumber;
            }
            this.BuyerProductIdentifier = buyerProductIdentifier;
            this.VendorProductIdentifier = vendorProductIdentifier;
            this.NetCost = netCost;
            this.ListPrice = listPrice;
            this.OrderedQuantity = orderedQuantity;
            this.AcknowledgementStatus = acknowledgementStatus;
        }

        [DataMember(Name = "itemSequenceNumber", EmitDefaultValue = false)]
        public string ItemSequenceNumber { get; set; }

        [DataMember(Name = "buyerProductIdentifier", EmitDefaultValue = false)] 
        public string BuyerProductIdentifier { get; set; }

        [DataMember(Name = "vendorProductIdentifier", EmitDefaultValue = false)]
        public string VendorProductIdentifier { get; set; }

        [DataMember(Name = "netCost", EmitDefaultValue = false)]
        public Money NetCost { get; set; }

        [DataMember(Name = "listPrice", EmitDefaultValue = false)]
        public Money ListPrice { get; set; }

        [DataMember(Name = "orderedQuantity", EmitDefaultValue = false)]
        public orderedQuantity OrderedQuantity { get; set; }

        [DataMember(Name = "acknowledgementStatus", EmitDefaultValue = false)]
        public AcknowledgementStatus AcknowledgementStatus { get; set; }

        [DataMember(Name = "receivingStatus", EmitDefaultValue = false)]
        public receivingStatus ReceivingStatus { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderItem {\n");
            sb.Append("  ItemSequenceNumber: ").Append(ItemSequenceNumber).Append("\n");
            sb.Append("  BuyerProductIdentifier: ").Append(BuyerProductIdentifier).Append("\n");
            sb.Append("  VendorProductIdentifier: ").Append(VendorProductIdentifier).Append("\n");
            sb.Append("  NetCost: ").Append(NetCost).Append("\n");
            sb.Append("  ListPrice: ").Append(ListPrice).Append("\n");
            sb.Append("  OrderedQuantity: ").Append(OrderedQuantity).Append("\n");
            sb.Append("  AcknowledgementStatus: ").Append(AcknowledgementStatus).Append("\n");
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
            return this.Equals(input as OrderItemStatus);
        }

        /// <summary>
        /// Returns true if OrderItem instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderItem to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderItemStatus input)
        {
            if (input == null)
                return false;

            return
                (
                    this.ItemSequenceNumber == input.ItemSequenceNumber ||
                    (this.ItemSequenceNumber != null &&
                    this.ItemSequenceNumber.Equals(input.ItemSequenceNumber))
                ) &&
                (
                    this.BuyerProductIdentifier == input.BuyerProductIdentifier ||
                    (this.BuyerProductIdentifier != null &&
                    this.BuyerProductIdentifier.Equals(input.BuyerProductIdentifier))
                ) &&
                (
                    this.VendorProductIdentifier == input.VendorProductIdentifier ||
                    (this.VendorProductIdentifier != null &&
                    this.VendorProductIdentifier.Equals(input.VendorProductIdentifier))
                ) &&
                (
                    this.NetCost == input.NetCost ||
                    (this.NetCost != null &&
                    this.NetCost.Equals(input.NetCost))
                ) &&
                (
                    this.ListPrice == input.ListPrice ||
                    (this.ListPrice != null &&
                    this.ListPrice.Equals(input.ListPrice))
                ) &&
                (
                    this.OrderedQuantity == input.OrderedQuantity ||
                    (this.OrderedQuantity != null &&
                    this.OrderedQuantity.Equals(input.OrderedQuantity))
                ) &&
                (
                    this.AcknowledgementStatus == input.AcknowledgementStatus ||
                    (this.AcknowledgementStatus != null &&
                    this.AcknowledgementStatus.Equals(input.AcknowledgementStatus))
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
                if (this.ItemSequenceNumber != null)
                    hashCode = hashCode * 59 + this.ItemSequenceNumber.GetHashCode();
                if (this.BuyerProductIdentifier != null)
                    hashCode = hashCode * 59 + this.BuyerProductIdentifier.GetHashCode();
                if (this.VendorProductIdentifier != null)
                    hashCode = hashCode * 59 + this.VendorProductIdentifier.GetHashCode();
                if (this.NetCost != null)
                    hashCode = hashCode * 59 + this.NetCost.GetHashCode();
                if (this.ListPrice != null)
                    hashCode = hashCode * 59 + this.ListPrice.GetHashCode();
                if (this.OrderedQuantity != null)
                    hashCode = hashCode * 59 + this.OrderedQuantity.GetHashCode();
                if (this.AcknowledgementStatus != null)
                    hashCode = hashCode * 59 + this.AcknowledgementStatus.GetHashCode();
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
