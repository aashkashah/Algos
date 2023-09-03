using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos.TwoPointers
{
    //test
    public class OppositeDirection
    {
        public List<int> TwoSumSorted(List<int> arr, int target)
        {
            int l = 0;
            int r = arr.Count - 1;

            while(l < r)
            {
                int twoSum = arr[l] + arr[r];
                if(twoSum == target)
                {
                    return new List<int> { l, r };
                } 
                else if(twoSum < target)
                {
                    l++;
                }
                else
                {
                    r--;
                }
            }
            return null;
        }

        public bool IsPalindrome(String str)
        {
            char[] arr = str.ToCharArray();
            int l = 0;
            int r = arr.Length - 1;

            while(l < r) 
            {
                while(l < r && !Char.IsLetterOrDigit(arr[l]))
                {
                    l++;
                }
                while(l<r && !Char.IsLetterOrDigit(arr[r]))
                {
                    r++;
                }

                if (Char.ToLower(arr[l]) != Char.ToLower(arr[r])) 
                {
                    return false;
                }
                l++; r++;
            }

            return true;
        }

        public void Main()
        {

        }
    }
}
