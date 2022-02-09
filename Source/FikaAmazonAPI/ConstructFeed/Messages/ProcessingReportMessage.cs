using System.Collections.Generic;
using System.Xml.Serialization;

namespace FikaAmazonAPI.ConstructFeed.Messages
{
    public partial class ProcessingReportMessage
    {
		[XmlElement(ElementName = "DocumentTransactionID")]
		public string DocumentTransactionID { get; set; }
		[XmlElement(ElementName = "StatusCode")]
		public string StatusCode { get; set; }
		[XmlElement(ElementName = "ProcessingSummary")]
		public ProcessingSummary ProcessingSummary { get; set; }
		[XmlElement(ElementName = "Result")]
		public List<Result> Result { get; set; }
	}
	[XmlRoot(ElementName = "ProcessingSummary")]
	public class ProcessingSummary
	{
		[XmlElement(ElementName = "MessagesProcessed")]
		public string MessagesProcessed { get; set; }
		[XmlElement(ElementName = "MessagesSuccessful")]
		public string MessagesSuccessful { get; set; }
		[XmlElement(ElementName = "MessagesWithError")]
		public string MessagesWithError { get; set; }
		[XmlElement(ElementName = "MessagesWithWarning")]
		public string MessagesWithWarning { get; set; }
	}

	[XmlRoot(ElementName = "Result")]
	public class Result
	{
		[XmlElement(ElementName = "MessageID")]
		public string MessageID { get; set; }
		[XmlElement(ElementName = "ResultCode")]
		public string ResultCode { get; set; }
		[XmlElement(ElementName = "ResultMessageCode")]
		public string ResultMessageCode { get; set; }
		[XmlElement(ElementName = "ResultDescription")]
		public string ResultDescription { get; set; }
		[XmlElement(ElementName = "AdditionalInfo")]
		public AdditionalInfo AdditionalInfo { get; set; }
	}

	[XmlRoot(ElementName = "AdditionalInfo")]
	public class AdditionalInfo
	{
		[XmlElement(ElementName = "SKU")]
		public string SKU { get; set; }
		[XmlElement(ElementName = "FulfillmentCenterID")]
		public string FulfillmentCenterID { get; set; }
		[XmlElement(ElementName = "AmazonOrderID")]
		public string AmazonOrderID { get; set; }
		[XmlElement(ElementName = "AmazonOrderItemCode")]
		public string AmazonOrderItemCode { get; set; }
	}

    

}
