using System;

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
        protected class FBAInboundEligibiltyApiUrls
        {
            private readonly static string _resourceBaseUrl = "/fba/inbound/v1";
            public static string GetItemEligibilityPreview
            {
                get => $"{_resourceBaseUrl}/eligibility/itemPreview";
            }
        }
        protected class ShippingApiUrls
        {
            private readonly static string _resourceBaseUrl = "/shipping/v1";
            public static string CreateShipment
            {
                get => $"{_resourceBaseUrl}/shipments";
            }
            public static string PurchaseShipment
            {
                get => $"{_resourceBaseUrl}/purchaseShipment";
            }
            public static string GetRates
            {
                get => $"{_resourceBaseUrl}/rates";
            }
            public static string GetAccount
            {
                get => $"{_resourceBaseUrl}/account";
            }
            public static string GetShipment(string shipmentId) => $"{_resourceBaseUrl}/shipments/{shipmentId}";
            public static string CancelShipment(string shipmentId) => $"{_resourceBaseUrl}/shipments/{shipmentId}/cancel";
            public static string PurchaseLabels(string shipmentId) => $"{_resourceBaseUrl}/shipments/{shipmentId}/purchaseLabels";
            public static string RetrieveShippingLabel(string shipmentId,string trackingId) => $"{_resourceBaseUrl}/shipments/{shipmentId}/containers/{trackingId}/label";
            public static string GetTrackingInformation(string trackingId) => $"{_resourceBaseUrl}/tracking/{trackingId}";
        }
        protected class MessaginApiUrls
        {
            private readonly static string _resourceBaseUrl = "/messaging/v1";

            public static string GetMessagingActionsForOrder(string amazonOrderId, string marketplaceIds) => $"{_resourceBaseUrl}/orders/{amazonOrderId}?marketplaceIds={marketplaceIds}";
            public static string ConfirmCustomizationDetails(string amazonOrderId) => $"{_resourceBaseUrl}/orders/{amazonOrderId}/messages/confirmCustomizationDetails";
            public static string CreateConfirmDeliveryDetails(string amazonOrderId) => $"{_resourceBaseUrl}/orders/{amazonOrderId}/messages/confirmDeliveryDetails";
            public static string CreateLegalDisclosure(string amazonOrderId) => $"{_resourceBaseUrl}/orders/{amazonOrderId}/messages/legalDisclosure";
            public static string CreateNegativeFeedbackRemoval(string amazonOrderId) => $"{_resourceBaseUrl}/orders/{amazonOrderId}/messages/negativeFeedbackRemoval";
            public static string CreateConfirmOrderDetails(string amazonOrderId) => $"{_resourceBaseUrl}/orders/{amazonOrderId}/messages/confirmOrderDetails";
            public static string CreateConfirmServiceDetails(string amazonOrderId) => $"{_resourceBaseUrl}/orders/{amazonOrderId}/messages/confirmServiceDetails";
            public static string CreateAmazonMotors(string amazonOrderId) => $"{_resourceBaseUrl}/orders/{amazonOrderId}/messages/amazonMotors";
            public static string CreateWarranty(string amazonOrderId) => $"{_resourceBaseUrl}/orders/{amazonOrderId}/messages/warranty";
            public static string GetAttributes(string amazonOrderId) => $"{_resourceBaseUrl}/orders/{amazonOrderId}/attributes";
            public static string CreateDigitalAccessKey(string amazonOrderId) => $"{_resourceBaseUrl}/orders/{amazonOrderId}/messages/digitalAccessKey";
            public static string CreateUnexpectedProblem(string amazonOrderId) => $"{_resourceBaseUrl}/orders/{amazonOrderId}/messages/unexpectedProblem";
        }
        protected class FBASmallAndLightApiUrls
        {
            private readonly static string _resourceBaseUrl = "/fba/smallAndLight/v1";

            public static string GetSmallAndLightEnrollmentBySellerSKU(string sellerSKU) => $"{_resourceBaseUrl}/enrollments/{sellerSKU}";
            public static string PutSmallAndLightEnrollmentBySellerSKU(string sellerSKU) => $"{_resourceBaseUrl}/enrollments/{sellerSKU}";
            public static string DeleteSmallAndLightEnrollmentBySellerSKU(string sellerSKU) => $"{_resourceBaseUrl}/enrollments/{sellerSKU}";
            public static string GetSmallAndLightEligibilityBySellerSKU(string sellerSKU) => $"{_resourceBaseUrl}/eligibilities/{sellerSKU}";
            public static string GetSmallAndLightFeePreview
            {
                get => $"{_resourceBaseUrl}/feePreviews";
            }
        }
        protected class MerchantFulfillmentApiUrls
        {
            private readonly static string _resourceBaseUrl = "/mfn/v0";
            
            public static string GetEligibleShipmentServicesOld
            {
                get => $"{_resourceBaseUrl}/eligibleServices";
            }
            public static string GetEligibleShipmentServices
            {
                get => $"{_resourceBaseUrl}/eligibleShippingServices";
            }
            public static string CreateShipment
            {
                get => $"{_resourceBaseUrl}/shipments";
            }
            public static string GetAdditionalSellerInputsOld
            {
                get => $"{_resourceBaseUrl}/sellerInputs";
            }
            public static string GetAdditionalSellerInputs
            {
                get => $"{_resourceBaseUrl}/additionalSellerInputs";
            }
            public static string GetShipment(string shipmentId) => $"{_resourceBaseUrl}/shipments/{shipmentId}";
            public static string CancelShipment(string shipmentId) => $"{_resourceBaseUrl}/shipments/{shipmentId}";
            public static string CancelShipmentOld(string shipmentId) => $"{_resourceBaseUrl}/shipments/{shipmentId}/cancel";
        }
        protected class NotificationApiUrls
        {
            private readonly static string _resourceBaseUrl = "/notifications/v1";
            public static string GetSubscription(string notificationType) => $"{_resourceBaseUrl}/subscriptions/{notificationType}";
            public static string CreateSubscription(string notificationType) => $"{_resourceBaseUrl}/subscriptions/{notificationType}";
            public static string GetSubscriptionById(string notificationType, string subscriptionId) => $"{_resourceBaseUrl}/subscriptions/{notificationType}/{subscriptionId}";
            public static string DeleteSubscriptionById(string notificationType, string subscriptionId) => $"{_resourceBaseUrl}/subscriptions/{notificationType}/{subscriptionId}";

            public static string GetDestinations
            {
                get => $"{_resourceBaseUrl}/destinations";
            }
            public static string CreateDestination
            {
                get => $"{_resourceBaseUrl}/destinations";
            }
            public static string GetDestination(string destinationId) => $"{_resourceBaseUrl}/destinations/{destinationId}";
            public static string DeleteDestination(string destinationId) => $"{_resourceBaseUrl}/destinations/{destinationId}";
        }

        protected class SalesApiUrls
        {
            private readonly static string _resourceBaseUrl = "/sales/v1";
            public static string GetOrderMetrics
            {
                get => $"{_resourceBaseUrl}/orderMetrics";
            }
        }
        protected class SellersApiUrls
        {
            private readonly static string _resourceBaseUrl = "/sellers/v1";
            public static string GetMarketplaceParticipations
            {
                get => $"{_resourceBaseUrl}/marketplaceParticipations";
            }
        }
        protected class ProductPricingApiUrls
        {
            private readonly static string _resourceBaseUrl = "/products/pricing/v0";
            public static string GetPricing
            {
                get => $"{_resourceBaseUrl}/price";
            }
            public static string GetCompetitivePricing
            {
                get => $"{_resourceBaseUrl}/competitivePrice";
            }

            public static string GetListingOffers(string SellerSKU) => $"{_resourceBaseUrl}/listings/{SellerSKU}/offers";
            public static string GetItemOffers(string Asin) => $"{_resourceBaseUrl}/items/{Asin}/offers";

        }

        protected class ReportApiUrls
        {
            private readonly static string _resourceBaseUrl = "/reports/2021-06-30";
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
            public static string GetReportDocument(string reportDocumentId) => $"{_resourceBaseUrl}/documents/{reportDocumentId}";

        }
        protected class UploadApiUrls
        {
            private readonly static string _resourceBaseUrl = "/uploads/2020-11-01";
            public static string CreateUploadDestinationForResource(string resource) => $"{_resourceBaseUrl}/uploadDestinations/{resource}";
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
        protected class FinanceApiUrls
        {
            private readonly static string _resourceBaseUrl = "/finances/v0";
            public static string ListFinancialEventGroups
            {
                get => $"{_resourceBaseUrl}/financialEventGroups";
            }
            public static string ListFinancialEventsByGroupId(string eventGroupId) => $"{_resourceBaseUrl}/financialEventGroups/{eventGroupId}/financialEvents";
            public static string ListFinancialEventsByOrderId(string orderId) => $"{_resourceBaseUrl}/orders/{orderId}/financialEvents";
            public static string ListFinancialEvents
            {
                get => $"{_resourceBaseUrl}/listFinancialEvents";
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
        protected class ShipmentInvoicingApiUrls
        {
            private readonly static string _resourceBaseUrl = "/fba/outbound/brazil/v0";
            public static string GetShipmentDetails(string shipmentId) => $"{_resourceBaseUrl}/shipments/{shipmentId}";
            public static string SubmitInvoice(string shipmentId) => $"{_resourceBaseUrl}/shipments/{shipmentId}/invoice";
            public static string GetInvoiceStatus(string shipmentId) => $"{_resourceBaseUrl}/shipments/{shipmentId}/invoice/status";
        }
        protected class ProductFeeApiUrls
        {
            private readonly static string _resourceBaseUrl = "/products/fees/v0";
            public static string GetMyFeesEstimateForSKU(string SellerSKU) => $"{_resourceBaseUrl}/listings/{SellerSKU}/feesEstimate";
            public static string GetMyFeesEstimateForASIN(string Asin) => $"{_resourceBaseUrl}/items/{Asin}/feesEstimate";
        }
        protected class SolicitationsApiUrls
        {
            private readonly static string _resourceBaseUrl = "/solicitations/v1";
            public static string GetSolicitationActionsForOrder(string amazonOrderId) => $"{_resourceBaseUrl}/orders/{amazonOrderId}";
            public static string CreateProductReviewAndSellerFeedbackSolicitation(string amazonOrderId) => $"{_resourceBaseUrl}/orders/{amazonOrderId}/solicitations/productReviewAndSellerFeedback";
        }
        protected class FeedsApiUrls
        {
            private readonly static string _resourceBaseUrl = "/feeds/2021-06-30";
            public static string GetFeeds
            {
                get => $"{_resourceBaseUrl}/feeds";
            }
            public static string CreateFeed
            {
                get => $"{_resourceBaseUrl}/feeds";
            }
            public static string CreateFeedDocument
            {
                get => $"{_resourceBaseUrl}/documents";
            }
            public static string GetFeedDocument(string feedDocumentId) => $"{_resourceBaseUrl}/documents/{feedDocumentId}";
            public static string GetFeed(string feedId) => $"{_resourceBaseUrl}/feeds/{feedId}";
            public static string CancelFeed(string feedId) => $"{_resourceBaseUrl}/feeds/{feedId}";
        }
        protected class FbaInventoriesApiUrls
        {
            private readonly static string _resourceBaseUrl = "/fba/inventory/v1";
            public static string GetInventorySummaries
            {
                get => $"{_resourceBaseUrl}/summaries";
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
            public static string ListCatalogItems
            {
                get => $"{_resourceBaseUrl}/items";
            }
            public static string ListCatalogCategories
            {
                get => $"{_resourceBaseUrl}/categories";
            }
            public static string GetCatalogItem(string asin) => $"{_resourceBaseUrl}/items/{asin}";
        }
    }




}
