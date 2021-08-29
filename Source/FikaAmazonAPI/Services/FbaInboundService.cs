using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.Services
{
    public class FbaInboundService : RequestService
    {
        public FbaInboundService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }
    }
}
