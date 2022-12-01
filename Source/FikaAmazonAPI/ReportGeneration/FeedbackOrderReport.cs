using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FikaAmazonAPI.ReportGeneration
{
    public class FeedbackOrderReport
    {
        public List<FeedbackOrderRow> Data { get; set; }=new List<FeedbackOrderRow>();
        public FeedbackOrderReport(string path, string refNumber)
        {
            if (string.IsNullOrEmpty(path))
                return;
            List<FeedbackOrderRow> values = File.ReadAllLines(path)
                                           .Skip(1)
                                           .Select(v => FeedbackOrderRow.FromCsv(v, refNumber))
                                           .ToList();
            Data = values;
        }


    }
    public class FeedbackOrderRow
    {
        public string refNumber { get; set; }
        public DateTime? Date { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public string Response { get; set; }
        public string OrderID { get; set; }
        public string RaterEmail { get; set; }

        public static FeedbackOrderRow FromCsv(string csvLine, string refNumber)
        {
            string[] values = csvLine.Split('\t');
            FeedbackOrderRow row = new FeedbackOrderRow();
            row.Date = DataConverter.GetDate(values[0], DataConverter.DateTimeFormat.DATE_BACKSLASH_FORMAT);
            row.Rating = Convert.ToInt32(values[1]);
            row.Comments = values[2];
            row.Response = values[3];
            row.OrderID = values[4];
            row.RaterEmail = values[5];
            row.refNumber = refNumber;

            return row;
        }

    }
}
