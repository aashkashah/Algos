using System;
using System.Collections.Generic;
using ListNode = Algos.LinkedList.ListNode;

namespace Algos
{
    public class ListChallenges
    {   
        static ListNode ReverseLinkedList(ListNode node)
        {
            ListNode prev = null;
            ListNode current = node;
            ListNode next = null;

            while (current != null)
            {
                // save next node before changing
                next = current.next;

                // do the reversal
                current.next = prev;

                // set pointers for next iteration
                prev = current;
                current = next;
            }

            node = prev;
            return node;
        }

        /// Modify the linked list so that all even elements appear before odd elementss
        /// Order of appearance of elements must not change
        static ListNode EvenAndOddList(ListNode node)
        {
            ListNode evenStart = null;
            ListNode evenEnd = null;
            ListNode oddStart = null;
            ListNode oddEnd = null;

            while (node != null)
            {
                if (node.data % 2 == 0)
                {
                    if (evenStart == null)
                    {
                        evenStart = node;
                        evenEnd = evenStart;
                    }
                    else
                    {
                        evenEnd.next = node;
                        evenEnd = evenEnd.next;
                    }
                }
                else
                {
                    if (oddStart == null)
                    {
                        oddStart = node;
                        oddEnd = oddStart;
                    }
                    else
                    {
                        oddEnd.next = node;
                        oddEnd = oddEnd.next;
                    }
                }

                node = node.next;
            }

            evenEnd.next = oddStart;
            node = evenStart;

            return node;
        }

        public void Main()
        {
            ListNode node = LinkedList.CreateLinkedList();
            //node = ReverseLinkedList(node);

            node = EvenAndOddList(node);

            Console.WriteLine();

        }
    }
}
