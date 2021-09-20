using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShipmentInvoicing
{
    public partial class ShipmentInvoiceStatusInfo
    {
        public string AmazonShipmentId { get; set; }
        public ShipmentInvoiceStatus InvoiceStatus { get; set; }
    }
    public enum ShipmentInvoiceStatus
    {
        Processing,
        Accepted,
        Errored,
        NotFound
    }
}
