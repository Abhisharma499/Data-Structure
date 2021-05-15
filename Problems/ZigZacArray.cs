using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
   public static class ZigZacArray
    {
        public static void ConvertArrayToZigZac(int [] array)
        {
            bool flag = false;
            int temp = 0;

            for(int i=0;i<=array.Length-2;i++)
            {

                if (flag == false)
                {
                    if (array[i] > array[i + 1])
                    {
                        temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }          
                }
                else
                {
                    if (array[i] < array[i + 1])
                    {
                        temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }

                flag = !flag;
            }

            for (int j = 0; j <= array.Length - 1; j++)
            {
                Console.WriteLine(array[j]);
            }
        }
    }
}
