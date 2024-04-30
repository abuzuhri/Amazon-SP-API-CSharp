using FikaAmazonAPI.ReportGeneration;

namespace FikaAmazonAPI.SampleCode
{
    internal class ReportManagerSample
    {

        AmazonConnection amazonConnection;
        public ReportManagerSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }

        public void CallReport()
        {
            ReportManager reportManager = new ReportManager(amazonConnection);
            var products = reportManager.GetProducts(); //GET_MERCHANT_LISTINGS_ALL_DATA
            var inventoryAging = reportManager.GetInventoryAging(); //GET_FBA_INVENTORY_AGED_DATA
            var ordersByDate = reportManager.GetOrdersByOrderDate(90); //GET_FLAT_FILE_ALL_ORDERS_DATA_BY_ORDER_DATE_GENERAL
            var ordersByLastUpdate = reportManager.GetOrdersByLastUpdate(90); //GET_FLAT_FILE_ALL_ORDERS_DATA_BY_LAST_UPDATE_GENERAL
            var settlementOrder = reportManager.GetSettlementOrder(90); //GET_V2_SETTLEMENT_REPORT_DATA_FLAT_FILE_V2
            var returnMFNOrder = reportManager.GetReturnMFNOrder(90); //GET_FLAT_FILE_RETURNS_DATA_BY_RETURN_DATE
            var returnFBAOrder = reportManager.GetReturnFBAOrder(50); //GET_FBA_FULFILLMENT_CUSTOMER_RETURNS_DATA
            var reimbursementsOrder = reportManager.GetReimbursementsOrder(1000); //GET_FBA_REIMBURSEMENTS_DATA
            var feedbacks = reportManager.GetFeedbackFromDays(180); //GET_SELLER_FEEDBACK_DATA
            var UnsuppressedInventory = reportManager.GetUnsuppressedInventoryDataAsync().ConfigureAwait(false).GetAwaiter().GetResult(); //GET_FBA_MYI_UNSUPPRESSED_INVENTORY_DATA
        }
    }
}
