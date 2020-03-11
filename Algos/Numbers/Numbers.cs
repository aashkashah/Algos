using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Algos
{
    public class Numbers
    {
        static string KiloFormat(int num)
        {
            if (num >= 100000000)
                return (num / 1000000).ToString("#,0M");

            if (num >= 10000000)
                return (num / 1000000).ToString("0.#") + "M";

            if (num >= 100000)
                return (num / 1000).ToString("#,0K");

            if (num >= 10000)
                return (num / 1000).ToString("0.#") + "K";

            return num.ToString("#,0");
        }

        private static readonly SortedDictionary<int, string> numberLookup = new SortedDictionary<int, string>
        {
             {1000,"K"},
             {1000000, "M" },
             {1000000000, "B" }
        };

        public static string ShortFormNumber(float number)
        {
            for (int i = numberLookup.Count - 1; i >= 0; i--)
            {
                var pair = numberLookup.ElementAt(i);
                if (Math.Abs(number) >= pair.Key)
                {
                    int roundNum = (int)Math.Floor(number / pair.Key);

                    return roundNum.ToString() + pair.Value;
                }
            }
            return number.ToString();
        }

        public static string ToShortNumber(decimal num)
        {
            var result = num.ToString(CultureInfo.InvariantCulture);

            if (num > 999999999 || num < -999999999)
            {
                result = num.ToString("0,,,.#B", CultureInfo.InvariantCulture);

                if (result.Length > 4)
                {
                    result = num.ToString("0,,,B", CultureInfo.InvariantCulture);
                }
            }
            else if (num > 999999 || num < -999999)
            {
                result = num.ToString("0,,.#M", CultureInfo.InvariantCulture);

                if (result.Length > 4)
                {
                    result = num.ToString("0,,M", CultureInfo.InvariantCulture);
                }

            }
            else if (num > 999 || num < -999)
            {
                result = num.ToString("0,.#K", CultureInfo.InvariantCulture);
            }

            return result;
        }

        public void Main()
        {
            var res1 = ToShortNumber(123456789);
            var res2 = ToShortNumber(1934567890);
            var res3 = ToShortNumber(1934567890);

            Console.WriteLine(res3);
            Console.ReadLine();
        }
    }
}
