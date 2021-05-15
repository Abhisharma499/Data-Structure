using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    public class MaxSubArray
    {

       // [1,2,3,4,5,6,7,8,0]  3
        public static int MaxSubArraySum(int[] arr, int n)
        {
            int max = 0;
            int left = 0;

            for(int i =0;i<=n-1;i++)
            {
                max = max + arr[i];
            }

            int tempsum = max;
            for(int j= n;j<=arr.Length-1;j++ )
            {
                tempsum = tempsum - arr[left] + arr[j];
                left++;

                if(tempsum> max)
                {
                    max = tempsum;
                }
            }

            return max;


        }

        //public static int MaxSubArraySum(int []arr,int n)
        //{
        //    int max = 0;
        //    int sum = 0;

        //    //1,2,3,4,5,6   3
        //    for(int i=0;i<=arr.Length-n;i++)
        //    {
        //        sum = 0;

        //        for(int j=0;j<=n-1;j++)
        //        {
        //            sum = sum + arr[i+j];
        //        }

        //        if(sum> max)
        //        {
        //            max = sum;
        //        }
        //    }

        //    return max;
        //}
    }
}
