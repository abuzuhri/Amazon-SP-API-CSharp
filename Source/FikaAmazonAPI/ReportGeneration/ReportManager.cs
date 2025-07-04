using FikaAmazonAPI.AmazonSpApiSDK.Models.Reports;
using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
            using var stream = await GetFeedbackFromDateAsync(_amazonConnection, fromDate, toDate);
            FeedbackOrderReport report = new FeedbackOrderReport(stream, _amazonConnection.RefNumber);
            return report.Data;
        }

        private async Task<MemoryStream> GetFeedbackFromDateAsync(AmazonConnection amazonConnection, DateTime fromDate,
            DateTime toDate)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileStreamAsync(ReportTypes.GET_SELLER_FEEDBACK_DATA,
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
            using var stream = await GetReimbursementsOrderAsync(_amazonConnection, fromDate, toDate);
            ReimbursementsOrderReport report = new ReimbursementsOrderReport(stream, _amazonConnection.RefNumber);
            return report.Data;
        }

        private async Task<MemoryStream> GetReimbursementsOrderAsync(AmazonConnection amazonConnection, DateTime fromDate,
            DateTime toDate)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileStreamAsync(
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
            using var stream = await GetReturnFBAOrderAsync(_amazonConnection, fromDate, toDate, marketplaces,
                cancellationToken);
            ReturnFBAOrderReport report = new ReturnFBAOrderReport(stream, _amazonConnection.RefNumber);

            return report.Data;
        }

        private async Task<MemoryStream> GetReturnFBAOrderAsync(AmazonConnection amazonConnection, DateTime fromDate,
            DateTime toDate, List<MarketPlace> marketplaces = null, CancellationToken cancellationToken = default)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileStreamAsync(
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
                using var stream = await GetReturnMFNOrderAsync(_amazonConnection, date.StartDate, date.EndDate);
                ReturnFBMOrderReport report = new ReturnFBMOrderReport(stream, _amazonConnection.RefNumber);
                list.AddRange(report.Data);
            }

            return list;
        }

        private async Task<MemoryStream> GetReturnMFNOrderAsync(AmazonConnection amazonConnection, DateTime fromDate,
            DateTime toDate)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileStreamAsync(
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

            var streams = await GetSettlementOrderAsync(_amazonConnection, fromDate, toDate);
            foreach (var stream in streams)
            {
                using var s = stream;
                SettlementOrderReport report = new SettlementOrderReport(s, _amazonConnection.RefNumber);
                list.AddRange(report.Data);
            }

            return list;
        }

        private async Task<IList<MemoryStream>> GetSettlementOrderAsync(AmazonConnection amazonConnection, DateTime fromDate,
            DateTime toDate)
        {
            return await amazonConnection.Reports.DownloadExistingReportAndDownloadFileStreamAsync(
                ReportTypes.GET_V2_SETTLEMENT_REPORT_DATA_FLAT_FILE_V2, fromDate, toDate);
        }

        #endregion


        #region GetUnsuppressedInventoryData

        public async Task<List<UnsuppressedInventoryDataRow>> GetUnsuppressedInventoryDataAsync()
        {
            using var stream = await GetUnsuppressedInventoryDatayAsync(_amazonConnection);
            var report = new UnsuppressedInventoryDataReport(stream, _amazonConnection.RefNumber);
            return report.Data;
        }

        private async Task<MemoryStream> GetUnsuppressedInventoryDatayAsync(AmazonConnection amazonConnection)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileStreamAsync(ReportTypes
                .GET_FBA_MYI_UNSUPPRESSED_INVENTORY_DATA);
        }

        #endregion

        #region GetInventoryQty

        public async Task<List<ProductAFNInventoryRow>> GetAFNInventoryQtyAsync()
        {
            using var stream = await GetAFNInventoryQtyAsync(_amazonConnection);
            ProductAFNInventoryReport report = new ProductAFNInventoryReport(stream, _amazonConnection.RefNumber);
            return report.Data;
        }

        private async Task<MemoryStream> GetAFNInventoryQtyAsync(AmazonConnection amazonConnection)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileStreamAsync(ReportTypes.GET_AFN_INVENTORY_DATA);
        }

        #endregion

        #region GetInventoryAging

        public List<InventoryAgingRow> GetInventoryAging() =>
            Task.Run(() => GetInventoryAgingAsync()).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<InventoryAgingRow>> GetInventoryAgingAsync()
        {
            using var stream = await GetInventoryAgingAsync(_amazonConnection);
            InventoryAgingReport report = new InventoryAgingReport(stream, _amazonConnection.RefNumber);
            return report.Data;
        }

        private async Task<MemoryStream> GetInventoryAgingAsync(AmazonConnection amazonConnection)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileStreamAsync(ReportTypes
                .GET_FBA_INVENTORY_AGED_DATA);
        }

        #endregion

        #region Products

        public List<ProductsRow> GetProducts(List<MarketPlace> marketplaces = null) =>
            Task.Run(() => GetProductsAsync(marketplaces)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<ProductsRow>> GetProductsAsync(List<MarketPlace> marketplaces = null,
            CancellationToken cancellationToken = default)
        {
            using var stream = await GetProductsAsync(_amazonConnection, marketplaces, cancellationToken);
            ProductsReport report = new ProductsReport(stream);
            return report.Data;
        }

        private Task<MemoryStream> GetProductsAsync(AmazonConnection amazonConnection, List<MarketPlace> marketplaces = null,
            CancellationToken cancellationToken = default)
        {
            return amazonConnection.Reports.CreateReportAndDownloadFileStreamAsync(ReportTypes.GET_MERCHANT_LISTINGS_ALL_DATA,
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
            using var stream = await GetCategoriesAsync(_amazonConnection, rootNodesOnly);
            CategoriesReport report = new CategoriesReport(stream, _amazonConnection.RefNumber);
            return report.Data.Node;
        }

        private async Task<MemoryStream> GetCategoriesAsync(AmazonConnection amazonConnection, bool rootNodesOnly)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileStreamAsync(ReportTypes.GET_XML_BROWSE_TREE_DATA,
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
                using var stream = await GetOrdersByLastUpdateAsync(_amazonConnection, range.StartDate, range.EndDate);
                OrdersReport report = new OrdersReport(stream, _amazonConnection.RefNumber);
                list.AddRange(report.Data);
            }

            return list;
        }

        private async Task<MemoryStream> GetOrdersByLastUpdateAsync(AmazonConnection amazonConnection, DateTime fromDate,
            DateTime toDate)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileStreamAsync(
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
                using var stream = await GetOrdersByOrderDateAsync(_amazonConnection, range.StartDate, range.EndDate);
                OrdersReport report = new OrdersReport(stream, _amazonConnection.RefNumber);
                list.AddRange(report.Data);
            }

            return list;
        }

        private async Task<MemoryStream> GetOrdersByOrderDateAsync(AmazonConnection amazonConnection, DateTime fromDate,
            DateTime toDate)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileStreamAsync(
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
                using var stream = await GetOrderInvoicingDataAsync(_amazonConnection, range.StartDate, range.EndDate,
                    marketplaces);
                OrderInvoicingReport report = new OrderInvoicingReport(stream, _amazonConnection.RefNumber);
                list.AddRange(report.Data);
            }

            return list;
        }

        private async Task<MemoryStream> GetOrderInvoicingDataAsync(AmazonConnection amazonConnection, DateTime fromDate,
            DateTime toDate, List<MarketPlace> marketplaces = null)
        {
            var options = new AmazonSpApiSDK.Models.Reports.ReportOptions();
            options.Add("ShowSalesChannel", "true");
            return await amazonConnection.Reports.CreateReportAndDownloadFileStreamAsync(
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

            using var stream = await GetLedgerDetailAsync(_amazonConnection, fromDate, toDate);
            LedgerDetailReport report = new LedgerDetailReport(stream, _amazonConnection.RefNumber);
            list.AddRange(report.Data);

            return list;
        }

        private async Task<MemoryStream> GetLedgerDetailAsync(AmazonConnection amazonConnection, DateTime fromDate,
            DateTime toDate)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileStreamAsync(
                ReportTypes.GET_LEDGER_DETAIL_VIEW_DATA, fromDate, toDate);
        }

        #endregion

        #region InventoryPlanningData

        public List<InventoryPlanningDataRow> GetInventoryPlanningData() =>
            Task.Run(() => GetInventoryPlanningDataAsync()).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<InventoryPlanningDataRow>> GetInventoryPlanningDataAsync()
        {
            using var stream = await GetInventoryPlanningDataAsync(_amazonConnection);
            InventoryPlanningDataReport report = new InventoryPlanningDataReport(stream, _amazonConnection.RefNumber);
            return report.Data;
        }

        private async Task<MemoryStream> GetInventoryPlanningDataAsync(AmazonConnection amazonConnection)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileStreamAsync(ReportTypes
                .GET_FBA_INVENTORY_PLANNING_DATA);
        }

        #endregion

        #region FbaEstimateFee

        public List<FbaEstimateFeeReportRow> GetFbaEstimateFeeData(DateTime fromDate, DateTime toDate) =>
            Task.Run(() => GetFbaEstimateFeeDataAsync(fromDate, toDate)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<FbaEstimateFeeReportRow>> GetFbaEstimateFeeDataAsync(DateTime fromDate, DateTime toDate)
        {
            List<FbaEstimateFeeReportRow> list = new List<FbaEstimateFeeReportRow>();

            using var stream = await GetFbaEstimateFeeDataAsync(_amazonConnection, fromDate, toDate);
            FbaEstimateFeeReport report = new FbaEstimateFeeReport(stream, _amazonConnection.RefNumber);
            list.AddRange(report.Data);

            return list;
        }

        private async Task<MemoryStream> GetFbaEstimateFeeDataAsync(AmazonConnection amazonConnection, DateTime fromDate,
            DateTime toDate)
        {
            return await amazonConnection.Reports.CreateReportAndDownloadFileStreamAsync(
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

            using var stream = await GetReferralFeeReportDataAsync(_amazonConnection, fromDate, toDate);
            ReferralFeeReport report = new ReferralFeeReport(stream, _amazonConnection.RefNumber);
            list.AddRange(report.Data);

            return list;
        }

        private async Task<MemoryStream> GetReferralFeeReportDataAsync(AmazonConnection amazonConnection, DateTime fromDate,
            DateTime toDate)
        {
            var reportPath =
                await amazonConnection.Reports.CreateReportAndDownloadFileStreamAsync(
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
                    return await amazonConnection.Reports.GetReportFileStreamByReportIdAsync(reportId, false);
                }
            }

            return reportPath;
        }

        #endregion
    }
}