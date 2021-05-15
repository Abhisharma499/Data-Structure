using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public static class LengthofLastWord
    {
        public static int CalculateLength(string str)
        {
            int count = 0;

            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (str[i] == ' ')
                {
                    if(count==0)
                    continue;
                    break;
                }
                count++;          
            }

            return count;
        }
    }
}
