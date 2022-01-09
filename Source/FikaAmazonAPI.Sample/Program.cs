using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FikaAmazonAPI.AmazonSpApiSDK.Api.Sellers;
using FikaAmazonAPI.AmazonSpApiSDK.Clients;
using FikaAmazonAPI;
using FikaAmazonAPI.ConstructFeed;
using FikaAmazonAPI.ConstructFeed.Messages;
using FikaAmazonAPI.Parameter;
using FikaAmazonAPI.Parameter.Notification;
using FikaAmazonAPI.Parameter.Order;
using FikaAmazonAPI.Parameter.Report;
using FikaAmazonAPI.Utils;
using static FikaAmazonAPI.ConstructFeed.BaseXML;
using static FikaAmazonAPI.Utils.Constants;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using FikaAmazonAPI.AmazonSpApiSDK.Services;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.Token.RestrictedResource;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Reports;
using FikaAmazonAPI.AmazonSpApiSDK.Models.MerchantFulfillment;
using FikaAmazonAPI.Parameter.Finance;

namespace FikaAmazonAPI.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {


            AmazonConnection amazonConnection = new AmazonConnection(new AmazonCredential()
            {
                AccessKey = Environment.GetEnvironmentVariable("AccessKey"),
                SecretKey = Environment.GetEnvironmentVariable("SecretKey"),
                RoleArn = Environment.GetEnvironmentVariable("RoleArn"),
                ClientId = Environment.GetEnvironmentVariable("ClientId"),
                ClientSecret = Environment.GetEnvironmentVariable("ClientSecret"),
                RefreshToken = Environment.GetEnvironmentVariable("RefreshToken"),
                MarketPlace = MarketPlace.UnitedArabEmirates, //MarketPlace.GetMarketPlaceByID("A2VIGQ35RCS4UG")
                IsActiveLimitRate = true
            }) ;

            var dddd= amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_FBA_INVENTORY_AGED_DATA);

            var parameters = new ParameterListFinancialEvents();
            parameters.PostedAfter = new DateTime(2021, 12, 1);
            var fEvents = amazonConnection.Financial.ListFinancialEvents(parameters);

            //var rb=amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_FBA_STORAGE_FEE_CHARGES_DATA,DateTime.UtcNow.AddDays(-60), DateTime.UtcNow.AddDays(-1));

            GetEligibleShipmentServicesRequest getEligibleShipmentServicesRequest = new GetEligibleShipmentServicesRequest()
            {
                ShippingOfferingFilter = new ShippingOfferingFilter()
                {
                    CarrierWillPickUp = CarrierWillPickUpOption.CarrierWillPickUp,
                    DeliveryExperience = DeliveryExperienceOption.NoTracking,
                    IncludePackingSlipWithLabel = true,
                    IncludeComplexShippingOptions = false
                },
                ShipmentRequestDetails = new ShipmentRequestDetails()
                {

                    AmazonOrderId = "22-333333-3333333333",
                    ItemList = new ItemList()
                    {
                        new Item()
                        {
                            ItemDescription ="AAAAA",
                            Quantity=1,
                            OrderItemId="11111111"

                        }
                    },
                    ShipFromAddress =new Address()
                    {
                        AddressLine1 ="addd",
                        City="AAAA",
                        DistrictOrCounty="",
                        Email="sss@isskd.com",
                        Name="TEST",
                        PostalCode="97122",
                        CountryCode="AE",
                        Phone="+97150999999"
                    },
                    PackageDimensions=new PackageDimensions()
                    {
                        Height =1,
                        Length=1,
                        Width=1,
                        Unit=UnitOfLength.Centimeters
                    },
                    Weight=new Weight(1,UnitOfWeight.G),
                    ShippingServiceOptions=new ShippingServiceOptions()
                    {
                        DeliveryExperience=DeliveryExperienceType.NoTracking,
                        CarrierWillPickUp=false

                    }
                },
                
            };

            var result=amazonConnection.MerchantFulfillment.GetEligibleShipmentServices(getEligibleShipmentServicesRequest);

            //createdSince cannot be after createdUntil
            DateTime createdSince = DateTime.UtcNow.AddDays(-60);
            DateTime createdUntil = DateTime.UtcNow;

            var data222221 = amazonConnection.Reports.DownloadExistingReportAndDownloadFile(
                                                 ReportTypes.GET_V2_SETTLEMENT_REPORT_DATA_FLAT_FILE_V2, 
                                                 createdSince, 
                                                 createdUntil);


            //while (true)
            //{
            //    var fromDate = DateTime.UtcNow.AddDays(-3);
            //    var toDate = DateTime.UtcNow.AddDays(-1);
            //    var ddddd = amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_FBA_FULFILLMENT_CUSTOMER_RETURNS_DATA, fromDate, toDate);
            //    Console.WriteLine(ddddd);
            //}


            DateTime startDate11 = new DateTime(2021, 10, 03);
            var data111 = amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_SELLER_FEEDBACK_DATA, startDate11, null, null);


            var marketplaceById = MarketPlace.GetMarketPlaceByID("A2VIGQ35RCS4UG");

            

            Console.ReadLine();
            
        }



    }
}
