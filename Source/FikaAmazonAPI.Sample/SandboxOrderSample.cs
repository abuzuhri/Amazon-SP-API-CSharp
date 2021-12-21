using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Sample
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
            var orders = amazonConnection.Orders.GetOrders
            (
                 new FikaAmazonAPI.Parameter.Order.ParameterOrderList()
                 {
                     TestCase = Constants.TestCase200
                 }
            );
        }
    }
}
