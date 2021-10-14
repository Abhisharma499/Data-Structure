using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    public static class TwoSum
    {
        public static int[] TwoSumCalculate(int[] nums, int target)
        {
            int[] result = new int[2];
            int i = 0;
            int complement = 0;

            Dictionary<int, int> indexValuePair = new Dictionary<int, int>();

            for(i=0;i<=nums.Length-1;i++)
            {
                complement = target - nums[i];

                if (indexValuePair.ContainsValue(complement))
                {
                    result[0] = indexValuePair.Where(x => x.Value == complement).FirstOrDefault().Key;
                    result[1] = i;

                    return result;
                }
                else
                {
                    indexValuePair.Add(i, nums[i]);
                }
            }
            

            return result;
        }

        public static int[] TwoSumCalculatePractice(int[] nums, int target)
        {
            int[] result = new int[2];

            Dictionary<int, int> map = new Dictionary<int, int>();

            for(int i=0;i<nums.Length;i++)
            {
                if(map.ContainsKey(target-nums[i]))
                {
                    return new int[] { map[target - nums[i]], i };
                }
                else
                {
                    if(!map.ContainsKey(nums[i]))
                    {
                        map.Add(nums[i], i);
                    }
                }
            }

            return result;
        }
    }
}
