using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.EasyShip20220323
{

    /// <summary>
    /// Invoice number and date.
    /// </summary>
    [DataContract]
    public class InvoiceData
    {
        /// <summary>
        /// The invoice number.
        /// </summary>
        /// <value>The invoice number.</value>
        [DataMember(Name = "invoiceNumber", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "invoiceNumber")]
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// The date that the invoice was generated.
        /// </summary>
        /// <value>The date that the invoice was generated.</value>
        [DataMember(Name = "invoiceDate", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "invoiceDate")]
        public DateTime? InvoiceDate { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InvoiceData {\n");
            sb.Append("  InvoiceNumber: ").Append(InvoiceNumber).Append("\n");
            sb.Append("  InvoiceDate: ").Append(InvoiceDate).Append("\n");
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
