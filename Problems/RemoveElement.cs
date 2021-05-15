using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
   public static class RemoveElement
    {
        public static int Remove(int [] array, int value)
        {
            int i = 0;
            int n = array.Length;

            while(i<n)
            {
                if(array[i]== value)
                {
                    array[i] = array[n - 1];
                    n--;
                }
                else
                {
                    i++;
                }
            }

            return n;
        }
    }
}
