using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FikaAmazonAPI;
using FikaAmazonAPI.Search.Order;
using FikaAmazonAPI.Search.Report;
using FikaAmazonAPI.Utils;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {


            AmazonConnection amazonConnection2 = new AmazonConnection(new AmazonCredential()
            {
                AccessKey = Environment.GetEnvironmentVariable("AccessKey"),
                SecretKey = Environment.GetEnvironmentVariable("SecretKey"),
                RoleArn = Environment.GetEnvironmentVariable("RoleArn"),
                ClientId = Environment.GetEnvironmentVariable("ClientId"),
                ClientSecret = Environment.GetEnvironmentVariable("ClientSecret"),
                RefreshToken = Environment.GetEnvironmentVariable("RefreshToken"),
                MarketPlace = MarketPlace.UnitedArabEmirates

            });

            #region OrderV0

            #region GetOrder Test
            //SerachOrderList serachOrderList = new SerachOrderList();
            //serachOrderList.CreatedAfter = DateTime.UtcNow.AddMinutes(-600000);

            //serachOrderList.OrderStatuses = new List<OrderStatuses>();
            //serachOrderList.OrderStatuses.Add(OrderStatuses.Canceled);

            //serachOrderList.AmazonOrderIds = new List<string>();
            //serachOrderList.AmazonOrderIds.Add("403-1710607-6240347");
            //serachOrderList.AmazonOrderIds.Add("403-5583945-7236361");
            //serachOrderList.AmazonOrderIds.Add("403-3320829-4528316");
            //serachOrderList.AmazonOrderIds.Add("406-2574982-2047546");


            //var orders=amazonConnection2.Orders.GetOrders(serachOrderList);
            #endregion

            //Order
            //var orders =amazonConnection2.Orders.GetOrder("403-1710607-6240347");

            //var BuyerInfo = amazonConnection2.Orders.GetOrderBuyerInfo("402-0467973-4229120");
            //var BuyerInfo = amazonConnection2.Orders.GetOrderAddress("402-0467973-4229120");
            //var BuyerInfo = amazonConnection2.Orders.GetOrderItems("402-0467973-4229120");
            //var BuyerInfo = amazonConnection2.Orders.GetOrderItemsBuyerInfo("402-0467973-4229120");


            #endregion

            var parameters = new ParameterReportList();
            parameters.pageSize = 100;
            parameters.ReportTypes = new List<ReportTypes>();
            parameters.ReportTypes.Add(ReportTypes.GET_FLAT_FILE_PENDING_ORDERS_DATA);
            parameters.marketplaceIds = new List<string>();
            parameters.marketplaceIds.Add(MarketPlace.UnitedArabEmirates.ID);

            amazonConnection2.Reports.GetReport(parameters);

            Console.ReadLine();
            
        }
    }
}
