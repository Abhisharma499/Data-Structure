using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    public static class BitManipulation
    {
        public static void CheckIfIthBitSet(int number, int bitposition)
        {
            if ((number & (1 << (bitposition)-1))!= 0)
                Console.Write("SET");
            else
                Console.Write("NOT SET");
        }
    }
}
