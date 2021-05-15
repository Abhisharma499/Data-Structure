using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    class Palindromes
    {
        public static bool CheckPalindromes(string str)
        {
            str = str.ToLower();
            int j = str.Length - 1;
            for (int i = 0; i <= (str.Length - 1) / 2; i++)
            {
                if (str[i] != str[j])
                {
                    return false;
                }
                j--;
            }

            return true;
        }
    

    public static bool CheckPalindrome(int number)
    {
        int reversedNumber = 0;
        int remainer = 0;
        int preservedNumber = number;

        if (number < 0)
        {
            return false;
        }
        else if ((number > -1 && number < 10))
        {
            return true;
        }
        else
        {
            while (number > 0)
            {

                remainer = number % 10;

                number = number / 10;

                reversedNumber = reversedNumber * 10 + remainer;
            }

            if (preservedNumber == reversedNumber)
            {
                return true;
            }

            return false;
        }
    }
}
}
    

