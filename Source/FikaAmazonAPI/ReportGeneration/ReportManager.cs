using FikaAmazonAPI.AmazonSpApiSDK.Models.Reports;
using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

        public List<FeedbackOrderRow> GetFeedbackFromDays(int days) =>
            Task.Run(() => GetFeedbackFromDaysAsync(days)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<FeedbackOrderRow>> GetFeedbackFromDaysAsync(int days)
        {
            DateTime fromDate = DateTime.UtcNow.AddDays(-1 * days);
            DateTime toDate = DateTime.UtcNow;
            return await GetFeedbackFromDateAsync(fromDate, toDate);
        }

        public async Task<List<FeedbackOrderRow>> GetFeedbackFromDateAsync(DateTime fromDate, DateTime toDate)
        {
            var path = await GetFeedbackFromDateAsync(_amazonConnection, fromDate, toDate);
            FeedbackOrderReport report = new FeedbackOrderReport(path, _amazonConnection.RefNumber);
            return report.Data;
        }

        private async Task<string> GetFeedbackFromDateAsync(AmazonConnection amazonConnection, DateTime fromDate,
            DateTime toDate)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileAsync(ReportTypes.GET_SELLER_FEEDBACK_DATA,
                fromDate);
        }

        #endregion

        #region Performance

        #endregion

        #region Reimbursement

        public IList<ReimbursementsOrderRow> GetReimbursementsOrder(int days) =>
            Task.Run(() => GetReimbursementsOrderAsync(days)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<IList<ReimbursementsOrderRow>> GetReimbursementsOrderAsync(int days)
        {
            DateTime fromDate = DateTime.UtcNow.AddDays(-1 * days);
            DateTime toDate = DateTime.UtcNow;
            return await GetReimbursementsOrderAsync(fromDate, toDate);
        }

        public IList<ReimbursementsOrderRow> GetReimbursementsOrder(DateTime fromDate, DateTime toDate) =>
            Task.Run(() => GetReimbursementsOrderAsync(fromDate, toDate)).ConfigureAwait(false).GetAwaiter()
                .GetResult();

        public async Task<IList<ReimbursementsOrderRow>> GetReimbursementsOrderAsync(DateTime fromDate, DateTime toDate)
        {
            var path = await GetReimbursementsOrderAsync(_amazonConnection, fromDate, toDate);
            ReimbursementsOrderReport report = new ReimbursementsOrderReport(path, _amazonConnection.RefNumber);
            return report.Data;
        }

        private async Task<string> GetReimbursementsOrderAsync(AmazonConnection amazonConnection, DateTime fromDate,
            DateTime toDate)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileAsync(
                ReportTypes.GET_FBA_REIMBURSEMENTS_DATA, fromDate, toDate);
        }

        #endregion

        #region ReturnFBAOrder

        public List<ReturnFBAOrderRow> GetReturnFBAOrder(int days, List<MarketPlace> marketplaces = null) =>
            Task.Run(() => GetReturnFBAOrderAsync(days, marketplaces)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<ReturnFBAOrderRow>> GetReturnFBAOrderAsync(int days,
            List<MarketPlace> marketplaces = null, CancellationToken cancellationToken = default)
        {
            DateTime fromDate = DateTime.UtcNow.AddDays(-1 * days);
            DateTime toDate = DateTime.UtcNow;
            return await GetReturnFBAOrderAsync(fromDate, toDate, marketplaces, cancellationToken);
        }

        public List<ReturnFBAOrderRow> GetReturnFBAOrder(DateTime fromDate, DateTime toDate,
            List<MarketPlace> marketplaces = null) =>
            Task.Run(() => GetReturnFBAOrderAsync(fromDate, toDate, marketplaces)).ConfigureAwait(false).GetAwaiter()
                .GetResult();

        public async Task<List<ReturnFBAOrderRow>> GetReturnFBAOrderAsync(DateTime fromDate, DateTime toDate,
            List<MarketPlace> marketplaces = null, CancellationToken cancellationToken = default)
        {
            var path = await GetReturnFBAOrderAsync(_amazonConnection, fromDate, toDate, marketplaces,
                cancellationToken);
            ReturnFBAOrderReport report = new ReturnFBAOrderReport(path, _amazonConnection.RefNumber);

            return report.Data;
        }

        private async Task<string> GetReturnFBAOrderAsync(AmazonConnection amazonConnection, DateTime fromDate,
            DateTime toDate, List<MarketPlace> marketplaces = null, CancellationToken cancellationToken = default)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileAsync(
                ReportTypes.GET_FBA_FULFILLMENT_CUSTOMER_RETURNS_DATA, fromDate, toDate, marketplaces: marketplaces,
                cancellationToken: cancellationToken);
        }

        #endregion

        #region ReturnFBMOrder

        public List<ReturnFBMOrderRow> GetReturnMFNOrder(int days) =>
            Task.Run(() => GetReturnMFNOrderAsync(days)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<ReturnFBMOrderRow>> GetReturnMFNOrderAsync(int days)
        {
            DateTime fromDate = DateTime.UtcNow.AddDays(-1 * days);
            DateTime toDate = DateTime.UtcNow;
            return await GetReturnMFNOrderAsync(fromDate, toDate);
        }

        public List<ReturnFBMOrderRow> GetReturnMFNOrder(DateTime fromDate, DateTime toDate) =>
            Task.Run(() => GetReturnMFNOrderAsync(fromDate, toDate)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<ReturnFBMOrderRow>> GetReturnMFNOrderAsync(DateTime fromDate, DateTime toDate)
        {
            List<ReturnFBMOrderRow> list = new List<ReturnFBMOrderRow>();
            var dateList = ReportDateRange.GetDateRange(fromDate, toDate, DAY_60);
            foreach (var date in dateList)
            {
                var path = await GetReturnMFNOrderAsync(_amazonConnection, date.StartDate, date.EndDate);

                ReturnFBMOrderReport report = new ReturnFBMOrderReport(path, _amazonConnection.RefNumber);
                list.AddRange(report.Data);
            }

            return list;
        }

        private async Task<string> GetReturnMFNOrderAsync(AmazonConnection amazonConnection, DateTime fromDate,
            DateTime toDate)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileAsync(
                ReportTypes.GET_FLAT_FILE_RETURNS_DATA_BY_RETURN_DATE, fromDate, toDate);
        }

        #endregion

        #region Settlement

        public List<SettlementOrderRow> GetSettlementOrder(int days) =>
            Task.Run(() => GetSettlementOrderAsync(days)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<SettlementOrderRow>> GetSettlementOrderAsync(int days)
        {
            DateTime fromDate = DateTime.UtcNow.AddDays(-1 * days);
            DateTime toDate = DateTime.UtcNow;
            return await GetSettlementOrderAsync(fromDate, toDate);
        }

        public async Task<List<SettlementOrderRow>> GetSettlementOrderAsync(DateTime fromDate, DateTime toDate)
        {
            List<SettlementOrderRow> list = new List<SettlementOrderRow>();
            var totalDays = (DateTime.UtcNow - fromDate).TotalDays;
            if (totalDays > 90)
                fromDate = DateTime.UtcNow.AddDays(-90);

            var paths = await GetSettlementOrderAsync(_amazonConnection, fromDate, toDate);
            foreach (var path in paths)
            {
                SettlementOrderReport report = new SettlementOrderReport(path, _amazonConnection.RefNumber);
                list.AddRange(report.Data);
            }

            return list;
        }

        private async Task<IList<string>> GetSettlementOrderAsync(AmazonConnection amazonConnection, DateTime fromDate,
            DateTime toDate)
        {
            return await amazonConnection.Reports.DownloadExistingReportAndDownloadFileAsync(
                ReportTypes.GET_V2_SETTLEMENT_REPORT_DATA_FLAT_FILE_V2, fromDate, toDate);
        }

        #endregion


        #region GetUnsuppressedInventoryData

        public async Task<List<UnsuppressedInventoryDataRow>> GetUnsuppressedInventoryDataAsync()
        {
            var path = await GetUnsuppressedInventoryDatayAsync(_amazonConnection);
            var report = new UnsuppressedInventoryDataReport(path, _amazonConnection.RefNumber);
            return report.Data;
        }

        private async Task<string> GetUnsuppressedInventoryDatayAsync(AmazonConnection amazonConnection)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileAsync(ReportTypes
                .GET_FBA_MYI_UNSUPPRESSED_INVENTORY_DATA);
        }

        #endregion

        #region GetInventoryQty

        public async Task<List<ProductAFNInventoryRow>> GetAFNInventoryQtyAsync()
        {
            var path = await GetAFNInventoryQtyAsync(_amazonConnection);
            ProductAFNInventoryReport report = new ProductAFNInventoryReport(path, _amazonConnection.RefNumber);
            return report.Data;
        }

        private async Task<string> GetAFNInventoryQtyAsync(AmazonConnection amazonConnection)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileAsync(ReportTypes.GET_AFN_INVENTORY_DATA);
        }

        #endregion

        #region GetInventoryAging

        public List<InventoryAgingRow> GetInventoryAging() =>
            Task.Run(() => GetInventoryAgingAsync()).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<InventoryAgingRow>> GetInventoryAgingAsync()
        {
            var path = await GetInventoryAgingAsync(_amazonConnection);
            InventoryAgingReport report = new InventoryAgingReport(path, _amazonConnection.RefNumber);
            return report.Data;
        }

        private async Task<string> GetInventoryAgingAsync(AmazonConnection amazonConnection)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileAsync(ReportTypes
                .GET_FBA_INVENTORY_AGED_DATA);
        }

        #endregion

        #region Products

        public List<ProductsRow> GetProducts(List<MarketPlace> marketplaces = null) =>
            Task.Run(() => GetProductsAsync(marketplaces)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<ProductsRow>> GetProductsAsync(List<MarketPlace> marketplaces = null,
            CancellationToken cancellationToken = default)
        {
            var path = await GetProductsAsync(_amazonConnection, marketplaces, cancellationToken);
            ProductsReport report = new ProductsReport(path);
            return report.Data;
        }

        private Task<string> GetProductsAsync(AmazonConnection amazonConnection, List<MarketPlace> marketplaces = null,
            CancellationToken cancellationToken = default)
        {
            return amazonConnection.Reports.CreateReportAndDownloadFileAsync(ReportTypes.GET_MERCHANT_LISTINGS_ALL_DATA,
                marketplaces: marketplaces, cancellationToken: cancellationToken);
        }

        #endregion

        #region Categories

        public List<CategoriesRow> GetCategories()
        {
            return Task.Run(() => GetCategoriesAsync()).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public async Task<List<CategoriesRow>> GetCategoriesAsync(bool rootNodesOnly = false)
        {
            var path = await GetCategoriesAsync(_amazonConnection, rootNodesOnly);
            CategoriesReport report = new CategoriesReport(path, _amazonConnection.RefNumber);
            return report.Data.Node;
        }

        private async Task<string> GetCategoriesAsync(AmazonConnection amazonConnection, bool rootNodesOnly)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileAsync(ReportTypes.GET_XML_BROWSE_TREE_DATA,
                reportOptions: new ReportOptions
                {
                    { "RootNodesOnly", rootNodesOnly.ToString() }
                });
        }

        #endregion

        #region Orders

        public List<OrdersRow> GetOrdersByLastUpdate(int days) =>
            Task.Run(() => GetOrdersByLastUpdateAsync(days)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<OrdersRow>> GetOrdersByLastUpdateAsync(int days)
        {
            DateTime fromDate = DateTime.UtcNow.AddDays(-1 * days);
            DateTime toDate = DateTime.UtcNow;
            return await GetOrdersByLastUpdateAsync(fromDate, toDate);
        }

        public async Task<List<OrdersRow>> GetOrdersByLastUpdateAsync(DateTime fromDate, DateTime toDate)
        {
            List<OrdersRow> list = new List<OrdersRow>();
            var dateList = ReportDateRange.GetDateRange(fromDate, toDate, DAY_30);
            foreach (var range in dateList)
            {
                var path = await GetOrdersByLastUpdateAsync(_amazonConnection, range.StartDate, range.EndDate);
                OrdersReport report = new OrdersReport(path, _amazonConnection.RefNumber);
                list.AddRange(report.Data);
            }

            return list;
        }

        private async Task<string> GetOrdersByLastUpdateAsync(AmazonConnection amazonConnection, DateTime fromDate,
            DateTime toDate)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileAsync(
                ReportTypes.GET_FLAT_FILE_ALL_ORDERS_DATA_BY_LAST_UPDATE_GENERAL, fromDate, toDate);
        }

        public List<OrdersRow> GetOrdersByOrderDate(int days) =>
            Task.Run(() => GetOrdersByOrderDateAsync(days)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<OrdersRow>> GetOrdersByOrderDateAsync(int days)
        {
            DateTime fromDate = DateTime.UtcNow.AddDays(-1 * days);
            DateTime toDate = DateTime.UtcNow;
            return await GetOrdersByOrderDateAsync(fromDate, toDate);
        }

        public List<OrdersRow> GetOrdersByOrderDate(DateTime fromDate, DateTime toDate) =>
            Task.Run(() => GetOrdersByOrderDateAsync(fromDate, toDate)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<OrdersRow>> GetOrdersByOrderDateAsync(DateTime fromDate, DateTime toDate)
        {
            List<OrdersRow> list = new List<OrdersRow>();
            var dateList = ReportDateRange.GetDateRange(fromDate, toDate, DAY_30);
            foreach (var range in dateList)
            {
                var path = await GetOrdersByOrderDateAsync(_amazonConnection, range.StartDate, range.EndDate);
                OrdersReport report = new OrdersReport(path, _amazonConnection.RefNumber);
                list.AddRange(report.Data);
            }

            return list;
        }

        private async Task<string> GetOrdersByOrderDateAsync(AmazonConnection amazonConnection, DateTime fromDate,
            DateTime toDate)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileAsync(
                ReportTypes.GET_FLAT_FILE_ALL_ORDERS_DATA_BY_ORDER_DATE_GENERAL, fromDate, toDate);
        }

        public List<OrderInvoicingReportRow> GetOrderInvoicingData(DateTime fromDate, DateTime toDate,
            List<MarketPlace> marketplaces = null) =>
            Task.Run(() => GetOrderInvoicingDataAsync(fromDate, toDate, marketplaces)).ConfigureAwait(false)
                .GetAwaiter().GetResult();

        public async Task<List<OrderInvoicingReportRow>> GetOrderInvoicingDataAsync(DateTime fromDate, DateTime toDate,
            List<MarketPlace> marketplaces = null)
        {
            List<OrderInvoicingReportRow> list = new List<OrderInvoicingReportRow>();
            var dateList = ReportDateRange.GetDateRange(fromDate, toDate, DAY_30);
            foreach (var range in dateList)
            {
                var path = await GetOrderInvoicingDataAsync(_amazonConnection, range.StartDate, range.EndDate,
                    marketplaces);
                OrderInvoicingReport report = new OrderInvoicingReport(path, _amazonConnection.RefNumber);
                list.AddRange(report.Data);
            }

            return list;
        }

        private async Task<string> GetOrderInvoicingDataAsync(AmazonConnection amazonConnection, DateTime fromDate,
            DateTime toDate, List<MarketPlace> marketplaces = null)
        {
            var options = new AmazonSpApiSDK.Models.Reports.ReportOptions();
            options.Add("ShowSalesChannel", "true");
            return await amazonConnection.Reports.CreateReportAndDownloadFileAsync(
                ReportTypes.GET_FLAT_FILE_ORDER_REPORT_DATA_INVOICING, fromDate, toDate, options, false, marketplaces);
        }

        #endregion

        #region Settlement

        public List<LedgerDetailReportRow> GetLedgerDetail(int days) =>
            Task.Run(() => GetLedgerDetailAsync(days)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<LedgerDetailReportRow>> GetLedgerDetailAsync(int days)
        {
            DateTime fromDate = DateTime.UtcNow.AddDays(-1 * days);
            DateTime toDate = DateTime.UtcNow;
            return await GetLedgerDetailAsync(fromDate, toDate);
        }

        public async Task<List<LedgerDetailReportRow>> GetLedgerDetailAsync(DateTime fromDate, DateTime toDate)
        {
            List<LedgerDetailReportRow> list = new List<LedgerDetailReportRow>();
            var totalDays = (DateTime.UtcNow - fromDate).TotalDays;
            if (totalDays > 90)
                fromDate = DateTime.UtcNow.AddDays(-90);

            var path = await GetLedgerDetailAsync(_amazonConnection, fromDate, toDate);
            LedgerDetailReport report = new LedgerDetailReport(path, _amazonConnection.RefNumber);
            list.AddRange(report.Data);

            return list;
        }

        private async Task<string> GetLedgerDetailAsync(AmazonConnection amazonConnection, DateTime fromDate,
            DateTime toDate)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileAsync(
                ReportTypes.GET_LEDGER_DETAIL_VIEW_DATA, fromDate, toDate);
        }

        #endregion

        #region InventoryPlanningData

        public List<InventoryPlanningDataRow> GetInventoryPlanningData() =>
            Task.Run(() => GetInventoryPlanningDataAsync()).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<InventoryPlanningDataRow>> GetInventoryPlanningDataAsync()
        {
            var path = await GetInventoryPlanningDataAsync(_amazonConnection);
            InventoryPlanningDataReport report = new InventoryPlanningDataReport(path, _amazonConnection.RefNumber);
            return report.Data;
        }

        private async Task<string> GetInventoryPlanningDataAsync(AmazonConnection amazonConnection)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileAsync(ReportTypes
                .GET_FBA_INVENTORY_PLANNING_DATA);
        }

        #endregion

        #region FbaEstimateFee

        public List<FbaEstimateFeeReportRow> GetFbaEstimateFeeData(DateTime fromDate, DateTime toDate) =>
            Task.Run(() => GetFbaEstimateFeeDataAsync(fromDate, toDate)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<FbaEstimateFeeReportRow>> GetFbaEstimateFeeDataAsync(DateTime fromDate, DateTime toDate)
        {
            List<FbaEstimateFeeReportRow> list = new List<FbaEstimateFeeReportRow>();

            var path = await GetFbaEstimateFeeDataAsync(_amazonConnection, fromDate, toDate);
            FbaEstimateFeeReport report = new FbaEstimateFeeReport(path, _amazonConnection.RefNumber);
            list.AddRange(report.Data);

            return list;
        }

        private async Task<string> GetFbaEstimateFeeDataAsync(AmazonConnection amazonConnection, DateTime fromDate,
            DateTime toDate)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileAsync(
                ReportTypes.GET_FBA_ESTIMATED_FBA_FEES_TXT_DATA, fromDate, toDate);
        }

        #endregion


        #region GetReferralFee

        public List<ReferralFeeReportRow> GetReferralFeeReportData(DateTime fromDate, DateTime toDate) =>
            Task.Run(() => GetReferralFeeReportDataAsync(fromDate, toDate)).ConfigureAwait(false).GetAwaiter()
                .GetResult();

        public async Task<List<ReferralFeeReportRow>> GetReferralFeeReportDataAsync(DateTime fromDate, DateTime toDate)
        {
            List<ReferralFeeReportRow> list = new List<ReferralFeeReportRow>();

            var path = await GetReferralFeeReportDataAsync(_amazonConnection, fromDate, toDate);
            ReferralFeeReport report = new ReferralFeeReport(path, _amazonConnection.RefNumber);
            list.AddRange(report.Data);

            return list;
        }

        private async Task<string> GetReferralFeeReportDataAsync(AmazonConnection amazonConnection, DateTime fromDate,
            DateTime toDate)
        {
            var reportPath =
                await amazonConnection.Reports.CreateReportAndDownloadFileAsync(
                    ReportTypes.GET_REFERRAL_FEE_PREVIEW_REPORT, fromDate, toDate);
            if (reportPath == null)
            {
                var getOldReports = amazonConnection.Reports.GetReports(new Parameter.Report.ParameterReportList()
                {
                    reportTypes = new ReportTypes[] { ReportTypes.GET_REFERRAL_FEE_PREVIEW_REPORT },
                    processingStatuses = new List<ProcessingStatuses> { ProcessingStatuses.DONE }
                });

                if (getOldReports != null && getOldReports.Count > 0)
                {
                    var reportId = getOldReports.FirstOrDefault().ReportId;
                    return await amazonConnection.Reports.GetReportFileByReportIdAsync(reportId, false);
                }
            }

            return reportPath;
        }

        #endregion
    }
}