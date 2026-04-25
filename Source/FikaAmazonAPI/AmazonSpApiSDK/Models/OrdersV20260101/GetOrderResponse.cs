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
    public partial class GetOrderResponse :  IEquatable<GetOrderResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetOrderResponse" /> class.
        /// </summary>
        public GetOrderResponse() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetOrderResponse" /> class.
        /// </summary>
        /// <param name="order">Comprehensive information about a customer order. (required)</param>
        public GetOrderResponse(Order order)
        {
            this.Order = order;
        }

        /// <summary>
        /// Comprehensive information about a customer order. (required)
        /// </summary>
        /// <value>Comprehensive information about a customer order. (required)</value>
        [DataMember(Name="order", EmitDefaultValue=false)]
        public Order Order { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetOrderResponse {\n");
            sb.Append("  Order: ").Append(Order).Append("\n");
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
            return Equals(obj as GetOrderResponse);
        }

        /// <summary>
        /// Returns true if GetOrderResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of GetOrderResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetOrderResponse input)
        {
            if (input == null)
                return false;

            return 
                (
                    Order == input.Order ||
                    Order != null &&
                    Order.Equals(input.Order)
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
                if (Order != null)
                    hashCode = hashCode * 59 + Order.GetHashCode();
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
