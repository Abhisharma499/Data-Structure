using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
   public class UniqueValuesInArray
    {
        public static int GetUniqueValueInArray(int [] arr)
        {
            int count = 1;

            for(int i=0;i<=arr.Length-2;i++)
            {
                if(arr[i]!=arr[i+1])
                {
                    count++;
                }
            }

            return count;
        }
    }
}
