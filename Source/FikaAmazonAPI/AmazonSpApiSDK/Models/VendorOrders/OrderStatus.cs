using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Converters;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders.Constants;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders
{
    [DataContract]
    public partial class OrderStatus : IEquatable<OrderStatus>, IValidatableObject
    {
        [JsonConstructorAttribute]
        public OrderStatus() { }
        public OrderStatus(
            string purchaseOrderNumber = default(string), PurchaseOrderStatus? purchaseOrderStatus = default(PurchaseOrderStatus?), DateTime? purchaseOrderDate = default(DateTime?), 
            DateTime? lastUpdatedDate = default(DateTime?), PartyIdentification sellingParty = default(PartyIdentification), PartyIdentification shipToParty = default(PartyIdentification), List<OrderItemStatus> itemStatus = default(List<OrderItemStatus>)
        )
        {
            if (purchaseOrderNumber == null)
            {
                throw new InvalidDataException("purchaseOrderNumber is a required property for OrderStatus and cannot be null");
            }
            else
            {
                this.PurchaseOrderNumber = purchaseOrderNumber;
            }
            if (purchaseOrderStatus == null)
            {
                throw new InvalidDataException("purchaseOrderStatus is a required property for OrderStatus and cannot be null");
            }
            else
            {
                this.PurchaseOrderStatus = purchaseOrderStatus;
            }
            if (purchaseOrderDate == null)
            {
                throw new InvalidDataException("purchaseOrderDate is a required property for OrderStatus and cannot be null");
            }
            else
            {
                this.PurchaseOrderDate = purchaseOrderDate;
            }
            this.LastUpdatedDate = lastUpdatedDate;
            if (sellingParty == null)
            {
                throw new InvalidDataException("sellingParty is a required property for OrderStatus and cannot be null");
            }
            else
            {
                this.SellingParty = sellingParty;
            }
            if (shipToParty == null)
            {
                throw new InvalidDataException("shipToParty is a required property for OrderStatus and cannot be null");
            }
            else
            {
                this.ShipToParty = shipToParty;
            }
            if (itemStatus == null)
            {
                throw new InvalidDataException("itemStatus is a required property for OrderStatus and cannot be null");
            }
            else
            {
                this.ItemStatus = itemStatus;
            }
        }

        /// <summary>
        /// The purchase order number for this order. Formatting Notes: alpha-numeric code.
        /// </summary>
        /// <value>The purchase order number for this order. Formatting Notes: alpha-numeric code.</value>
        [DataMember(Name = "purchaseOrderNumber", EmitDefaultValue = false)]
        public string PurchaseOrderNumber { get; set; }

        [DataMember(Name = "purchaseOrderStatus", EmitDefaultValue = false)]
        public PurchaseOrderStatus? PurchaseOrderStatus { get; set; }

        [DataMember(Name = "purchaseOrderDate", EmitDefaultValue = false)]
        public DateTime? PurchaseOrderDate { get; set; }

        [DataMember(Name = "lastUpdatedDate", EmitDefaultValue = false)]
        public DateTime? LastUpdatedDate { get; set; }

        [DataMember(Name = "sellingParty", EmitDefaultValue = false)]
        public PartyIdentification SellingParty { get; set; }

        [DataMember(Name = "shipToParty", EmitDefaultValue = false)]
        public PartyIdentification ShipToParty { get; set; }

        [DataMember(Name = "itemStatus", EmitDefaultValue = false)]
        public List<OrderItemStatus> ItemStatus { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderStatus {\n");
            sb.Append("  PurchaseOrderNumber: ").Append(PurchaseOrderNumber).Append("\n");
            sb.Append("  PurchaseOrderStatus: ").Append(PurchaseOrderStatus).Append("\n");
            sb.Append("  PurchaseOrderDate: ").Append(PurchaseOrderDate).Append("\n");
            sb.Append("  LastUpdatedDate: ").Append(LastUpdatedDate).Append("\n");
            sb.Append("  SellingParty: ").Append(SellingParty).Append("\n");
            sb.Append("  ShipToParty: ").Append(ShipToParty).Append("\n");
            sb.Append("  ItemStatus: ").Append(ItemStatus).Append("\n");
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
            return this.Equals(input as Order);
        }

        /// <summary>
        /// Returns true if Order instances are equal
        /// </summary>
        /// <param name="input">Instance of Order to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderStatus input)
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
                    this.PurchaseOrderStatus == input.PurchaseOrderStatus ||
                    (this.PurchaseOrderStatus != null &&
                    this.PurchaseOrderStatus.Equals(input.PurchaseOrderStatus))
                ) &&
                (
                    this.PurchaseOrderDate == input.PurchaseOrderDate ||
                    (this.PurchaseOrderDate != null &&
                    this.PurchaseOrderDate.Equals(input.PurchaseOrderDate))
                ) &&
                (
                    this.LastUpdatedDate == input.LastUpdatedDate ||
                    (this.LastUpdatedDate != null &&
                    this.LastUpdatedDate.Equals(input.LastUpdatedDate))
                ) &&
                (
                    this.SellingParty == input.SellingParty ||
                    (this.SellingParty != null &&
                    this.SellingParty.Equals(input.SellingParty))
                ) &&
                (
                    this.ShipToParty == input.ShipToParty ||
                    (this.ShipToParty != null &&
                    this.ShipToParty.Equals(input.ShipToParty))
                ) &&
                (
                    this.ItemStatus == input.ItemStatus ||
                    (this.ItemStatus != null &&
                    this.ItemStatus.Equals(input.ItemStatus))
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
                if (this.PurchaseOrderStatus != null)
                    hashCode = hashCode * 59 + this.PurchaseOrderStatus.GetHashCode();
                if (this.PurchaseOrderDate != null)
                    hashCode = hashCode * 59 + this.PurchaseOrderDate.GetHashCode();
                if (this.LastUpdatedDate != null)
                    hashCode = hashCode * 59 + this.LastUpdatedDate.GetHashCode();
                if (this.SellingParty != null)
                    hashCode = hashCode * 59 + this.SellingParty.GetHashCode();
                if (this.ShipToParty != null)
                    hashCode = hashCode * 59 + this.ShipToParty.GetHashCode();
                if (this.ItemStatus != null)
                    hashCode = hashCode * 59 + this.ItemStatus.GetHashCode();
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
