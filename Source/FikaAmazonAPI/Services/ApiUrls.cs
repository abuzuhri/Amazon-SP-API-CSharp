namespace AmazonSpApiSDK.Services
{

    public static class EnvironemntManager
    {
        public static Environments Environemnt { get; set; } = Environments.Production;
        public enum Environments
        {
            Sandbox, Production
        }
    }

    public class ApiUrls
    {

        protected class OAuthUrls
        {
            public static string TokenUrl
            {
                get => $"identity/v1/oauth2/token";
            }
            public static string RefreshTokenUrl
            {
                get => $"identity/v1/oauth2/token";
            }
        }

        protected class TaxonomyApiUrls
        {
            private readonly static string _resourceBaseUrl = "/commerce/taxonomy/v1_beta";
            public static string getDefaultCategoryTreeIdUrl
            {
                get => $"{_resourceBaseUrl}/get_default_category_tree_id";
            }
            public static string CategoryTreeUrl
            {
                get => $"{_resourceBaseUrl}/category_tree";
            }
            public static string GetItemAspectsForCategory
            {
                get => $"/get_item_aspects_for_category";
            }
        }
        protected class ReportApiUrls
        {
            private readonly static string _resourceBaseUrl = "/reports/2020-09-04";
            public static string CreateReport
            {
                get => $"{_resourceBaseUrl}/reports";
            }
            public static string GetReports
            {
                get => $"{_resourceBaseUrl}/reports";
            }
            public static string GetReport(string reportId) => $"{_resourceBaseUrl}/reports/{reportId}";
            public static string CancelReport(string reportId) => $"{_resourceBaseUrl}/reports/{reportId}";
            public static string GetReportSchedules
            {
                get => $"{_resourceBaseUrl}/schedules";
            }
            public static string CreateReportSchedule
            {
                get => $"{_resourceBaseUrl}/schedules";
            }
            public static string GetReportSchedule(string reportScheduleId) => $"{_resourceBaseUrl}/schedules/{reportScheduleId}";
            public static string CancelReportSchedule(string reportScheduleId) => $"{_resourceBaseUrl}/schedules/{reportScheduleId}";
            public static string GetReportDocument(string reportDocumentId) => $"{_resourceBaseUrl}/schedules/{reportDocumentId}";

        }
        protected class InventoryApiUrls
        {
            private readonly static string _resourceBaseUrl = "/sell/inventory/v1";
            public static string bulkCreateOrReplaceInventoryItemUrl
            {
                get => $"{_resourceBaseUrl}/bulk_create_or_replace_inventory_item";
            }
            public static string InventoryItemUrl
            {
                get => $"{_resourceBaseUrl}/inventory_item";
            }
            public static string InventoryItemGroupUrl
            {
                get => $"{_resourceBaseUrl}/inventory_item_group";
            }
            public static string Offer
            {
                get => $"{_resourceBaseUrl}/offer";
            }
            public static string BulkCreateOffer
            {
                get => $"{_resourceBaseUrl}/bulk_create_offer";
            }
            public static string BulkPublishOffer
            {
                get => $"{_resourceBaseUrl}/bulk_publish_offer";
            }
            public static string PublishByInventoryItemGroup
            {
                get => $"{_resourceBaseUrl}/publish_by_inventory_item_group";
            }
            public static string WithdrawByInventoryItemGroup
            {
                get => $"{_resourceBaseUrl}/withdraw_by_inventory_item_group";
            }
            public static string Location
            {
                get => $"{_resourceBaseUrl}/location";
            }
        }

        protected class AccountApiUrls
        {
            private readonly static string _resourceBaseUrl = "/sell/account/v1";
            public static string returnPolicy
            {
                get => $"{_resourceBaseUrl}/return_policy";
            }
            public static string FulfillmentPolicy
            {
                get => $"{_resourceBaseUrl}/fulfillment_policy";
            }
            public static string PayementPolicy
            {
                get => $"{_resourceBaseUrl}/payment_policy";
            }
            public static string Privilege
            {
                get => $"{_resourceBaseUrl}/privilege";
            }
        }

        protected class OrdersApiUrls
        {
            private readonly static string _resourceBaseUrl = "/orders/v0";
            public static string Orders
            {
                get => $"{_resourceBaseUrl}/orders";
            }
            public static string Order(string orderId) => $"{_resourceBaseUrl}/orders/{orderId}";
            public static string OrderItems(string orderId) => $"{_resourceBaseUrl}/orders/{orderId}/orderItems";
            public static string OrderBuyerInfo(string orderId) => $"{_resourceBaseUrl}/orders/{orderId}/buyerInfo";
            public static string OrderItemsBuyerInfo(string orderId) => $"{_resourceBaseUrl}/orders/{orderId}/orderItems/buyerInfo";
            public static string OrderShipmentInfo(string orderId) => $"{_resourceBaseUrl}/orders/{orderId}/address";
        }

        protected class CategoryApiUrls
        {
            private readonly static string _resourceBaseUrl = "/catalog/v0";
            public static string Items
            {
                get => $"{_resourceBaseUrl}/items";
            }
        }
    }




}
