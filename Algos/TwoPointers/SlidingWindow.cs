using System;
using System.Collections.Generic;
using System.Linq;

namespace Algos.TwoPointers
{
    public class SlidingWindow
    {

        public int SubarraySumFixed(List<int> nums, int k)
        {
            int windowSum = 0;
            for (int i = 0; i < k; i++)
            {
                windowSum += nums[i];
            }
            int largest = windowSum;
            for (int right = k; right < nums.Count; right++)
            {
                int left = right - k;
                windowSum -= nums[left];
                windowSum += nums[right];
                largest = Math.Max(largest, windowSum);
            }
            return largest;
        }

        public List<int> FindAllAnagrams(string original, string check)
        {
            int originalLen  = original.Length;
            int checkLen = check.Length;
            List<int> res = new List<int>();
            if(originalLen < checkLen) { return res; }

            int[] checkCounter = new int[26];
            int[] window = new int[26];

            for(int i=0; i < checkLen; i++)
            {
                checkCounter[check[i] - 'a']++;
                window[original[i] - 'a']++;
            }

            if (window.SequenceEqual(checkCounter)) res.Add(0);

            for(int i = checkLen; i < originalLen; i++)
            {
                window[original[i - checkLen] - 'a']--;
                window[original[i] - 'a']++;
                if(window.SequenceEqual(checkCounter)) res.Add(i - checkLen + 1);
            }
            return res;
        }

        public int SubarraySumLongest(List<int> nums, int target)
        {
            int windowSum = 0, length = 0;
            int left = 0;

            for(int right = 0; right < nums.Count; right++) 
            {
                windowSum = windowSum + nums[right];
                while(windowSum > target) 
                {
                    windowSum = windowSum - nums[left];
                    left++;
                }
                length = Math.Max(length, right - left + 1);
            }
            return length;
        }

        public static int LengthOfLongestSubstring(string s)
        {
            int n = s.Length;
            HashSet<char> charSet = new HashSet<char>();
            int maxLength = 0, start = 0, end = 0;

            while (end < n)
            {
                if (!charSet.Contains(s[end]))
                {
                    charSet.Add(s[end]);
                    maxLength = Math.Max(maxLength, end - start + 1);
                    end++;
                }
                else
                {
                    charSet.Remove(s[start]);
                    start++;
                }
            }

            return maxLength;
        }

        public int SubarraySumShortest(List<int> nums, int target)
        {
            int n = nums.Count;
            int minLenght = nums.Count;
            int left = 0, windowSum = 0;

            for (int right = 0; right < n; right++)
            {
                windowSum += nums[right];

                while(windowSum >= target)
                {
                    minLenght = Math.Min(minLenght, right - left + 1);
                    windowSum -= nums[left];
                    left++;
                }
            }

            return minLenght;
        }

        public void Main()
        {

        }
    }
}
