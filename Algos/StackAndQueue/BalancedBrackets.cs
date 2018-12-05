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

        public void Main_Stack(string[] args)
        {
            string isBalanced = AreBracketsBalanced("[{}]");
            Console.WriteLine(isBalanced);
        }

    }
}
