namespace FikaAmazonAPI.SampleCode
{
    public class FulFillmentInboundv20240320Sample
    {
        AmazonConnection amazonConnection;
        public FulFillmentInboundv20240320Sample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }

       
        public void CreateShipmentPlan()
        {
            FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInboundv20240320.CreateInboundPlanRequest oCreateInboundShipmentPlanRequest = new FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInboundv20240320.CreateInboundPlanRequest();

            oCreateInboundShipmentPlanRequest.Name = "TestShipment";
            oCreateInboundShipmentPlanRequest.DestinationMarketplaces = new List<string> {amazonConnection.GetCurrentMarketplace.ID};


            oCreateInboundShipmentPlanRequest.SourceAddress = new FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInboundv20240320.Address();
            oCreateInboundShipmentPlanRequest.SourceAddress.AddressLine1 = "Add";
            oCreateInboundShipmentPlanRequest.SourceAddress.AddressLine2 = "ADD2";
            oCreateInboundShipmentPlanRequest.SourceAddress.City = "City";
            oCreateInboundShipmentPlanRequest.SourceAddress.CountryCode = "AE";
            oCreateInboundShipmentPlanRequest.SourceAddress.PostalCode = "0000";
            oCreateInboundShipmentPlanRequest.SourceAddress.Name = "Name";



            oCreateInboundShipmentPlanRequest.Items = new List<AmazonSpApiSDK.Models.FulfillmentInboundv20240320.ItemInput>();
            FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInboundv20240320.ItemInput oInboundShipmentPlanRequestItem = new FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInboundv20240320.ItemInput();
            oInboundShipmentPlanRequestItem.Msku = "16118";
            oInboundShipmentPlanRequestItem.Quantity = 1;
            oInboundShipmentPlanRequestItem.LabelOwner = AmazonSpApiSDK.Models.FulfillmentInboundv20240320.LabelOwner.SELLER;
            oInboundShipmentPlanRequestItem.PrepOwner = AmazonSpApiSDK.Models.FulfillmentInboundv20240320.PrepOwner.SELLER;
          
            var oResult = amazonConnection.FulFillmentInboundv20240320.CreateInboundPlan(oCreateInboundShipmentPlanRequest);

        }

      

    }
}
