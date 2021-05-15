using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
   public static class CountPrimes
    {
        public static int  countPrimeFunction(int n)
        {
            bool[] Primes = new bool[n];

            for(int i=2;i<= Primes.Length-1;i++)
            {
                Primes[i] = true;
            }

            int primeCount = 0;

            for(int i=2;i<=n-1;i++)
            {
                if(Primes[i]==true)
                {
                    primeCount++;

                    for(int j=2;i*j<=n-1;j++)
                    {
                        Primes[i*j] = false;
                    }
                }
            }

            

            return primeCount;
        }
    }
}
