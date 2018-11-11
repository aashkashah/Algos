using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    class StackAndQueue
    {
        static string AreBracketsBalanced(string s)
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

        static int MinimumMoves(string[][] grid, int startX, int startY, int goalX, int goalY)
        {
            // GetNextNeighbors

            // bfs to find the min route



            return int.MinValue;
        }

        public static void Main2(string[] args)
        {
            string isBalanced = AreBracketsBalanced("[{}]");
            Console.WriteLine(isBalanced);
        }

    }
}
