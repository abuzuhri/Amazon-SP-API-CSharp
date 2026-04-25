using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Information about how the order is being processed, packed, and shipped to the customer.
    /// </summary>
    [DataContract]
    public partial class OrderFulfillment : IEquatable<OrderFulfillment>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderFulfillment" /> class.
        /// </summary>
        public OrderFulfillment() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderFulfillment" /> class.
        /// </summary>
        /// <param name="fulfillmentStatus">The current fulfillment status of an order, indicating where the order is in the fulfillment process from placement to handover to carrier. (required)</param>
        /// <param name="fulfilledBy">Specifies whether Amazon or the merchant is responsible for fulfilling this order.</param>
        /// <param name="fulfillmentServiceLevel">The category of the shipping speed option selected by the customer at checkout.</param>
        /// <param name="shipByWindow">A time period with start and end boundaries.</param>
        /// <param name="deliverByWindow">A time period with start and end boundaries.</param>

        public OrderFulfillment(FulfillmentStatusEnum fulfillmentStatus,
                                FulfilledByEnum? fulfilledBy,
                                FulfillmentServiceLevelEnum? fulfillmentServiceLevel,
                                DeliveryWindow shipByWindow,
                                DeliveryWindow deliverByWindow)
        {
            this.FulfillmentStatus = fulfillmentStatus;
            this.FulfilledBy = fulfilledBy;
            this.FulfillmentServiceLevel = fulfillmentServiceLevel;
            this.ShipByWindow = shipByWindow;
            this.DeliverByWindow = deliverByWindow;
        }


        /// <summary>
        /// The current fulfillment status of an order, indicating where the order is in the fulfillment process from placement to handover to carrier. (required)
        /// </summary>
        /// <value>The current fulfillment status of an order, indicating where the order is in the fulfillment process from placement to handover to carrier. (required)</value>
        [DataMember(Name = "fulfillmentStatus", EmitDefaultValue = false)]
        public FulfillmentStatusEnum FulfillmentStatus { get; set; }

        /// <summary>
        /// Specifies whether Amazon or the merchant is responsible for fulfilling this order.
        /// </summary>
        /// <value>Specifies whether Amazon or the merchant is responsible for fulfilling this order.</value>
        [DataMember(Name = "fulfilledBy", EmitDefaultValue = false)]
        public FulfilledByEnum? FulfilledBy { get; set; }

        /// <summary>
        /// The category of the shipping speed option selected by the customer at checkout.
        /// </summary>
        /// <value>The category of the shipping speed option selected by the customer at checkout.</value>
        [DataMember(Name = "fulfillmentServiceLevel", EmitDefaultValue = false)]
        public FulfillmentServiceLevelEnum? FulfillmentServiceLevel { get; set; }

        /// <summary>
        /// A time period with start and end boundaries.
        /// </summary>
        /// <value>A time period with start and end boundaries.</value>
        [DataMember(Name = "shipByWindow", EmitDefaultValue = false)]
        public DeliveryWindow ShipByWindow { get; set; }

        /// <summary>
        /// A time period with start and end boundaries.
        /// </summary>
        /// <value>A time period with start and end boundaries.</value>
        [DataMember(Name = "deliverByWindow", EmitDefaultValue = false)]
        public DeliveryWindow DeliverByWindow { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderFulfillment {\n");
            sb.Append("  FulfillmentStatus: ").Append(FulfillmentStatus).Append("\n");
            sb.Append("  FulfilledBy: ").Append(FulfilledBy).Append("\n");
            sb.Append("  FulfillmentServiceLevel: ").Append(FulfillmentServiceLevel).Append("\n");
            sb.Append("  ShipByWindow: ").Append(ShipByWindow).Append("\n");
            sb.Append("  DeliverByWindow: ").Append(DeliverByWindow).Append("\n");
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
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as OrderFulfillment);
        }

        /// <summary>
        /// Returns true if OrderFulfillment instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderFulfillment to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderFulfillment input)
        {
            if (input == null)
                return false;

            return
                (
                    this.FulfillmentStatus == input.FulfillmentStatus ||
                    (this.FulfillmentStatus != null &&
                    this.FulfillmentStatus.Equals(input.FulfillmentStatus))
                ) &&
                (
                    this.FulfilledBy == input.FulfilledBy ||
                    (this.FulfilledBy != null &&
                    this.FulfilledBy.Equals(input.FulfilledBy))
                ) &&
                (
                    this.FulfillmentServiceLevel == input.FulfillmentServiceLevel ||
                    (this.FulfillmentServiceLevel != null &&
                    this.FulfillmentServiceLevel.Equals(input.FulfillmentServiceLevel))
                ) &&
                (
                    this.ShipByWindow == input.ShipByWindow ||
                    (this.ShipByWindow != null &&
                    this.ShipByWindow.Equals(input.ShipByWindow))
                ) &&
                (
                    this.DeliverByWindow == input.DeliverByWindow ||
                    (this.DeliverByWindow != null &&
                    this.DeliverByWindow.Equals(input.DeliverByWindow))
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
                if (this.FulfillmentStatus != null)
                    hashCode = hashCode * 59 + this.FulfillmentStatus.GetHashCode();
                if (this.FulfilledBy != null)
                    hashCode = hashCode * 59 + this.FulfilledBy.GetHashCode();
                if (this.FulfillmentServiceLevel != null)
                    hashCode = hashCode * 59 + this.FulfillmentServiceLevel.GetHashCode();
                if (this.ShipByWindow != null)
                    hashCode = hashCode * 59 + this.ShipByWindow.GetHashCode();
                if (this.DeliverByWindow != null)
                    hashCode = hashCode * 59 + this.DeliverByWindow.GetHashCode();
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