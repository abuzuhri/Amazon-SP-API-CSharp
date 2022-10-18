using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders
{
    [DataContract]
    public partial class OrderListStatus : IEquatable<OrderListStatus>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderList" /> class.
        /// </summary>
        /// <param name="pagination">pagination.</param>
        /// <param name="orders">orders.</param>
        public OrderListStatus(Pagination pagination = default(Pagination), List<OrderStatus> ordersStatus = default(List<OrderStatus>))
        {
            this.Pagination = pagination;
            this.OrdersStatus = ordersStatus;
        }

        /// <summary>
        /// Gets or Sets Pagination
        /// </summary>
        [DataMember(Name = "pagination", EmitDefaultValue = false)]
        public Pagination Pagination { get; set; }

        /// <summary>
        /// Gets or Sets Orders
        /// </summary>
        [DataMember(Name = "ordersStatus", EmitDefaultValue = false)]
        public List<OrderStatus> OrdersStatus { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderListStatus {\n");
            sb.Append("  Pagination: ").Append(Pagination).Append("\n");
            sb.Append("  OrdersStatus: ").Append(OrdersStatus).Append("\n");
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
            return this.Equals(input as OrderListStatus);
        }

        /// <summary>
        /// Returns true if OrderList instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderList to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderListStatus input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Pagination == input.Pagination ||
                    (this.Pagination != null &&
                    this.Pagination.Equals(input.Pagination))
                ) &&
                (
                    this.OrdersStatus == input.OrdersStatus ||
                    this.OrdersStatus != null &&
                    this.OrdersStatus.SequenceEqual(input.OrdersStatus)
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
                if (this.Pagination != null)
                    hashCode = hashCode * 59 + this.Pagination.GetHashCode();
                if (this.OrdersStatus != null)
                    hashCode = hashCode * 59 + this.OrdersStatus.GetHashCode();
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
