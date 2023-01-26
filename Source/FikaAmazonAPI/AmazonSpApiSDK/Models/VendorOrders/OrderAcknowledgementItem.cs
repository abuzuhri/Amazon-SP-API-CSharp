using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using FikaAmazonAPI.AmazonSpApiSDK.Models.EasyShip20220323;
using FikaAmazonAPI.AmazonSpApiSDK.Models.ListingsItems;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders
{
    [DataContract]
    public partial class OrderAcknowledgementItem : IEquatable<OrderAcknowledgementItem>, IValidatableObject
    {
        [JsonConstructorAttribute]
        public OrderAcknowledgementItem() { }
        public OrderAcknowledgementItem(string itemSequenceNumber = default(string), string amazonProductIdentifier = default(string), string vendorProductIdentifier = default(string), ItemQuantity orderedQuantity = default(ItemQuantity), Money netCost = default(Money), Money listPrice = default(Money), string discountMultiplier = default(string), List<OrderItemAcknowledgement> itemAcknowledgements = default(List<OrderItemAcknowledgement>))
        {
            // to ensure "purchaseOrderNumber" is required (not null)
            if (orderedQuantity == null)
            {
                throw new InvalidDataException("orderedQuantity is a required property for OrderAcknowledgementItem and cannot be null");
            }
            else
            {
                this.OrderedQuantity = orderedQuantity;
            }
            ItemSequenceNumber = itemSequenceNumber;
            AmazonProductIdentifier = amazonProductIdentifier;
            NetCost = netCost;
            ListPrice = listPrice;
            DiscountMultiplier = discountMultiplier;
            if (itemAcknowledgements == null)
            {
                throw new InvalidDataException("itemAcknowledgements is a required property for OrderAcknowledgementItem and cannot be null");
            }
            else
            {
                this.ItemAcknowledgements = itemAcknowledgements;
            }
        }

        [DataMember(Name = "itemSequenceNumber", EmitDefaultValue = false)]
        public string ItemSequenceNumber { get; set; }

        [DataMember(Name = "amazonProductIdentifier", EmitDefaultValue = false)]
        public string AmazonProductIdentifier { get; set; }

        [DataMember(Name = "vendorProductIdentifier", EmitDefaultValue = false)]
        public string VendorProductIdentifier { get; set; }

        [DataMember(Name = "orderedQuantity", EmitDefaultValue = false)]
        public ItemQuantity OrderedQuantity { get; set; }

        [DataMember(Name = "netCost", EmitDefaultValue = false)]
        public Money NetCost { get; set; }

        [DataMember(Name = "listPrice", EmitDefaultValue = false)]
        public Money ListPrice { get; set; }

        [DataMember(Name = "discountMultiplier", EmitDefaultValue = false)]
        public string DiscountMultiplier { get; set; }

        [DataMember(Name = "itemAcknowledgements", EmitDefaultValue = false)]
        public List<OrderItemAcknowledgement> ItemAcknowledgements { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderAcknowledgementItem {\n");
            sb.Append("  ItemSequenceNumber: ").Append(ItemSequenceNumber).Append("\n");
            sb.Append("  AmazonProductIdentifier: ").Append(AmazonProductIdentifier).Append("\n");
            sb.Append("  VendorProductIdentifier: ").Append(VendorProductIdentifier).Append("\n");
            sb.Append("  OrderedQuantity: ").Append(OrderedQuantity).Append("\n");
            sb.Append("  NetCost: ").Append(NetCost).Append("\n");
            sb.Append("  ListPrice: ").Append(ListPrice).Append("\n");
            sb.Append("  DiscountMultiplier: ").Append(DiscountMultiplier).Append("\n");
            sb.Append("  ItemAcknowledgements: ").Append(ItemAcknowledgements).Append("\n");
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
            return this.Equals(input as OrderAcknowledgementItem);
        }

        public bool Equals(OrderAcknowledgementItem input)
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
                    this.AmazonProductIdentifier == input.AmazonProductIdentifier ||
                    (this.AmazonProductIdentifier != null &&
                    this.AmazonProductIdentifier.Equals(input.AmazonProductIdentifier))
                ) &&
                (
                    this.VendorProductIdentifier == input.VendorProductIdentifier ||
                    (this.VendorProductIdentifier != null &&
                    this.VendorProductIdentifier.Equals(input.VendorProductIdentifier))
                ) &&
                (
                    this.OrderedQuantity == input.OrderedQuantity ||
                    (this.OrderedQuantity != null &&
                    this.OrderedQuantity.Equals(input.OrderedQuantity))
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
                    this.DiscountMultiplier == input.DiscountMultiplier ||
                    (this.DiscountMultiplier != null &&
                    this.DiscountMultiplier.Equals(input.DiscountMultiplier))
                ) &&
                (
                    this.ItemAcknowledgements == input.ItemAcknowledgements ||
                    this.ItemAcknowledgements != null &&
                    this.ItemAcknowledgements.SequenceEqual(input.ItemAcknowledgements)
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
                if (this.AmazonProductIdentifier != null)
                    hashCode = hashCode * 59 + this.AmazonProductIdentifier.GetHashCode();
                if (this.VendorProductIdentifier != null)
                    hashCode = hashCode * 59 + this.VendorProductIdentifier.GetHashCode();
                if (this.OrderedQuantity != null)
                    hashCode = hashCode * 59 + this.OrderedQuantity.GetHashCode();
                if (this.NetCost != null)
                    hashCode = hashCode * 59 + this.NetCost.GetHashCode();
                if (this.ListPrice != null)
                    hashCode = hashCode * 59 + this.ListPrice.GetHashCode();
                if (this.DiscountMultiplier != null)
                    hashCode = hashCode * 59 + this.DiscountMultiplier.GetHashCode();
                if (this.ItemAcknowledgements != null)
                    hashCode = hashCode * 59 + this.ItemAcknowledgements.GetHashCode();
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
