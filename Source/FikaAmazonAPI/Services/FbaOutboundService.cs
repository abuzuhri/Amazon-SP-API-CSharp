using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.Services
{
    public class FbaOutboundService : RequestService
    {
        public FbaOutboundService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }
    }
}
