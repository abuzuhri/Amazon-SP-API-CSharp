using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FikaAmazonAPI.ReportGeneration
{
    public class SellerFeedBackData
    {
        public SellerFeedBackDataResult Data { get; private set; }
        public SellerFeedBackData(string path)
        {
            if (string.IsNullOrEmpty(path))
                return;
            var values = File.ReadAllText(path);
            Data = JsonConvert.DeserializeObject<SellerFeedBackDataResult>(values);
        }
    }
    public class SellerFeedBackDataResult
    {
        public class Rootobject
        {
            public Accountstatus[] accountStatuses { get; set; }
            public Performancemetric[] performanceMetrics { get; set; }
        }

        public class Accountstatus
        {
            public string marketplaceId { get; set; }
            public string status { get; set; }
        }

        public class Performancemetric
        {
            public Lateshipmentrate lateShipmentRate { get; set; }
            public Invoicedefectrate invoiceDefectRate { get; set; }
            public Orderdefectrate orderDefectRate { get; set; }
            public Ontimedeliveryrate onTimeDeliveryRate { get; set; }
            public Validtrackingrate validTrackingRate { get; set; }
            public Prefulfillmentcancellationrate preFulfillmentCancellationRate { get; set; }
            public object[] warningStates { get; set; }
            public Accounthealthrating accountHealthRating { get; set; }
            public Listingpolicyviolations listingPolicyViolations { get; set; }
            public Productauthenticitycustomercomplaints productAuthenticityCustomerComplaints { get; set; }
            public Productconditioncustomercomplaints productConditionCustomerComplaints { get; set; }
            public Productsafetycustomercomplaints productSafetyCustomerComplaints { get; set; }
            public Receivedintellectualpropertycomplaints receivedIntellectualPropertyComplaints { get; set; }
            public Restrictedproductpolicyviolations restrictedProductPolicyViolations { get; set; }
            public Suspectedintellectualpropertyviolations suspectedIntellectualPropertyViolations { get; set; }
            public Foodandproductsafetyissues foodAndProductSafetyIssues { get; set; }
            public Customerproductreviewspolicyviolations customerProductReviewsPolicyViolations { get; set; }
            public Otherpolicyviolations otherPolicyViolations { get; set; }
            public Documentrequests documentRequests { get; set; }
            public string marketplaceId { get; set; }
        }

        public class Lateshipmentrate
        {
            public Reportingdaterange reportingDateRange { get; set; }
            public string status { get; set; }
            public decimal targetValue { get; set; }
            public string targetCondition { get; set; }
            public int orderCount { get; set; }
            public int lateShipmentCount { get; set; }
            public int rate { get; set; }
        }

        public class Reportingdaterange
        {
            public DateTime reportingDateFrom { get; set; }
            public DateTime reportingDateTo { get; set; }
        }

        public class Invoicedefectrate
        {
            public Reportingdaterange1 reportingDateRange { get; set; }
            public string status { get; set; }
            public decimal targetValue { get; set; }
            public string targetCondition { get; set; }
            public Invoicedefect invoiceDefect { get; set; }
            public Missinginvoice missingInvoice { get; set; }
            public Lateinvoice lateInvoice { get; set; }
            public int orderCount { get; set; }
            public int rate { get; set; }
        }

        public class Reportingdaterange1
        {
            public DateTime reportingDateFrom { get; set; }
            public DateTime reportingDateTo { get; set; }
        }

        public class Invoicedefect
        {
            public string status { get; set; }
            public int count { get; set; }
        }

        public class Missinginvoice
        {
            public string status { get; set; }
            public int count { get; set; }
        }

        public class Lateinvoice
        {
            public string status { get; set; }
            public int count { get; set; }
        }

        public class Orderdefectrate
        {
            public Afn afn { get; set; }
            public Mfn mfn { get; set; }
        }

        public class Afn
        {
            public Reportingdaterange2 reportingDateRange { get; set; }
            public string status { get; set; }
            public decimal targetValue { get; set; }
            public string targetCondition { get; set; }
            public Orderwithdefects orderWithDefects { get; set; }
            public Claims claims { get; set; }
            public Chargebacks chargebacks { get; set; }
            public Negativefeedback negativeFeedback { get; set; }
            public int orderCount { get; set; }
            public float rate { get; set; }
            public string fulfillmentType { get; set; }
        }

        public class Reportingdaterange2
        {
            public DateTime reportingDateFrom { get; set; }
            public DateTime reportingDateTo { get; set; }
        }

        public class Orderwithdefects
        {
            public string status { get; set; }
            public int count { get; set; }
        }

        public class Claims
        {
            public string status { get; set; }
            public int count { get; set; }
        }

        public class Chargebacks
        {
            public string status { get; set; }
            public int count { get; set; }
        }

        public class Negativefeedback
        {
            public string status { get; set; }
            public int count { get; set; }
        }

        public class Mfn
        {
            public Reportingdaterange3 reportingDateRange { get; set; }
            public string status { get; set; }
            public float targetValue { get; set; }
            public string targetCondition { get; set; }
            public Orderwithdefects1 orderWithDefects { get; set; }
            public Claims1 claims { get; set; }
            public Chargebacks1 chargebacks { get; set; }
            public Negativefeedback1 negativeFeedback { get; set; }
            public int orderCount { get; set; }
            public int rate { get; set; }
            public string fulfillmentType { get; set; }
        }

        public class Reportingdaterange3
        {
            public DateTime reportingDateFrom { get; set; }
            public DateTime reportingDateTo { get; set; }
        }

        public class Orderwithdefects1
        {
            public string status { get; set; }
            public int count { get; set; }
        }

        public class Claims1
        {
            public string status { get; set; }
            public int count { get; set; }
        }

        public class Chargebacks1
        {
            public string status { get; set; }
            public int count { get; set; }
        }

        public class Negativefeedback1
        {
            public string status { get; set; }
            public int count { get; set; }
        }

        public class Ontimedeliveryrate
        {
            public Reportingdaterange4 reportingDateRange { get; set; }
            public string status { get; set; }
            public float targetValue { get; set; }
            public string targetCondition { get; set; }
            public int shipmentCountWithValidTracking { get; set; }
            public int onTimeDeliveryCount { get; set; }
            public int rate { get; set; }
        }

        public class Reportingdaterange4
        {
            public DateTime reportingDateFrom { get; set; }
            public DateTime reportingDateTo { get; set; }
        }

        public class Validtrackingrate
        {
            public Reportingdaterange5 reportingDateRange { get; set; }
            public string status { get; set; }
            public decimal targetValue { get; set; }
            public string targetCondition { get; set; }
            public int shipmentCount { get; set; }
            public int validTrackingCount { get; set; }
            public int rate { get; set; }
        }

        public class Reportingdaterange5
        {
            public DateTime reportingDateFrom { get; set; }
            public DateTime reportingDateTo { get; set; }
        }

        public class Prefulfillmentcancellationrate
        {
            public Reportingdaterange6 reportingDateRange { get; set; }
            public string status { get; set; }
            public decimal targetValue { get; set; }
            public string targetCondition { get; set; }
            public int orderCount { get; set; }
            public int cancellationCount { get; set; }
            public int rate { get; set; }
        }

        public class Reportingdaterange6
        {
            public DateTime reportingDateFrom { get; set; }
            public DateTime reportingDateTo { get; set; }
        }

        public class Accounthealthrating
        {
            public string ahrStatus { get; set; }
            public Reportingdaterange7 reportingDateRange { get; set; }
        }

        public class Reportingdaterange7
        {
            public DateTime reportingDateFrom { get; set; }
            public DateTime reportingDateTo { get; set; }
        }

        public class Listingpolicyviolations
        {
            public Reportingdaterange8 reportingDateRange { get; set; }
            public string status { get; set; }
            public int targetValue { get; set; }
            public string targetCondition { get; set; }
            public int defectsCount { get; set; }
        }

        public class Reportingdaterange8
        {
            public DateTime reportingDateFrom { get; set; }
            public DateTime reportingDateTo { get; set; }
        }

        public class Productauthenticitycustomercomplaints
        {
            public Reportingdaterange9 reportingDateRange { get; set; }
            public string status { get; set; }
            public int targetValue { get; set; }
            public string targetCondition { get; set; }
            public int defectsCount { get; set; }
        }

        public class Reportingdaterange9
        {
            public DateTime reportingDateFrom { get; set; }
            public DateTime reportingDateTo { get; set; }
        }

        public class Productconditioncustomercomplaints
        {
            public Reportingdaterange10 reportingDateRange { get; set; }
            public string status { get; set; }
            public int targetValue { get; set; }
            public string targetCondition { get; set; }
            public int defectsCount { get; set; }
        }

        public class Reportingdaterange10
        {
            public DateTime reportingDateFrom { get; set; }
            public DateTime reportingDateTo { get; set; }
        }

        public class Productsafetycustomercomplaints
        {
            public Reportingdaterange11 reportingDateRange { get; set; }
            public string status { get; set; }
            public int targetValue { get; set; }
            public string targetCondition { get; set; }
            public int defectsCount { get; set; }
        }

        public class Reportingdaterange11
        {
            public DateTime reportingDateFrom { get; set; }
            public DateTime reportingDateTo { get; set; }
        }

        public class Receivedintellectualpropertycomplaints
        {
            public Reportingdaterange12 reportingDateRange { get; set; }
            public string status { get; set; }
            public int targetValue { get; set; }
            public string targetCondition { get; set; }
            public int defectsCount { get; set; }
        }

        public class Reportingdaterange12
        {
            public DateTime reportingDateFrom { get; set; }
            public DateTime reportingDateTo { get; set; }
        }

        public class Restrictedproductpolicyviolations
        {
            public Reportingdaterange13 reportingDateRange { get; set; }
            public string status { get; set; }
            public int targetValue { get; set; }
            public string targetCondition { get; set; }
            public int defectsCount { get; set; }
        }

        public class Reportingdaterange13
        {
            public DateTime reportingDateFrom { get; set; }
            public DateTime reportingDateTo { get; set; }
        }

        public class Suspectedintellectualpropertyviolations
        {
            public Reportingdaterange14 reportingDateRange { get; set; }
            public string status { get; set; }
            public int targetValue { get; set; }
            public string targetCondition { get; set; }
            public int defectsCount { get; set; }
        }

        public class Reportingdaterange14
        {
            public DateTime reportingDateFrom { get; set; }
            public DateTime reportingDateTo { get; set; }
        }

        public class Foodandproductsafetyissues
        {
            public Reportingdaterange15 reportingDateRange { get; set; }
            public string status { get; set; }
            public int targetValue { get; set; }
            public string targetCondition { get; set; }
            public int defectsCount { get; set; }
        }

        public class Reportingdaterange15
        {
            public DateTime reportingDateFrom { get; set; }
            public DateTime reportingDateTo { get; set; }
        }

        public class Customerproductreviewspolicyviolations
        {
            public Reportingdaterange16 reportingDateRange { get; set; }
            public string status { get; set; }
            public int targetValue { get; set; }
            public string targetCondition { get; set; }
            public int defectsCount { get; set; }
        }

        public class Reportingdaterange16
        {
            public DateTime reportingDateFrom { get; set; }
            public DateTime reportingDateTo { get; set; }
        }

        public class Otherpolicyviolations
        {
            public Reportingdaterange17 reportingDateRange { get; set; }
            public string status { get; set; }
            public int targetValue { get; set; }
            public string targetCondition { get; set; }
            public int defectsCount { get; set; }
        }

        public class Reportingdaterange17
        {
            public DateTime reportingDateFrom { get; set; }
            public DateTime reportingDateTo { get; set; }
        }

        public class Documentrequests
        {
            public Reportingdaterange18 reportingDateRange { get; set; }
            public string status { get; set; }
            public int targetValue { get; set; }
            public string targetCondition { get; set; }
            public int defectsCount { get; set; }
        }

        public class Reportingdaterange18
        {
            public DateTime reportingDateFrom { get; set; }
            public DateTime reportingDateTo { get; set; }
        }

    }
}
