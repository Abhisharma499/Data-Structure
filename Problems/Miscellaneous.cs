using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    class Miscellaneous
    {
        public static async Task TestMethod1()
        {

            Console.WriteLine("1");
            await Task.Delay(1);
        }
        public static async Task TestMethod2()
        {
            Console.WriteLine("2");
            await Task.Delay(1);
        }
        public static int Test(params int[] numbers)
        {

            return 0;
        }
        public static string CompressString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            int count = 1;
            string result = string.Empty;

            //wwwwaaadexxxxxxywww
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i - 1] == input[i])
                {
                    count++;
                }
                else
                {
                    if (count == 1)
                    {
                        result += input[i - 1];
                    }
                    else
                    {
                        result += input[i - 1] + count.ToString();
                    }

                    count = 1;

                }
            }

            if (count == 1)
            {
                result += input[input.Length - 1];
            }
            else
            {
                result += input[input.Length - 1] + count.ToString();
            }

            return result;
        }
        public static void BFS(int[][] graph, bool[] visited, int start)
        {
            Queue<int> nodes = new Queue<int>();

            nodes.Enqueue(start);
            visited[start] = true;
            int numberOfVertices = graph[0].Length;


            while (nodes.Count() > 0)
            {
                int current = nodes.Dequeue();
                Console.WriteLine(current);

                for (int i = 0; i < numberOfVertices; i++)
                {
                    if (graph[current][i] == 1 && visited[i] != true)
                    {
                        nodes.Enqueue(i);
                        visited[i] = true;
                    }
                }

            }
        }
        public static void DFSGraph(int[][] graph, bool[] visited, int start)
        {
            Console.WriteLine(start);
            visited[start] = true;

            int length = graph[0].Length;

            for (int i = 0; i < length; i++)
            {
                if (graph[start][i] == 1 && visited[i] == false)
                {
                    DFSGraph(graph, visited, i);
                }
            }

        }

        public static void RefVsOut(out int num)
        {
            num = 10;
            num = num + 1;
        }


        private static async Task NewMethod()
        {
            Task task = TestMethod1();
            Task task2 = TestMethod2();

            List<Task> myTasks = new List<Task>() { task, task2 };

            while (myTasks.Count() > 0)
            {
                Task finishedTask = await Task.WhenAny(myTasks);

                if (finishedTask == task)
                {
                    Console.WriteLine("Task 1 finished");
                }
                else if (finishedTask == task2)
                {
                    Console.WriteLine("Task 2 finished");
                }
                myTasks.Remove(finishedTask);
            }
        }

        public static char maximumOccurringCharacter(string text)
        {

            Dictionary<char, int> map = new Dictionary<char, int>();

            foreach (char chr in text.ToCharArray())
            {
                if (map.ContainsKey(chr))
                {
                    map[chr]++;
                }
                else
                {
                    map[chr] = 1;
                }
            }

            return map.OrderByDescending(x => x.Value).FirstOrDefault().Key;

        }

        public static int MagicNumber(int number, int multiplyNumber)
        {
            int result = 0;
            int multiplier = multiplyNumber;
            if (number <= 0)
            {
                return 0;
            }
            if (number == 1)
            {
                return multiplyNumber;
            }

            while (number != 0)
            {

                result += (number & 1) * multiplier;
                number = number >> 1;
                multiplier = multiplier * multiplyNumber;
            }

            return result;

        }

        public static int Atoi(string strNumber)
        {
            if (string.IsNullOrEmpty(strNumber))
            {
                return 0;
            }

            int resultNumber = 0;


            foreach (char ch in strNumber)
            {
                if (ch - 48 < 0 || ch - 48 > 9)
                {
                    resultNumber = 0;
                    break;
                }
                else
                {
                    resultNumber = resultNumber * 10 + (ch - 48);
                }

            }

            return resultNumber;
        }

        public static int MaxinWindowsSizeOfK(int[] numbers, int k)
        {
            int sum = 0, tempSum = 0;
            int i = 0, j = 0;


            while (j < numbers.Length)
            {
                tempSum += numbers[j];

                while (j - i + 1 != k)
                {
                    j++;
                    tempSum += numbers[j];
                }

                if (j - i + 1 == k)
                {
                    sum = Math.Max(sum, tempSum);
                }

                tempSum = tempSum - numbers[i];
                i++;
                j++;
            }

            return sum;
        }

        public static int DivideWithOutOperator(int bigNumber, int smallNumber)
        {
            int count = 0;
            int incrementor = 0;
            bool isNegativeNumber = false;

            if (bigNumber < 0)
            {
                isNegativeNumber = true;
            }

            while (true)
            {
                while (bigNumber - (smallNumber * (1 << incrementor)) >= 0)
                {
                    incrementor++;
                }

                bigNumber = bigNumber - smallNumber * (1 << incrementor - 1);

                count = count + (1 << incrementor - 1);
                incrementor = 0;

                if (bigNumber == 0)
                {
                    return isNegativeNumber ? -1 * count : count; ;
                }
                else if (bigNumber < smallNumber)
                {
                    return isNegativeNumber ? -1 * count : count;
                }

            }
        }

        public static int CountTotalSetBit(int n)
        {
            int count = 0;

            if (n <= 0)
            {
                return 0;
            }

            while ((n & (n - 1)) != 0)
            {
                count++;
                n = n & (n - 1);
            }

            return count + 1;
        }

        public static int GetIndex(int[] nums)
        {
            int start = 0, end = nums.Length - 1, mid = -1;
            int total = end - start + 1;


            while (start <= end)
            {
                mid = start + (end - start) / 2;



                if (nums[mid] < nums[(mid - 1 + total) % total] && nums[mid] < nums[(mid + 1) % total])
                {
                    return mid;
                }
                else if (nums[mid] < nums[(mid - 1 + total) % total])
                {
                    return mid - 1;
                }

                else if (nums[mid] > nums[(mid + 1) % total])
                {
                    return mid + 1;
                }

                if (nums[start] < nums[mid])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }
            return -1;

        }

        public static int BinarySearch(int[] nums, int target, int startIndex, int endIndex)
        {
            int start = startIndex;
            int end = endIndex;
            int mid = -1;

            while (start <= end)
            {
                mid = start + (end - start) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] > target)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return -1;
        }
        public static int Search(int[] nums, int target)
        {
            int start = 0;
            int end = nums.Length - 1;

            if (nums.Length == 0)
            {
                return -1;
            }

            if (end == 0)
            {
                if (nums[end] == target)
                {
                    return end;
                }
                else
                {
                    return -1;
                }
            }

            if (nums[start] < nums[end])
            {
                return BinarySearch(nums, target, start, end);
            }
            int index = GetIndex(nums);

            if (index != -1)
            {

                int right = BinarySearch(nums, target, index, end);
                int left = BinarySearch(nums, target, start, index - 1);

                if (left == -1)
                {
                    return right;
                }
                else
                {
                    return left;
                }
            }

            return -1;
        }
        public static int KthSmallestElementInSortedArrays(int[] array1, int[] array2, int k)
        {
            if (array1.Length == 0 && array2.Length == 0)
            {
                return -1;
            }

            if (array1.Length == 0)
            {
                if (array2.Length > k)
                {
                    return array2[k - 1];
                }
                else
                {
                    return -1;
                }
            }

            if (array2.Length == 0)
            {
                if (array1.Length > k)
                {
                    return array1[k - 1];
                }
                else
                {
                    return -1;
                }
            }

            int n = array1.Length;
            int m = array2.Length;
            int i = 0, j = 0, count = 0;

            //2 3 6 7 9
            //1 4 8 10
            while (i < n && j < m)
            {
                if (array1[i] <= array2[j])
                {
                    count++;

                    if (count == k)
                    {
                        return array1[j];
                    }

                    i++;
                }
                else
                {
                    count++;

                    if (count == k)
                    {
                        return array1[j];
                    }

                    j++;
                }
            }


            while (i < n)
            {
                count++;
                if (count == k)
                {
                    return array1[i];
                }
                i++;
            }

            while (j < m)
            {
                count++;
                if (count == k)
                {
                    return array2[j];
                }
                j++;
            }



            return -1;

        }
        public static float SquareRootByBinarySearch(int start, int end, int number, int decimalPlaces)
        {
            int mid = 0;
            float result = -1;
            while (start <= end)
            {
                mid = start + (end - start) / 2;

                if (mid * mid == number)
                {
                    result = mid;
                    break;
                }
                else if (mid * mid < number)
                {
                    result = mid;
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            float decimalNumber = 0.1f;

            for (int i = 1; i <= 3; i++)
            {

                result = result + decimalNumber;

                while (result * result < number)
                {
                    result += decimalNumber;
                }

                if (result * result > number)
                {
                    result -= decimalNumber;
                }

                decimalNumber = decimalNumber / 10;
            }

            return result;
        }
        public static void CombinationSum3(int n, int index, int target, List<int> result, List<IList<int>> subsets, int k)
        {
            if (target < 0)
            {
                return;
            }

            List<int> temp = new List<int>();

            temp.AddRange(result);

            if (target == 0 && temp.Count() == k)
            {
                subsets.Add(temp);
                return;
            }




            for (int i = index; i <= n; i++)
            {
                result.Add(i);

                CombinationSum3(n, i + 1, target - i, result, subsets, k);

                result.Remove(i);

            }
        }

        public static void Combination(int index, List<int> result, List<IList<int>> subsets, int k, int n)
        {
            List<int> temp = new List<int>();
            temp.AddRange(result);
            if (temp.Count() == k)
            {
                subsets.Add(temp);
                return;
            }
            for (int i = index; i <= n; i++)
            {

                result.Add(i);
                Combination(i + 1, result, subsets, k, n);
                result.Remove(i);
            }
        }

        public static void Permutations(int[] numbers, List<int> result, List<IList<int>> subsets, int k)
        {
            List<int> temp = new List<int>();
            temp.AddRange(result);
            if (temp.Count() == k)
            {
                subsets.Add(temp);
                return;
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                if (result.Contains(numbers[i]))
                {
                    continue;
                }
                result.Add(numbers[i]);
                Permutations(numbers, result, subsets, k);
                result.Remove(numbers[i]);
            }
        }


        public static void Subsets(int[] numbers, int index, List<int> result, List<IList<int>> subsets)
        {
            List<int> temp = new List<int>();
            temp.AddRange(result);
            subsets.Add(temp);

            for (int i = index; i < numbers.Length; i++)
            {
                if (i > index && numbers[i] == numbers[i - 1])
                {
                    continue;
                }
                result.Add(numbers[i]);
                Subsets(numbers, i + 1, result, subsets);
                result.Remove(numbers[i]);
            }
        }
        public static void CombinationSum(int[] numbers, int index, int target, List<int> result, List<IList<int>> subsets)
        {
            List<int> temp = new List<int>();

            temp.AddRange(result);

            if (temp.Sum() == target)
            {
                subsets.Add(temp);
                return;
            }


            for (int i = index; i < numbers.Length; i++)
            {
                if (i > index && numbers[i] == numbers[i - 1])
                {
                    continue;
                }

                if (result.Sum() + numbers[i] > target)
                {
                    continue;
                }

                result.Add(numbers[i]);

                CombinationSum(numbers, i + 1, target, result, subsets);

                result.Remove(numbers[i]);
            }
        }


        public static void PrintPermutaions(char[] str, List<char> output, int lengthOfString)
        {
            if (lengthOfString == output.Count)
            {
                List<char> temp = new List<char>();
                Console.WriteLine();
                temp.AddRange(output);
                foreach (char ch in temp)
                    Console.Write(ch);
                return;
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (output.Contains(str[i]))
                {
                    continue;
                }

                output.Add(str[i]);

                PrintPermutaions(str, output, 3);

                output.Remove(output[output.Count() - 1]);

            }

        }

        public delegate int mydel(int a);
        static int[,] mem = new int[2, 2]
        {
            {1,2 },{1,2}
        };

        static int[][] maze = new int[3][]
        {
            new int[]{1,3,1},
            new int[]{1,5,1},
            new int[]{4,2,1},
        };

        static int One(int a)
        {
            Console.WriteLine(a);
            return 1;
        }
        static int Two(int a)
        {
            Console.WriteLine(a);
            return 2;
        }
        static int Three(int a)
        {
            Console.WriteLine(a);
            return 3;
        }

        static int[][] grid = new int[3][]
       {
            new int[]{2,1,2},
            new int[]{1,1,0},
            new int[]{0,1,1},
       };

        static int[][] array = new int[3][]
         {
                new int[]{},
                new int[]{},
                new int[]{},
         };

        public static string ReverseWordsInAString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            string temp = string.Empty;
            string result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ')
                {
                    temp = temp + input[i];
                }
                else
                {
                    if (temp != string.Empty)
                    {
                        result = temp + " " + result;
                    }

                    temp = string.Empty;
                }
            }

            if (result.Length > 0 && result[result.Length - 1] == ' ')
            {
                if (temp == string.Empty)
                {
                    return result.Substring(0, result.Length - 1); ;
                }

                return temp + " " + result.Substring(0, result.Length - 1);
            }

            if (result == string.Empty)
            {
                return temp;
            }

            return temp + " " + result;
        }

        public static string ReverseWordsInAStringWithStack(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            Stack<string> words = new Stack<string>();
            string temp = string.Empty;
            string result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    if (temp != string.Empty)
                    {
                        words.Push(temp);
                        temp = string.Empty;
                    }
                }
                else
                {
                    temp = temp + input[i];
                }
            }

            if (temp != string.Empty)
            {
                result = result + temp;

            }

            temp = string.Empty;

            while (words.Count() > 0)
            {
                temp = words.Pop();

                result = result + " " + temp;
            }

            if (result.Length > 0 && result[0] == ' ')
            {
                return result.Substring(1);
            }

            return result;
        }

        static void PowerSetBinary()
        {
            List<List<int>> result = new List<List<int>>();
            List<int> y = new List<int> { 1, 2, 3 };

            for (int i = 0; i <= 7; i++)
            {
                List<int> temp = new List<int>();
                for (int j = 0; j <= 2; j++)
                {
                    if ((i & 1 << j) > 0)
                    {
                        temp.Add(y[j]);
                    }
                }

                result.Add(temp);
            }


        }

        public static int FindMin(int[] nums)
        {
            int start = 0, end = nums.Length - 1;
            if (nums.Length == 1)
            {
                return nums[0];
            }
            else if (nums[0] <= nums[end])
            {
                return nums[0];
            }

            int mid = 0;
            int lengthOfArray = nums.Length;

            while (start <= end)
            {
                mid = start + (end - start) / 2;

                if ((nums[mid] < nums[(mid - 1 + lengthOfArray) % lengthOfArray]) && (nums[mid] < nums[(mid + 1) % lengthOfArray]))
                {
                    return nums[mid];
                }

                else if (nums[mid] >= nums[start])
                {
                    start = mid;
                }
                else
                {
                    end = mid;
                }
            }

            return -1;
        }

        public static int NumberOfSubArrayWithSumK(int[] nums, int k)
        {
            if (nums.Length == 0 && k == 0)
            {
                return 1;
            }

            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            keyValuePairs.Add(0, 1);
            int count = 0;
            int sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum = sum + nums[i];
                if (keyValuePairs.ContainsKey(sum - k))
                {
                    count = count + keyValuePairs[sum - k];
                    if (keyValuePairs.ContainsKey(sum))
                    {
                        keyValuePairs[sum]++;
                    }
                    else
                    {
                        keyValuePairs.Add(sum, 1);
                    }
                }
                else
                {
                    keyValuePairs[sum] = 1;
                }
            }

            return count;
        }

        //2,8,-3,-5,2,-4,6,1,2,1,-3,4
        public static int LargestSubArrayWithGivenSum(int[] nums, int k)
        {

            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            int result = 0;
            int sum = 0;
            keyValuePairs.Add(0, -1);

            for (int i = 0; i < nums.Length; i++)
            {
                sum = sum + nums[i];

                //2,8,-3,-5,2,-4,6,1,2,1,-3,4

                if (sum == k)
                {
                    if (keyValuePairs.ContainsKey(k))
                    {
                        result = Math.Max(result, i - keyValuePairs[k]);
                    }
                    else
                    {
                        result = Math.Max(result, i + 1);
                        keyValuePairs.Add(sum, i);
                    }
                }
                else
                {
                    if (!keyValuePairs.ContainsKey(sum))
                    {
                        keyValuePairs.Add(sum, i);
                    }
                }

            }

            return result;

        }

        public static int LargestSubArrayWithSumZero(int[] nums, int k)
        {
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            int result = 0;
            int sum = 0;
            keyValuePairs.Add(0, -1);

            for (int i = 0; i < nums.Length; i++)
            {
                sum = sum + nums[i];

                if (!keyValuePairs.ContainsKey(sum))
                {
                    keyValuePairs.Add(sum, i);
                }
                else
                {
                    result = Math.Max(result, i - keyValuePairs[sum]);
                }
            }

            return result;
        }

        public static int LargestSubstringWithNonRepeatingCharacter(string s)
        {
            int start = 0, end = 0;
            Dictionary<char, int> charPositionMap = new Dictionary<char, int>();

            int result = 0;

            while (end < s.Length)
            {
                if (charPositionMap.ContainsKey(s[end]))
                {
                    start = Math.Max(start, charPositionMap[s[end]] + 1);
                    charPositionMap[s[end]] = end;

                }
                else
                {
                    charPositionMap.Add(s[end], end);
                }

                result = Math.Max(result, end - start + 1);
                end++;
            }

            return result;
        }
        public int findMin(int[] nums)
        {
            // If the list has just one element then return that element.
            if (nums.Length == 1)
            {
                return nums[0];
            }

            // initializing left and right pointers.
            int left = 0, right = nums.Length - 1;

            // if the last element is greater than the first element then there is no rotation.
            // e.g. 1 < 2 < 3 < 4 < 5 < 7. Already sorted array.
            // Hence the smallest element is first element. A[0]
            if (nums[right] > nums[0])
            {
                return nums[0];
            }

            // Binary search way
            while (right >= left)
            {
                // Find the mid element
                int mid = left + (right - left) / 2;

                // if the mid element is greater than its next element then mid+1 element is the smallest
                // This point would be the point of change. From higher to lower value.
                if (nums[mid] > nums[mid + 1])
                {
                    return nums[mid + 1];
                }

                // if the mid element is lesser than its previous element then mid element is the smallest
                if (nums[mid - 1] > nums[mid])
                {
                    return nums[mid];
                }

                // if the mid elements value is greater than the 0th element this means
                // the least value is still somewhere to the right as we are still dealing with elements
                // greater than nums[0]
                if (nums[mid] > nums[0])
                {
                    left = mid + 1;
                }
                else
                {
                    // if nums[0] is greater than the mid value then this means the smallest value is somewhere to
                    // the left
                    right = mid - 1;
                }
            }
            return -1;
        }
        public static List<List<int>> PowersetSoln(List<int> array)
        {
            var subsets = new List<List<int>>();
            subsets.Add(new List<int>());

            for (int i = 0; i < array.Count; i++)
            {
                int subsetLen = subsets.Count;
                for (int innerSubset = 0; innerSubset < subsetLen; innerSubset++)
                {
                    var newSubset = new List<int>(subsets[innerSubset]);
                    newSubset.Add(array[i]);
                    subsets.Add(newSubset);
                }

            }

            return subsets;
        }
        public static void PowersetSoln(List<int> array, List<List<int>> result, List<int> output, int index)
        {
            List<int> temp = new List<int>();
            temp.AddRange(output);
            result.Add(temp);

            for (int i = index; i < array.Count(); i++)
            {
                output.Add(array[i]);

                PowersetSoln(array, result, output, i + 1);

                output.RemoveAt(output.Count() - 1);
            }
        }

        public static bool PerfectNumber(int number)
        {
            if (number <= 0)
            {
                return false;
            }

            int sumOfFactors = 1;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    sumOfFactors += i;
                    sumOfFactors += number / i;
                }
            }

            return sumOfFactors == number;

        }

        public static int LCS(string str1, string str2, int n, int m)
        {
            if (n < 1 || m < 1)
            {
                return 0;
            }

            if (str1[n - 1] == str2[m - 1])
            {
                return 1 + LCS(str1, str2, n - 1, m - 1);
            }
            else
            {
                return Math.Max(LCS(str1, str2, n - 1, m), LCS(str1, str2, n, m - 1));
            }
        }

        public static int StrStr(string big, string small)
        {
            if (string.IsNullOrEmpty(small) && string.IsNullOrEmpty(big))
            {
                return 0;
            }

            if (big.Length < small.Length)
            {
                return -1;
            }

            int bigLength = big.Length;
            int smallLength = small.Length;
            bool Ismatch = true;

            for (int i = 0; i < bigLength - smallLength + 1; i++)
            {
                Ismatch = true;

                //"hello"
                //ll
                for (int j = 0; j < smallLength; j++)
                {
                    if (big[j + i] != small[j])
                    {
                        Ismatch = false;
                        break;
                    }
                }

                if (Ismatch)
                {
                    return i;
                }
            }

            return -1;

        }

        public static string LongestCommonPrefix(string[] inputs)
        {
            if (inputs.Length == 0)
            {
                return "";
            }

            string prefix = inputs[0];


            for (int i = 1; i < inputs.Length; i++)
            {
                while (inputs[i].IndexOf(prefix) != 0)
                {
                    prefix = prefix.Remove(prefix.Length - 1, 1);

                    if (prefix == string.Empty)
                    {
                        return prefix;
                    }
                }
            }

            return prefix;
        }

        public static string CountAndSay(int n)
        {
            string result = "1";
            string tempResult = string.Empty;
            int count = 1;
            string finalResult1 = result + Environment.NewLine;
            int j;

            for (int i = 2; i <= n; i++)
            {
                for (j = 0; j < result.Length; j++)
                {
                    if (j + 1 < result.Length && result[j] == result[j + 1])
                    {
                        count++;
                        continue;
                    }

                    tempResult += count.ToString() + result[j].ToString();
                    count = 1;
                }

                result = tempResult;
                finalResult1 += result + Environment.NewLine;
                tempResult = string.Empty;
            }

            return finalResult1;
        }

        public static bool CheckIfGraphBiPartitie(int[] graph, int[] color, int m, int startingVertex, int totalVertex)
        {
            if (startingVertex == totalVertex)
            {
                return true;
            }

            for (int i = 1; i <= m; i++)
            {
                if (IsValidColor(startingVertex, i))
                {
                    color[startingVertex] = i;

                    bool isNextColorable = CheckIfGraphBiPartitie(graph, color, m, startingVertex + 1, totalVertex);

                    if (isNextColorable)
                    {
                        return true;
                    }

                    color[startingVertex] = 0;
                }
            }

            return false;

        }

        public static bool IsValidColor(int V, int color)
        {
            return true;
        }

        public static bool WordBreak(string s, IList<string> wordDict)
        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }

            for (int i = 1; i <= s.Length; i++)
            {
                if (wordDict.Contains(s.Substring(0, i)) && WordBreak(s.Substring(i), wordDict))
                {
                    return true;
                }
            }

            return false;
        }

        public static IList<string> WordBreak2(string s, IList<string> wordDict)
        {
            List<string> result = new List<string>();

            WordBreakHelper(s, "", wordDict, result);



            return result;
        }

        public static void WordBreakHelper(string s, string output, IList<string> wordDict, List<string> result)
        {
            if (string.IsNullOrEmpty(s))
            {
                result.Add(output.Trim());
                return;
            }

            string leftPart = string.Empty;
            string rightPart = string.Empty;

            for (int i = 0; i < s.Length; i++)
            {
                leftPart = s.Substring(0, i + 1);

                if (wordDict.Contains(leftPart))
                {
                    rightPart = s.Substring(i + 1);

                    WordBreakHelper(rightPart, output + leftPart + " ", wordDict, result);
                }
            }

        }

        public static int CountNumberOfDistinctElementsInWindows(List<int> numbers, int k)
        {
            //2 5 5 6 3 2 3 2 4 5 2 2 2 2 3 6
            //k= 4
            int result = 0;
            int i = 0, j = 0;
            Dictionary<int, int> elements = new Dictionary<int, int>();

            while (j < numbers.Count())
            {
                if (elements.ContainsKey(numbers[j]))
                {
                    elements[numbers[j]]++;
                }
                else
                {
                    elements[numbers[j]] = 1;
                }

                while (j - i + 1 < k)
                {
                    j++;

                    if (elements.ContainsKey(numbers[j]))
                    {
                        elements[numbers[j]]++;
                    }
                    else
                    {
                        elements[numbers[j]] = 1;
                    }

                }

                if (j - i + 1 == k)
                {
                    result = Math.Max(elements.Count(), result);
                }

                if (elements.ContainsKey(numbers[i]))
                {
                    if (elements[numbers[i]] > 0)
                    {
                        elements[numbers[i]]--;
                    }

                    if (elements[numbers[i]] == 0)
                    {
                        elements.Remove(numbers[i]);
                    }
                }

                i++;
                j++;
            }

            return result;
        }
    }
}
