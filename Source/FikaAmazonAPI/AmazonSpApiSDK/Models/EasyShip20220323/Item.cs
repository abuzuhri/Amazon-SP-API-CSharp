using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.EasyShip20220323
{

    /// <summary>
    /// Item identifier and serial number information.
    /// </summary>
    [DataContract]
    public class Item
    {
        /// <summary>
        /// Gets or Sets OrderItemId
        /// </summary>
        [DataMember(Name = "orderItemId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "orderItemId")]
        public string OrderItemId { get; set; }

        /// <summary>
        /// Gets or Sets OrderItemSerialNumbers
        /// </summary>
        [DataMember(Name = "orderItemSerialNumbers", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "orderItemSerialNumbers")]
        public OrderItemSerialNumbers OrderItemSerialNumbers { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Item {\n");
            sb.Append("  OrderItemId: ").Append(OrderItemId).Append("\n");
            sb.Append("  OrderItemSerialNumbers: ").Append(OrderItemSerialNumbers).Append("\n");
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
