using System;
using System.Collections.Generic;

namespace FikaAmazonAPI.ReportGeneration
{
    public class ReportDateRange
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ReportDateRange(DateTime startDate, DateTime endDate) { StartDate = startDate; EndDate = endDate;}


        public static IList<ReportDateRange> GetDateRange(DateTime startDate,DateTime endDate,int MaxDays)
        {
            List<ReportDateRange> list=new List<ReportDateRange>();

            double totalDays = (endDate - startDate).TotalDays;
            int range = (int)(totalDays / MaxDays);
            int remind = (int)(totalDays % MaxDays);
            if (remind > 0)
                range++;

            for (int i = 0; i < range; i++)
            {
                var newStartDate = startDate.AddDays(i * MaxDays);
                var newEndDate = newStartDate.AddDays(MaxDays);
                if (i == range - 1)
                    newEndDate = endDate;

                list.Add(new ReportDateRange(newStartDate, newEndDate));
            }

            return list;
        }
    }
}
