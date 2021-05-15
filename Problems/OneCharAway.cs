using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    public static class OneCharAway
    {
        public static bool IsOneCharAway(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
            {
                return false;
            }
            else if((Math.Abs(s1.Length-s2.Length))>1)
            {
                return false;
            }
            else if(s1.Length == s2.Length)
            {
               return StringsLengthEqual(s1,s2);

            }
            else if(s1.Length-s2.Length ==1)
            {
                return StringsOneAway(s1, s2);

            }
            else
            {
                return StringsOneAway(s2, s1);
            }
        }

        public static bool StringsLengthEqual(string s1, string s2)
        {
            uint unMatchedcount = 0;
            int i = 0;

            for(i=0;i<=s1.Length-1;i++)
            {
                if(s1[i]!=s2[i])
                {
                    unMatchedcount++;
                }
            }

          return  unMatchedcount > 1 ? false : true;

        }

        public static bool StringsOneAway(string s1, string s2)
        {
            //abcde
            //abde
            uint unMatchedcount = 0;
            int j = 0;
            int i = 0;
            while(i<s2.Length)
            {
                if(s1[i]== s2[j])
                {
                    j++;
                    i++;
                }
                else
                {
                    unMatchedcount++;
                    i++;
                }

                if(unMatchedcount > 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
