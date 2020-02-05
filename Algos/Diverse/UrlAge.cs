using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public class UrlAge
    {

        public static readonly DateTime ReferenceTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        static ulong FindUrlAge(string urlReleaseDate)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            Double releaseDateDbl;
            Double.TryParse(urlReleaseDate, out releaseDateDbl);
            var res = epoch.AddSeconds(releaseDateDbl);

            var temp = DateTime.Now - res;

            return (ulong)temp.TotalDays;


        }

        static DateTime? FindUrlDate(string unixTime)
        {
            Double parsedUnixTime;
            if (string.IsNullOrEmpty(unixTime) && Double.TryParse(unixTime, out parsedUnixTime))
            {
                return ReferenceTime.AddSeconds(parsedUnixTime);
            }
            else
            {
                return null;
            }
        }

        static string ExtractReleaseDateFromUrl(string url)
        {
            var relaseDate = string.Empty;
            if (url.Contains("release") && url.Count() > 32)
            {
                relaseDate = url.Substring(32, 10);
            }

            return relaseDate;
        }

        static bool TestingFullFlow(string sourceUrl)
        {
            var releaseDateStr = ExtractReleaseDateFromUrl(sourceUrl);
            Double releaseDate;

            if (releaseDateStr != string.Empty && Double.TryParse(releaseDateStr, out releaseDate))
            {
                var epochToDate = ReferenceTime.AddSeconds(releaseDate);
                TimeSpan urlAge = (DateTime.Now.ToUniversalTime() - epochToDate);

                // if url age is greater than 4 days, add a drop reason and return
                if (urlAge.Days > 4)
                {
                    return false;
                }
            }

            return true;
        }

        static string ConvertDateTimeToEpoch(DateTime date)
        {
            //var res = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();

            var res = (DateTime.UtcNow - ReferenceTime).TotalSeconds.ToString();
            var index = res.IndexOf('.');

            res = res.Substring(0, index);

            return res.ToString();
        }

        static string FormatDate(DateTime date)
        {
            var epoch = new DateTime(2009, 1, 1);
            var res = epoch.AddDays(4045).ToString("yyyy_MM_dd");
            
            return res;
        }

        static DateTime GetMaxDate(DateTime? releaseDate, DateTime? urlDate, DateTime? serpDate = null)
        {
            DateTime minDate = DateTime.MaxValue;

            List<DateTime> dateList = new List<DateTime>();

            if (releaseDate.HasValue) dateList.Add(releaseDate.Value);
            if (urlDate.HasValue) dateList.Add(urlDate.Value);
            if (serpDate.HasValue) dateList.Add(serpDate.Value);
            
            foreach(DateTime date in dateList)
            {
                if (date < minDate)
                    minDate = date;
            }

            return minDate;
        }

        public static double ConvertStringToDouble(string str)
        {
            Double parsedValue;
            if (!string.IsNullOrEmpty(str) && Double.TryParse(str, out parsedValue))
            {
                return parsedValue;
            }

            return 0;
        }

        public static int? ConvertStringToInt(string str)
        {
            int parsedValue;
            if (!string.IsNullOrEmpty(str) && int.TryParse(str, out parsedValue))
            {   
                return parsedValue;
            }

            return null;
        }

        public static DateTime? GetDateFromUnixTime(int? videoReleaseDateInUnixTimeInt)
        {   
            if (videoReleaseDateInUnixTimeInt != null)
            {   
                return ReferenceTime.AddSeconds((double)videoReleaseDateInUnixTimeInt);
            }
            else
            {
                return null;
            }
        }

        /// <returns>Release date if present</returns>
        private static string ExtractReleaseDateFromSourceUrl(string url)
        {
            // TODO: really we should parse via Uri class but for now the urls are in fixed format
            const string releasePrefix = "release=";
            int ix = url.IndexOf(releasePrefix);
            if (ix < 0) return null;
            ix += releasePrefix.Length;
            int ixEnd = url.IndexOf("&", ix);
            return (ixEnd < 0) ? url.Substring(ix) : url.Substring(ix, ixEnd - ix - 1);
        }

        private static DateTime? GetMaxDateFromURL(string url)
        {
            List<DateTime> dateList = new List<DateTime>();
            if (dateList.Count == 0)
                return null;
            else
                return dateList.ElementAt(0);
        }

        private static bool IsUrlOld(DateTime date)
        {
            if (date < DateTime.Now.AddDays(-4))
                return true;
            else
                return false;
        }

        public void Main()
        {
            //var res = FindUrlDate("1310771851");

            //var res = ExtractReleaseDateFromUrl("https://googleapis.com/?release=1310771851");
            //var res = ExtractReleaseDateFromUrl("https://googleapis.com/?release=");

            //var res = TestingFullFlow("https://googleapis.com/?release=131077185&");

            //var res = ConvertDateTimeToEpoch(DateTime.Now);

            var res = FormatDate(DateTime.Now);

            //var res = GetMaxDate(DateTime.Now.AddDays(-10), DateTime.Now.AddDays(20), DateTime.Now.AddDays(5));
            //var res = GetMaxDate(null,null);

            //var res = ConvertStringToInt("1580497772");

            //var res = GetDateFromUnixTime(null);

            //var res = ExtractReleaseDateFromSourceUrl("https://googleapis.com/?release=1310771851");

            Console.WriteLine(res);
        }
    }
}
