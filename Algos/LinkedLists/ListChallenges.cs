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

        static ListNode ReversePartOfLinkedList(ListNode node, int m , int n)
        {
            ListNode prev = null;
            ListNode current = node;
            ListNode next = null;

            return node;
        }

        /// Modify the linked list so that all even elements appear before odd elements
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

        /// <summary>
        /// https://leetcode.com/explore/interview/card/top-interview-questions-easy/93/linked-list/771/
        /// </summary>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode head = new ListNode() { data = 0 };
            ListNode tail = head;

            while (l1 != null && l2 != null)
            {
                if (l1.data < l2.data)
                {
                    tail.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    tail.next = l2;
                    l2 = l2.next;
                }
                tail = tail.next;
            }

            if (l1 == null)
            {
                tail.next = l2;
            }

            if (l2 == null)
            {
                tail.next = l1;
            }

            return head.next;
        }

        
        public ListNode sortedMerge(ListNode headA, ListNode headB)
        {

            /* a dummy first node to  
            hang the result on */
            ListNode dummyNode = new ListNode() { data = 0 };

            /* tail points to the  
            last result node */
            ListNode tail = dummyNode;

            while (true)
            {

                /* if either list runs out,  
                use the other list */
                if (headA == null)
                {
                    tail.next = headB;
                    break;
                }
                if (headB == null)
                {
                    tail.next = headA;
                    break;
                }

                /* Compare the data of the two  
                lists whichever lists' data is  
                smaller, append it into tail and  
                advance the head to the next Node  
                */
                if (headA.data <= headB.data)
                {
                    tail.next = headA;
                    headA = headA.next;
                }
                else
                {
                    tail.next = headB;
                    headB = headB.next;
                }

                /* Advance the tail */
                tail = tail.next;
            }

            return dummyNode.next;
        }

        /// <summary>
        /// https://leetcode.com/explore/interview/card/top-interview-questions-medium/107/linked-list/783/#
        /// </summary>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode res = new ListNode();
            ListNode head = res;
            int carry = 0;

            while (l1 != null && l2 != null)
            {
                int sum = l1.data + l2.data + carry;
                if (sum / 10 == 1)
                {
                    carry = 1;
                    sum = sum % 10;
                }
                else 
                {
                    carry = 0;
                }
                

                ListNode node = new ListNode() { data = sum };
                res.next = node;
                res = res.next;
                
                l1 = l1.next;
                l2 = l2.next;
            }

            while (l1 != null)
            {
                int sum = l1.data + carry;
                if (sum / 10 == 1)
                {
                    carry = 1;
                    sum = sum % 10;
                }
                else 
                {
                    carry = 0;
                }

                ListNode node = new ListNode() { data = sum };
                res.next = node;
                res = res.next;

                l1 = l1.next;
            }

            while (l2 != null)
            {
                int sum = l2.data + carry;
                if (sum / 10 == 1)
                {
                    carry = 1;
                    sum = sum % 10;
                }
                else
                {
                    carry = 0;
                }

                ListNode node = new ListNode() { data = sum };
                res.next = node;
                res = res.next;

                l2 = l2.next;
            }

            if (carry == 1)
            {
                ListNode node = new ListNode() { data = carry };
                res.next = node;
            }


            return head.next;
        }


        public void Main()
        {
            ListNode node = LinkedList.CreateLinkedList();
            //node = ReverseLinkedList(node);

            //node = EvenAndOddList(node);


            ListNode llist = new ListNode()
            {
                data = 2,
                next = new ListNode()
                {
                    data = 9,
                    next = new ListNode()
                    {
                        data = 3
                    }
                }
            };

            ListNode llist2 = new ListNode()
            {
                data = 5,
                next = new ListNode()
                {
                    data = 9,
                    next = new ListNode()
                    {
                        data = 4
                    }
                }
            };

            //var res = MergeTwoLists(llist, llist2);

            //var res = sortedMerge(llist, llist2);

            var res = AddTwoNumbers(llist, llist2);

            Console.ReadLine();
            Console.WriteLine();

        }
    }
}
