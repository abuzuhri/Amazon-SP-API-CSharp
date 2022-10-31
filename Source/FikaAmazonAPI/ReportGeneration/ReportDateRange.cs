using System;
using System.Collections.Generic;

namespace FikaAmazonAPI.ReportGeneration
{
    public class ReportDateRange
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ReportDateRange(DateTime startDate, DateTime endDate) { StartDate = startDate; EndDate = endDate;}


		public static IList<ReportDateRange> GetDateRange(DateTime startDate, DateTime endDate, int MaxDays)
		{
			List<ReportDateRange> list = new List<ReportDateRange>();
			DateTime tempEnd = startDate;
			DateTime start = startDate;

			while (true)
			{
				tempEnd = tempEnd.AddDays(MaxDays);
				if (tempEnd > endDate)
				{
					tempEnd = endDate;
					list.Add(new ReportDateRange(start, tempEnd));
					break;
				}
				else
				{
					list.Add(new ReportDateRange(start, tempEnd));
					start = tempEnd.AddSeconds(1);
				}

			}

			return list;
        }
    }
}
