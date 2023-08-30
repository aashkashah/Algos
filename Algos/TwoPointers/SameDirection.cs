using System.Collections.Generic;
using static Algos.LinkedList;

namespace Algos.TwoPointers
{
    public class SameDirection
    {
        public int RemoveDuplicates(List<int> arr)
        {
            int slow = 0;
            for(int fast = 0; fast < arr.Count; fast++)
            {
                if (arr[fast] != arr[slow])
                {
                    slow++;
                    arr[slow] = arr[fast];
                }
            }
            return slow + 1; ;
        }

        public int MiddleOfList(ListNode node)
        {
            ListNode slow = node;
            ListNode fast = node;

            while(fast != null  && fast.next != null) 
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow.data;
        }

        public int MoveZeros(List<int> arr)
        {
            int slow = 0;
            for(int fast = 0; fast < arr.Count; fast ++) 
            {
                if (arr[fast] != 0)
                {
                    int temp = arr[slow];
                    arr[slow] = arr[fast];
                    arr[fast] = temp;
                    slow++;
                }
            }
            return 0;
        }

        public void Main()
        {

        }
    }
}
