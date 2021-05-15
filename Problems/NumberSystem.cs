using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    public class NumberSystem
    {
        public static long CalculateModularExponentiation(int number,int power,int mod)
        {
            long result = 1;
            if(power==0)
            {
                return 1;
            }
            else if(power ==1)
            {
                return number;
            }

            while (power != 0)
            {

                if (power % 2 == 1)
                {
                    result = (result%mod * number%mod)%mod;
                    power--;
                }
                else
                {
                    number = (number%mod * number%mod)%mod;
                    power = power / 2;
                }
            }

            return result%mod;
        }

        public static long ModuleMultiplicativeInverse(int number, int mod)
        {
            if(CalculateGCD(number,mod)!=1)
            {
                throw new Exception("Module inverse does not exist");
            }

            return CalculateModularExponentiation(number, mod - 2, mod);
        }

        public static int CalculateGCD(int a,int b)
        {
            if(b==0)
            {
                return a;
            }
            else
            {
                return CalculateGCD(b, a % b);
            }
        }

        public static void SieveofEratosthenes(int number)
        {
            bool[] arrayofPrimes = new bool[number + 1];

            for(int i=2;i<= arrayofPrimes.Length-1;i++)
            {
                arrayofPrimes[i] = true;
            }

            for(int i=2;i*i<=number;i++)
            {
                if(arrayofPrimes[i])
                for(int j=i*i;j<=number;j=j+i)
                {
                        arrayofPrimes[j] = false;
                }
            }

            for (int i = 0; i <= arrayofPrimes.Length - 1; i++)
            {
                if(arrayofPrimes[i])
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static void EulerToientFunction(int number)
        {
            //To calculate all the number before number who are prime factor of number
            //That is having GCD of 1 with number

            //Formula

            //Result = (Number *(p1-1)*(p2-1))/p1*p2;
           //Find the prime factor p1 and p2, and then just use this formula
             
            //Finding Prime divisors

            int count = 0;
            int result = number;


            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                {
                    while (number % i == 0)
                    {
                        number = number / i;
                        count++;
                    }

                    result = result / i;
                    result = result* (i-1);               
                }
            }

            if (number > 1)
            {
                result = result / number;
                result = result * number - 1; 
            }

            Console.WriteLine(result);
        }

        public static void EulerToientFunctionConstantTime(int number)
        {
            int[] array= new int[number + 1];

            for(int i=1;i<= number; i++)
            {
                array[i] = i;
            }

            for(int i=2;i<=number;i++)
            {
                if(i==array[i])
                {
                    for (int j = i; j <= number; j = j + i)
                    {
                        array[j] = array[j] / i;
                        array[j] = array[j] * i - 1;
                    }
                }
            }

            Console.WriteLine(array[number]); 
        }

        public static bool FermatLittleTheorm(int number)
        {
            Random rand = new Random();
            if(number<=1)
            {
                return false;
            }
            else if(number == 2 || number==3)
            {
                return true;
            }

            for (int i = 0; i <= 1000; i++)
            {
                int a = rand.Next(2, number - 2 + 1);

                if (BinaryExponentiation.CalculatePower(a, number - 1, number) != 1)
                {
                    return false;
                }
            }

            return true;   
        }


        public static void SegmentedSieve(int L,int R)
        {
            bool[] primes = new bool[R+1];

            bool[] SegmentPrimes = new bool[R - L + 1];

            for(int i=0;i<= SegmentPrimes.Length-1;i++)
            {
                SegmentPrimes[i] = true;
            }

            List<int> primeNumbers = new List<int>();
            
            for(int i=2;i<=primes.Length-1;i++)
            {
                primes[i] = true;
            }

            for(int i=2;i*i<=Math.Sqrt(R);i++)
            {
                if(primes[i]==true)
                {
                    for(int j=i*i;j<=R;j=j+i)
                    {
                        primes[j] = false;
                    }
                }
            }

            for(int i=2;i<=R;i++)
            {
                if(primes[i])
                {
                    primeNumbers.Add(i);
                }
            }

            int StartBase = 0;

            for(int i=0;primeNumbers[i]*primeNumbers[i]<=R;i++)
            {
                StartBase = (L / primeNumbers[i]) * primeNumbers[i];

                if(StartBase<L)
                {
                    StartBase = StartBase + primeNumbers[i];
                }

                for(int j=StartBase;j<=R;j=j+primeNumbers[i])
                {
                    SegmentPrimes[j - L] = false;
                }
            }

            for(int i=0;i<=SegmentPrimes.Length-1;i++)
            {
                if(SegmentPrimes[i])
                {
                    Console.WriteLine(L+i);
                }
            }

        }

        public static int Power(int x, int n, int mod)
        {
            if (n == 0)
            {
                return 1;
            }

            int result = 1;

            if(n % 2 == 0)
            {
                 result = Power(x, n / 2,mod);
                return ((result%mod) * (result%mod))%mod;
            }
            else
            {
                return (result%mod * result%mod * x%mod)%mod;
            }
        }

        public static int ModularExponent(int number, int power, int p)
        {
            if (power == 1 || number == 0)
            {
                return number;
            }

            if (power == 0)
            {
                return 1;
            }

            int result = ModularExponent(number, power / 2, p);

            result = (result % p * result % p) % p;

            if (power % 2 == 1)
            {
                result = result * number;
            }

            return result % p;

        }
    }
}
