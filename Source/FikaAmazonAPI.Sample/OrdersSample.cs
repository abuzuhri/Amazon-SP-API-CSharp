using FikaAmazonAPI.Parameter.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Sample
{
    public class OrdersSample
    {
        AmazonConnection amazonConnection;
        public OrdersSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }

        public void GetOrders()
        {
            ParameterOrderList serachOrderList = new ParameterOrderList();
            serachOrderList.CreatedAfter = DateTime.UtcNow.AddMinutes(-600000);

            serachOrderList.OrderStatuses = new List<OrderStatuses>();
            serachOrderList.OrderStatuses.Add(OrderStatuses.Canceled);

            serachOrderList.AmazonOrderIds = new List<string>();
            serachOrderList.AmazonOrderIds.Add("403-1710607-6240347");
            serachOrderList.AmazonOrderIds.Add("403-5583945-7236361");
            serachOrderList.AmazonOrderIds.Add("403-3320829-4528316");
            serachOrderList.AmazonOrderIds.Add("406-2574982-2047546");

            var orders = amazonConnection.Orders.GetOrders(serachOrderList);
        }


        
        public void GetOrderBuyerInfo()
        {
            var BuyerInfo = amazonConnection.Orders.GetOrderBuyerInfo("402-0467973-4229120");
        }

        
        public void GetOrderAddress()
        {
            var Address = amazonConnection.Orders.GetOrderAddress("402-0467973-4229120");
        }

        
        public void GetOrderItems()
        {
            var Items = amazonConnection.Orders.GetOrderItems("402-0467973-4229120");
        }

        
        public void GetOrderItemsBuyerInfo()
        {
            var ItemsBuyerInfo = amazonConnection.Orders.GetOrderItemsBuyerInfo("402-0467973-4229120");
        }
    }
}
