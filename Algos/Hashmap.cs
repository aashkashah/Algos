using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    // Java has HashMap, TreeMap, LinkedHashMap
    // Java's HashMap = C#'s Dictionary
    class Hashmap
    {
        // available types :
        // HashSet<string> hash = new HashSet<string>();
        // SortedSet<string> sortedSet = new SortedSet<string>();
        // SortedList
        // SortedDictionary


        static string checkMagazine(string[] magazine, string[] note)
        {
            Dictionary<string, int> availableWords = new Dictionary<string, int>();

            // make a list of words available to create ransom note
            for(int i = 0; i < magazine.Length; i++)
            {
                if (availableWords.ContainsKey(magazine[i]))
                {
                    availableWords[magazine[i]]++;
                }
                else
                {
                    availableWords.Add(magazine[i], 1);
                }
            }

            // check if ransom note can be generated
            for(int i = 0; i < note.Length; i++)
            {
                if (availableWords.ContainsKey(note[i]) && availableWords[note[i]] > 0)
                {
                    availableWords[note[i]]--;
                }
                else
                {   
                    return "NO";
                }
            }

            return "YES";
        }

        static string twoStrings(string s1, string s2)
        {
            char[] s1CharArr = s1.ToCharArray();
            char[] s2charArr = s2.ToCharArray();
            HashSet<char> hash = new HashSet<char>();


            for(int i = 0; i < s1CharArr.Length; i++)
            {
                if (!hash.Contains(s1CharArr[i]))
                {
                    hash.Add(s1CharArr[i]);
                }
            }

            for (int i = 0; i < s2charArr.Length; i++)
            {
                if (hash.Contains(s2charArr[i]))
                {
                    return "YES";
                }
            }

            return "NO";
        }

        static void whatFlavors(int[] cost, int money)
        {
            Dictionary<int, int> seenFlavors = new Dictionary<int, int>();

            for (int i = 0; i < cost.Length; i++)
            {
                int firstFlavorCost = money - cost[i];
                if (seenFlavors.ContainsKey(firstFlavorCost))
                {
                    int flavorPos = 0;
                    seenFlavors.TryGetValue(firstFlavorCost, out flavorPos);
                    Console.WriteLine(flavorPos + " " + (i+1));
                    break;
                }

                seenFlavors.Add(cost[i], i + 1);
            }

            Console.ReadLine();

        }

        public static void Main2(string[] args)
        {
            // ransom note
            //string[] magazine = new string[] { "ive", "got", "a", "lovely", "bunch", "of", "coconuts" };
            //string[] note = new string[] { "ive", "got", "some", "coconuts" };
            //string canFormNote = checkMagazine(magazine, note);

            // determine if two strings share a common substring
            //string shareCommonSubStr = twoStrings("hello", "alpha");
            //Console.WriteLine(shareCommonSubStr);


            whatFlavors(new int[] { 2, 2, 4, 3 } , 4);
        }
    }
}
