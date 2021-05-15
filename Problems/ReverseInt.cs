using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    public class ReverseInt
    {
        //531
        public static int ReverseInteger(int number)
        {
            long reversedNumber = 0;
            bool numberNegative = false;

            if (number < 0)
            {
                number = number * -1;
                numberNegative = true;
            }

            while (number > 0)
            {
                if (number == 1)
                {
                    Console.WriteLine("");
                }
                int remainder = number % 10;

                number = number / 10;

                if (reversedNumber * 10 + remainder > Int32.MaxValue)
                {
                    return 0;
                }

                reversedNumber = reversedNumber * 10 + remainder;
            }

            return (Int32)(numberNegative == true ? reversedNumber * -1 : reversedNumber);
        }
    }
}
