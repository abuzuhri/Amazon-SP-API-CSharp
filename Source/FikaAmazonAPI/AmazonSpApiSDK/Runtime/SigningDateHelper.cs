using System;

namespace FikaAmazonAPI.AmazonSpApiSDK.Runtime
{
    public class SigningDateHelper : IDateHelper
    {
        public DateTime GetUtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
