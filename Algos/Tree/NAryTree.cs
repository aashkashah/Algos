using System;
using System.Collections.Generic;

namespace Algos
{
    /// <summary>
    /// Create a dictonary with functions like search, add, delete, enummerate
    /// </summary>
    class NAryTree
    {
        public class Node
        {
            public Dictionary<char, Node> children;
            public char letter;
            public bool isWord;
        }

        bool SearchWord(string word, Node dictionary)
        {
            char[] wordArr = word.ToCharArray();

            for (int i = 0; i < wordArr.Length; i++)
            {
                if (dictionary.letter == wordArr[i] && dictionary.isWord)
                {
                    return true;
                }
                else if (dictionary.children.ContainsKey(wordArr[i]))
                {   
                    dictionary = dictionary.children[wordArr[i]];
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
    }
}
