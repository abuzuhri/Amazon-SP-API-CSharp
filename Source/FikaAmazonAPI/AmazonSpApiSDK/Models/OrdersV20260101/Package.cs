using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Shipping package created for order, including tracking information.
    /// </summary>
    [DataContract]
    public partial class Package : IEquatable<Package>, IValidatableObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Package" /> class.
        /// </summary>
        protected Package() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Package" /> class.
        /// </summary>
        /// <param name="packageReferenceId">A unique identifier for this package within the context of the order. (required)</param>
        /// <param name="createdTime">The exact time when this shipping package was created and prepared for shipment. In ISO 8601 format.</param>
        /// <param name="packageStatus">Current status and detailed tracking information for a shipping package throughout the delivery process.</param>
        /// <param name="carrier">The carrier responsible for transporting this package to the customer.</param>
        /// <param name="shipTime">The exact time when this package was handed over to the carrier and began its journey to the customer. In ISO 8601 format.</param>
        /// <param name="shippingService">The specific shipping method or service used for delivering this package.</param>
        /// <param name="trackingNumber">The carrier-provided tracking number that customers can use to monitor the package's delivery progress.</param>
        /// <param name="shipFromAddress">The physical address of the merchant.</param>
        /// <param name="packageItems">A list of all order items included in this specific package.</param>

        public Package(string packageReferenceId,
                         DateTime? createdTime,
                         PackageStatus packageStatus,
                         string carrier,
                         DateTime? shipTime,
                         string shippingService,
                         string trackingNumber,
                         Address shipFromAddress,
                         List<PackageItem> packageItems)
        {
            this.PackageReferenceId = packageReferenceId;
            this.CreatedTime = createdTime;
            this.PackageStatus = packageStatus;
            this.Carrier = carrier;
            this.ShipTime = shipTime;
            this.ShippingService = shippingService;
            this.TrackingNumber = trackingNumber;
            this.ShipFromAddress = shipFromAddress;
            this.PackageItems = packageItems;
        }

        /// <summary>
        /// A unique identifier for this package within the context of the order. (required)
        /// </summary>
        /// <value>A unique identifier for this package within the context of the order. (required)</value>
        [DataMember(Name = "packageReferenceId", EmitDefaultValue = false)]
        public string PackageReferenceId { get; set; }

        /// <summary>
        /// The exact time when this shipping package was created and prepared for shipment. In ISO 8601 format.
        /// </summary>
        /// <value>The exact time when this shipping package was created and prepared for shipment. In ISO 8601 format.</value>
        [DataMember(Name = "createdTime", EmitDefaultValue = false)]
        public DateTime? CreatedTime { get; set; }

        /// <summary>
        /// Current status and detailed tracking information for a shipping package throughout the delivery process.
        /// </summary>
        /// <value>Current status and detailed tracking information for a shipping package throughout the delivery process.</value>
        [DataMember(Name = "packageStatus", EmitDefaultValue = false)]
        public PackageStatus PackageStatus { get; set; }

        /// <summary>
        /// The carrier responsible for transporting this package to the customer.
        /// </summary>
        /// <value>The carrier responsible for transporting this package to the customer.</value>
        [DataMember(Name = "carrier", EmitDefaultValue = false)]
        public string Carrier { get; set; }

        /// <summary>
        /// The exact time when this package was handed over to the carrier and began its journey to the customer. In ISO 8601 format.
        /// </summary>
        /// <value>The exact time when this package was handed over to the carrier and began its journey to the customer. In ISO 8601 format.</value>
        [DataMember(Name = "shipTime", EmitDefaultValue = false)]
        public DateTime? ShipTime { get; set; }

        /// <summary>
        /// The specific shipping method or service used for delivering this package.
        /// </summary>
        /// <value>The specific shipping method or service used for delivering this package.</value>
        [DataMember(Name = "shippingService", EmitDefaultValue = false)]
        public string ShippingService { get; set; }

        /// <summary>
        /// The carrier-provided tracking number that customers can use to monitor the package's delivery progress.
        /// </summary>
        /// <value>The carrier-provided tracking number that customers can use to monitor the package's delivery progress.</value>
        [DataMember(Name = "trackingNumber", EmitDefaultValue = false)]
        public string TrackingNumber { get; set; }

        /// <summary>
        /// The physical address of the merchant.
        /// </summary>
        /// <value>The physical address of the merchant.</value>
        [DataMember(Name = "shipFromAddress", EmitDefaultValue = false)]
        public Address ShipFromAddress { get; set; }

        /// <summary>
        /// The cancellation information of the order item.
        /// </summary>
        /// <value>The cancellation information of the order item.</value>
        [DataMember(Name = "packageItems", EmitDefaultValue = false)]
        public List<PackageItem> PackageItems { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Package {\n");
            sb.Append("  PackageReferenceId: ").Append(PackageReferenceId).Append("\n");
            sb.Append("  CreatedTime: ").Append(CreatedTime).Append("\n");
            sb.Append("  PackageStatus: ").Append(PackageStatus).Append("\n");
            sb.Append("  Carrier: ").Append(Carrier).Append("\n");
            sb.Append("  ShipTime: ").Append(ShipTime).Append("\n");
            sb.Append("  ShippingService: ").Append(ShippingService).Append("\n");
            sb.Append("  TrackingNumber: ").Append(TrackingNumber).Append("\n");
            sb.Append("  ShipFromAddress: ").Append(ShipFromAddress).Append("\n");
            sb.Append("  PackageItems: ").Append(PackageItems).Append("\n");
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
            return this.Equals(obj as Package);
        }

        /// <summary>
        /// Returns true if Package instances are equal
        /// </summary>
        /// <param name="input">Instance of Package to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Package input)
        {
            if (input == null)
                return false;

            return
                (
                    this.PackageReferenceId == input.PackageReferenceId ||
                    (this.PackageReferenceId != null &&
                    this.PackageReferenceId.Equals(input.PackageReferenceId))
                ) &&
                (
                    this.CreatedTime == input.CreatedTime ||
                    (this.CreatedTime != null &&
                    this.CreatedTime.Equals(input.CreatedTime))
                ) &&
                (
                    this.PackageStatus == input.PackageStatus ||
                    (this.PackageStatus != null &&
                    this.PackageStatus.Equals(input.PackageStatus))
                ) &&
                (
                    this.Carrier == input.Carrier ||
                    (this.Carrier != null &&
                    this.Carrier.SequenceEqual(input.Carrier))
                ) &&
                (
                    this.ShipTime == input.ShipTime ||
                    (this.ShipTime != null &&
                    this.ShipTime.Equals(input.ShipTime))
                ) &&
                (
                    this.ShippingService == input.ShippingService ||
                    (this.ShippingService != null &&
                    this.ShippingService.Equals(input.ShippingService))
                ) &&
                (
                    this.TrackingNumber == input.TrackingNumber ||
                    (this.TrackingNumber != null &&
                    this.TrackingNumber.Equals(input.TrackingNumber))
                ) &&
                (
                    this.ShipFromAddress == input.ShipFromAddress ||
                    (this.ShipFromAddress != null &&
                    this.ShipFromAddress.Equals(input.ShipFromAddress))
                ) &&
                (
                    this.PackageItems == input.PackageItems ||
                    (this.PackageItems != null &&
                    this.PackageItems.SequenceEqual(input.PackageItems))
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
                if (this.PackageReferenceId != null)
                    hashCode = hashCode * 59 + this.PackageReferenceId.GetHashCode();
                if (this.CreatedTime != null)
                    hashCode = hashCode * 59 + this.CreatedTime.GetHashCode();
                if (this.PackageStatus != null)
                    hashCode = hashCode * 59 + this.PackageStatus.GetHashCode();
                if (this.Carrier != null)
                    hashCode = hashCode * 59 + this.Carrier.GetHashCode();
                if (this.ShipTime != null)
                    hashCode = hashCode * 59 + this.ShipTime.GetHashCode();
                if (this.ShippingService != null)
                    hashCode = hashCode * 59 + this.ShippingService.GetHashCode();
                if (this.TrackingNumber != null)
                    hashCode = hashCode * 59 + this.TrackingNumber.GetHashCode();
                if (this.ShipFromAddress != null)
                    hashCode = hashCode * 59 + this.ShipFromAddress.GetHashCode();
                if (this.PackageItems != null)
                    hashCode = hashCode * 59 + this.PackageItems.GetHashCode();
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
