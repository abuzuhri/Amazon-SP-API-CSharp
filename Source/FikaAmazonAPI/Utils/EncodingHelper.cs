using System.Globalization;
using System.Text;

namespace FikaAmazonAPI.Utils
{
    public static class EncodingHelper
    {
        public static Encoding GetEncodingFromCulture(CultureInfo culture)
        {
            string cultureName = culture.Name.ToLower();

            return cultureName switch
            {
                "en-us" => Encoding.GetEncoding("Windows-1252"), // Westeuropa (ANSI)
                "de-de" => Encoding.GetEncoding("Windows-1252"), // Westeuropa (ANSI)
                "fr-fr" => Encoding.GetEncoding("Windows-1252"), // Westeuropa (ANSI)
                "ja-jp" => Encoding.GetEncoding("shift_jis"), // Japanisch
                "zh-cn" => Encoding.GetEncoding("gb2312"), // Vereinfachtes Chinesisch
                "ru-ru" => Encoding.GetEncoding("Windows-1251"), // Kyrillisch
                "ko-kr" => Encoding.GetEncoding("ks_c_5601-1987"), // Koreanisch
                "ar-sa" => Encoding.GetEncoding("Windows-1256"), // Arabisch
                _ => Encoding.UTF8 // Standard als Fallback
            };
        }
    }
}
