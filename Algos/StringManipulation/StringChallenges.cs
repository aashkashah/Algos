using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    class StringChallenges
    {

        /// <summary>
        /// https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/879/
        /// </summary>
        private char[] ReverseString(char[] s)
        {
            for (int i = 0, j = s.Length -1; i < s.Length/2; i++, j--)
            {
                char temp = s[i];
                s[i] = s[j];
                s[j] = temp;
            }

            return s;

        }

        /// <summary>
        /// https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/881/
        /// </summary>
        private int FirstUniqChar(string s)
        {
            int uniqueIndex = 0;
            
            HashSet<char> hash = new HashSet<char>();
            char[] charArr = s.ToCharArray();
            char uniqueChar = charArr[0];

            for (int i = 0; i < charArr.Length; i++)
            {   
                if (!hash.Contains(charArr[i]))
                {
                    uniqueChar = charArr[i];
                    uniqueIndex = i;
                }
            }

            return 0;
        }

        /// <summary>
        /// https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/882/
        /// </summary>
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            Dictionary<char, int> dict = new Dictionary<char, int>();
            char[] sArr = s.ToCharArray();
            char[] tArr = t.ToCharArray();

            for (int i = 0; i < sArr.Length; i++)
            {
                if (dict.ContainsKey(sArr[i]))
                {
                    dict[sArr[i]] = dict[sArr[i]] + 1;
                }
                else
                {
                    dict.Add(sArr[i], 1);
                }
            }

            for (int i = 0; i < tArr.Length; i++)
            {
                if (dict.ContainsKey(tArr[i]))
                {
                    dict[tArr[i]] = dict[tArr[i]] - 1;

                    if(dict[tArr[i]] == 0)
                    {
                        dict.Remove(tArr[i]);
                    }
                }
            }


            return (dict.Count > 0 ? false : true);
        }

        /// <summary>
        /// https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/883/
        /// </summary>
        public bool IsPalindrome(string s)
        {
            char[] charArr = s.ToCharArray();
            int leftIndex = 0;
            int rightIndex = charArr.Length - 1;

            while(leftIndex < rightIndex)
            {
                char c = char.ToLower(charArr[leftIndex]);
                if ((int)c >= 65 && (int)c <= 90)
                {
                }
                else 
                {
                    while (leftIndex < rightIndex)
                    {
                        
                    }
                }
            }

            return false;
        }


        public void Main()
        {
            char[] str = new char[] { 'a', 'b', 'c', 'd', 'x', 'y', 'z' };
            //var res = ReverseString(str);

            var res = IsAnagram("rat", "art");

            Console.WriteLine(res);

            Console.ReadLine();
        }

    }
}
