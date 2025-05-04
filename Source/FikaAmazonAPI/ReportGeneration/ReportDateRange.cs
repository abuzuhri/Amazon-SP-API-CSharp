using System;
using System.Collections.Generic;

namespace FikaAmazonAPI.ReportGeneration
{
    public class ReportDateRange
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ReportDateRange(DateTime startDate, DateTime endDate) { StartDate = startDate; EndDate = endDate;}


        public static IList<ReportDateRange> GetDateRange(DateTime startDate, DateTime endDate, int maxDays)
        {
            List<ReportDateRange> list = new List<ReportDateRange>();
            DateTime tempEnd;
            DateTime start = startDate;

            while (start < endDate)
            {
                tempEnd = start.AddDays(maxDays);

                if (tempEnd > endDate)
                {
                    tempEnd = endDate;
                }

                list.Add(new ReportDateRange(start, tempEnd));

                start = tempEnd.AddSeconds(1);
            }

            return list;
        }
    }
}
