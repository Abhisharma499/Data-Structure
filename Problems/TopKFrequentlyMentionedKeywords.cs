using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    public class TopKFrequentlyMentionedKeywords
    {
        public IList<string> TopKFrequent(string[] words, int k)
        {
            Dictionary<string, int> keywordOccurencePair = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (keywordOccurencePair.ContainsKey(word))
                {
                    keywordOccurencePair[word]++;
                }
                else
                {
                    keywordOccurencePair[word] = 1;
                }

            }

            return keywordOccurencePair.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Take(k).Select(x=>x.Key).ToList();
        }








        public static string[] ToKeywords()
        {
            int k = 2;
            int count = 0;
            string[] keywords = new string[] { "anacell", "betacellular", "cetracular", "deltacellular", "eurocell" };

            string[] reviews = new string[] {  "I love anacell Best services; Best services provided by anacell",
  "betacellular has great services",
  "deltacellular provides much better services than betacellular",
  "cetracular is worse than anacell",
  "Betacellular is better than deltacellular.",};

            Dictionary<string, int> keywordOccurencePair = new Dictionary<string, int>();

            foreach (string keyword in keywords)
            {
                count = reviews.Count(x => x.ToLower().Split(' ').Contains(keyword));
                keywordOccurencePair.Add(keyword, count);
            }

            return keywordOccurencePair.OrderByDescending(x => x.Value).ThenByDescending(x => x.Key).Take(k).Select(x => x.Key).ToArray();
        }


        //public static List<string> ToKeywords1(string[] words, int k)
        //{
        //    Dictionary<string, int> wordsFrequency = new Dictionary<string, int>();

        //    foreach(string word in words)
        //    {
        //        if(wordsFrequency.ContainsKey(word))
        //        {
        //            wordsFrequency[word]++;
        //        }
        //        else
        //        {
        //            wordsFrequency[word] = 0;
        //        }
        //    }

        //    Dictionary<int, string[]> result = new Dictionary<int, string[]>();

        //    foreach(KeyValuePair<string,int> keyValuePair in wordsFrequency)
        //    {
        //        if(result.ContainsKey(keyValuePair.Value))
        //        {

        //        }
        //    }

        //   // return wordsFrequency.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Take(k).Select(x=>x.Key).ToList();
        //}
    }
}
