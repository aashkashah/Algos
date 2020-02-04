﻿using System;
using System.Collections.Generic;


namespace Algos
{
    public class MergeLists
    {
        /// Given two sorted lists in increasing order, merge them in reverse   
        static List<int> MergeListsInreverse(List<int> list1, List<int> list2)
        {
            List<int> result = new List<int>();

            Stack<int> stack1 = CreateStackFromList(list1);
            Stack<int> stack2 = CreateStackFromList(list2);
            
            while (stack1.Count > 0 && stack2.Count > 0)
            {
                if (stack1.Peek() > stack2.Peek())
                {
                    result.Add(stack1.Pop());
                }
                else if (stack2.Peek() > stack1.Peek())
                {
                    result.Add(stack2.Pop());
                }
            }

            AddElemToListFromStack(stack1, ref result);
            AddElemToListFromStack(stack2, ref result);
            
            return result;

        }

        /// Helper method for merging two lists in reverse
        /// Creates and returns a stack from list
        static Stack<int> CreateStackFromList(List<int> list)
        {
            Stack<int> stack = new Stack<int>();
            foreach (int elem in list)
            {
                stack.Push(elem);
            }

            return stack;
        }

        /// Helper method for merging two lists in reverse
        /// Adds element to list from a stack until empty
        static void AddElemToListFromStack(Stack<int> stack, ref List<int> list)
        {
            while (stack.Count > 0)
            {
                list.Add(stack.Pop());
            }
        }

        static List<int> MergeList(List<int> list1, List<int> list2)
        {
            int i = 0; int j = 0;
            List<int> result = new List<int>();

            while(i < list1.Count && j < list2.Count) 
            {
                if(list1[i] < list2[j]) 
                {
                    result.Add(list1[i]);
                    i++;
                }
                else 
                {
                    result.Add(list2[j]);
                    j++;
                }
            }

            if(i < list1.Count) 
            {
                AppendListToAnother(list1, i, ref result);
            }

            if(j < list2.Count) 
            {
                AppendListToAnother(list2, j, ref result);
            }

            return result;
        }

        private static void AppendListToAnother(List<int> list, int index, ref List<int> output) 
        {
            while (index < list.Count)
            {
                output.Add(list[index]);
                index++;
            }
        }

        public void Main_Stack()
        {
            var result = MergeListsInreverse(new List<int>() { 5, 10, 15, 40 }, new List<int>() { 2, 3, 20 });
            var result2 = MergeList(new List<int>() { 5, 10, 15, 40 }, new List<int>() { 2, 3, 20 });
            
            foreach (var res in result)
            {
                Console.Write(res + " ");
            }
        }

    }
}
