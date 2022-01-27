using System;
using System.Collections.Generic;
using System.Text;
using static FikaAmazonAPI.ReportGeneration.ReimbursementsOrderReport;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.ReportGeneration
{
    public class ReportManager
    {
        private const int DAY_30 = 30;
        private const int DAY_60 = 60;
        private const int DAY_90 = 90;
        private AmazonConnection _amazonConnection { get; set; }
        public ReportManager(AmazonConnection amazonConnection)
        {
            _amazonConnection = amazonConnection;
        }

        #region feedback
        public List<FeedbackOrderRow> GetFeedbackFromDays(int days)
        {
            DateTime fromDate = DateTime.UtcNow.AddDays(-1 * days);
            DateTime toDate = DateTime.UtcNow;
            return GetFeedbackFromDate(fromDate,toDate);
        }
        public List<FeedbackOrderRow> GetFeedbackFromDate(DateTime fromDate, DateTime toDate)
        {
            var path = GetFeedbackFromDate(_amazonConnection, fromDate, toDate);
            FeedbackOrderReport report = new FeedbackOrderReport(path, _amazonConnection.RefNumber);
            return report.Data;
        }
        private string GetFeedbackFromDate(AmazonConnection amazonConnection, DateTime fromDate, DateTime toDate)
        {
            return amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_SELLER_FEEDBACK_DATA, fromDate);
        }

        #endregion

        #region Performance
        #endregion

        #region Reimbursement
        public IList<ReimbursementsOrderRow> GetReimbursementsOrder(int days)
        {
            DateTime fromDate = DateTime.UtcNow.AddDays(-1 * days);
            DateTime toDate = DateTime.UtcNow;
            return GetReimbursementsOrder(fromDate, toDate);
        }
        public IList<ReimbursementsOrderRow> GetReimbursementsOrder(DateTime fromDate, DateTime toDate)
        {
            var path = GetReimbursementsOrder(_amazonConnection, fromDate, toDate);
            ReimbursementsOrderReport report = new ReimbursementsOrderReport(path, _amazonConnection.RefNumber);
            return report.Data;
        }

        private string GetReimbursementsOrder(AmazonConnection amazonConnection, DateTime fromDate, DateTime toDate)
        {
            return amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_FBA_REIMBURSEMENTS_DATA, fromDate, toDate);
        }


        #endregion

        #region ReturnFBAOrder
        public List<ReturnFBAOrderRow> GetReturnFBAOrder(int days)
        {
            DateTime fromDate = DateTime.UtcNow.AddDays(-1 * days);
            DateTime toDate = DateTime.UtcNow;
            return GetReturnFBAOrder(fromDate, toDate);
        }
        public List<ReturnFBAOrderRow> GetReturnFBAOrder(DateTime fromDate, DateTime toDate)
        {
            var path = GetReturnFBAOrder(_amazonConnection, fromDate, toDate);
            ReturnFBAOrderReport report = new ReturnFBAOrderReport(path, _amazonConnection.RefNumber);
  
            return report.Data;
        }

        private string GetReturnFBAOrder(AmazonConnection amazonConnection, DateTime fromDate, DateTime toDate)
        {
            return amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_FBA_FULFILLMENT_CUSTOMER_RETURNS_DATA, fromDate, toDate);
        }


        #endregion

        #region ReturnFBMOrder
        public List<ReturnFBMOrderRow> GetReturnMFNOrder(int days)
        {
            DateTime fromDate = DateTime.UtcNow.AddDays(-1 * days);
            DateTime toDate = DateTime.UtcNow;
            return GetReturnMFNOrder(fromDate, toDate);
        }
        public List<ReturnFBMOrderRow> GetReturnMFNOrder(DateTime fromDate, DateTime toDate)
        {
            List<ReturnFBMOrderRow> list=new List<ReturnFBMOrderRow>();
            var dateList = ReportDateRange.GetDateRange(fromDate, toDate, DAY_60);
            foreach (var date in dateList)
            {
                var path = GetReturnMFNOrder(_amazonConnection, date.StartDate, date.EndDate);

                ReturnFBMOrderReport report = new ReturnFBMOrderReport(path, _amazonConnection.RefNumber);
                list.AddRange(report.Data);
            }
            return list;
        }
        public string GetReturnMFNOrder(AmazonConnection amazonConnection, DateTime fromDate, DateTime toDate)
        {
            return amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_FLAT_FILE_RETURNS_DATA_BY_RETURN_DATE, fromDate, toDate);
        }


        #endregion

        #region Settlement
        public List<SettlementOrderRow> GetSettlementOrder(int days)
        {
            DateTime fromDate = DateTime.UtcNow.AddDays(-1 * days);
            DateTime toDate = DateTime.UtcNow;
            return GetSettlementOrder(fromDate, toDate);
        }
        public List<SettlementOrderRow> GetSettlementOrder(DateTime fromDate, DateTime toDate)
        {
            List<SettlementOrderRow> list = new List<SettlementOrderRow>();
            var totalDays = (DateTime.UtcNow - fromDate).TotalDays;
            if (totalDays > 90)
                fromDate = DateTime.UtcNow.AddDays(-90);

            var paths = GetSettlementOrder(_amazonConnection, fromDate, toDate);
            foreach (var path in paths)
            {
                SettlementOrderReport report = new SettlementOrderReport(path, _amazonConnection.RefNumber);
                list.AddRange(report.Data);
            }

            return list;
        }
        private IList<string> GetSettlementOrder(AmazonConnection amazonConnection, DateTime fromDate, DateTime toDate)
        {
            return amazonConnection.Reports.DownloadExistingReportAndDownloadFile(ReportTypes.GET_V2_SETTLEMENT_REPORT_DATA_FLAT_FILE_V2, fromDate, toDate);
        }
        #endregion

        #region GetInventoryQty
        public void GetInventoryQty()
        {
            //var path = GetInventoryQty(_amazonConnections);
            throw new Exception("Report not finished");
        }
        private string GetInventoryQty(AmazonConnection amazonConnection)
        {
            return amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_AFN_INVENTORY_DATA);
        }
        #endregion

        #region GetInventoryAging
        public List<InventoryAgingRow> GetInventoryAging()
        {
            var path = GetInventoryAging(_amazonConnection);
            InventoryAgingReport report = new InventoryAgingReport(path, _amazonConnection.RefNumber);
            return report.Data;
        }
        private string GetInventoryAging(AmazonConnection amazonConnection)
        {
            return amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_FBA_INVENTORY_AGED_DATA);
        }
        #endregion

        #region Products
        public List<ProductsRow> GetProducts()
        {
            var path = GetProducts(_amazonConnection);
            ProductsReport report = new ProductsReport(path, _amazonConnection.RefNumber);
            return report.Data;
        }
        private string GetProducts(AmazonConnection amazonConnection)
        {
            return amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_MERCHANT_LISTINGS_ALL_DATA);
        }
        #endregion

        #region Orders
        public List<OrdersRow> GetOrdersByLastUpdate(int days)
        {
            DateTime fromDate = DateTime.UtcNow.AddDays(-1 * days);
            DateTime toDate = DateTime.UtcNow;
            return GetOrdersByLastUpdate(fromDate, toDate);
        }
        public List<OrdersRow> GetOrdersByLastUpdate(DateTime fromDate, DateTime toDate)
        {
            List<OrdersRow> list = new List<OrdersRow>();
            var dateList = ReportDateRange.GetDateRange(fromDate, toDate, DAY_30);
            foreach (var range in dateList)
            {
                var path = GetOrdersByLastUpdate(_amazonConnection, range.StartDate, range.EndDate);
                OrdersReport report = new OrdersReport(path, _amazonConnection.RefNumber);
                list.AddRange(report.Data);
            }
            return list;
        }
        private string GetOrdersByLastUpdate(AmazonConnection amazonConnection, DateTime fromDate, DateTime toDate)
        {
            return amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_FLAT_FILE_ALL_ORDERS_DATA_BY_LAST_UPDATE_GENERAL, fromDate, toDate);
        }

        public List<OrdersRow> GetOrdersByOrderDate(int days)
        {
            DateTime fromDate = DateTime.UtcNow.AddDays(-1 * days);
            DateTime toDate = DateTime.UtcNow;
            return GetOrdersByOrderDate(fromDate,toDate);
        }
        public List<OrdersRow> GetOrdersByOrderDate(DateTime fromDate, DateTime toDate)
        {
            List<OrdersRow> list = new List<OrdersRow>();
            var dateList=ReportDateRange.GetDateRange(fromDate, toDate,DAY_30);
            foreach (var range in dateList)
            {
                var path = GetOrdersByOrderDate(_amazonConnection, range.StartDate, range.EndDate);
                OrdersReport report = new OrdersReport(path, _amazonConnection.RefNumber);
                list.AddRange(report.Data);
            }
            return list;
        }
        private string GetOrdersByOrderDate(AmazonConnection amazonConnection, DateTime fromDate, DateTime toDate)
        {
            return amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_FLAT_FILE_ALL_ORDERS_DATA_BY_ORDER_DATE_GENERAL, fromDate, toDate);
        }
        #endregion




    }


}
