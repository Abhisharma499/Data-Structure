using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
   public static class PlusOne
    {
        public static int[] PlusOneToNumber(int[] digits)
        {

           

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] != 9)
                {
                    ++digits[i];
                    return digits;
                }
                else
                {
                    digits[i] = 0;
                }
            }

            int[] newArray = new int[digits.Length + 1];
            newArray[0] = 1;
            return newArray;
        }
    }
}
