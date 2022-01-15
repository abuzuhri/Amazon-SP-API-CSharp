using System;
using System.Collections.Generic;
using System.Text;
using static FikaAmazonAPI.ReportGeneration.ReimbursementsOrderReport;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.ReportGeneration
{
    public class ReportManager
    {
        private IList<AmazonConnection> _amazonConnections { get; set; }
        public ReportManager(IList<AmazonConnection> amazonConnections)
        {
            _amazonConnections = amazonConnections;
        }

        #region feedback
        public List<FeedbackOrderRow> GetFeedbackFromDays(int days)
        {
            DateTime dateTime = DateTime.UtcNow.AddDays(-1 * days);
            return GetFeedbackFromDate(dateTime);
        }
        public List<FeedbackOrderRow> GetFeedbackFromDate(DateTime dateTime)
        {
            List<FeedbackOrderRow> list=new List<FeedbackOrderRow>();
            foreach (var connection in _amazonConnections)
            {
                var path = GetFeedbackFromDate(connection, dateTime);
                FeedbackOrderReport report = new FeedbackOrderReport(path, connection.RefNumber);
                list.AddRange(report.Data);
            }
            return list;
        }
        private string GetFeedbackFromDate(AmazonConnection amazonConnection, DateTime dateTime)
        {
            return amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_SELLER_FEEDBACK_DATA, dateTime);
        }
        #endregion

        #region Reimbursement

        public IList<ReimbursementsOrderRow> GetReimbursementsOrder(DateTime fromDate, DateTime toDate)
        {
            List<ReimbursementsOrderRow> list = new List<ReimbursementsOrderRow>();
            foreach (var connection in _amazonConnections)
            {
                var path = GetReimbursementsOrder(connection, fromDate, toDate);
                ReimbursementsOrderReport report = new ReimbursementsOrderReport(path, connection.RefNumber);
                list.AddRange(report.Data);
            }
            return list;
        }

        private string GetReimbursementsOrder(AmazonConnection amazonConnection, DateTime fromDate, DateTime toDate)
        {
            return amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_FBA_REIMBURSEMENTS_DATA, fromDate, toDate);
        }


        #endregion

        #region ReturnFBAOrder

        public List<ReturnFBAOrderRow> GetReturnFBAOrder(DateTime fromDate, DateTime toDate)
        {
            List<ReturnFBAOrderRow> list=new List<ReturnFBAOrderRow>();

            foreach (var connection in _amazonConnections)
            {
                var path = GetReturnFBAOrder(connection, fromDate, toDate);
                ReturnFBAOrderReport report = new ReturnFBAOrderReport(path, connection.RefNumber);
                list.AddRange(report.Data);
            }
            return list;
        }

        private string GetReturnFBAOrder(AmazonConnection amazonConnection, DateTime fromDate, DateTime toDate)
        {
            return amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_FBA_FULFILLMENT_CUSTOMER_RETURNS_DATA, fromDate, toDate);
        }


        #endregion

        #region ReturnFBMOrder

        public List<ReturnFBMOrderRow> GetReturnMFNOrder(DateTime fromDate, DateTime toDate)
        {
            List<ReturnFBMOrderRow> list=new List<ReturnFBMOrderRow>();
            foreach (var connection in _amazonConnections)
            {
                var path = GetReturnMFNOrder(connection, fromDate, toDate);

                ReturnFBMOrderReport report = new ReturnFBMOrderReport(path, connection.RefNumber);
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
            List<SettlementOrderRow> list=new List<SettlementOrderRow>();
            foreach (var connection in _amazonConnections)
            {
                var paths = GetSettlementOrder(connection, fromDate, toDate);
                foreach (var path in paths)
                {
                    SettlementOrderReport report = new SettlementOrderReport(path, connection.RefNumber);
                    list.AddRange(report.Data);
                }
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
            foreach (var connection in _amazonConnections)
            {
                var path = GetInventoryQty(connection);
                throw new Exception("Report not finished");
            }
        }
        private string GetInventoryQty(AmazonConnection amazonConnection)
        {
            return amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_AFN_INVENTORY_DATA);
        }
        #endregion

        #region GetInventoryAging
        public List<InventoryAgingRow> GetInventoryAging()
        {
            List<InventoryAgingRow> list=new List<InventoryAgingRow>();

            foreach (var connection in _amazonConnections)
            {
                var path = GetInventoryAging(connection);
                InventoryAgingReport report = new InventoryAgingReport(path, connection.RefNumber);
                list.AddRange(report.Data);
            }
            return list;
        }
        private string GetInventoryAging(AmazonConnection amazonConnection)
        {
            return amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_FBA_INVENTORY_AGED_DATA);
        }
        #endregion

        #region Products
        public List<ProductsRow> GetProducts()
        {
            List<ProductsRow> list=new List<ProductsRow>();
            foreach (var connection in _amazonConnections)
            {
                var path = GetProducts(connection);
                ProductsReport report = new ProductsReport(path, connection.RefNumber);
                list.AddRange(report.Data);
            }
            return list;
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
            foreach (var connection in _amazonConnections)
            {
                var path = GetOrdersByLastUpdate(connection, fromDate, toDate);
                OrdersReport report = new OrdersReport(path, connection.RefNumber);
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
            foreach (var connection in _amazonConnections)
            {
                var path = GetOrdersByOrderDate(connection, fromDate, toDate);
                OrdersReport report = new OrdersReport(path, connection.RefNumber);
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
