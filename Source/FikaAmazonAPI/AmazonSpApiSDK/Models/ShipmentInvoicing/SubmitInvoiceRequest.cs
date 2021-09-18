using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonSpApiSDK.Models.ShipmentInvoicing
{
    public class SubmitInvoiceRequest
    {
        public string MarketplaceId { get; set; }
        public string ContentMD5Value { get; set; }
        public byte[] InvoiceContent { get; set; }
    }
}
