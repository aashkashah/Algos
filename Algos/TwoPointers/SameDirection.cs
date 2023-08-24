using System.Collections.Generic;
using static Algos.LinkedList;

namespace Algos.TwoPointers
{
    public class SameDirection
    {
        public int RemoveDuplicates(List<int> arrList)
        {
            int slow = 0;
            for(int fast = 0; fast < arrList.Count; fast++)
            {
                if(arrList[slow] != arrList[fast])
                {
                    slow++;
                    arrList[slow] = arrList[fast];
                }
            }
            return slow + 1;
        }

        public void Main()
        {
            ListNode node = LinkedList.CreateLinkedList();

        }
    }
}
