using System;

namespace FikaAmazonAPI.AmazonSpApiSDK.Services
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
        protected class FulFillmentOutboundApiUrls
        {
            private readonly static string _resourceBaseUrl = "/fba/outbound/2020-07-01";
            public static string GetFulfillmentPreview
            {
                get => $"{_resourceBaseUrl}/fulfillmentOrders/preview";
            }
            public static string ListAllFulfillmentOrders
            {
                get => $"{_resourceBaseUrl}/fulfillmentOrders";
            }
            public static string CreateFulfillmentOrder
            {
                get => $"{_resourceBaseUrl}/fulfillmentOrders";
            }
            public static string GetPackageTrackingDetails
            {
                get => $"{_resourceBaseUrl}/tracking";
            }
            public static string ListReturnReasonCodes
            {
                get => $"{_resourceBaseUrl}/returnReasonCodes";
            }
            public static string CreateFulfillmentReturn(string sellerFulfillmentOrderId) => $"{_resourceBaseUrl}/fulfillmentOrders/{sellerFulfillmentOrderId}/return";
            public static string GetFulfillmentOrder(string sellerFulfillmentOrderId) => $"{_resourceBaseUrl}/fulfillmentOrders/{sellerFulfillmentOrderId}";
            public static string UpdateFulfillmentOrder(string sellerFulfillmentOrderId) => $"{_resourceBaseUrl}/fulfillmentOrders/{sellerFulfillmentOrderId}";
            public static string CancelFulfillmentOrder(string sellerFulfillmentOrderId) => $"{_resourceBaseUrl}/fulfillmentOrders/{sellerFulfillmentOrderId}/cancel";
            public static string GetFeatures
            {
                get => $"{_resourceBaseUrl}/features";
            }
            public static string GetFeatureInventory(string featureName) => $"{_resourceBaseUrl}/features/inventory/{featureName}";
            public static string GetFeatureSKU(string featureName, string sellerSku) => $"{_resourceBaseUrl}/features/inventory/{featureName}/{sellerSku}";
        }
        protected class FulFillmentInboundApiUrls
        {
            private readonly static string _resourceBaseUrl = "/fba/inbound/v0";
            public static string GetInboundGuidance
            {
                get => $"{_resourceBaseUrl}/itemsGuidance";
            }
            public static string CreateInboundShipmentPlan
            {
                get => $"{_resourceBaseUrl}/plans";
            }
            public static string UpdateInboundShipment(string shipmentId) => $"{_resourceBaseUrl}/shipments/{shipmentId}";
            public static string CreateInboundShipment(string shipmentId) => $"{_resourceBaseUrl}/shipments/{shipmentId}";
            public static string GetPreorderInfo(string shipmentId) => $"{_resourceBaseUrl}/shipments/{shipmentId}/preorder";
            public static string ConfirmPreorder(string shipmentId) => $"{_resourceBaseUrl}/shipments/{shipmentId}/preorder/confirm";
            public static string GetPrepInstructions
            {
                get => $"{_resourceBaseUrl}/prepInstructions";
            }
            public static string GetTransportDetails(string shipmentId) => $"{_resourceBaseUrl}/shipments/{shipmentId}/transport";
            public static string PutTransportDetails(string shipmentId) => $"{_resourceBaseUrl}/shipments/{shipmentId}/transport";
            public static string VoidTransport(string shipmentId) => $"{_resourceBaseUrl}/shipments/{shipmentId}/transport/void";
            public static string EstimateTransport(string shipmentId) => $"{_resourceBaseUrl}/shipments/{shipmentId}/transport/estimate";
            public static string ConfirmTransport(string shipmentId) => $"{_resourceBaseUrl}/shipments/{shipmentId}/transport/confirm";
            public static string GetLabels(string shipmentId) => $"{_resourceBaseUrl}/shipments/{shipmentId}/labels";
            public static string GetBillOfLading(string shipmentId) => $"{_resourceBaseUrl}/shipments/{shipmentId}/billOfLading";
            public static string GetShipments
            {
                get => $"{_resourceBaseUrl}/shipments";
            }
            public static string GetShipmentItemsByShipmentId(string shipmentId) => $"{_resourceBaseUrl}/shipments/{shipmentId}/items";
            public static string GetShipmentItems
            {
                get => $"{_resourceBaseUrl}/shipmentItems";
            }

            #region V20240320

            public static string GetListInboundPlans
            {
                get => $"{_resourceBaseUrl}/inboundPlans";
            }
            public static string CreateInboundPlan
            {
                get => $"{_resourceBaseUrl}/inboundPlans";
            }

            public static string GetInboundPlan(string inboundPlanId) => $"{_resourceBaseUrl}/inboundPlans/{inboundPlanId}";
            public static string ListInboundPlanBoxes(string inboundPlanId) => $"{_resourceBaseUrl}/inboundPlans/{inboundPlanId}/boxes";
            public static string CancelInboundPlan(string inboundPlanId) => $"{_resourceBaseUrl}/inboundPlans/{inboundPlanId}/cancellation";
            public static string ListInboundPlanItems(string inboundPlanId) => $"{_resourceBaseUrl}/inboundPlans/{inboundPlanId}/items";
            public static string SetPackingInformation(string inboundPlanId) => $"{_resourceBaseUrl}/inboundPlans/{inboundPlanId}/packingInformation";
            public static string ListPackingOptions(string inboundPlanId) => $"{_resourceBaseUrl}/inboundPlans/{inboundPlanId}/packingOptions";
            public static string GeneratePackingOptions(string inboundPlanId) => $"{_resourceBaseUrl}/inboundPlans/{inboundPlanId}/packingOptions";
            public static string ConfirmPackingOption(string inboundPlanId, string packingOptionId) => $"{_resourceBaseUrl}/inboundPlans/{inboundPlanId}/packingOptions/{packingOptionId}/confirmation";
            public static string ListPackingGroupItems(string inboundPlanId, string packingOptionId, string packingGroupId) => $"{_resourceBaseUrl}/inboundPlans/{inboundPlanId}/packingOptions/{packingOptionId}/packingGroups/{packingGroupId}/items";
            public static string ListInboundPlanPallets(string inboundPlanId) => $"{_resourceBaseUrl}/inboundPlans/{inboundPlanId}/pallets";
            public static string ListPlacementOptions(string inboundPlanId) => $"{_resourceBaseUrl}/inboundPlans/{inboundPlanId}/placementOptions";
            public static string GeneratePlacementOptions(string inboundPlanId) => $"{_resourceBaseUrl}/inboundPlans/{inboundPlanId}/placementOptions";
            public static string ConfirmPlacementOption(string inboundPlanId, string placementOptionId) => $"{_resourceBaseUrl}/inboundPlans/{inboundPlanId}/placementOptions/{placementOptionId}/confirmation";
            public static string GetShipment(string inboundPlanId, string shipmentId) => $"{_resourceBaseUrl}/inboundPlans/{inboundPlanId}/shipments/{shipmentId}";
            public static string GetDeliveryChallanDocument(string inboundPlanId, string shipmentId) => $"{_resourceBaseUrl}/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/deliveryChallanDocument";
            public static string UpdateShipmentDeliveryWindow(string inboundPlanId, string shipmentId) => $"{_resourceBaseUrl}/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/deliveryWindow";
            public static string GetSelfShipAppointmentSlots(string inboundPlanId, string shipmentId) => $"{_resourceBaseUrl}/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/selfShipAppointmentSlots";
            public static string GenerateSelfShipAppointmentSlots(string inboundPlanId, string shipmentId) => $"{_resourceBaseUrl}/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/selfShipAppointmentSlots";
            public static string CancelSelfShipAppointment(string inboundPlanId, string shipmentId, string slotId) => $"{_resourceBaseUrl}/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/selfShipAppointmentSlots/{slotId}/cancellation";
            public static string ScheduleSelfShipAppointment(string inboundPlanId, string shipmentId, string slotId) => $"{_resourceBaseUrl}/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/selfShipAppointmentSlots/{slotId}/schedule";
            public static string UpdateShipmentTrackingDetails(string inboundPlanId, string shipmentId) => $"{_resourceBaseUrl}/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/trackingDetails";
            public static string ListTransportationOptions(string inboundPlanId) => $"{_resourceBaseUrl}/inboundPlans/{inboundPlanId}/transportationOptions";
            public static string GenerateTransportationOptions(string inboundPlanId) => $"{_resourceBaseUrl}/inboundPlans/{inboundPlanId}/transportationOptions";
            public static string ConfirmTransportationOptions(string inboundPlanId) => $"{_resourceBaseUrl}/inboundPlans/{inboundPlanId}/transportationOptions/confirmation";
            public static string ListItemComplianceDetails() => $"{_resourceBaseUrl}/items/compliance";
            public static string UpdateItemComplianceDetails() => $"{_resourceBaseUrl}/items/compliance";
            public static string GetInboundOperationStatus(string operationId) => $"{_resourceBaseUrl}/operations/{operationId}";


            #endregion


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
            public static string RetrieveShippingLabel(string shipmentId, string trackingId) => $"{_resourceBaseUrl}/shipments/{shipmentId}/containers/{trackingId}/label";
            public static string GetTrackingInformation(string trackingId) => $"{_resourceBaseUrl}/tracking/{trackingId}";
        }

        protected class ShippingApiV2Urls
        {
            private readonly static string _resourceBaseUrl = "/shipping/v2";
            public static string GetRates
            {
                get => $"{_resourceBaseUrl}/shipments/rates";
            }
            public static string PurchaseShipment
            {
                get => $"{_resourceBaseUrl}/shipments";
            }
            public static string GetTracking(string carrierId, string trackingId) => $"{_resourceBaseUrl}/tracking?carrierId={carrierId}&trackingId={trackingId}";
            public static string GetShipmentDocuments(string shipmentId, string packageClientReferenceId, string format) => $"{_resourceBaseUrl}/shipments/{shipmentId}/documents?packageClientReferenceId={packageClientReferenceId}&format={format}";
            public static string CancelShipment(string shipmentId) => $"{_resourceBaseUrl}/shipments/{shipmentId}/cancel";
        }
        protected class MessaginApiUrls
        {
            private readonly static string _resourceBaseUrl = "/messaging/v1";

            public static string GetMessagingActionsForOrder(string amazonOrderId) => $"{_resourceBaseUrl}/orders/{amazonOrderId}";
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
            public static string SendInvoice(string amazonOrderId) => $"{_resourceBaseUrl}/orders/{amazonOrderId}/messages/invoice";
        }
        protected class EasyShip20220323
        {
            private readonly static string _resourceBaseUrl = "/easyShip/2022-03-23";
            public static string ListHandoverSlots
            {
                get => $"{_resourceBaseUrl}/timeSlot";
            }
            public static string GetScheduledPackage
            {
                get => $"{_resourceBaseUrl}/package";
            }
            public static string CreateScheduledPackage
            {
                get => $"{_resourceBaseUrl}/package";
            }
            public static string UpdateScheduledPackages
            {
                get => $"{_resourceBaseUrl}/package";
            }
        }
        protected class FBASmallAndLightApiUrls
        {
            private readonly static string _resourceBaseUrl = "/fba/smallAndLight/v1";

            public static string GetSmallAndLightEnrollmentBySellerSKU(string sellerSKU) => $"{_resourceBaseUrl}/enrollments/{Uri.EscapeDataString(sellerSKU)}";
            public static string PutSmallAndLightEnrollmentBySellerSKU(string sellerSKU) => $"{_resourceBaseUrl}/enrollments/{Uri.EscapeDataString(sellerSKU)}";
            public static string DeleteSmallAndLightEnrollmentBySellerSKU(string sellerSKU) => $"{_resourceBaseUrl}/enrollments/{Uri.EscapeDataString(sellerSKU)}";
            public static string GetSmallAndLightEligibilityBySellerSKU(string sellerSKU) => $"{_resourceBaseUrl}/eligibilities/{Uri.EscapeDataString(sellerSKU)}";
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
        protected class RestrictionsApiUrls
        {
            private readonly static string _resourceBaseUrl = "/listings/2021-08-01";
            public static string GetListingsRestrictions
            {
                get => $"{_resourceBaseUrl}/restrictions";
            }
        }
        protected class AuthorizationsApiUrls
        {
            private readonly static string _resourceBaseUrl = "/authorization/v1";
            public static string GetAuthorizationCode
            {
                get => $"{_resourceBaseUrl}/authorizationCode";
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
        internal class ProductPricingApiUrls
        {
            private static readonly string _resourceBaseUrl = "/products/pricing/v0";
            public static string GetPricing
            {
                get => $"{_resourceBaseUrl}/price";
            }
            public static string GetCompetitivePricing
            {
                get => $"{_resourceBaseUrl}/competitivePrice";
            }

            public static string GetListingOffersBySellerSku(string SellerSKU) => $"{_resourceBaseUrl}/listings/{Uri.EscapeDataString(SellerSKU)}/offers";
            public static string GetItemOffers(string Asin) => $"{_resourceBaseUrl}/items/{Asin}/offers";
            public static string GetListingOffers(string sellerSKU) => $"{_resourceBaseUrl}/listings/{Uri.EscapeDataString(sellerSKU)}/offers";

            public static string GetBatchItemOffers => $"/batches{_resourceBaseUrl}/itemOffers";

            public static string GetBatchListingOffers => $"/batches{_resourceBaseUrl}/listingOffers";

            #region v2022-05-01
            private static readonly string _resourceBaseUrl_v20220501 = "/products/pricing/2022-05-01";
            public static string FeaturedOfferExpectedPriceUri => $"{_resourceBaseUrl_v20220501}/offer/featuredOfferExpectedPrice";
            public static string GetFeaturedOfferExpectedPriceBatch => $"/batches{FeaturedOfferExpectedPriceUri}";
            #endregion
        }
        protected class ProductTypeApiUrls
        {
            private readonly static string _resourceBaseUrl = "/definitions/2020-09-01";
            public static string SearchDefinitionsProductTypes
            {
                get => $"{_resourceBaseUrl}/productTypes";
            }

            public static string GetDefinitionsProductType(string productType) => $"{_resourceBaseUrl}/productTypes/{productType}";
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
        protected class VendorDirectFulfillmentOrdersApiUrls
        {
            private readonly static string _resourceBaseUrl = "/vendor/directFulfillment/orders/v1";
            public static string GetOrders
            {
                get => $"{_resourceBaseUrl}/purchaseOrders";
            }
            public static string SubmitAcknowledgement
            {
                get => $"{_resourceBaseUrl}/acknowledgements";
            }
            public static string GetOrder(string purchaseOrderNumber) => $"{_resourceBaseUrl}/purchaseOrders/{purchaseOrderNumber}";
        }
        protected class VendorOrdersApiUrls
        {
            private readonly static string _resourceBaseUrl = "/vendor/orders/v1";
            public static string GetPurchaseOrders
            {
                get => $"{_resourceBaseUrl}/purchaseOrders";
            }
            public static string GetPurchaseOrder(string purchaseOrderNumber) => $"{_resourceBaseUrl}/purchaseOrders/{purchaseOrderNumber}";
            public static string SubmitAcknowledgement
            {
                get => $"{_resourceBaseUrl}/acknowledgements";
            }
            public static string GetPurchaseOrdersStatus
            {
                get => $"{_resourceBaseUrl}/purchaseOrdersStatus";
            }
        }
        protected class VendorTransactionStatusApiUrls
		{
			private readonly static string _resourceBaseUrl = "/vendor/transactions/v1";
			public static string GetTransaction(string transactionId) => $"{_resourceBaseUrl}/transactions/{transactionId}";
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
                get => $"{_resourceBaseUrl}/financialEvents";
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
            public static string GetMyFeesEstimateForSKU(string SellerSKU) => $"{_resourceBaseUrl}/listings/{Uri.EscapeDataString(SellerSKU)}/feesEstimate";
            public static string GetMyFeesEstimateForASIN(string Asin) => $"{_resourceBaseUrl}/items/{Asin}/feesEstimate";

            public static string GetMyFeesEstimate => $"{_resourceBaseUrl}/feesEstimate";
        }
        protected class TokenApiUrls
        {
            private readonly static string _resourceBaseUrl = "/tokens/2021-03-01";
            public static string RestrictedDataToken
            {
                get => $"{_resourceBaseUrl}/restrictedDataToken";
            }
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
        public class OrdersApiUrls
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
            public static string UpdateShipmentStatus(string orderId) => $"{_resourceBaseUrl}/orders/{orderId}/shipment";
            public static string GetOrderRegulatedInfo(string orderId) => $"{_resourceBaseUrl}/orders/{orderId}/regulatedInfo";
            public static string UpdateVerificationStatus(string orderId) => $"{_resourceBaseUrl}/orders/{orderId}/regulatedInfo";
            public static string GetOrderItemsApprovals(string orderId) => $"{_resourceBaseUrl}/orders/{orderId}/approvals";
            public static string UpdateOrderItemsApprovals(string orderId) => $"{_resourceBaseUrl}/orders/{orderId}/approvals";
            public static string ConfirmShipment(string orderId) => $"{_resourceBaseUrl}/orders/{orderId}/shipmentConfirmation";
        }

        protected class CategoryApiUrls
        {
            private readonly static string _resourceBaseUrl = "/catalog/v0";

            private readonly static string _202012resourceBaseUrl = "/catalog/2020-12-01";

            private readonly static string _202204resourceBaseUrl = "/catalog/2022-04-01";


            public static string ListCatalogItems
            {
                get => $"{_resourceBaseUrl}/items";
            }
            public static string ListCatalogCategories
            {
                get => $"{_resourceBaseUrl}/categories";
            }
            public static string GetCatalogItem(string asin) => $"{_resourceBaseUrl}/items/{asin}";
            public static string GetCatalogItem202012(string asin) => $"{_202012resourceBaseUrl}/items/{asin}";

            public static string SearchCatalogItems => $"{_202012resourceBaseUrl}/items";

            public static string SearchCatalogItems202204 => $"{_202204resourceBaseUrl}/items";
            public static string GetCatalogItem202204(string asin) => $"{_202204resourceBaseUrl}/items/{asin}";
        }

        protected class ListingsItemsApiUrls
        {
            private readonly static string _resourceBaseUrl = "/listings/2021-08-01";

            //https://stackoverflow.com/questions/575440/url-encoding-using-c-sharp/21771206#21771206
            public static string GetListingItem(string seller, string sku) => $"{_resourceBaseUrl}/items/{seller}/{Uri.EscapeDataString(sku)}";

            public static string PutListingItem(string seller, string sku) => $"{_resourceBaseUrl}/items/{seller}/{Uri.EscapeDataString(sku)}";

            public static string DeleteListingItem(string seller, string sku) => $"{_resourceBaseUrl}/items/{seller}/{Uri.EscapeDataString(sku)}";

            public static string PatchListingItem(string seller, string sku) => $"{_resourceBaseUrl}/items/{seller}/{Uri.EscapeDataString(sku)}";
        }

        protected class ListingsRestrictionsApi
        {
            private readonly static string _resourceBaseUrl = "/listings/2021-08-01";
            public static string GetListingsRestrictions() => $"{_resourceBaseUrl}/restrictions";
        }

        protected class ProductTypeDefinitionsApi
        {
            private readonly static string _resourceBaseUrl = "/definitions/2020-09-01/productTypes";
            public static string GetDefinitionsProductType(string productType) => $"{_resourceBaseUrl}/{productType}";
            public static string SearchDefinitionsProductTypes => $"{_resourceBaseUrl}";
        }

    }




}
