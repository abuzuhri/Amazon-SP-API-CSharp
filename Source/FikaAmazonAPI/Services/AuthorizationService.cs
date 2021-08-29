using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.Services
{
    public class AuthorizationService : RequestService
    {
        public AuthorizationService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }
    }
}
