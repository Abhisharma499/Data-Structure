using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    class MinimumJumpEndOfArray
    {
        private static void MinimumJumpToEndofArray(int[] numbers)
        {
            int[] path = new int[numbers.Length];
            int[] cost = new int[numbers.Length];

            path[0] = 0;
            cost[0] = 0;

            //for(int i=1;i<=numbers.Length-1;i++)
            //{
            //    path[i] = -1;
            //    cost[i] = -1;
            //}

            for (int i = 1; i < numbers.Length; i++)
            {
                cost[i] = int.MaxValue;
                for (int j = 0; j < i; j++)
                {
                    if (i <= j + numbers[j])
                    {
                        //cost[i] = Math.Min(cost[i], cost[j] + 1);
                        cost[i] = cost[j] + 1;
                        path[i] = j;
                        break;
                    }
                }
            }


        }
    }
}
