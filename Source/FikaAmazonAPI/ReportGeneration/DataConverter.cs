using System;
using System.Globalization;

namespace FikaAmazonAPI.ReportGeneration
{
    public class DataConverter
    {

        public static class DateTimeFormat
        {
            public const string DATE_FORMAT_DOT = "dd.MM.yyyy";
            public const string DATETIME_FORMAT_UTC_DOT = "dd.MM.yyyy HH:mm:ss UTC";
            public const string DATETIME_K_FORMAT = "yyyy-MM-ddTHH:mm:ssK";
            public const string DATE_BACKSLASH_FORMAT = "M/d/yy";
            public const string DATE_MMM_FORMAT = "dd-MMM-yyyy";
            public const string DATE_AGING_FORMAT = "yyyy-MM-dd";
            public const string DATE_LEDGER_FORMAT = "MM/dd/yyyy";
        }

        public static CultureInfo DataConverterCultureInfo = CultureInfo.CurrentCulture;

        public static DateTime? GetDate(string str, string format)
        {
            if (DateTime.TryParseExact(str, format,
                           DataConverterCultureInfo,
                           System.Globalization.DateTimeStyles.None,
                           out DateTime value))
            {
                return value;
            }
            return null;
        }
        public static decimal? GetDecimal(string str)
        {
            if (decimal.TryParse(str?.Replace(",","."), NumberStyles.Any, new CultureInfo("en-US"), out decimal value))
            {
                return value;
            }
            return null;
        }
        public static int? GetInt(string str)
        {
            if (int.TryParse(str?.Replace(",", "."), NumberStyles.Integer, new CultureInfo("en-US"), out int value))
            {
                return value;
            }
            return null;
        }
        public static double? GetDouble(string str)
        {
            if (double.TryParse(str?.Replace(",", "."), NumberStyles.Any, new CultureInfo("en-US"), out double value))
            {
                return value;
            }
            return null;
        }
    }
}