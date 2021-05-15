using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    public static class ModuloArthmetic
    {
        public static int CalculateGCD(int a, int b)
        {
            if(b == 0)
            {
                return a;
            }

          return CalculateGCD(b, a % b);
        }


    }
}
