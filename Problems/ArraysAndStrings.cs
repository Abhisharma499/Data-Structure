using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    class ClosestElement
    {
        int element;
        int distance;

       public ClosestElement(int element,int distance)
        {
            this.element = element;
            this.distance = distance;
        }
    }
    class Coordinate
    {
        public int x, y;

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class Numbers
    {
        public int num1, num2;
    }
    public class DNode
    {
        public int StartTime;
        public int EndTime;
        public int Profit;
    }
    public class ArrayAndStrings
    {

        public static int CompressString(string[] input)
        {
            if (input.Length == 0 || input.Length == 1)
            {
                return input.Length;
            }

            string output = string.Empty;
            int count = 1;
            int i = 0;
            string temp = string.Empty;
            //"a","a","b","b","c","c","c"
            for (i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    count++;
                }
                else
                {
                    if (count == 1)
                    {
                        temp = input[i].ToString();
                        output += temp;
                        temp = string.Empty;
                        continue;
                    }

                    temp = input[i] + count.ToString();
                    output += temp;
                    count = 1;
                    temp = string.Empty;
                }
            }

            if (count > 1)
            {
                temp = input[i - 1] + count.ToString();
                output += temp;
            }

            return output.Length;
        }

        //public static IList<int> FindKClosestElements(int[] numbers, int k, int x)
        //{
        //    List<int> output = new List<int>();

        //    if (numbers.Length == 0)
        //    {
        //        return output;
        //    }

        //    if (numbers[0] > x)
        //    {
        //        for (int i = 0; i < k; i++)
        //        {
        //            output.Add(numbers[i]);
        //        }

        //        return output;
        //    }
        //    else if (numbers[numbers.Length - 1] < x)
        //    {
        //        int length = numbers.Length - 1;
        //        for (int j = 0; j < k; j++)
        //        {
        //            output.Add(numbers[j]);
        //            length--;
        //        }

        //        return output;
        //    }
        //    else
        //    {
        //        List<ClosestElement> elements = new List<ClosestElement>();

        //        for(int i = 0; i < numbers.Length; i++)
        //        {
        //            ClosestElement el = new ClosestElement(numbers[i], Math.Abs(numbers[i] - x));
        //            elements.Add(el);

        //        }

        //    }

        //}
        public static IList<IList<int>> PascalTriangle(int rows)
        {
            IList<IList<int>> result = new List<IList<int>>();
            IList<int> firstRow = new List<int>() { 1 };
            result.Add(firstRow);

            // 1
            //1 1
            //1 2 1
            //1 3 3 1
            //1 4 6 4 1
            for (int i = 1; i <= rows - 1; i++)
            {
                IList<int> currentRow = new List<int>() { 1 };

                for (int j = 1; j < i; j++)
                {
                    currentRow.Add(result[i - 1][j - 1] + result[i - 1][j]);
                }

                currentRow.Add(1);

                result.Add(currentRow);
            }

            return result;
        }

        public static int[][] Merge(int[][] intervals)
        {
            List<Numbers> sortedIntervals = new List<Numbers>();

            foreach (int[] arr in intervals)
            {
                sortedIntervals.Add(new Numbers() { num1 = arr[0], num2 = arr[1] });
            }

            sortedIntervals = sortedIntervals.OrderBy(x => x.num1).ToList();


            if (intervals.Length == 0)
            {
                return new int[0][];
            }
            List<Numbers> MergedIntervals = new List<Numbers>();

            MergedIntervals.Add(new Numbers() { num1 = sortedIntervals[0].num1, num2 = sortedIntervals[0].num2 });

            //[1,3][1,3]
            //[[1,3],[2,6],[8,10],[15,18]]
            //[[0,5],[1,4]]
            foreach (Numbers numbers in sortedIntervals)
            {
                if (MergedIntervals[MergedIntervals.Count - 1].num2 >= numbers.num1)
                {
                    if (MergedIntervals[MergedIntervals.Count - 1].num2 >= numbers.num2)
                    {
                        continue;
                    }

                    MergedIntervals[MergedIntervals.Count - 1].num2 = numbers.num2;
                }
                else
                {
                    MergedIntervals.Add(new Numbers() { num1 = numbers.num1, num2 = numbers.num2 });
                }
            }

            int[][] result = new int[MergedIntervals.Count][];
            int k = 0;
            foreach (Numbers num in MergedIntervals)
            {
                result[k] = new int[2];
                result[k][0] = num.num1;
                result[k][1] = num.num2;
                k++;
            }

            return result;

        }
        public static int MaxSumSubArray(int[] numbers)
        {
            int max = numbers[0];
            int tempMax = 0;

            if (numbers.Length <= 1)
            {
                return numbers.Sum();
            }

            for (int i = 0; i <= numbers.Length - 1; i++)
            {
                tempMax = tempMax + numbers[i];
                if (tempMax > max)
                {
                    max = tempMax;
                }
                else if (tempMax < 0)
                {
                    tempMax = 0;
                }
            }

            return max;
        }
        private static int GetMaxLengthSequence(Dictionary<int, bool> numbers, int key)
        {
            int result = 0;
            while (numbers.ContainsKey(key))
            {
                result++;
                key++;
            }

            return result;
        }
        public static void NextPermutation(int[] nums)
        {
            Array.Sort(nums);

            int max = nums.Max();

            if (nums[0] == max)
            {
                Array.Sort(nums);
            }
            else
            {
                int temp = nums[nums.Length - 1];
                nums[nums.Length - 1] = nums[nums.Length - 2];
                nums[nums.Length - 2] = temp;
            }

        }
        public static int LongestConsecutiveEfficient(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            int result = 1;

            Dictionary<int, bool> numbers = new Dictionary<int, bool>();

            //100,4,200,1,3,2
            for (int i = 0; i < nums.Length; i++)
            {
                if (!numbers.ContainsKey(nums[i]))
                    numbers.Add(nums[i], true);
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (numbers.ContainsKey(nums[i] - 1))
                {
                    numbers[nums[i]] = false;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (numbers[nums[i]] == true)
                {
                    result = Math.Max(result, GetMaxLengthSequence(numbers, nums[i]));
                }
            }

            return result;
        }
        public static List<List<int>> DivideIntoArrayChunks(int[] arr, int divisor)
        {
            int temp = divisor;
            List<List<int>> returnList = new List<List<int>>();
            List<int> chunk = new List<int>();
            for (int i = 0; i <= arr.Length - 1; i++)
            {
                if (divisor == 0)
                {
                    returnList.Add(chunk);
                    chunk = new List<int>();
                    divisor = temp;
                }

                chunk.Add(arr[i]);
                divisor--;

                if (i == arr.Length - 1)
                {
                    returnList.Add(chunk);
                }
            }

            return returnList;

        }

        public static int MooreVotingAlgorithm(int[] nums)
        {

            nums = new int[] { 5, 1, 1, 5, 5 };
            int canIndex = 0;
            int count = 1;

            for (int i = 1; i <= nums.Length - 1; i++)
            {
                if (nums[canIndex] == nums[i])
                {
                    count++;
                }
                else
                {
                    count--;
                }

                if (count == 0)
                {
                    canIndex = i;
                    count = 1;
                }
            }

            return nums[canIndex];

        }

        public static bool CheckStraightLine(int[][] coordinates)
        {
            coordinates = new int[][] { new int[] { 1, 1 }, new int[] { 2, 2 }, new int[] { 3, 4 }, new int[] { 4, 5 }, new int[] { 5, 6 }, new int[] { 7, 7 } };


            int FirstpointX = coordinates[0][0];
            int FirstpointY = coordinates[0][1];
            int SecondpointX = coordinates[1][0];
            int SecondpointY = coordinates[1][1];
            int[] point = new int[2];
            float slope = 0;
            if (SecondpointX == FirstpointX)
            {
                slope = 100000;
            }
            else
            {
                slope = (float)(SecondpointY - (float)FirstpointY) / (SecondpointX - (float)FirstpointX);
            }

            float runningSlope = 0;

            for (int i = 2; i <= coordinates.GetLength(0) - 1; i++)
            {
                point = coordinates[i];

                if (point[0] == FirstpointX)
                {
                    runningSlope = 100000;
                }
                else
                {
                    runningSlope = (float)(point[1] - (float)FirstpointY) / (point[0] - (float)FirstpointX);
                }

                if (runningSlope != slope)
                {
                    return false;
                }
            }

            return true;
        }

        public static int FindJudge(int N, int[][] trust)
        {
            //trust = new int[][] { new int[] { 1, 3 }, new int[] { 1,4}, new int[] { 2,3}, new int[] { 2,4 }, new int[] { 4,3 }};

            N = 2;
            trust = new int[][] { new int[] { 1, 2 } };

            int[] resultArray = new int[N + 1];
            int[] relation = new int[2];

            for (int i = 0; i <= trust.GetLength(0) - 1; i++)
            {
                relation = trust[i];
                resultArray[relation[0]]--;
                resultArray[relation[1]]++;
            }

            for (int i = 1; i <= resultArray.Length - 1; i++)
            {
                if (resultArray[i] == N - 1)
                {
                    return i;
                }
            }

            return -1;
        }

        public static int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {

            image = new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 1, 1 } };
            sr = 1; sc = 1;
            newColor = 1;

            Queue<Coordinate> points = new Queue<Coordinate>();
            int rows = image.GetLength(0);
            int column = image[0].GetLength(0);
            Coordinate point = new Coordinate(sr, sc);
            points.Enqueue(point);
            int oldColor = image[sr][sc];

            if (oldColor == newColor)
            {
                return image;
            }

            while (points.Count() > 0)
            {
                Coordinate temp = points.Dequeue();

                image[temp.x][temp.y] = newColor;

                if (CheckIfPointInGridIsValid(rows, column, temp.x + 1, temp.y))
                {
                    if (CheckColorMatches(image[temp.x + 1][temp.y], oldColor))
                        points.Enqueue(new Coordinate(temp.x + 1, temp.y));
                }
                if (CheckIfPointInGridIsValid(rows, column, temp.x - 1, temp.y))
                {
                    if (CheckColorMatches(image[temp.x - 1][temp.y], oldColor))
                        points.Enqueue(new Coordinate(temp.x - 1, temp.y));
                }
                if (CheckIfPointInGridIsValid(rows, column, temp.x, temp.y + 1))
                {
                    if (CheckColorMatches(image[temp.x][temp.y + 1], oldColor))
                        points.Enqueue(new Coordinate(temp.x, temp.y + 1));
                }
                if (CheckIfPointInGridIsValid(rows, column, temp.x, temp.y - 1))
                {
                    if (CheckColorMatches(image[temp.x][temp.y - 1], oldColor))
                        points.Enqueue(new Coordinate(temp.x, temp.y - 1));
                }
            }

            return image;
        }

        public static bool CheckIfPointInGridIsValid(int rows, int column, int x, int y)
        {
            if (x < 0 || x > rows - 1 || y < 0 || y > column - 1)
            {
                return false;
            }

            return true;
        }

        public static bool CheckColorMatches(int currentColor, int baseColor)
        {
            return currentColor == baseColor;
        }

        public static string RemoveKdigits(string number, int k)
        {
            if (number.Length == k)
            {
                return "0";
            }

            int i = 0;

            while (k > 0)
            {
                i = i <= 0 ? 0 : --i;
                while (i <= number.Length - 2 && number[i] <= number[i + 1])
                {
                    i++;
                }

                if (i == number.Length - 1)
                {
                    number = number.Substring(0, number.Length - 1);
                }
                else
                {
                    number = number.Substring(0, i) + number.Substring(i + 1);
                }

                k--;
            }

            i = 0;

            while (number[i] == '0' && i < number.Length - 1)
                i++;

            if (i > 0)
            {
                number = number.Substring(i);
            }

            if (number.Length == 0)
            {
                return "0";
            }

            return number;
        }

        public static int FindMaxLength(int[] nums)
        {
            int[] runningCountArray = new int[nums.Length];
            int runningCount = 0;
            int max = 0;

            for (int i = 0; i <= nums.Length - 1; i++)
            {
                if (nums[i] == 0)
                {
                    ++runningCount;
                }
                else
                {
                    --runningCount;
                }

                runningCountArray[i] = runningCount;
            }

            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            keyValuePairs.Add(0, -1);

            for (int i = 0; i <= runningCountArray.Length - 1; i++)
            {
                if (keyValuePairs.ContainsKey(runningCountArray[i]))
                {
                    max = Math.Max(max, i - keyValuePairs[runningCountArray[i]]);
                }
                else
                {
                    keyValuePairs.Add(runningCountArray[i], i);
                }
            }

            return max;

        }

        //[ -1,3,-1,3,4,8,-11,5,2,-5 ]
        public static int MaxSubArray(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            if (nums.Length == 1)
            {
                return nums[0];
            }

            int sumMax = nums[0];
            int sumMax_current = nums[0];

            for (int i = 1; i <= nums.Length - 1; i++)
            {
                //[-1, 3, -1, 3, 4, 8, -11, 5, 2, -5]
                sumMax_current = Math.Max(sumMax_current + nums[i], nums[i]);

                sumMax = Math.Max(sumMax, sumMax_current);
            }

            return sumMax;

        }

        public static string IntegerToRoman(int number)
        {
            string[] units = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            string[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] hundred = { "", "C", "CC", "CCC", "CD", "D", "DX", "DXX", "DXXX", "CM" };
            string[] thousand = { "", "M", "MM", "MMM" };

            //3124
            return thousand[number / 1000] + hundred[(number % 1000) / 100] + tens[(number % 100) / 10] + units[(number % 10)];

        }

        public static int RomanToInteger(string romanNumber)
        {

            if (string.IsNullOrEmpty(romanNumber))
            {
                return 0;
            }

            Dictionary<string, int> mapper = new Dictionary<string, int>();

            mapper.Add("I", 1);
            mapper.Add("V", 5);
            mapper.Add("X", 10);
            mapper.Add("L", 50);
            mapper.Add("C", 100);
            mapper.Add("D", 500);
            mapper.Add("M", 1000);

            int result = 0;

            for (int i = 0; i < romanNumber.Length; i++)
            {
                if (i > 0 && mapper[romanNumber[i].ToString()] > mapper[romanNumber[i - 1].ToString()])
                {
                    result += mapper[romanNumber[i].ToString()] - 2 * mapper[romanNumber[i - 1].ToString()];
                }
                else
                {
                    result += mapper[romanNumber[i].ToString()];
                }

            }

            return result;
        }

        private static int StringToInteger(string number)
        {
            int result = 0;
            int incrementer = 1;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                if (number[i] - '0' <= 9 && number[i] - '0' >= 0)
                {
                    result += (number[i] - '0') * incrementer;
                    incrementer *= 10;
                }
                else
                {
                    return -1;
                }
            }

            return result;
        }

        public static int StrStr(string main, string sub)
        {
            if (string.IsNullOrEmpty(main) || (sub.Length > main.Length))
            {
                return -1;
            }

            if (string.IsNullOrEmpty(sub))
            {
                return 0;
            }

            int mainLength = main.Length;
            int subLength = sub.Length;
            int j = 0;

            for (int i = 0; i <= mainLength - subLength; i++)
            {
                for (j = 0; j < subLength; j++)
                {
                    if (main[i + j] != sub[j])
                    {
                        break;
                    }
                }

                if (j == subLength)
                {
                    return i;
                }
            }

            return -1;

        }

        public static void NextPermutaion1(List<int> nums, int index, List<int> temp, List<List<int>> result, int size)
        {
            if (temp.Sum() == size)
            {
                List<int> t = new List<int>();
                t.AddRange(temp);
                result.Add(t);
                return;
            }

            for (int i = index; i < nums.Count(); i++)
            {
                if (i > index && nums[i] == nums[i - 1])
                    continue;

                if (temp.Sum() + nums[i] <= size)
                {
                    temp.Add(nums[i]);
                    NextPermutaion1(nums, i + 1, temp, result, size);
                    temp.Remove(nums[i]);
                }
            }
        }

        public static int ReversePairs(int[] nums)
        {
            int count = 0;

            long n1, n2;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    n1 = (long)nums[i];
                    n2 = (long)nums[j] * 2;
                    if (n1 > n2)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        //1,2,2,3,3,3,4,4,5
        public static int[] RemoveDuplicate(int[] nums)
        {
            if (nums.Length < 2)
            {
                return nums;
            }

            int j = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] != nums[i + 1])
                {
                    nums[j] = nums[i];
                    j++;
                }
            }

            nums[j] = nums[nums.Length - 1];

            return nums;


        }

        //[-1,3,4,5,2,2,2,2]
        public static int LongestIncreaingSubsequence(int[] nums)
        {
            int count = 1;
            int elementToCompare;
            int tempresult = 1;

            for (int i = 0; i < nums.Length; i++)
            {
                elementToCompare = nums[i];
                for (int j = i; j < nums.Length; j++)
                {
                    if (elementToCompare < nums[j])
                    {
                        elementToCompare = nums[j];
                        tempresult++;
                    }
                }

                count = Math.Max(count, tempresult);
                tempresult = 1;
            }




            return count;
        }

        public static void SieveOfErosthesis()
        {
            bool[] numbers = new bool[20];

            for (int i = 2; i < numbers.Length; i++)
            {
                numbers[i] = true;
            }

            for (int i = 2; i < Math.Sqrt(numbers.Length); i++)
            {
                if (numbers[i])
                {
                    for (int j = i * i; j < numbers.Length; j = j + i)
                    {
                        numbers[j] = false;
                    }
                }

            }
        }

        public static int Compress(char[] chars)
        {

            if (chars.Length == 1 || chars.Length == 0)
            {
                return chars.Length;
            }

            List<string> result = new List<string>();
            int count = 1;
            int i = 0;

            for (; i < chars.Length - 1; i++)
            {
                if (chars[i] == chars[i + 1])
                {
                    count++;
                }
                else
                {

                    result.Add(chars[i].ToString());

                    if (count > 9)
                    {
                        char[] temp = count.ToString().ToCharArray();

                        for (int j = 0; j < temp.Length; j++)
                        {
                            result.Add(temp[j].ToString());
                        }
                    }
                    else if (count > 1)
                    {
                        result.Add(count.ToString());
                    }

                    count = 1;
                }
            }

            result.Add(chars[i - 1].ToString());

            if (count > 9)
            {
                char[] temp = count.ToString().ToCharArray();

                for (int j = 0; j < temp.Length; j++)
                {
                    result.Add(temp[j].ToString());
                }
            }
            else
            {
                result.Add(count.ToString());
            }

            return result.Count;

        }

        public static string ReverseWordsInAString(string input)
        {
            if (input.Length == 0)
            {
                return input;
            }

            List<string> mystring = input.Trim().Split(' ').ToList();

            mystring = mystring.Where(x => x.Length > 0).Select(x => x).ToList();

            string output = string.Empty;

            for (int i = mystring.Count - 1; i >= 0; i--)
            {
                output += mystring[i].Trim() + " ";
            }

            return output.Substring(0, output.Length - 1);
        }

        public static string ReverseWordsWithoutExtraSpace(string input)
        {
            string output = string.Empty;
            string temp = string.Empty;

            //"the sky is blue"

            input = input.Trim();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (input[i].ToString() == " ")
                {
                    if (temp.Length > 0)
                    {
                        output = output + " " + temp;
                        temp = string.Empty;
                    }
                    continue;
                }
                else
                {
                    temp = input[i] + temp;
                }
            }

            if (temp.Length > 0)
            {
                output = output + " " + temp;
            }

            return output.Substring(1);
        }
    }
}
