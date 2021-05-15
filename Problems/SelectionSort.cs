using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    public static class SelectionSort
    {
        public static int[] Sort(int[] array)
        {
            int min = 0;
            int minIndex = -1;
            bool minChanged = false;
            int temp = 0;

            for(int i=0;i<=array.Length-2;i++)
            {
                minChanged = false;
                min = array[i];
                for(int j=i+1;j<=array.Length-1;j++)
                {
                    if(array[j]<min)
                    {
                        minIndex = j;
                        min = array[j];
                        minChanged = true;
                    }
                }

                if(minChanged)
                {
                    temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                }             
            }

            return array;
        }
    }
}
