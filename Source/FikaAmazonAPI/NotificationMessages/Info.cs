using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.NotificationMessages
{
    public partial class Info
    {
        public long PackageNumber { get; set; }
        public string CarrierCode { get; set; }
        public string TrackingNumber { get; set; }
    }
}
