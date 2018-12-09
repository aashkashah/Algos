using System;
using System.Collections.Generic;

namespace Algos
{
    public class SlidingWindow
    {
        /// Finds the maximum sum in a specified window length of an array
        public int FindMaxSumInAWindow(int[] arr, int windowLen)
        {
            int max = 0;
            int windowSum = 0;

            for (int i = 0; i < windowLen; i++)
            {
                windowSum += arr[i];
            }

            max = windowSum;

            for (int i = 0; i < arr.Length - windowLen; i++)
            {
                windowSum = windowSum - arr[i] + arr[i + windowLen];
                if (windowSum > max)
                {
                    max = windowSum;
                }
            }

            return max;
        }

        /// Find maximum number of unique elements in a specified window of an array
        /// https://www.geeksforgeeks.org/maximum-number-of-unique-integers-in-sub-array-of-given-size/
        static int FindMaxUniqueElemInSubArray(int[] arr, int windowLen)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            int maxUniqueElem = 0;
            int uniqueElem = 0;

            for (int i = 0; i < windowLen; i++)
            {   
                if (dictionary.ContainsKey(arr[i]))
                {
                    dictionary[arr[i]] = dictionary[arr[i]] + 1;
                }
                else
                {
                    dictionary.Add(arr[i], 1);
                    uniqueElem++;
                }
            }

            maxUniqueElem = uniqueElem;

            for (int i = 0; i < arr.Length - windowLen; i++)
            {
                // remove element form last window
                int val = dictionary[arr[i]];

                if (val == 0)
                {
                    dictionary.Remove(arr[i]);
                }
                else
                {
                    dictionary[arr[i]] = val - 1;
                }

                if (dictionary.ContainsKey(arr[i + windowLen]))
                {
                    val = dictionary[arr[i + windowLen]];
                    dictionary[arr[i + windowLen]] = val + 1;
                }
                else
                {
                    dictionary.Add(arr[i + windowLen], 1);
                }

                uniqueElem = dictionary.Count;

                if (uniqueElem > maxUniqueElem)
                {
                    maxUniqueElem = uniqueElem;
                }

            }

            return maxUniqueElem;
        }

        public void Main(string[] args)
        {
            //var maxLen = FindMaxSumInAWindow(new int[] { 1, 4, 2, 10, 23, 3, 1, 0, 20 }, 4);
            //var maxLen2 = FindMaxSumInAWindow(new int[] { 100, 200, 300, 400 }, 2);

            var maxUniqueElem = FindMaxUniqueElemInSubArray(new int[] { 5, 3, 5, 3, 2, 5 }, 3);
          
            Console.WriteLine(maxUniqueElem);
        }
    }
}
