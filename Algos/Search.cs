using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    class Search
    {
        static long minTime(long[] machines, long goal)
        {
            long product = 0;
            for (int day = 1; ; day++)
            {
                for (int m = 0; m < machines.Length; m++)
                {
                    if (day % machines[m] == 0)
                    {
                        product++;
                    }
                    if (product == goal)
                    {
                        return day;
                    }
                }
            }
        }


        public static void Main(string[] args)
        {
            long days = minTime(new long[] { 1, 3, 4 }, 10);
            Console.WriteLine(days);
            Console.ReadLine();
        }
    }
}
