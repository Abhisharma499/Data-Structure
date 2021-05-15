using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    public class Anagram
    {
        public static bool CheckAnagram(string str, string str1)
        {
            Dictionary<char, int> word1 = new Dictionary<char, int>();
            Dictionary<char, int> word2 = new Dictionary<char, int>();

            //anagram //nagaram
            foreach(char ch in str.ToCharArray())
            {
                if (word1.ContainsKey(ch))
                {
                    word1[ch]++;
                }
                else
                {
                    word1[ch] = 1;
                }
            }

            foreach (char ch in str1.ToCharArray())
            {
                if (word2.ContainsKey(ch))
                {
                    word2[ch]++;
                }
                else
                {
                    word2[ch] = 1;
                }
            }

            foreach(KeyValuePair<char,int> keyValuePair in word1)
            {
                if(word2.ContainsKey(keyValuePair.Key))
                {
                   if(word2[keyValuePair.Key] != word1[keyValuePair.Key])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
