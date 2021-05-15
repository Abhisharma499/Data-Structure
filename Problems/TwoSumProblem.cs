using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class TwoSumProblem
    {
        public static int[] TwoSum(int[] nums, int target)
        {

            //new int[] { 2, 5, 5, 11 }, 7
            var numsDictionary = new Dictionary<int, int>();

            var complement = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                complement = target - nums[i];
                var index = 0;
                if (complement > 0 && numsDictionary.TryGetValue(complement, out index))
                {
                    return new int[] { index, i };
                }

                if (numsDictionary.ContainsKey(nums[i]) == false)
                {
                    numsDictionary.Add(nums[i], i);
                }
            }

            return null;
















            //Dictionary<int,int> keyValuePairs = new System.Collections.Generic.Dictionary<int,int>();
            //int[] returnArray = new int[2] { -1, -1 };
            //int firstNumber = nums[0];

            //for(int i = 1; i<=nums.Length -1 ; i++)
            //{
            //    keyValuePairs.Add(i, nums[i]);
            //}

            //for(int j =0;j<= keyValuePairs.Count-1;j++)
            //{
            //    int numberToFind = target - firstNumber;

            //    if (keyValuePairs.ContainsValue(numberToFind))
            //    {
            //        returnArray[0] = j;
            //        returnArray[1] = keyValuePairs.Where(x => x.Value == numberToFind).Select(x => x.Key).FirstOrDefault();
            //        break;
            //    }

            //    firstNumber = keyValuePairs[j+ 1];
            //}

            //return returnArray;
        }
    }
}
