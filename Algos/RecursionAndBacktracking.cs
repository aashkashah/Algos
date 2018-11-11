using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    class RecursionAndBacktracking
    {

        static int totalStepPerms = 0;

        static int Fibonacci(int num)
        {
            if(num == 0)
            {
                return 0;
            }
            if(num == 1)
            {
                return 1;
            }
            else
            {
                int result =  Fibonacci(num - 1) + Fibonacci(num - 2);
                return result;
            }
        }

        static int stepPerms(int totalStairCases, int[] noOfStairs)
        {
            for (int i = 0; i < totalStairCases; i++)
            {
                stepsHelper(noOfStairs[i], 0, 0);
            }
            // how to not use global variable ?
            return totalStepPerms;
        }

        static int stepsHelper(int stairs, int currSum, int totalWays)
        {
            for (int i = 1; i <= 3; i++)
            {
                if (stairs == currSum)
                {
                    totalStepPerms++;
                    return 1;
                }
                if (currSum + i > stairs)
                {
                    return 0;
                }

                // explore
                stepsHelper(stairs, currSum + i, totalWays);
            }
            return totalStepPerms;
        }

        static int SuperDigit(int n, int k)
        {
            // can you write this recursively ? 
            // that's the whole point of this exercise
            int total = k * SuperDigitHelper(n);

            while (total / 10 != 0)
            {
                total = SuperDigitHelper(total);
            }

            return total;
        }

        static int SuperDigitHelper(int n)
        {
            int total = 0;
            while (n != 0)
            {
                total += n % 10;
                n = n / 10;
            }

            return total;
        }

        
        // Takes a string and returns all permutations  
        static void PermuteString(string strToPermute)
        {
            PermuteHelper(strToPermute, "");
        }

        static void PermuteHelper(string s, string chosen)
        {
            // base case
            if (string.IsNullOrEmpty(s))
            {
                Console.WriteLine(chosen);
            }
            else
            {
                for (int i = 0; i < s.Length; i++)
                {
                    // choose
                    char c = s[i];
                    chosen += c;
                    s = s.Remove(i, 1);

                    // explore
                    PermuteHelper(s, chosen);

                    // un choose
                    s = s.Insert(i, c.ToString());
                    chosen = chosen.Remove(chosen.Length - 1, 1);
                }
            }
        }

        // Finds all binary combinations of a given number
        static void PrintBinary(int num)
        {
            PrintBinaryHelper(num, "");
        }

        static void PrintBinaryHelper(int num, string binary)
        {
            // base case
            if (num == 0)
            {
                Console.WriteLine(binary);
            }
            else // recursive steps
            {   
                PrintBinaryHelper(num - 1, binary + "0");

                PrintBinaryHelper(num - 1, binary + "1");
            }

        }

        // Finds all decimal combinations of a given number
        static void PrintDecimal(int num)
        {
            PrintDecimalHelper(num, "");
        }

        static void PrintDecimalHelper(int num, string dec)
        {
            // base case
            if (num == 0)
            {
                Console.WriteLine(dec);
            }
            else // recusrsive steps
            {
                for (int i = 0; i <= 9; i++)
                {
                    PrintDecimalHelper(num - 1, dec + i);
                }
            }
        }

        static void Sublists(List<string> list)
        {

        }

        static void SublistsHelper(List<string> list, List<string> chosen)
        {
            // base

            // recursive

            // choose
            string s = list[0];
            chosen.Add(s);
            list.RemoveAt(0);
            
            // explore
            SublistsHelper(list, chosen);

            // un choose
            chosen.RemoveAt(0);
            list.Add(s);
        }

        public static void Main(string[] args)
        {
            //int fib = Fibonacci(6);
            //Console.WriteLine(fib);
            
            //int totalStepWays = stepPerms(2, new int[] {5, 1});
            //Console.WriteLine(totalStepWays);

            //int superDigit = SuperDigit(148, 5);
            //Console.WriteLine(superDigit);

            //PermuteString("MARTY");

            //PrintBinary(3);

            //PrintDecimal(2);
            
            Console.ReadLine();

        }
    }
}
