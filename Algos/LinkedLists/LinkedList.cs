using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public class LinkedList
    {
        public class ListNode
        {
            public ListNode next;
            public int data;
        }

        public static ListNode CreateLinkedList()
        {
            ListNode llist = new ListNode()
            {
                data = 2,
                next = new ListNode()
                {
                    data = 7,
                    next = new ListNode()
                    {
                        data = 3,
                        next = new ListNode()
                        {
                            data = 4,
                            next = new ListNode()
                            {
                                data = 5,
                                next = new ListNode()
                                {
                                    data = 6
                                }
                            }
                        }
                    }
                }
            };

            return llist;
        }
    }
}
