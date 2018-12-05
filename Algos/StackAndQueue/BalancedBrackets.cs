using System;
using System.Collections.Generic;

namespace Algos
{
    public class BalancedBrackets
    {
        public static string AreBracketsBalanced(string s)
        {
            Stack<char> stack = new Stack<char>();
            char[] charStr = s.ToCharArray();

            for(int i = 0; i < charStr.Length; i++)
            {
                if (charStr[i] == '{' || charStr[i] == '(' || charStr[i] == '[')
                    stack.Push(charStr[i]);
                else if (charStr[i] == '}' || charStr[i] == ')' || charStr[i] == ']')
                {
                    if(stack.Count > 0)
                    {
                        // can refactor the if else nest
                        char elemInStack = stack.Pop();
                        if (charStr[i] == '}')
                        {
                            if (elemInStack != '{')
                                return "NO";
                        }
                        else if (charStr[i] == ')')
                        {
                            if (elemInStack != '(')
                                return "NO";
                        }
                        else if (charStr[i] == ']')
                        {
                            if (elemInStack != '[')
                                return "NO";
                        }
                    }
                    else
                    {
                        return "NO";
                    }
                    
                }
            }
            if(stack.Count > 0)
            {
                return "NO";
            }
            else
            {
                return "YES";
            }
        }

		/// <summary>
		/// Implement a queue using two stacks
		/// 1. Enqueue, 2. Dequeue, 3. Print
		/// </summary>
		/// <param name="totalOperations">Total number of operations</param>
		/// <param name="operations">List of operations</param>
		static void QueueUsingTwoStacks(int totalOperations, List<List<int>> operations)
		{	
			Stack<int> stack = new Stack<int>();

			foreach (List<int> operation in operations)
			{
				if (operation[0] == 1)
				{
					Enqueue(ref stack, operation[1]);
				}
				else if (operation[0] == 2)
				{
					Dequeue(ref stack);
				}
				else
				{
					Print(stack);
				}
			}

		}

		static void Enqueue(ref Stack<int> firstStack, int value)
		{	
			// insert at top of stack
			firstStack.Push(value);
		}

		static int Dequeue(ref Stack<int> stack)
		{
			Stack<int> tempStack = new Stack<int>();

			// reverse and pop top value
			while (stack.Count > 0)
			{	
				tempStack.Push(stack.Pop());
			}

			var firstElem = tempStack.Pop();

			// revese back stack into original
			while (tempStack.Count > 0)
			{
				stack.Push(tempStack.Pop());
			}

			return firstElem;
		}

		static void Print(Stack<int> stack)
		{
			Stack<int> tempStack = new Stack<int>();

			// reverse and pop top value
			while (stack.Count > 0)
			{
				tempStack.Push(stack.Pop());
			}

			var firstElem = tempStack.Pop();

			// revese back stack into original
			while (tempStack.Count > 0)
			{
				stack.Push(tempStack.Pop());
			}

			Console.WriteLine(firstElem);
		}

		public void Main_Stack(string[] args)
		{
            //string isBalanced = AreBracketsBalanced("[{}]");
            //Console.WriteLine(isBalanced);

			QueueUsingTwoStacks(10, new List<List<int>>()
			{
				new List<int>() { 1, 42 },
				new List<int>() { 2 },
				new List<int>() { 1, 14 },
				new List<int>() { 3 },
				new List<int>() { 1, 28 },
				new List<int>() { 3 },
				new List<int>() { 1, 60 },
				new List<int>() { 1, 78 },
				new List<int>() { 2 },
				new List<int>() { 2 }
			});

			Console.ReadLine();
        }

    }
}
