using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Information about where the customer placed this order.
    /// </summary>
    [DataContract]
    public partial class SalesChannel : IEquatable<SalesChannel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesChannel" /> class.
        /// </summary>
        public SalesChannel() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesChannel" /> class.
        /// </summary>
        /// <param name="channelName">The name of the sales platform or channel where the customer placed this order. (required)</param>
        /// <param name="marketplaceId">The unique identifier for the specific marketplace within the sales channel where this order was placed.</param>
        /// <param name="marketplaceName">The human-readable name of the marketplace where this order was placed.</param>
        public SalesChannel(ChannelTypeEnum channelName = default,
                            string marketplaceId = default,
                            string marketplaceName = default)
        {
            // to ensure "channelName" is required (not null)
            if (channelName == null)
            {
                throw new InvalidDataException("channelName is a required property for SalesChannel and cannot be null");
            }
            else
            {
                this.ChannelName = channelName;
            }

            this.MarketplaceId = marketplaceId;
            this.MarketplaceName = marketplaceName;
        }


        /// <summary>
        /// The name of the sales platform or channel where the customer placed this order.
        /// </summary>
        /// <value>The name of the sales platform or channel where the customer placed this order.</value>
        [DataMember(Name = "channelName", EmitDefaultValue = false)]
        public ChannelTypeEnum ChannelName { get; set; }

        /// <summary>
        /// The unique identifier for the specific marketplace within the sales channel where this order was placed.
        /// </summary>
        /// <value>The unique identifier for the specific marketplace within the sales channel where this order was placed.</value>
        [DataMember(Name = "marketplaceId", EmitDefaultValue = false)]
        public string MarketplaceId { get; set; }

        /// <summary>
        /// The human-readable name of the marketplace where this order was placed.
        /// </summary>
        /// <value>The human-readable name of the marketplace where this order was placed.</value>
        [DataMember(Name = "marketplaceName", EmitDefaultValue = false)]
        public string MarketplaceName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SalesChannel {\n");
            sb.Append("  ChannelName: ").Append(ChannelName).Append("\n");
            sb.Append("  MarketplaceId: ").Append(MarketplaceId).Append("\n");
            sb.Append("  MarketplaceName: ").Append(MarketplaceName).Append("\n");
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
            return this.Equals(input as SalesChannel);
        }

        /// <summary>
        /// Returns true if SalesChannel instances are equal
        /// </summary>
        /// <param name="input">Instance of SalesChannel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SalesChannel input)
        {
            if (input == null)
                return false;

            return
                (
                    this.ChannelName == input.ChannelName ||
                    (this.ChannelName != null &&
                    this.ChannelName.Equals(input.ChannelName))
                ) &&
                (
                    this.MarketplaceId == input.MarketplaceId ||
                    (this.MarketplaceId != null &&
                    this.MarketplaceId.Equals(input.MarketplaceId))
                ) &&
                (
                    this.MarketplaceName == input.MarketplaceName ||
                    (this.MarketplaceName != null &&
                    this.MarketplaceName.Equals(input.MarketplaceName))
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
                if (this.ChannelName != null)
                    hashCode = hashCode * 59 + this.ChannelName.GetHashCode();
                if (this.MarketplaceId != null)
                    hashCode = hashCode * 59 + this.MarketplaceId.GetHashCode();
                if (this.MarketplaceName != null)
                    hashCode = hashCode * 59 + this.MarketplaceName.GetHashCode();

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