using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace FikaAmazonAPI.ReportGeneration
{
    /// <summary>
    /// Represents a Seller Performance report from Amazon Selling Partner API
    /// </summary>
    public class SellerPerformanceReport
    {
        /// <summary>
        /// Represents the collection of account status objects
        /// for each marketplace identified in the Seller Performance report.
        /// </summary>
        public List<AccountStatus> AccountStatuses { get; set; }

        /// <summary>
        /// Collection of marketplace-specific performance data
        /// </summary>
        public List<SellerPerformanceMetrics> Metrics { get; set; } = new List<SellerPerformanceMetrics>();

        /// <summary>
        /// Creates a new instance of SellerPerformanceReport from a JSON file
        /// </summary>
        /// <param name="jsonFilePath">Path to the JSON file</param>
        /// <param name="refNumber">Reference number for the report</param>
        public SellerPerformanceReport(string jsonFilePath, string refNumber)
        {
            if (string.IsNullOrEmpty(jsonFilePath))
                return;

            Parse(File.ReadAllText(jsonFilePath), refNumber);
        }

        /// <summary>
        /// Creates a new instance of SellerPerformanceReport from a stream
        /// </summary>
        /// <param name="stream">Stream containing the JSON report data</param>
        /// <param name="refNumber">Reference number for the report</param>
        public SellerPerformanceReport(Stream stream, string refNumber)
        {
            if (stream == null)
                return;

            using (var reader = new StreamReader(stream))
            {
                Parse(reader.ReadToEnd(), refNumber);
            }
        }

        private void Parse(string jsonContent, string refNumber)
        {
            var performanceData = JsonConvert.DeserializeObject<SellerPerformanceData>(jsonContent);

            if (performanceData?.AccountStatuses != null)
            {
                AccountStatuses = performanceData.AccountStatuses;
            }

            if (performanceData?.PerformanceMetrics != null)
            {
                foreach (var metric in performanceData.PerformanceMetrics)
                {
                    Metrics.Add(new SellerPerformanceMetrics
                    {
                        MarketplaceId = metric.MarketplaceId,
                        RefNumber = refNumber,
                        SnapshotDate = DateTime.UtcNow,

                        // Account Health Rating
                        AccountHealthStatus = metric.AccountHealthRating?.AhrStatus,
                        AccountHealthScore = metric.AccountHealthRating?.AhrScore,

                        // Order Defect Rate - AFN (FBA)
                        OrderDefectRateAFN = metric.OrderDefectRate?.Afn?.Rate,
                        OrderDefectRateTargetAFN = metric.OrderDefectRate?.Afn?.TargetValue,
                        OrderCountAFN = metric.OrderDefectRate?.Afn?.OrderCount,
                        OrdersWithDefectsCountAFN = metric.OrderDefectRate?.Afn?.OrderWithDefects?.Count,
                        ClaimsCountAFN = metric.OrderDefectRate?.Afn?.Claims?.Count,
                        ChargebackCountAFN = metric.OrderDefectRate?.Afn?.Chargebacks?.Count,
                        NegativeFeedbackCountAFN = metric.OrderDefectRate?.Afn?.NegativeFeedback?.Count,

                        // Order Defect Rate - MFN (FBM)
                        OrderDefectRateMFN = metric.OrderDefectRate?.Mfn?.Rate,
                        OrderDefectRateTargetMFN = metric.OrderDefectRate?.Mfn?.TargetValue,
                        OrderCountMFN = metric.OrderDefectRate?.Mfn?.OrderCount,
                        OrdersWithDefectsCountMFN = metric.OrderDefectRate?.Mfn?.OrderWithDefects?.Count,
                        ClaimsCountMFN = metric.OrderDefectRate?.Mfn?.Claims?.Count,
                        ChargebackCountMFN = metric.OrderDefectRate?.Mfn?.Chargebacks?.Count,
                        NegativeFeedbackCountMFN = metric.OrderDefectRate?.Mfn?.NegativeFeedback?.Count,

                        // Late Shipment Rate
                        LateShipmentRate = metric.LateShipmentRate?.Rate,
                        LateShipmentRateTarget = metric.LateShipmentRate?.TargetValue,
                        LateShipmentCount = metric.LateShipmentRate?.LateShipmentCount,

                        // Pre-fulfillment Cancellation Rate
                        PreFulfillmentCancelRate = metric.PreFulfillmentCancellationRate?.Rate,
                        PreFulfillmentCancelRateTarget = metric.PreFulfillmentCancellationRate?.TargetValue,
                        PreFulfillmentCanceledOrderCount = metric.PreFulfillmentCancellationRate?.CancellationCount,

                        // Valid Tracking Rate
                        ValidTrackingRate = metric.ValidTrackingRate?.Rate,
                        ValidTrackingRateTarget = metric.ValidTrackingRate?.TargetValue,

                        // On-Time Delivery Rate
                        OnTimeDeliveryRate = metric.OnTimeDeliveryRate?.Rate,
                        OnTimeDeliveryRateTarget = metric.OnTimeDeliveryRate?.TargetValue,

                        // Invoice Defect Rate
                        InvoiceDefectRate = metric.InvoiceDefectRate?.Rate,
                        InvoiceDefectRateTarget = metric.InvoiceDefectRate?.TargetValue,

                        // Policy Violations
                        ListingPolicyViolationsCount = metric.ListingPolicyViolations?.DefectsCount,
                        ProductAuthenticityComplaintsCount = metric.ProductAuthenticityCustomerComplaints?.DefectsCount,
                        ProductConditionComplaintsCount = metric.ProductConditionCustomerComplaints?.DefectsCount,
                        ProductSafetyComplaintsCount = metric.ProductSafetyCustomerComplaints?.DefectsCount,
                        IntellectualPropertyComplaintsCount = metric.ReceivedIntellectualPropertyComplaints?.DefectsCount,
                        SuspectedIPViolationsCount = metric.SuspectedIntellectualPropertyViolations?.DefectsCount,
                        PolicyViolationWarningsCount = metric.PolicyViolationWarnings?.WarningsCount
                    });
                }
            }
        }
    }

    /// <summary>
    /// Represents a row of data in the Seller Performance report
    /// </summary>
    public class SellerPerformanceMetrics
    {
        /// <summary>
        /// Amazon Marketplace ID
        /// </summary>
        public string MarketplaceId { get; set; }
        
        /// <summary>
        /// Date of the report
        /// </summary>
        public DateTime? SnapshotDate { get; set; }
        
        /// <summary>
        /// Account health status (GREAT, GOOD, FAIR, AT_RISK)
        /// </summary>
        public string AccountHealthStatus { get; set; }
        
        /// <summary>
        /// Account health score
        /// </summary>
        public decimal? AccountHealthScore { get; set; }
        
        #region Order Defect Rate - AFN (FBA)
        
        /// <summary>
        /// Order defect rate percentage for AFN (FBA) orders
        /// </summary>
        public decimal? OrderDefectRateAFN { get; set; }
        
        /// <summary>
        /// Target order defect rate percentage for AFN (FBA) orders
        /// </summary>
        public decimal? OrderDefectRateTargetAFN { get; set; }
        
        /// <summary>
        /// Total AFN (FBA) order count
        /// </summary>
        public int? OrderCountAFN { get; set; }
        
        /// <summary>
        /// Number of AFN (FBA) orders with defects
        /// </summary>
        public int? OrdersWithDefectsCountAFN { get; set; }
        
        /// <summary>
        /// Number of claims for AFN (FBA) orders
        /// </summary>
        public int? ClaimsCountAFN { get; set; }
        
        /// <summary>
        /// Number of chargebacks for AFN (FBA) orders
        /// </summary>
        public int? ChargebackCountAFN { get; set; }
        
        /// <summary>
        /// Number of negative feedback for AFN (FBA) orders
        /// </summary>
        public int? NegativeFeedbackCountAFN { get; set; }
        
        #endregion
        
        #region Order Defect Rate - MFN (FBM)
        
        /// <summary>
        /// Order defect rate percentage for MFN (FBM) orders
        /// </summary>
        public decimal? OrderDefectRateMFN { get; set; }
        
        /// <summary>
        /// Target order defect rate percentage for MFN (FBM) orders
        /// </summary>
        public decimal? OrderDefectRateTargetMFN { get; set; }
        
        /// <summary>
        /// Total MFN (FBM) order count
        /// </summary>
        public int? OrderCountMFN { get; set; }
        
        /// <summary>
        /// Number of MFN (FBM) orders with defects
        /// </summary>
        public int? OrdersWithDefectsCountMFN { get; set; }
        
        /// <summary>
        /// Number of claims for MFN (FBM) orders
        /// </summary>
        public int? ClaimsCountMFN { get; set; }
        
        /// <summary>
        /// Number of chargebacks for MFN (FBM) orders
        /// </summary>
        public int? ChargebackCountMFN { get; set; }
        
        /// <summary>
        /// Number of negative feedback for MFN (FBM) orders
        /// </summary>
        public int? NegativeFeedbackCountMFN { get; set; }
        
        #endregion
        
        #region Late Shipment Rate
        
        /// <summary>
        /// Late shipment rate percentage
        /// </summary>
        public decimal? LateShipmentRate { get; set; }
        
        /// <summary>
        /// Target late shipment rate percentage
        /// </summary>
        public decimal? LateShipmentRateTarget { get; set; }
        
        /// <summary>
        /// Number of late shipments
        /// </summary>
        public int? LateShipmentCount { get; set; }
        
        #endregion
        
        #region Pre-fulfillment Cancellation Rate
        
        /// <summary>
        /// Pre-fulfillment cancel rate percentage
        /// </summary>
        public decimal? PreFulfillmentCancelRate { get; set; }
        
        /// <summary>
        /// Target pre-fulfillment cancel rate percentage
        /// </summary>
        public decimal? PreFulfillmentCancelRateTarget { get; set; }
        
        /// <summary>
        /// Number of orders canceled before fulfillment
        /// </summary>
        public int? PreFulfillmentCanceledOrderCount { get; set; }
        
        #endregion
        
        #region Valid Tracking Rate
        
        /// <summary>
        /// Valid tracking rate percentage
        /// </summary>
        public decimal? ValidTrackingRate { get; set; }
        
        /// <summary>
        /// Target valid tracking rate percentage
        /// </summary>
        public decimal? ValidTrackingRateTarget { get; set; }
        
        #endregion
        
        #region On-Time Delivery Rate
        
        /// <summary>
        /// On-time delivery rate percentage
        /// </summary>
        public decimal? OnTimeDeliveryRate { get; set; }
        
        /// <summary>
        /// Target on-time delivery rate percentage
        /// </summary>
        public decimal? OnTimeDeliveryRateTarget { get; set; }
        
        #endregion
        
        #region Invoice Defect Rate
        
        /// <summary>
        /// Invoice defect rate percentage
        /// </summary>
        public decimal? InvoiceDefectRate { get; set; }
        
        /// <summary>
        /// Target invoice defect rate percentage
        /// </summary>
        public decimal? InvoiceDefectRateTarget { get; set; }
        
        #endregion
        
        #region Policy Violations
        
        /// <summary>
        /// Number of listing policy violations
        /// </summary>
        public int? ListingPolicyViolationsCount { get; set; }
        
        /// <summary>
        /// Number of product authenticity complaints
        /// </summary>
        public int? ProductAuthenticityComplaintsCount { get; set; }
        
        /// <summary>
        /// Number of product condition complaints
        /// </summary>
        public int? ProductConditionComplaintsCount { get; set; }
        
        /// <summary>
        /// Number of product safety complaints
        /// </summary>
        public int? ProductSafetyComplaintsCount { get; set; }
        
        /// <summary>
        /// Number of intellectual property complaints
        /// </summary>
        public int? IntellectualPropertyComplaintsCount { get; set; }
        
        /// <summary>
        /// Number of suspected intellectual property violations
        /// </summary>
        public int? SuspectedIPViolationsCount { get; set; }
        
        /// <summary>
        /// Number of policy violation warnings
        /// </summary>
        public int? PolicyViolationWarningsCount { get; set; }
        
        #endregion
        
        /// <summary>
        /// Reference number for the report
        /// </summary>
        public string RefNumber { get; set; }
    }

    /// <summary>
    /// Helper classes for deserializing the JSON response
    /// </summary>
    internal class SellerPerformanceData
    {
        [JsonProperty("accountStatuses")]
        public List<AccountStatus> AccountStatuses { get; set; }
        
        [JsonProperty("performanceMetrics")]
        public List<PerformanceMetrics> PerformanceMetrics { get; set; }
    }

    public class AccountStatus
    {
        [JsonProperty("marketplaceId")]
        public string MarketplaceId { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
    }

    internal class PerformanceMetrics
    {
        [JsonProperty("marketplaceId")]
        public string MarketplaceId { get; set; }
        
        [JsonProperty("lateShipmentRate")]
        public LateShipmentRateMetric LateShipmentRate { get; set; }
        
        [JsonProperty("lateShipmentRateList")]
        public List<LateShipmentRateMetric> LateShipmentRateList { get; set; }
        
        [JsonProperty("invoiceDefectRate")]
        public InvoiceDefectRateMetric InvoiceDefectRate { get; set; }
        
        [JsonProperty("orderDefectRate")]
        public OrderDefectRateMetrics OrderDefectRate { get; set; }
        
        [JsonProperty("onTimeDeliveryRate")]
        public OnTimeDeliveryRateMetric OnTimeDeliveryRate { get; set; }
        
        [JsonProperty("validTrackingRate")]
        public ValidTrackingRateMetric ValidTrackingRate { get; set; }
        
        [JsonProperty("preFulfillmentCancellationRate")]
        public PreFulfillmentCancellationRateMetric PreFulfillmentCancellationRate { get; set; }
        
        [JsonProperty("warningStates")]
        public List<string> WarningStates { get; set; }
        
        [JsonProperty("accountHealthRating")]
        public AccountHealthRating AccountHealthRating { get; set; }
        
        // Policy violations
        [JsonProperty("listingPolicyViolations")]
        public PolicyViolationMetric ListingPolicyViolations { get; set; }
        
        [JsonProperty("productAuthenticityCustomerComplaints")]
        public PolicyViolationMetric ProductAuthenticityCustomerComplaints { get; set; }
        
        [JsonProperty("productConditionCustomerComplaints")]
        public PolicyViolationMetric ProductConditionCustomerComplaints { get; set; }
        
        [JsonProperty("productSafetyCustomerComplaints")]
        public PolicyViolationMetric ProductSafetyCustomerComplaints { get; set; }
        
        [JsonProperty("receivedIntellectualPropertyComplaints")]
        public PolicyViolationMetric ReceivedIntellectualPropertyComplaints { get; set; }
        
        [JsonProperty("restrictedProductPolicyViolations")]
        public PolicyViolationMetric RestrictedProductPolicyViolations { get; set; }
        
        [JsonProperty("suspectedIntellectualPropertyViolations")]
        public PolicyViolationMetric SuspectedIntellectualPropertyViolations { get; set; }
        
        [JsonProperty("foodAndProductSafetyIssues")]
        public PolicyViolationMetric FoodAndProductSafetyIssues { get; set; }
        
        [JsonProperty("customerProductReviewsPolicyViolations")]
        public PolicyViolationMetric CustomerProductReviewsPolicyViolations { get; set; }
        
        [JsonProperty("otherPolicyViolations")]
        public PolicyViolationMetric OtherPolicyViolations { get; set; }
        
        [JsonProperty("documentRequests")]
        public PolicyViolationMetric DocumentRequests { get; set; }
        
        [JsonProperty("policyViolationWarnings")]
        public PolicyViolationWarnings PolicyViolationWarnings { get; set; }
    }

    internal class ReportingDateRange
    {
        [JsonProperty("reportingDateFrom")]
        public string ReportingDateFrom { get; set; }
        
        [JsonProperty("reportingDateTo")]
        public string ReportingDateTo { get; set; }
    }

    internal class LateShipmentRateMetric
    {
        [JsonProperty("reportingDateRange")]
        public ReportingDateRange ReportingDateRange { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("targetValue")]
        public decimal TargetValue { get; set; }
        
        [JsonProperty("targetCondition")]
        public string TargetCondition { get; set; }
        
        [JsonProperty("orderCount")]
        public int OrderCount { get; set; }
        
        [JsonProperty("lateShipmentCount")]
        public int LateShipmentCount { get; set; }
        
        [JsonProperty("rate")]
        public decimal Rate { get; set; }
    }

    internal class InvoiceDefectRateMetric
    {
        [JsonProperty("reportingDateRange")]
        public ReportingDateRange ReportingDateRange { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("targetValue")]
        public decimal TargetValue { get; set; }
        
        [JsonProperty("targetCondition")]
        public string TargetCondition { get; set; }
        
        [JsonProperty("invoiceDefect")]
        public InvoiceDefect InvoiceDefect { get; set; }
        
        [JsonProperty("missingInvoice")]
        public InvoiceDefect MissingInvoice { get; set; }
        
        [JsonProperty("lateInvoice")]
        public InvoiceDefect LateInvoice { get; set; }
        
        [JsonProperty("orderCount")]
        public int OrderCount { get; set; }
        
        [JsonProperty("rate")]
        public decimal Rate { get; set; }
    }

    internal class InvoiceDefect
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("count")]
        public int Count { get; set; }
    }

    internal class OrderDefectRateMetrics
    {
        [JsonProperty("afn")]
        public OrderDefectRateMetric Afn { get; set; }
        
        [JsonProperty("mfn")]
        public OrderDefectRateMetric Mfn { get; set; }
    }

    internal class OrderDefectRateMetric
    {
        [JsonProperty("reportingDateRange")]
        public ReportingDateRange ReportingDateRange { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("targetValue")]
        public decimal TargetValue { get; set; }
        
        [JsonProperty("targetCondition")]
        public string TargetCondition { get; set; }
        
        [JsonProperty("orderWithDefects")]
        public DefectCount OrderWithDefects { get; set; }
        
        [JsonProperty("claims")]
        public DefectCount Claims { get; set; }
        
        [JsonProperty("chargebacks")]
        public DefectCount Chargebacks { get; set; }
        
        [JsonProperty("negativeFeedback")]
        public DefectCount NegativeFeedback { get; set; }
        
        [JsonProperty("orderCount")]
        public int OrderCount { get; set; }
        
        [JsonProperty("rate")]
        public decimal Rate { get; set; }
        
        [JsonProperty("fulfillmentType")]
        public string FulfillmentType { get; set; }
    }

    internal class DefectCount
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("count")]
        public int Count { get; set; }
    }

    internal class OnTimeDeliveryRateMetric
    {
        [JsonProperty("reportingDateRange")]
        public ReportingDateRange ReportingDateRange { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("targetValue")]
        public decimal TargetValue { get; set; }
        
        [JsonProperty("targetCondition")]
        public string TargetCondition { get; set; }
        
        [JsonProperty("shipmentCountWithValidTracking")]
        public int ShipmentCountWithValidTracking { get; set; }
        
        [JsonProperty("onTimeDeliveryCount")]
        public int OnTimeDeliveryCount { get; set; }
        
        [JsonProperty("rate")]
        public decimal Rate { get; set; }
    }

    internal class ValidTrackingRateMetric
    {
        [JsonProperty("reportingDateRange")]
        public ReportingDateRange ReportingDateRange { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("targetValue")]
        public decimal TargetValue { get; set; }
        
        [JsonProperty("targetCondition")]
        public string TargetCondition { get; set; }
        
        [JsonProperty("shipmentCount")]
        public int ShipmentCount { get; set; }
        
        [JsonProperty("validTrackingCount")]
        public int ValidTrackingCount { get; set; }
        
        [JsonProperty("rate")]
        public decimal Rate { get; set; }
    }

    internal class PreFulfillmentCancellationRateMetric
    {
        [JsonProperty("reportingDateRange")]
        public ReportingDateRange ReportingDateRange { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("targetValue")]
        public decimal TargetValue { get; set; }
        
        [JsonProperty("targetCondition")]
        public string TargetCondition { get; set; }
        
        [JsonProperty("orderCount")]
        public int OrderCount { get; set; }
        
        [JsonProperty("cancellationCount")]
        public int CancellationCount { get; set; }
        
        [JsonProperty("rate")]
        public decimal Rate { get; set; }
    }

    internal class AccountHealthRating
    {
        [JsonProperty("ahrStatus")]
        public string AhrStatus { get; set; }
        
        [JsonProperty("reportingDateRange")]
        public ReportingDateRange ReportingDateRange { get; set; }
        
        [JsonProperty("ahrScore")]
        public decimal AhrScore { get; set; }
    }

    internal class PolicyViolationMetric
    {
        [JsonProperty("reportingDateRange")]
        public ReportingDateRange ReportingDateRange { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("targetValue")]
        public decimal TargetValue { get; set; }
        
        [JsonProperty("targetCondition")]
        public string TargetCondition { get; set; }
        
        [JsonProperty("defectsCount")]
        public int DefectsCount { get; set; }
    }

    internal class PolicyViolationWarnings
    {
        [JsonProperty("warningsCount")]
        public int WarningsCount { get; set; }
        
        [JsonProperty("reportingDateRange")]
        public ReportingDateRange ReportingDateRange { get; set; }
    }
}