using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    class ArrayPrograms
    {
        public static int[] SortColors(int[] nums)
        {
            if (nums.Length == 0)
            {
                return nums;
            }

            int low = 0;
            int mid = 0;
            int high = nums.Length - 1;

            while (mid <= high)
            {
                int test = nums[mid];
                switch (test)
                {
                    case 0:
                        int temp = nums[mid];
                        nums[mid] = nums[low];
                        nums[low] = temp;
                        mid++;
                        low++;
                        break;

                    case 1:
                        mid++;
                        break;

                    case 2:

                        int temp1 = nums[mid];
                        nums[mid] = nums[high];
                        nums[high] = temp1;
                        high--;
                        break;


                }
            }

            return nums;

        }
        static int FindArrayDuplicate(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                return -1;
            }

            int slow = numbers[0];
            int fast = numbers[0];

            do
            {
                slow = numbers[slow];
                fast = numbers[numbers[fast]];
            } while (slow != fast);


            slow = numbers[0];

            while (slow != fast)
            {
                slow = numbers[slow];
                fast = numbers[fast];
            }

            return slow;
        }

        public static bool IsValid(string s)
        {
            List<char> openP = new List<char>() { '[', '{', '(' };
            List<char> closeP = new List<char>() { ']', '}', ')' };
            Stack<char> parenthesis = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (openP.Contains(s[i]))
                {
                    parenthesis.Push(s[i]);
                }
                else if (closeP.Contains(s[i]))
                {
                    if (parenthesis.Count() == 0)
                    {
                        return false;
                    }

                    if (parenthesis.Peek() != openP[closeP.IndexOf(s[i])])
                    {
                        return false;
                    }
                    else
                    {
                        parenthesis.Pop();
                    }
                }
            }

            if (parenthesis.Count() > 0)
            {
                return false;
            }

            return true;
        }

        public static bool IsValidSudoku(string[][] board)
        {
            HashSet<string> elemets = new HashSet<string>();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] == ".")
                    {
                        continue;
                    }
                    string rowElement = "row" + i + board[i][j];
                    string columnElement = "column" + j + board[i][j];
                    // string boxElement = "box" + (i * 3) / 3 + j / 3 + "" + board[i][j];

                    string boxElement = "box" + (i / 3) * 3 + j / 3 + board[i][j];
                    if (!elemets.Add(rowElement) || !elemets.Add(columnElement) || !elemets.Add(boxElement))
                    {
                        return false;
                    }

                }
            }

            return true;
        }


        public static int MinMeetingRooms(int[] startTimes, int[] endTimes)
        {
            int tempMax = 1;
            int result = 1;

            Array.Sort(startTimes);
            Array.Sort(endTimes);
            int j = 0;

            for (int i = 1; i < startTimes.Length; i++)
            {
                if (startTimes[i] >= endTimes[j])
                {
                    tempMax--;
                    result = Math.Max(result, tempMax);
                    j++;
                }
                else
                {
                    tempMax++;
                    result = Math.Max(result, tempMax);
                }
            }

            return result;
        }
        public static int JobScheduling(int[] startTime, int[] endTime, int[] profit)
        {
            List<DNode> times = new List<DNode>();
            int[] profitArray = new int[startTime.Length];
            int j = 0;

            for (int i = 0; i < startTime.Length; i++)
            {
                times.Add(new DNode() { StartTime = startTime[i], EndTime = endTime[i], Profit = profit[i] });

            }

            times = times.OrderBy(x => x.EndTime).ToList();

            for (int i = 0; i < times.Count; i++)
                profitArray[i] = times[i].Profit;

            for (int i = 1; i < profitArray.Length; i++)
            {
                while (j < i)
                {
                    if (times[j].EndTime <= times[i].StartTime)
                    {
                        profitArray[i] = Math.Max(profitArray[i], times[i].Profit + profitArray[j]);

                    }

                    j++;
                }

                j = 0;
            }

            return profitArray.Max();

        }
        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            int count = 0;
            int tempCount = 0;

            if (nums.Length == 0)
            {
                return 0;
            }

            if (nums[0] == 1)
            {
                count = 1;
                tempCount = 1;
            }

            //1 1 0 1 1 1
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == 1 && nums[i + 1] == 1)
                {
                    tempCount++;
                }
                else
                {
                    count = Math.Max(tempCount, count);
                    if (nums[i + 1] == 1)
                    {
                        tempCount = 1;
                    }
                    else
                    {
                        tempCount = 0;
                    }
                }
            }

            return Math.Max(tempCount, count);

        }
        static void RemoveDuplicateFromArray(int[] numbers)
        {
            int index = 0;
            int i = 0;

            for (; i < numbers.Length - 1; i++)
            {
                if (numbers[i] != numbers[i + 1])
                {
                    numbers[index] = numbers[i];
                    index++;
                }
            }

            numbers[index] = numbers[i];
            index++;

            for (; index < numbers.Length; index++)
            {
                numbers[index] = 0;
            }

        }
        public static int LengthOfLongestSubstring(string s)
        {
            if (s == null)
            {
                return 0;
            }
            if (s.Length == 0)
            {
                return 0;
            }
            int count = 0;
            int tempCount = 0;
            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();

            int i = 0;
            int begin = 0;
            //dvdf

            while (i < s.Length)
            {
                if (!keyValuePairs.ContainsKey(s[i]))
                {
                    tempCount++;
                    keyValuePairs.Add(s[i], 1);
                    i++;
                }
                else
                {
                    keyValuePairs = new Dictionary<char, int>();
                    count = Math.Max(tempCount, count);
                    i = ++begin;
                    tempCount = 0;
                }
            }


            return Math.Max(count, tempCount);

        }
        public static int SubarraySum(int[] nums, int k)
        {
            int i = 0;
            int count = 0;
            int sum = 0;
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            keyValuePairs.Add(0, 1);

            if (nums.Length == 0)
            {
                return 0;
            }
            if (nums.Length == 1 && nums[0] == k)
            {
                return 1;
            }

            while (i < nums.Length)
            {
                sum = sum + nums[i];

                if (keyValuePairs.ContainsKey(sum - k))
                {
                    count += keyValuePairs[sum - k];
                }

                if (keyValuePairs.ContainsKey(sum))
                {
                    keyValuePairs[sum]++;
                }
                else
                {
                    keyValuePairs.Add(sum, 1);
                }

                i++;
            }



            return count;
        }

        public static int[] TwoSumProblem(int[] numbers, int sum)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            int[] result1 = new int[2];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (result.ContainsKey(sum - numbers[i]))
                {
                    result1[0] = result[sum - numbers[i]];
                    result1[1] = i;
                    break;
                }
                else
                {
                    if (!result.ContainsKey(numbers[i]))
                        result.Add(numbers[i], i);
                }
            }

            return result1;
        }

        public static int LongestConsecutive(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            int result = 1;
            int tempResult = 1;

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                {
                    continue;
                }
                else if (nums[i] - nums[i + 1] == -1)
                {
                    tempResult++;
                }
                else
                {
                    result = Math.Max(result, tempResult);
                    tempResult = 1;
                }
            }

            result = Math.Max(result, tempResult);
            return result;
        }
        public static int ReachTill1MinStepsRecursive(int number)
        {
            if (number == 1)
            {
                return 0;
            }

            int op1 = ReachTill1MinStepsRecursive(number - 1);

            int minimumSteps = op1;

            minimumSteps = Math.Min(op1, minimumSteps);

            if (number % 2 == 0)
            {
                int op2 = ReachTill1MinStepsRecursive(number / 2);

                minimumSteps = Math.Min(op2, minimumSteps);
            }

            if (number % 3 == 0)
            {
                int op3 = ReachTill1MinStepsRecursive(number / 3);

                minimumSteps = Math.Min(op3, minimumSteps);
            }

            return minimumSteps + 1;
        }


        public static int ReachTill1MinStepsIterative(int number)
        {
            if (number <= 1)
            {
                return 0;
            }

            int[] result = new int[number + 1];

            result[1] = 0;
            int min = int.MaxValue;

            for (int i = 2; i <= number; i++)
            {
                min = result[i - 1];

                if (i % 2 == 0)
                {
                    min = Math.Min(min, result[i / 2]);
                }

                if (i % 3 == 0)
                {
                    min = Math.Min(min, result[i / 3]);
                }

                result[i] = min + 1;

            }

            return result[number];
        }
    }
}
