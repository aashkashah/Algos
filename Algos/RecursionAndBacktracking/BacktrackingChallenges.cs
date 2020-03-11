using System;
using System.Collections.Generic;

namespace Algos
{
    class BacktrackingChallenges
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
        
        /// Takes a string and returns all permutations  
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

        /// Finds all binary combinations of a given number
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

        /// Finds all decimal combinations of a given number
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
            else
            {
                // recusrsive steps
                for (int i = 0; i <= 9; i++)
                {
                    PrintDecimalHelper(num - 1, dec + i);
                }
            }
        }

        /// Find all sublists of a given list
        static void Sublists(List<string> list)
        {
            SublistsHelper(list, new List<string>());
        }

        static void SublistsHelper(List<string> list, List<string> chosen)
        {
            // base
            if (list.Count == 0)
            {
                Console.WriteLine(chosen);
            }
            else
            {   // recursive
                for (int i = 0; i < list.Count; i++)
                {
                    // choose
                    string s = list[i];
                    list.RemoveAt(i);

                    // explore with
                    chosen.Add(s);
                    SublistsHelper(list, chosen);

                    // explore without
                    chosen.RemoveAt(i);
                    SublistsHelper(list, chosen);

                    // un choose
                    list.Add(s);
                }
            }
        }

        /// Find all possible dice roll combinations
        /// for a number of dice
        static void DiceRoll(int num)
        {
            //DiceRollHelper(num, new List<int>());
            DiceRollWithMaxSumHelper(num, 0, 5, new List<int>());
        }

        static void DiceRollHelper(int dice, List<int> selection)
        {
            // base
            if (dice == 0)
            {
                string s = string.Empty;
                selection.ForEach((elem) => { s += " " + elem.ToString(); });
                Console.WriteLine(s);
            }
            // recursive steps
            else
            {
                for (int i = 1; i <= 6; i++)
                {
                    // choose
                    selection.Add(i);

                    // explore
                    DiceRollHelper(dice - 1, selection);

                    // un-choose
                    selection.Remove(i);
                }
            }

        }

        /// Find all dice roll combinations that are less than a given number
        static void DiceRollWithMaxSumHelper(int dice, int currSum, int maxSum, List<int> selection)
        {
            // base
            if (dice == 0) 
            {
                string s = string.Empty;
                selection.ForEach((elem) => { s += " " + elem.ToString(); });
                Console.WriteLine(s);
            }
            // recursive steps
            else
            {
                for (int i = 1; i <= 6; i++)
                {
                    if (currSum + i <= maxSum)
                    {
                        // choose
                        selection.Add(i);
                        currSum += i;

                        // explore
                        DiceRollWithMaxSumHelper(dice - 1, currSum, maxSum, selection);

                        // un-choose
                        selection.Remove(i);
                        currSum -= i; // ?
                    }
                }
            }
           
        }

        static void SumOfSubsets(int[] arr)
        {
            List<int> arrList = new List<int>();
            arrList.AddRange(arr);

            SubsetsHelper(arrList, new List<int>());
        }
        
        static void SubsetsHelper(List<int> arr, List<int> chosen)
        {
            // base case
            if (arr.Count == 0)
            {
                // print sum
                for (int i = 0; i < chosen.Count; i++)
                {
                    Console.Write(chosen[i] + " ");
                }
                Console.WriteLine();
            }
            // recursive case
            else
            {
                for (int i = 0; i < arr.Count; i++)
                {
                    // choose
                    int elem = arr[i];
                    arr.Remove(elem);
                    
                    // explore with
                    chosen.Add(elem);
                    SubsetsHelper(arr, chosen);

                    // explore without
                    chosen.Remove(elem);
                    SubsetsHelper(arr, chosen);

                    // un-choose
                    arr.Add(elem);
                }

            }
        }

        static List<string> GenerateParenthesis(int n)
        {
            List<string> ans = new List<string>();
            GenerateParanthesisHelper(ans, "", 0, 0, n);

            return ans;
        }

        static void GenerateParanthesisHelper(List<string> ans, string cur, int open, int close, int max)
        {
            if (cur.Length == max * 2)
            {
                ans.Add(cur);
                return;
            }

            if (open < max)
            {
                GenerateParanthesisHelper(ans, cur + "(", open + 1, close, max);
            }
            if (close < max)
            {
                GenerateParanthesisHelper(ans, cur + ")", open, close + 1, max);
            }
        }

        static IList<string> LetterCombinations(string digits)
        {
            PhoneNumerHelper(digits.ToCharArray(), new List<string>(), "", 0);
            return null;
        }

        static void PhoneNumerHelper(char[] digits, List<string> result, string current, int index)
        {
            if (digits.Length == index)
            {   
                result.Add(current);
                return;
            }

            var letters = GetOptions(digits[index]);
            for (int i = 0; i < letters.Count; i++)
            {   
                PhoneNumerHelper(digits, result, current + letters[i], index + 1);
            }

        }

        static List<char> GetOptions(char number)
        {
            switch (number)
            {
                case '2':
                    return new List<char> { 'a', 'b', 'c' };
                    
                case '3':
                    return new List<char> { 'd', 'e', 'f' };

                case '4':
                    return new List<char> { 'g', 'h', 'i' };

                case '5':
                    return new List<char> { 'j', 'k', 'l', 'm' };

                default:
                    return null;
            }
        }

        /// <summary>
        /// https://leetcode.com/explore/interview/card/top-interview-questions-medium/109/backtracking/795/
        /// Given a collection of distinct integers, return all possible permutations.
        /// </summary>
        static List<List<int>> PermuteDigits(int[] nums)
        {
            List<int> numList = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                numList.Add(nums[i]);
            }

            List<List<int>> res = new List<List<int>>();
            PermuteDigitsHelper(res, new List<int>(), numList);

            return res;
        }

        static void PermuteDigitsHelper(List<List<int>> result, List<int> curr, List<int> nums)
        {
            if (nums.Count == 0)
            {
                result.Add(curr);
                return;
            }
            // recursive

            for (int i = 0; i < nums.Count; i++)
            {
                var elem = nums[i];
                curr.Add(nums[i]);
                nums.Remove(elem);

                PermuteDigitsHelper(result, curr, nums);

                nums.Add(elem);
                curr.Remove(elem);
            }
        }

        /// <summary>
        /// https://leetcode.com/problems/combination-sum/
        /// </summary>
        static List<List<int>> CombinationSum(int[] candidates, int target)
        {
            List<List<int>> result = new List<List<int>>();
            CombinationSumHelper(candidates, 0, target, new List<int>(), ref result);

            return result;
        }

        static void CombinationSumHelper(int[] nums, int start, int remain, List<int> currList, ref List<List<int>> res)
        {
            if (remain < 0) return;
            if (remain == 0)
            {
                // end
                res.Add(currList);
                return;
            }
            // recursive
            for (int i = start; i < nums.Length; i++)
            {   
                var elem = nums[i];
                // choose
                currList.Add(nums[i]);

                // explore
                CombinationSumHelper(nums, i, remain - nums[i], currList, ref res);

                // unchoose
                currList.Remove(elem);
                
            }

        }


        public void Main()
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

            //List<string> list = new List<string>() { "Jane", "Marty", "Joe", "Susan" };
            //Sublists(list);

            //DiceRoll(3);

            //SumOfSubsets(new int[] { 2, 4, 5 });

            //LetterCombinations("234");

            //var res = PermuteDigits(new int[] { 1, 2, 3 });

            var res = CombinationSum(new int[] { 2, 3, 5 }, 8);

            Console.ReadLine();

        }
    }
}
