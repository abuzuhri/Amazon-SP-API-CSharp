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

        public List<ReimbursementsOrderRow> ReimbursementsOrder { get; set; } = new List<ReimbursementsOrderRow>();
        public List<FeedbackOrderRow> FeedbackOrder { get; set; } = new List<FeedbackOrderRow>();
        public List<ReturnFBMOrderRow> ReturnFBMOrder { get; set; } = new List<ReturnFBMOrderRow>();
        public List<ReturnFBAOrderRow> ReturnFBAOrder { get; set; } = new List<ReturnFBAOrderRow>();
        public List<SettlementOrderRow> SettlementOrder { get; set; } = new List<SettlementOrderRow>();
        public List<ProductsRow> Products { get; set; } = new List<ProductsRow>();
        public List<InventoryAgingRow> InventoryAging { get; set; } = new List<InventoryAgingRow>();

        private void ConvertReport(string path, ReportTypes reportName, string refNumber)
        {
            if (reportName == ReportTypes.GET_FBA_REIMBURSEMENTS_DATA)
            {
                ReimbursementsOrderReport report = new ReimbursementsOrderReport(path, refNumber);
                ReimbursementsOrder.AddRange(report.Data);
            }
            else if (reportName == ReportTypes.GET_SELLER_FEEDBACK_DATA)
            {
                FeedbackOrderReport report = new FeedbackOrderReport(path, refNumber);
                FeedbackOrder.AddRange(report.Data);
            }
            else if (reportName == ReportTypes.GET_FLAT_FILE_RETURNS_DATA_BY_RETURN_DATE)
            {
                ReturnFBMOrderReport report = new ReturnFBMOrderReport(path, refNumber);
                ReturnFBMOrder.AddRange(report.Data);
            }
            else if (reportName == ReportTypes.GET_FBA_FULFILLMENT_CUSTOMER_RETURNS_DATA)
            {
                ReturnFBAOrderReport report = new ReturnFBAOrderReport(path, refNumber);
                ReturnFBAOrder.AddRange(report.Data);
            }
            else if (reportName == ReportTypes.GET_V2_SETTLEMENT_REPORT_DATA_FLAT_FILE_V2)
            {
                SettlementOrderReport report = new SettlementOrderReport(path, refNumber);
                SettlementOrder.AddRange(report.Data);
            }
            else if (reportName == ReportTypes.GET_MERCHANT_LISTINGS_ALL_DATA)
            {
                ProductsReport report = new ProductsReport(path, refNumber);
                Products.AddRange(report.Data);
            }
            else if (reportName == ReportTypes.GET_AFN_INVENTORY_DATA)
            {
                //ProductsReport report = new ProductsReport(path,refNumber);
                //ProductsReport.AddRange(report.Data);
            }
            else if (reportName == ReportTypes.GET_FBA_INVENTORY_AGED_DATA)
            {
                InventoryAgingReport report = new InventoryAgingReport(path, refNumber);
                InventoryAging.AddRange(report.Data);
            }
        }


        #region feedback
        public void GetFeedbackFromDays(int days)
        {
            DateTime dateTime = DateTime.UtcNow.AddDays(-1 * days);
            GetFeedbackFromDate(dateTime);
        }
        public void GetFeedbackFromDate(DateTime dateTime)
        {
            foreach (var connection in _amazonConnections)
            {
                var path = GetFeedbackFromDate(connection, dateTime);
                ConvertReport(path, ReportTypes.GET_SELLER_FEEDBACK_DATA, connection.RefNumber);
            }
        }
        public string GetFeedbackFromDate(AmazonConnection amazonConnection, DateTime dateTime)
        {
            return amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_SELLER_FEEDBACK_DATA, dateTime);
        }
        #endregion

        #region Reimbursement

        public void GetReimbursementsOrder(DateTime fromDate, DateTime toDate)
        {
            foreach (var connection in _amazonConnections)
            {
                var path = GetReimbursementsOrder(connection, fromDate, toDate);
                ConvertReport(path, ReportTypes.GET_FBA_REIMBURSEMENTS_DATA, connection.RefNumber);
            }
        }

        public string GetReimbursementsOrder(AmazonConnection amazonConnection, DateTime fromDate, DateTime toDate)
        {
            return amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_FBA_REIMBURSEMENTS_DATA, fromDate, toDate);
        }


        #endregion

        #region ReturnFBAOrder

        public void GetReturnFBAOrder(DateTime fromDate, DateTime toDate)
        {
            foreach (var connection in _amazonConnections)
            {
                var path = GetReturnFBAOrder(connection, fromDate, toDate);
                ConvertReport(path, ReportTypes.GET_FBA_FULFILLMENT_CUSTOMER_RETURNS_DATA, connection.RefNumber);
            }
        }

        public string GetReturnFBAOrder(AmazonConnection amazonConnection, DateTime fromDate, DateTime toDate)
        {
            return amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_FBA_FULFILLMENT_CUSTOMER_RETURNS_DATA, fromDate, toDate);
        }


        #endregion

        #region ReturnFBMOrder

        public void GetReturnMFNOrder(DateTime fromDate, DateTime toDate)
        {
            foreach (var connection in _amazonConnections)
            {
                var path = GetReturnMFNOrder(connection, fromDate, toDate);
                ConvertReport(path, ReportTypes.GET_FLAT_FILE_RETURNS_DATA_BY_RETURN_DATE, connection.RefNumber);
            }
        }
        public string GetReturnMFNOrder(AmazonConnection amazonConnection, DateTime fromDate, DateTime toDate)
        {
            return amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_FLAT_FILE_RETURNS_DATA_BY_RETURN_DATE, fromDate, toDate);
        }


        #endregion

        #region Settlement
        public void GetSettlementOrder(int days)
        {
            DateTime fromDate = DateTime.UtcNow.AddDays(-1 * days);
            DateTime toDate = DateTime.UtcNow;
            GetSettlementOrder(fromDate, toDate);
        }
        public void GetSettlementOrder(DateTime fromDate, DateTime toDate)
        {
            foreach (var connection in _amazonConnections)
            {
                var paths = GetSettlementOrder(connection, fromDate, toDate);
                foreach (var path in paths)
                {
                    ConvertReport(path, ReportTypes.GET_V2_SETTLEMENT_REPORT_DATA_FLAT_FILE_V2, connection.RefNumber);
                }
            }
        }
        public IList<string> GetSettlementOrder(AmazonConnection amazonConnection, DateTime fromDate, DateTime toDate)
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
                ConvertReport(path, ReportTypes.GET_AFN_INVENTORY_DATA, connection.RefNumber);
            }
        }
        public string GetInventoryQty(AmazonConnection amazonConnection)
        {
            return amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_AFN_INVENTORY_DATA);
        }
        #endregion

        #region GetInventoryAging
        public void GetInventoryAging()
        {
            foreach (var connection in _amazonConnections)
            {
                var path = GetInventoryAging(connection);
                ConvertReport(path, ReportTypes.GET_FBA_INVENTORY_AGED_DATA, connection.RefNumber);
            }
        }
        public string GetInventoryAging(AmazonConnection amazonConnection)
        {
            return amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_FBA_INVENTORY_AGED_DATA);
        }
        #endregion

        #region Products
        public void GetProducts()
        {
            foreach (var connection in _amazonConnections)
            {
                var path = GetProducts(connection);
                ConvertReport(path, ReportTypes.GET_MERCHANT_LISTINGS_ALL_DATA, connection.RefNumber);
            }
        }
        public string GetProducts(AmazonConnection amazonConnection)
        {
            return amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_MERCHANT_LISTINGS_ALL_DATA);
        }
        #endregion



    }


}
