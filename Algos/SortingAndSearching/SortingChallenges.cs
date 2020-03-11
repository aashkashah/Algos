using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using Lucene.Net.Util;

namespace Algos
{
    class SortingChallenges
    {
        static int[] SortColors(int[] nums)
        {
            //// 1-pass
            //int p1 = 0, p2 = nums.Length - 1, index = 0;
            //while (index <= p2)
            //{
            //    if (nums[index] == 0)
            //    {
            //        nums[index] = nums[p1];
            //        nums[p1] = 0;
            //        p1++;
            //    }
            //    if (nums[index] == 2)
            //    {
            //        nums[index] = nums[p2];
            //        nums[p2] = 2;
            //        p2--;
            //        index--;
            //    }
            //    index++;
            //}

            //return nums;

            int len = nums.Length;

            int left = 0;
            int right = len - 1;
            int current = 0;
            while (current <= right)
            {
                if (nums[current] == 0)
                {
                    //swap(nums, left, current);
                    int temp = nums[left];
                    nums[left] = nums[current];
                    nums[current] = temp;
                    left++;
                    current++;
                }
                else if (nums[current] == 1)
                {
                    current++;
                }
                else
                {
                    //swap(nums, right, current);
                    int temp = nums[right];
                    nums[right] = nums[current];
                    nums[current] = temp;
                    right--;
                }
            }
           
            return nums;
        }

        public void Main()
        {
            int[] arr = new int[] { 2, 0, 2, 1, 1, 0 };
            var res = SortColors(arr);

            Console.WriteLine(res);
            Console.ReadLine();

        }
    }
}
