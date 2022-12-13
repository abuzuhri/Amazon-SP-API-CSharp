using FikaAmazonAPI.AmazonSpApiSDK.Models.FbaSmallandLight;
using FikaAmazonAPI.AmazonSpApiSDK.Models.MerchantFulfillment;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Sellers;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Shipping;
using FikaAmazonAPI.Parameter.FulFillmentInbound;
using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.SampleCode
{
    public class FulFillmentInboundSample
    {
        AmazonConnection amazonConnection;
        public FulFillmentInboundSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }

        public void GetInboundGuidance()
        {
            var parm = new Parameter.FulFillmentInbound.ParameterGetInboundGuidance() {
                MarketplaceId= MarketPlace.UnitedArabEmirates.ID,
                ASINList=new List<string> { "B071XVSXRL" }
            };
            amazonConnection.FulFillmentInbound.GetInboundGuidance(parm);
        }
        
        public void GetPrepInstructions()
        {
            var parm = new Parameter.FulFillmentInbound.ParameterGetPrepInstructions() {
                ShipToCountryCode = "AE",
                MarketplaceId= MarketPlace.UnitedArabEmirates.ID,
                ASINList =new List<string> { "B071XVSXRL" }
            };
            amazonConnection.FulFillmentInbound.GetPrepInstructions(parm);
        }

        public void CreateShipmentPlan()
        {
            FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound.CreateInboundShipmentPlanRequest oCreateInboundShipmentPlanRequest = new FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound.CreateInboundShipmentPlanRequest();

            oCreateInboundShipmentPlanRequest.ShipToCountryCode = "AE";
            oCreateInboundShipmentPlanRequest.LabelPrepPreference = FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound.LabelPrepPreference.SELLERLABEL;


            oCreateInboundShipmentPlanRequest.ShipFromAddress = new FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound.Address();
            oCreateInboundShipmentPlanRequest.ShipFromAddress.AddressLine1 = "Add";
            oCreateInboundShipmentPlanRequest.ShipFromAddress.AddressLine2 = "ADD2";
            oCreateInboundShipmentPlanRequest.ShipFromAddress.City = "City";
            oCreateInboundShipmentPlanRequest.ShipFromAddress.CountryCode = "AE";
            oCreateInboundShipmentPlanRequest.ShipFromAddress.PostalCode = "0000";
            oCreateInboundShipmentPlanRequest.ShipFromAddress.Name = "Name";



            oCreateInboundShipmentPlanRequest.InboundShipmentPlanRequestItems = new FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound.InboundShipmentPlanRequestItemList();
            FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound.InboundShipmentPlanRequestItem oInboundShipmentPlanRequestItem = new FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound.InboundShipmentPlanRequestItem();
            oInboundShipmentPlanRequestItem.SellerSKU = "16118";
            oInboundShipmentPlanRequestItem.ASIN = "B08BXH6234";
            oInboundShipmentPlanRequestItem.Quantity = 1;
            oInboundShipmentPlanRequestItem.Condition = FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound.Condition.NewItem;

            oCreateInboundShipmentPlanRequest.InboundShipmentPlanRequestItems.Add(oInboundShipmentPlanRequestItem);
            var oResult = amazonConnection.FulFillmentInbound.CreateInboundShipmentPlan(oCreateInboundShipmentPlanRequest);

        }

        public void GetFulFillmentInboundLabelsFromWebCreationSample(string shipmentId,int boxCount)
        {
            var labelParams = new ParameterGetLabels()
            {
                PageType = PageType.PackageLabel_Letter_6,
                shipmentId = shipmentId,
                LabelType = LabelType.SELLER_LABEL,
                PageSize = boxCount
            };

            var labels = amazonConnection.FulFillmentInbound.GetLabels(labelParams);

        }

    }
}
