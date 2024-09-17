using FikaAmazonAPI.ReportGeneration.ReportDataTable;
using System;
using System.Collections.Generic;

namespace FikaAmazonAPI.ReportGeneration
{
    public class ReferralFeeReport
    {
        public List<ReferralFeeReportRow> Data { get; set; } = new List<ReferralFeeReportRow>();
        public ReferralFeeReport(string path, string refNumber)
        {
            if (string.IsNullOrEmpty(path))
                return;

            var table = Table.ConvertFromCSV(path);

            List<ReferralFeeReportRow> values = new List<ReferralFeeReportRow>();
            foreach (var row in table.Rows)
            {
                values.Add(ReferralFeeReportRow.FromRow(row, refNumber));
            }
            Data = values;
        }
    }
    public class ReferralFeeReportRow
    {
        public string sellerSku { get; set; }
        public string asin { get; set; }
        public string itemName { get; set; }
        public decimal? price { get; set; }
        public decimal? estimatedReferralFeePerItem { get; set; }

        public decimal? ReferralFeePercentage
        {
            get
            {

                try
                {
                    decimal? priceP = estimatedReferralFeePerItem * 100 / price;
                    return Math.Round(priceP.Value);
                }
                catch { return default(decimal?); }
            }
        }

        public string refNumber { get; set; }




        public static ReferralFeeReportRow FromRow(TableRow rowData, string refNumber)
        {
            var row = new ReferralFeeReportRow();

            row.sellerSku = rowData.GetString("seller-sku");
            row.asin = rowData.GetString("asin");
            row.itemName = rowData.GetString("item-name");

            row.price = DataConverter.GetDecimal(rowData.GetString("price"));
            row.estimatedReferralFeePerItem = DataConverter.GetDecimal(rowData.GetString("estimated-referral-fee-per-item"));


            row.refNumber = refNumber;

            return row;
        }
    }
}
