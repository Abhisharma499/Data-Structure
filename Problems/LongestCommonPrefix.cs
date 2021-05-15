using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
   public static class LongestCommonPrefix
    {
        public static string LongestCommonPrefixFunction(string[] strs)
        {

            if(strs.Length ==0)
            {
                return "";
            }
            string prefix = strs[0];

            for(int i=1;i<=strs.Length-1;i++)
            {
                while(!strs[i].StartsWith(prefix) && prefix.Length!=0)
                {

                    prefix = prefix.Substring(0, prefix.Length-1);
                }
            }

            return prefix;
        }
    }
}
