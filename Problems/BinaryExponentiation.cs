using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
   public static class BinaryExponentiation
    {
        public static int CalculatePowerRecursive(int number,int power)
        {
            if(power==0)
            {
                return 1;
            }
            else if(power==1)
            {
                return number;
            }

            int result = CalculatePowerRecursive(number, power / 2);
            result = result * result;

            if(power % 2 ==1)
            {
                result = result * number;
            }

            return result;
            
        }


        public static int CalculatePower(int number, int power, int mod)
        {
            if (power == 0)
            {
                return 1;
            }
            else if (power == 1)
            {
                return number;
            }

            int result = 1;

            while(power != 0)
            {
                if (power % 2 == 0)
                {
                    number = (number%mod * number%mod)%mod;
                    power = power / 2;
                }
                else
                {
                    result = (result%mod * number%mod)%mod;
                    power = power - 1;
                }

            }

            return result%mod;
        }
    }
}
