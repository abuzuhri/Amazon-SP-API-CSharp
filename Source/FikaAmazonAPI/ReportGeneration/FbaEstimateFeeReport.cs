using FikaAmazonAPI.ReportGeneration.ReportDataTable;
using System;
using System.Collections.Generic;

namespace FikaAmazonAPI.ReportGeneration
{
    public class FbaEstimateFeeReport
    {
        public List<FbaEstimateFeeReportRow> Data { get; set; } = new List<FbaEstimateFeeReportRow>();
        public FbaEstimateFeeReport(string path, string refNumber)
        {
            if (string.IsNullOrEmpty(path))
                return;

            var table = Table.ConvertFromCSV(path);

            List<FbaEstimateFeeReportRow> values = new List<FbaEstimateFeeReportRow>();
            foreach (var row in table.Rows)
            {
                values.Add(FbaEstimateFeeReportRow.FromRow(row, refNumber));
            }
            Data = values;
        }
    }
    public class FbaEstimateFeeReportRow
    {
        public string sku { get; set; }
        public string fnsku { get; set; }
        public string asin { get; set; }
        public string amazonStore { get; set; }
        public string productName { get; set; }
        public string productGroup { get; set; }
        public string brand { get; set; }
        public string fulfilledBy { get; set; }
        public decimal? yourPrice { get; set; }
        public decimal? salesPrice { get; set; }
        public decimal? longestSide { get; set; }
        public decimal? medianSide { get; set; }
        public decimal? shortestSide { get; set; }
        public decimal? lengthAndGirth { get; set; }
        public decimal? itemPackageWeight { get; set; }
        public decimal? estimatedFeeTotal { get; set; }
        public decimal? estimatedReferralFeePerUnit { get; set; }
        public decimal? estimatedPickPackFeePerUnit { get; set; }

        public decimal? ReferralFeePercentage
        {
            get
            {

                try
                {
                    decimal? price = estimatedReferralFeePerUnit * 100 / yourPrice;
                    return Math.Round(price.Value);
                }
                catch { return default(decimal?); }
            }
        }


        public string unitOfDimension { get; set; }
        public string unitOfWeight { get; set; }
        public string currency { get; set; }
        public string refNumber { get; set; }




        public static FbaEstimateFeeReportRow FromRow(TableRow rowData, string refNumber)
        {
            var row = new FbaEstimateFeeReportRow();

            row.sku = rowData.GetString("sku");
            row.fnsku = rowData.GetString("fnsku");
            row.asin = rowData.GetString("asin");
            row.amazonStore = rowData.GetString("amazon-store");
            row.productName = rowData.GetString("product-name");
            row.productGroup = rowData.GetString("product-group");
            row.brand = rowData.GetString("brand");
            row.fulfilledBy = rowData.GetString("fulfilled-by");

            row.yourPrice = DataConverter.GetDecimal(rowData.GetString("your-price"));
            row.salesPrice = DataConverter.GetDecimal(rowData.GetString("sales-price"));
            row.longestSide = DataConverter.GetDecimal(rowData.GetString("longest-side"));
            row.medianSide = DataConverter.GetDecimal(rowData.GetString("median-side"));
            row.shortestSide = DataConverter.GetDecimal(rowData.GetString("shortest-side"));
            row.lengthAndGirth = DataConverter.GetDecimal(rowData.GetString("length-and-girth"));
            row.lengthAndGirth = DataConverter.GetDecimal(rowData.GetString("length-and-girth"));
            row.itemPackageWeight = DataConverter.GetDecimal(rowData.GetString("item-package-weight"));
            row.estimatedFeeTotal = DataConverter.GetDecimal(rowData.GetString("estimated-fee-total"));
            row.estimatedReferralFeePerUnit = DataConverter.GetDecimal(rowData.GetString("estimated-referral-fee-per-unit"));
            row.estimatedPickPackFeePerUnit = DataConverter.GetDecimal(rowData.GetString("estimated-pick-pack-fee-per-unit"));

            row.unitOfDimension = rowData.GetString("unit-of-dimension");
            row.unitOfWeight = rowData.GetString("unit-of-weight");
            row.currency = rowData.GetString("currency");

            row.refNumber = refNumber;

            return row;
        }
    }
}
