using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    public class FindPairWithGivenSum
    {
        public static int[] FindPairWithSum(int []arr,int target)
        {
            Dictionary<int, int> NumberWithIndex = new Dictionary<int, int>();
            int[] result = new int[2];

            for(int i=0; i< arr.Length;i++)
            {
                if(NumberWithIndex.ContainsKey(target - arr[i] -30))
                {
                    result[0] = NumberWithIndex.Where(x => x.Key == target - arr[i] - 30).FirstOrDefault().Value;
                    result[1] = i;
                    break;
                }
                else
                {
                    NumberWithIndex.Add(arr[i], i);
                }
            }

            return result;
        }
    }
}
