using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    class StringManipulationChallenges
    {
        public static int MakeAnagram(string a, string b)
        {
            char[] firstLookup = new char[26];
            char[] secondLookup = new char[26];

            char[] firstCharArr = a.ToCharArray();
            char[] secondCharArr = b.ToCharArray();

            foreach(char c in firstCharArr)
            {
                firstLookup['a' - c] ++;
            }

            foreach (char c in secondCharArr)
            {
                secondLookup['a' - c]++;
            }

            foreach (char c in firstCharArr)
            {

            }

            return int.MinValue;
        }

        static string isvalid(string s)
        {
            char[] charArr = s.ToCharArray();
            char[] lookup = new char[26];
            
            int firstMax = int.MinValue;
            int secondmax = int.MinValue;
            int max = int.MinValue;

            for (int i = 0; i < charArr.Length; i++)
            {

            }
            


            return "NO";
        }

        public static void Main2(string[] args)
        {
            //int anagramDiff = MakeAnagram("cde", "abc");

            string valid = isvalid("aabbcd");
            Console.WriteLine(valid);
        }
    }
}
