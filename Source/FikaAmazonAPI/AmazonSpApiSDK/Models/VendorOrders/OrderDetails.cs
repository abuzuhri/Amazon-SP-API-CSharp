using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders
{
    /// <summary>
    /// Details of an order.
    /// </summary>
    [DataContract]
    public partial class OrderDetails : IEquatable<OrderDetails>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDetails" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public OrderDetails() { }
        public OrderDetails(DateTime? purchaseOrderDate = default(DateTime?), DateTime? purchaseOrderChangedDate = default(DateTime?), DateTime? purchaseOrderStateChangedDate = default(DateTime?), PartyIdentification buyingParty = default(PartyIdentification), PartyIdentification sellingParty = default(PartyIdentification), PartyIdentification shipToParty = default(PartyIdentification), PartyIdentification billToParty = default(PartyIdentification), List<OrderItem> items = default(List<OrderItem>))
        {
            // to ensure "purchaseOrderDate" is required (not null)
            if (purchaseOrderDate == null)
            {
                throw new InvalidDataException("purchaseOrderDate is a required property for OrderDetails and cannot be null");
            }
            else
            {
                this.PurchaseOrderDate = purchaseOrderDate;
            }
            this.PurchaseOrderChangedDate = purchaseOrderChangedDate;
            // to ensure "purchaseOrderStateChangedDate" is required (not null)
            if (purchaseOrderStateChangedDate == null)
            {
                throw new InvalidDataException("purchaseOrderStateChangedDate is a required property for OrderDetails and cannot be null");
            }
            else
            {
                this.PurchaseOrderStateChangedDate = purchaseOrderStateChangedDate;
            }
            this.BuyingParty = buyingParty;
            this.SellingParty = sellingParty;
            this.ShipToParty = shipToParty;
            this.BillToParty = billToParty;
            // to ensure "items" is required (not null)
            if (items == null)
            {
                throw new InvalidDataException("items is a required property for OrderDetails and cannot be null");
            }
            else
            {
                this.Items = items;
            }
        }

        /// <summary>
        /// The date the purchase order was placed. This field is expected to be in ISO-8601 date/time format, for example:2018-07-16T23:00:00Z/ 2018-07-16T23:00:00-05:00 /2018-07-16T23:00:00-08:00. If no time zone is specified, UTC should be assumed.
        /// </summary>
        /// <value>The date the order was placed. This field is expected to be in ISO-8601 date/time format, for example:2018-07-16T23:00:00Z/ 2018-07-16T23:00:00-05:00 /2018-07-16T23:00:00-08:00. If no time zone is specified, UTC should be assumed.</value>
        [DataMember(Name = "purchaseOrderDate", EmitDefaultValue = false)]
        public DateTime? PurchaseOrderDate { get; set; }

        /// <summary>
        /// The date the purchase order was last changed by Amazon after the order was placed. If present, this means the PO data was changed on that date and vendors are required to fulfill the updated PO (item quantity, shop to location, ship window, etc.)
        /// This field is expected to be in ISO-8601 date/time format, for example:2018-07-16T23:00:00Z/ 2018-07-16T23:00:00-05:00 /2018-07-16T23:00:00-08:00. If no time zone is specified, UTC should be assumed.
        /// </summary>
        /// <value>The date the order was placed. This field is expected to be in ISO-8601 date/time format, for example:2018-07-16T23:00:00Z/ 2018-07-16T23:00:00-05:00 /2018-07-16T23:00:00-08:00. If no time zone is specified, UTC should be assumed.</value>
        [DataMember(Name = "purchaseOrderChangedDate", EmitDefaultValue = false)]
        public DateTime? PurchaseOrderChangedDate { get; set; }

        /// <summary>
        /// The date when current purchase order state changed. This field is expected to be in ISO-8601 date/time format, for example:2018-07-16T23:00:00Z/ 2018-07-16T23:00:00-05:00 /2018-07-16T23:00:00-08:00. If no time zone is specified, UTC should be assumed.
        /// </summary>
        /// <value>The date the order was placed. This field is expected to be in ISO-8601 date/time format, for example:2018-07-16T23:00:00Z/ 2018-07-16T23:00:00-05:00 /2018-07-16T23:00:00-08:00. If no time zone is specified, UTC should be assumed.</value>
        [DataMember(Name = "purchaseOrderStateChangedDate", EmitDefaultValue = false)]
        public DateTime? PurchaseOrderStateChangedDate { get; set; }

        [DataMember(Name = "buyingParty", EmitDefaultValue = false)]
        public PartyIdentification BuyingParty { get; set; }

        [DataMember(Name = "sellingParty", EmitDefaultValue = false)]
        public PartyIdentification SellingParty { get; set; }

        [DataMember(Name = "shipToParty", EmitDefaultValue = false)]
        public PartyIdentification ShipToParty { get; set; }

        [DataMember(Name = "billToParty", EmitDefaultValue = false)]
        public PartyIdentification BillToParty { get; set; }

        [DataMember(Name = "shipWindow", EmitDefaultValue = false)]
        public DateTimeInterval ShipWindow { get; set; }

        [DataMember(Name = "deliveryWindow", EmitDefaultValue = false)]
        public DateTimeInterval DeliveryWindow { get; set; }

        /// <summary>
        /// A list of items in this purchase order.
        /// </summary>
        /// <value>A list of items in this purchase order.</value>
        [DataMember(Name = "items", EmitDefaultValue = false)]
        public List<OrderItem> Items { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderDetails {\n");
            sb.Append("  PurchaseOrderDate: ").Append(PurchaseOrderDate).Append("\n");
            sb.Append("  PurchaseOrderChangedDate: ").Append(PurchaseOrderChangedDate).Append("\n");
            sb.Append("  PurchaseOrderStateChangedDate: ").Append(PurchaseOrderStateChangedDate).Append("\n");
            sb.Append("  BuyingParty: ").Append(BuyingParty).Append("\n");
            sb.Append("  SellingParty: ").Append(SellingParty).Append("\n");
            sb.Append("  ShipToParty: ").Append(ShipToParty).Append("\n");
            sb.Append("  BillToParty: ").Append(BillToParty).Append("\n");
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
            return this.Equals(input as OrderDetails);
        }

        /// <summary>
        /// Returns true if OrderDetails instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderDetails to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderDetails input)
        {
            if (input == null)
                return false;

            return
                (
                    this.PurchaseOrderDate == input.PurchaseOrderDate ||
                    (this.PurchaseOrderDate != null &&
                    this.PurchaseOrderDate.Equals(input.PurchaseOrderDate))
                ) &&
                (
                    this.PurchaseOrderChangedDate == input.PurchaseOrderChangedDate ||
                    (this.PurchaseOrderChangedDate != null &&
                    this.PurchaseOrderChangedDate.Equals(input.PurchaseOrderChangedDate))
                ) &&
                (
                    this.PurchaseOrderStateChangedDate == input.PurchaseOrderStateChangedDate ||
                    (this.PurchaseOrderStateChangedDate != null &&
                    this.PurchaseOrderStateChangedDate.Equals(input.PurchaseOrderStateChangedDate))
                ) &&
                (
                    this.BuyingParty == input.BuyingParty ||
                    (this.BuyingParty != null &&
                    this.BuyingParty.Equals(input.BuyingParty))
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
                    this.BillToParty == input.BillToParty ||
                    (this.BillToParty != null &&
                    this.BillToParty.Equals(input.BillToParty))
                ) &&
                (
                    this.Items == input.Items ||
                    this.Items != null &&
                    this.Items.SequenceEqual(input.Items)
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
                if (this.PurchaseOrderDate != null)
                    hashCode = hashCode * 59 + this.PurchaseOrderDate.GetHashCode();
                if (this.PurchaseOrderChangedDate != null)
                    hashCode = hashCode * 59 + this.PurchaseOrderChangedDate.GetHashCode();
                if (this.PurchaseOrderStateChangedDate != null)
                    hashCode = hashCode * 59 + this.PurchaseOrderStateChangedDate.GetHashCode();
                if (this.BuyingParty != null)
                    hashCode = hashCode * 59 + this.BuyingParty.GetHashCode();
                if (this.SellingParty != null)
                    hashCode = hashCode * 59 + this.SellingParty.GetHashCode();
                if (this.ShipToParty != null)
                    hashCode = hashCode * 59 + this.ShipToParty.GetHashCode();
                if (this.BillToParty != null)
                    hashCode = hashCode * 59 + this.BillToParty.GetHashCode();
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
