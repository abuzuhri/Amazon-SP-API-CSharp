using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// SearchOrders response.
    /// </summary>
    [DataContract]
    public partial class SearchOrdersResponse :  IEquatable<SearchOrdersResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchOrdersResponse" /> class.
        /// </summary>
        public SearchOrdersResponse() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchOrdersResponse" /> class.
        /// </summary>
        /// <param name="orders">An array containing all orders that match the search criteria. (required)</param>
        /// <param name="pagination">Contains tokens to fetch from a certain page.</param>
        /// <param name="lastUpdatedBefore">Only orders updated before the specified time are returned. The date must be in ISO 8601 format.</param>
        /// <param name="createdBefore">Only orders placed before the specified time are returned. The date must be in ISO 8601 format.</param>
        public SearchOrdersResponse(List<Order> orders,
                                    Pagination pagination,
                                    DateTime? lastUpdatedBefore,
                                    DateTime? createdBefore)
        {
            // to ensure "orders" is required (not null)
            if (orders == null)
            {
                throw new ArgumentNullException("orders is a required property for SearchOrdersResponse and cannot be null");
            }
            else 
            {
                this.Orders = orders;
            }

            this.Pagination = pagination;
            this.LastUpdatedBefore = lastUpdatedBefore;
            this.CreatedBefore = createdBefore;
        }

        /// <summary>
        /// An array containing all orders that match the search criteria.
        /// </summary>
        /// <value>An array containing all orders that match the search criteria.</value>
        [DataMember(Name="orders", EmitDefaultValue=false)]
        public List<Order> Orders { get; set; }

        /// <summary>
        /// Gets or Sets Pagination
        /// </summary>
        [DataMember(Name="pagination", EmitDefaultValue=false)]
        public Pagination Pagination { get; set; }

        /// <summary>
        /// Only orders updated before the specified time are returned. The date must be in ISO 8601 format.
        /// </summary>
        [DataMember(Name = "lastUpdatedBefore", EmitDefaultValue = false)]
        public DateTime? LastUpdatedBefore { get; set; }

        /// <summary>
        /// Only orders placed before the specified time are returned. The date must be in ISO 8601 format.
        /// </summary>
        [DataMember(Name = "createdBefore", EmitDefaultValue = false)]
        public DateTime? CreatedBefore { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SearchOrdersResponse {\n");
            sb.Append("  Orders: ").Append(Orders).Append("\n");
            sb.Append("  Pagination: ").Append(Pagination).Append("\n");
            sb.Append("  LastUpdatedBefore: ").Append(LastUpdatedBefore).Append("\n");
            sb.Append("  CreatedBefore: ").Append(CreatedBefore).Append("\n");
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
            return Equals(obj as SearchOrdersResponse);
        }

        /// <summary>
        /// Returns true if SearchOrdersResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of SearchOrdersResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SearchOrdersResponse input)
        {
            if (input == null)
                return false;

            return 
                (
                    Orders == input.Orders ||
                    Orders != null &&
                    Orders.SequenceEqual(input.Orders)
                ) && 
                (
                    Pagination == input.Pagination ||
                    Pagination != null &&
                    Pagination.Equals(input.Pagination)
                ) &&
                (
                    LastUpdatedBefore == input.LastUpdatedBefore ||
                    LastUpdatedBefore != null &&
                    LastUpdatedBefore.Equals(input.LastUpdatedBefore)
                ) &&
                (
                    CreatedBefore == input.CreatedBefore ||
                    CreatedBefore != null &&
                    CreatedBefore.Equals(input.CreatedBefore)
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
                if (Orders != null)
                    hashCode = hashCode * 59 + Orders.GetHashCode();
                if (Pagination != null)
                    hashCode = hashCode * 59 + Pagination.GetHashCode();
                if (LastUpdatedBefore != null)
                    hashCode = hashCode * 59 + LastUpdatedBefore.GetHashCode();
                if (CreatedBefore != null)
                    hashCode = hashCode * 59 + CreatedBefore.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
