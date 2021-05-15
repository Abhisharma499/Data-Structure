using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestProject.Problems;

namespace DataStructure
{
    public class Program
    {

        static AutoResetEvent evenReady = new AutoResetEvent(true);
        static AutoResetEvent oddReady = new AutoResetEvent(false);

        static void Main()
        {
            SmallestSubarrayWithGreaterThanGivenSum(new int[] { 1,10,3,40,18 }, 50);

        }

        public static List<List<int>> CountTripletsWithSumEqual(List<int> numbers)
        {
            int count = 0;

            List<List<int>> result = new List<List<int>>();
            List<int> tempResult = new List<int>();

            numbers.Sort();
            int start = 0;

            int end = numbers.Count() - 1;

            //{-4,-1, -1,0, 1, 2}

            for (int i = 0; i < numbers.Count() - 2; i++)
            {

                start = i + 1;

                while (start < end)
                {
                    if (numbers[start] + numbers[end] + numbers[i] == 0)
                    {
                        tempResult = new List<int>();
                        tempResult.Add(numbers[i]);
                        tempResult.Add(numbers[start]);
                        tempResult.Add(numbers[end]);
                        count++;
                        start++;
                        end--;
                        result.Add(tempResult);

                    }
                    else if (numbers[start] + numbers[end] + numbers[i] < 0)
                    {
                        start++;
                    }
                    else
                    {
                        end--;
                    }
                }
            }

            return result;
        }


        public static int CountTripletsWithSumEqual(List<int> numbers, int target)
        {
            int count = 0;

            numbers.Sort();
            int start = 0;

            int end = numbers.Count() - 1;

            //{-4,-1, -1,0, 1, 2}

            for (int i = 0; i < numbers.Count() - 2; i++)
            {

                start = i + 1;

                while (start < end)
                {
                    if (numbers[i] + numbers[start] + numbers[end] < target)
                    {
                        count += end - start;
                        start++;
                    }
                    else
                    {
                        end--;
                    }

                }
            }

            return count;
        }

        public static int SmallestSubarrayWithGreaterThanGivenSum(int[] numbers, int target)
        {
            int start = 0, end = 0, sum = 0, result = int.MaxValue;

            //1,10,3,40,18
            while (end < numbers.Length)
            {
                sum = sum + numbers[end];

                while (sum < target)
                {
                    end++;
                    sum = sum + numbers[end];
                }

                if (sum > target)
                {
                    result = Math.Min(result, end - start + 1);
                }

                //1,10,3,40,18
                while (sum > target)
                {
                    sum = sum - numbers[start];

                    if (sum > target)
                    {
                        result = Math.Min(result, end - start);
                        start++;
                    }
                    else
                    {
                        start++;
                        break;
                    }  
                }

                end++;
            }

            

            return result;

        }


        public static int SmallestSubarrayWithGivenSum(int[] numbers, int target)
        {
            int start = 0, end = 0, sum = 0, result = int.MaxValue;


            while (end < numbers.Length)
            {
                sum = sum + numbers[end];

                while (sum < target)
                {
                    end++;
                    sum = sum + numbers[end];
                }

                if (sum == target)
                {
                    result = Math.Min(result, end - start + 1);
                }


                while (sum > target)
                {
                    sum = sum - numbers[start];
                    start++;

                }

                if (sum == target)
                {
                    result = Math.Min(result, end - start + 1);
                }

                end++;
            }

            return result;




        }

        public static int[] ZigZagArray(int[] numbers)
        {

            int temp = 0;
            bool lookForsmall = true;

            for (int i = 0; i < numbers.Length - 1; i++)
            {

                // 3, 7, 4, 8, 6, 2, 1
                if (numbers[i] < numbers[i + 1] && lookForsmall)
                {

                }
                else if (numbers[i] > numbers[i + 1] && !lookForsmall)
                {

                }
                else
                {
                    temp = numbers[i];
                    numbers[i] = numbers[i + 1];
                    numbers[i + 1] = temp;


                }

                lookForsmall = !lookForsmall;
            }


            return numbers;
        }

        private static string ReverseAStringWithSpeacialCharacters(string input)
        {
            int start = 0;
            int end = input.Length - 1;
            char[] inputArray = input.ToCharArray();

            //"ABC"
            //ABCD

            while (start < end)
            {
                if (!char.IsLetter(inputArray[start]))
                {
                    start++;
                    continue;
                }
                if (!char.IsLetter(inputArray[end]))
                {
                    end--;
                    continue;
                }

                char temp;
                temp = inputArray[start];
                inputArray[start] = inputArray[end];
                inputArray[end] = temp;
                start++;
                end--;

            }

            return new string(inputArray);
        }

        public static void oddThread()
        {
            for (int i = 1; i < 10; i += 2)
            {
                oddReady.Set();
                evenReady.WaitOne();
                Console.WriteLine("Odd Thread: " + i);
                //oddReady.Set();
            }
        }

        public static void evenThread()
        {
            for (int i = 0; i < 10; i += 2)
            {
                oddReady.WaitOne();
                evenReady.Set();
                Console.WriteLine("Even Thread: " + i);
            }
        }

