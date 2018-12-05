using System;
using System.Collections.Generic;

namespace Algos
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/simple-text-editor/problem
    /// Append, delete, print and undo operations on a string
    /// </summary>
    public class TextEditor
    {
        public enum OperationType { Append, Delete, Print, Undo }

        public class Operation
        {
            public OperationType OperationType;
            public string strAdded;
            public string strRemoved;
            public int charIndex;
        }

        static void Append(ref string s, string strToAppend, Stack<Operation> operationStack, bool isUndo = false)
        {
            s = s + strToAppend;

            if (!isUndo)
            {
                operationStack.Push(new Operation() { OperationType = OperationType.Append, strAdded = strToAppend });
            }
        }

        static void Delete(ref string s, int characters, Stack<Operation> operationStack, bool isUndo = false)
        {
            string strToRemove = s.Substring(s.Length - characters);
            s = s.Remove(s.Length - characters);

            if(!isUndo)
            {
                operationStack.Push(new Operation() { OperationType = OperationType.Delete, strRemoved = strToRemove });
            }
        }

        static void Print(string s, int character)
        {
            Console.WriteLine(s[character - 1]);
        }

        static void Undo(ref string s, ref Stack<Operation> operationStack)
        {
            if (operationStack.Count == 0)
            {
                Console.WriteLine("No operation to undo");
            }

            var operation = operationStack.Pop();

            if (operation.OperationType == OperationType.Append)
            {
                Delete(ref s, operation.strAdded.Length, operationStack, true);
            }
            else if (operation.OperationType == OperationType.Delete)
            {
                Append(ref s, operation.strRemoved, operationStack, true);
            }
        }

        public void Stack_Main(string[] args)
        {
            List<Operation> operations = new List<Operation>();
            Stack<Operation> operationStack = new Stack<Operation>();
            string s = string.Empty;

            operations.AddRange(new List<Operation>()
            {
                new Operation() { OperationType = OperationType.Append, strAdded = "abc" },
                new Operation() { OperationType = OperationType.Print, charIndex = 3 },
                new Operation() { OperationType = OperationType.Delete, charIndex = 3 },
                new Operation() { OperationType = OperationType.Append, strAdded = "xy" },
                new Operation() { OperationType = OperationType.Print, charIndex = 2 },
                new Operation() { OperationType = OperationType.Undo },
                new Operation() { OperationType = OperationType.Undo },
                new Operation() { OperationType = OperationType.Print, charIndex = 1 },
            });

            foreach(Operation operation in operations)
            {
                if (operation.OperationType == OperationType.Append)
                {
                    Append(ref s, operation.strAdded, operationStack);
                }
                else if (operation.OperationType == OperationType.Delete)
                {
                    Delete(ref s, operation.charIndex, operationStack);
                }
                else if (operation.OperationType == OperationType.Print)
                {
                    Print(s, operation.charIndex);
                }
                else if (operation.OperationType == OperationType.Undo)
                {
                    Undo(ref s, ref operationStack);
                }
            }
        }
    }
}
