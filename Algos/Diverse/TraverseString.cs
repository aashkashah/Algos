using System;
using System.Collections.Generic;
using System.Text;

namespace Algos
{
	public class Test
	{
		public static string TraverseString(string str)
		{
			Stack<char> stack = new Stack<char>();
			char[] charArr = str.ToCharArray();
			
			StringBuilder res = new StringBuilder();

			// abc{def}gh
			for (int i = 0; i < charArr.Length; i++)
			{	
				if (charArr[i] == '}')
				{
					// pop
					if (stack.Count > 0)
					{
						char nextElem = stack.Peek();
						while (nextElem != '{')
						{
							res.Append(stack.Pop());
							nextElem = stack.Peek();
						}
						stack.Pop();
					}
					else
					{
						throw new Exception("Invalid string");
					}
				}
				else if (charArr[i] == '{')
				{	
					// push
					stack.Push(charArr[i]);
				}
				else
				{
					if (stack.Count > 0)
					{
						stack.Push(charArr[i]);
					}
					else
					{
						res.Append(charArr[i]);
					}
				}

			}

			if(stack.Count > 0)
			{
				throw new Exception("Invalid string");
			}

			return res.ToString();
		}

		public static string TraverseString2(string str)
		{
			Stack<char> stack = new Stack<char>();
			char[] charArr = str.ToCharArray();

			var result = new StringBuilder();

			for (int i = 0; i < charArr.Length; i++)
			{
				if (charArr[i] == '}')
				{
					if (stack.Count > 0)
					{
						// pop everything out until you encounter '{'
						char nextElem = stack.Peek();
						Queue<char> queue = new Queue<char>();

						while (nextElem != '{')
						{
							queue.Enqueue(stack.Pop());
							nextElem = stack.Peek();
						}

						// pop '{'
						stack.Pop();

						// if there's still values in stack
						if (stack.Count > 0)
						{
							while (queue.Count > 0)
							{
								stack.Push(queue.Dequeue());
							}
						}
						else
						{
							while (queue.Count > 0)
							{
								result.Append(queue.Dequeue());
							}
						}

					}
					else
					{
						return "Invalid string";
					}
				}
				else if (charArr[i] == '{' || stack.Count > 0)
				{
					stack.Push(charArr[i]);
				}
				else
				{
					result.Append(charArr[i]);
				}

			}

			if (stack.Count > 0)
			{
				return "Invalid string";
			}

			return result.ToString();

		}

		public void Main(string[] args)
		{
			string res = TraverseString2("abc{def}}gh"); // invalid
			string res2 = TraverseString2("abc{{def}}gh");
			string res3 = TraverseString2("abc{{def}}{gh}");
			string res4 = TraverseString2("{abc{{def}}{gh}}"); // {abc{fed}hg} {abcdefhg} ghfedcba
			string res5 = TraverseString2("{abc{{def}}{gh}"); // invalid
			string res6 = TraverseString2("");

			Console.WriteLine(res5);

		}

	}
}