        public static List<int> FindLongestMoviePair(List<int> movieDuration, int d)
        {
            //Input: movieDurations = [90, 85, 75, 60, 120, 150, 125], d = 250
            //Output:[0, 6]
            //Explanation: movieDurations[0] + movieDurations[6] = 90 + 125 = 215 is the maximum number within 220(250min -30min)

            List<int> movieDurationCopy = new List<int>(movieDuration);

            Dictionary<int, List<int>> indexMap = new Dictionary<int, List<int>>();

            List<int> indexList = new List<int>();

            for (int i = 0; i < movieDuration.Count(); i++)
            {
                indexList = new List<int>();
                if (indexMap.ContainsKey(movieDuration[i]))
                {
                    indexMap[movieDuration[i]].Add(i);
                }
                else
                {
                    indexList.Add(i);
                    indexMap.Add(movieDuration[i], indexList);
                }
            }

            int actualDurationToFind = d - 30;

            if (actualDurationToFind <= 0)
            {
                return new List<int>();
            }

            movieDuration.Sort();

            int start = 0;
            int end = movieDuration.Count() - 1;
            List<List<int>> keyValuePairs = new List<List<int>>();


            while (start < end)
            {
                if (movieDuration[start] + movieDuration[end] <= actualDurationToFind)
                {
                    List<int> temp = new List<int>();
                    temp.Add(movieDuration[start]);
                    temp.Add(movieDuration[end]);
                    keyValuePairs.Add(temp);
                    start++;
                }
                else
                {
                    end--;
                }
            }
            int maxduation = int.MinValue, sIndex = -1, eIndex = -1, svalue = int.MinValue, evalue = int.MinValue;


            foreach (List<int> vs in keyValuePairs)
            {
                if (vs[0] + vs[1] > maxduation)
                {
                    svalue = vs[0];
                    evalue = vs[1];
                }
                else if (vs[0] + vs[1] == maxduation)
                {
                    if (!(Math.Max(svalue, evalue) > Math.Max(vs[0], vs[1])))
                    {
                        svalue = vs[0];
                        evalue = vs[1];
                    }
                }
            }

            sIndex = indexMap[svalue][0];
            eIndex = indexMap[evalue][0];

            List<int> result = new List<int>();

            result.Add(sIndex);
            result.Add(eIndex);

            return result;



        }
        public static int ComputeCheckDigit(string identificationNumber)
        {

            int even = 0, odd = 0;

            for (int i = 0; i < identificationNumber.Length; i++)
            {
                if (i % 2 == 0)
                {
                    odd = odd + Convert.ToInt32(identificationNumber[i]) - '0';
                }
                else
                {
                    even = even + Convert.ToInt32(identificationNumber[i]) - '0';
                }
            }

            odd = odd * 3;

            even = even + odd;

            int temp = even % 10;

            return 10 - temp;


        }
        public static string FindIntersection(string[] input)
        {
            HashSet<string> test = new HashSet<string>();

            string str1 = input[0];
            string str2 = input[1];

            string result = "";

            foreach (string ch in str1.Split(','))
            {
                test.Add(ch.Trim());
            }

            foreach (string ch in str2.Split(','))
            {
                if (!test.Add(ch.Trim()))
                {
                    if (result == "")
                    {
                        result = ch;
                    }
                    else
                    {
                        result = result.Trim() + "," + ch.Trim();
                    }
                }
            }

            return result;
        }
        public static int ReturnMinPositiveTemperature(int[] temp)
        {
            if (temp.Length == 0)
            {
                return 0;
            }

            int result = int.MaxValue;
            int answer = 0;
            int tempResult = 0;

            //-10, -10

            for (int i = 0; i < temp.Length; i++)
            {
                tempResult = Math.Abs(temp[i] - 0);

                //15, -7, 9, 14, 7, 12
                if (result >= tempResult)
                {
                    result = tempResult;

                    if (Math.Abs(answer) == Math.Abs(temp[i]))
                    {
                        if (temp[i] > answer)
                        {
                            answer = temp[i];
                        }
                    }
                    else
                    {
                        answer = temp[i];
                    }
                }

            }

            return answer;
        }
        public static int RemoveDuplicates(int[] nums)
        {

            // [0,0,1,1,1,2,2,3,3,4]
            //[0,1,2,3,4]

            int j = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] != nums[i + 1])
                {
                    j++;
                    nums[j] = nums[i + 1];
                }

            }

            return j + 1;
        }
        public static void Subset(List<int> numbers, List<List<int>> result, List<int> output, int index)
        {
            List<int> temp = new List<int>();
            temp.AddRange(output);
            result.Add(temp);

            for (int i = index; i < numbers.Count(); i++)
            {
                if (i > index && numbers[i - 1] == numbers[i])
                {
                    continue;
                }

                output.Add(numbers[i]);

                Subset(numbers, result, output, i + 1);

                output.Remove(numbers[i]);
            }
        }

        public static void Permutation(List<int> numbers, List<int> output, List<List<int>> subsets)
        {
            if (output.Count() == numbers.Count())
            {
                List<int> temp = new List<int>();
                temp.AddRange(output);
                subsets.Add(temp);
                return;
            }

            for (int i = 0; i <= numbers.Count() - 1; i++)
            {
                if (!output.Contains(numbers[i]))
                {
                    output.Add(numbers[i]);

                    Permutation(numbers, output, subsets);

                    output.RemoveAt(output.Count() - 1);
                }
            }
        }

    }
}




















