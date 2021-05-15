using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    public static class InsertionSort
    {
        public static int[] Sort(int[] array)
        {
            int hole = 0;
            int value = 0;

            for(int i=1;i<=array.Length-1;i++)
            {
                hole = i;
                value = array[i];

                while(hole> 0 && array[hole-1]> value)
                {
                    array[hole] = array[hole - 1];
                    hole--;
                }

                array[hole] = value;        
            }

            return array;

        }
    }
}
