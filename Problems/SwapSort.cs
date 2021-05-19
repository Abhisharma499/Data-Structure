using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    class SwapSort
    {
        public static  void FindMissingAndDuplicate(int [] numbers)
        {
            //2,3,1,5,1
            int i = 0;

            while (i < numbers.Length) 
            { 
                if(numbers[i]!=i+1 && numbers[numbers[i] - 1] != numbers[i])
                {
                    int temp = numbers[numbers[i] - 1];
                    numbers[numbers[i] - 1] = numbers[i];
                    numbers[i] = temp;

                }
                else
                {
                    i++;
                }
            }

            for(i=0;i<numbers.Length;i++)
            {
                if(numbers[i]!= i+1)
                {
                    Console.WriteLine("The missing number is " + (i + 1));
                    Console.WriteLine("The Duplicate number is " + numbers[i]);
                }
            }
        }


    }
}
