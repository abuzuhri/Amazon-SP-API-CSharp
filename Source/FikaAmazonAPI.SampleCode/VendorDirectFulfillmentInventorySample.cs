using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorDirectFulfillmentInventory;

namespace FikaAmazonAPI.SampleCode;

public class VendorDirectFulfillmentInventorySample
{
    AmazonConnection amazonConnection;

    public VendorDirectFulfillmentInventorySample(AmazonConnection amazonConnection)
    {
        this.amazonConnection = amazonConnection;
    }

    public void SubmitInventoryUpdate()
    {
        var submitInventoryUpdateRequest = new SubmitInventoryUpdateRequest
        {
            Inventory = new InventoryUpdate
            {
                SellingParty = new PartyIdentification
                {
                    PartyId = ""
                },
                IsFullUpdate = false,
                Items = new List<ItemDetails>()
                {
                    new()
                    {
                        VendorProductIdentifier = "",
                        AvailableQuantity = new ItemQuantity
                        {
                            Amount = 99,
                            UnitOfMeasure = "LB"
                        },
                    }
                }
            }
        };

        var result =
            amazonConnection.VendorDirectFulfillmentInventory.SubmitInventoryUpdate("", submitInventoryUpdateRequest);
    }
}