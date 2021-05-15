using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    public static class PrimeFactors
    {
        public static void PrintPrimeFactorsOfANumber()
        {
            int a, b;
            Console.WriteLine("Please enter your integer: ");
            a = int.Parse(Console.ReadLine());
            for (b = 2; a > 1; b++)
                if (a % b == 0)
                {
                    int x = 0;
                    while (a % b == 0)
                    {
                        a /= b;
                        x++;
                    }
                    Console.WriteLine("{0} is a prime factor {1} times!", b, x);
                }

            Console.WriteLine("Th-Th-Th-Th-Th-... That's all, folks!");
        }

        public static void GetPrimeFactors()
        {
            int a, b;
            Console.WriteLine("Please enter your integer: ");
            a = int.Parse(Console.ReadLine());

            for (int i = 2; i <= Math.Sqrt(a); i++)
            {
                if (a % i == 0)
                {
                    Console.WriteLine(i);
                    a = a / i;
                }
            }
        }

        public static int BinaryExponent(int number, int power)
        {
            if (power == 0)
            {
                return 1;
            }
            else if(power==1)
            {
                return number;
            }

            int result = BinaryExponent(number, power / 2);
            result = result * result;

            if(power%2==1)
            {
                result = result * number;
            }

            return result;

        }

    }
}
