using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikaAmazonAPI.SampleCode
{
    public class SandboxOrderSample
    {
        AmazonConnection amazonConnection;
        public SandboxOrderSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }

        public void GetOrderTestCase200()
        {
            /* 
             var orders = amazonConnection.Orders.GetOrder
            (
                 new FikaAmazonAPI.Parameter.Order.ParameterGetOrder
                 {
                     TestCase = Constants.TestCase200
                 }
            );
            */
        }
    }
}
