using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    public static class LetterCombinationsofPhoneNumber
    {
        public static int Test(string[] wordsDict, string word1, string word2)
        {

            int index1 = -1, index2 = -1, min = int.MaxValue;

            for(int i=0;i<wordsDict.Length;i++)
            {
                if(wordsDict[i]==word1)
                {
                    index1 = i;
                }

                if(wordsDict[i] == word2)
                {
                    index2 = i;
                }

                if(index1!=-1 && index2!=-1)
                {
                    min = Math.Min(min, Math.Abs(index1-index2));
                }
            }

            return min;
            
        }
    }
}
