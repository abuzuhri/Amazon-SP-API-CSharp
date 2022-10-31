using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.EasyShip20220323
{

    /// <summary>
    /// A package. This object contains all the details of the scheduled Easy Ship package including the package identifier, physical attributes such as dimensions and weight, selected time slot to handover the package to carrier, status of the package, and tracking/invoice details.
    /// </summary>
    [DataContract]
    public class Package
    {
        /// <summary>
        /// Gets or Sets ScheduledPackageId
        /// </summary>
        [DataMember(Name = "scheduledPackageId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "scheduledPackageId")]
        public ScheduledPackageId ScheduledPackageId { get; set; }

        /// <summary>
        /// Gets or Sets PackageDimensions
        /// </summary>
        [DataMember(Name = "packageDimensions", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "packageDimensions")]
        public Dimensions PackageDimensions { get; set; }

        /// <summary>
        /// Gets or Sets PackageWeight
        /// </summary>
        [DataMember(Name = "packageWeight", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "packageWeight")]
        public Weight PackageWeight { get; set; }

        /// <summary>
        /// Gets or Sets PackageItems
        /// </summary>
        [DataMember(Name = "packageItems", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "packageItems")]
        public Items PackageItems { get; set; }

        /// <summary>
        /// Gets or Sets PackageTimeSlot
        /// </summary>
        [DataMember(Name = "packageTimeSlot", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "packageTimeSlot")]
        public TimeSlot PackageTimeSlot { get; set; }

        /// <summary>
        /// Gets or Sets PackageIdentifier
        /// </summary>
        [DataMember(Name = "packageIdentifier", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "packageIdentifier")]
        public string PackageIdentifier { get; set; }

        /// <summary>
        /// Gets or Sets Invoice
        /// </summary>
        [DataMember(Name = "invoice", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "invoice")]
        public InvoiceData Invoice { get; set; }

        /// <summary>
        /// Gets or Sets PackageStatus
        /// </summary>
        [DataMember(Name = "packageStatus", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "packageStatus")]
        public PackageStatus PackageStatus { get; set; }

        /// <summary>
        /// Gets or Sets TrackingDetails
        /// </summary>
        [DataMember(Name = "trackingDetails", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "trackingDetails")]
        public TrackingDetails TrackingDetails { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Package {\n");
            sb.Append("  ScheduledPackageId: ").Append(ScheduledPackageId).Append("\n");
            sb.Append("  PackageDimensions: ").Append(PackageDimensions).Append("\n");
            sb.Append("  PackageWeight: ").Append(PackageWeight).Append("\n");
            sb.Append("  PackageItems: ").Append(PackageItems).Append("\n");
            sb.Append("  PackageTimeSlot: ").Append(PackageTimeSlot).Append("\n");
            sb.Append("  PackageIdentifier: ").Append(PackageIdentifier).Append("\n");
            sb.Append("  Invoice: ").Append(Invoice).Append("\n");
            sb.Append("  PackageStatus: ").Append(PackageStatus).Append("\n");
            sb.Append("  TrackingDetails: ").Append(TrackingDetails).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

    }
}
