using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos.Tree
{
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
            if (word.Length == 0)
            {
                return false;
            }

            char[] wordArr = word.ToCharArray();
            for (int i = 0; i < wordArr.Length; i++)
            {
                if (dictionary.letter == wordArr[i] && dictionary.isWord)
                {
                    return true;
                }
                else if (dictionary.children.ContainsKey(wordArr[i]))
                {
                    // recurse until end of word
                    char temp = wordArr[i];
                    word.Remove(i); //t
                    var res = SearchWord(word, dictionary.children[temp]); //t
                    if (res == false)
                        return false;
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
