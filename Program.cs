using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructure
{

    public static class Test
    {
        public static int Add10(this int b)
        {
            return b + 10;
        }
    }


    public class Solution
    {
        int a = 10;
        Dictionary<int, string> map = new Dictionary<int, string>();
        List<int> numbers;
        List<string> words;
        public string NumberToWords(int num)
        {

            numbers = new List<int>() { 1000000000, 1000000, 1000, 100 };
            words = new List<string>() { "Billion", "Million", "Thousand", "Hundred" };

            if (num == 0)
            {
                return "Zero";
            }

            SetMap();


            return Helper(num);
        }

        public string Helper(int num)
        {
            string result = string.Empty;

            if (map.ContainsKey(num))
            {
                return map[num];
            }

            if (num < 100)
            {
                return Helper((num / 10) * 10) + " " + Helper((num % 10));
            }

            for (int i = 0; i < numbers.Count(); i++)
            {
                if (num < numbers[i])
                {
                    continue;
                }
                else
                {
                    result = Helper(num / numbers[i]) + " " + words[i] + " " + Helper(num % numbers[i]);
                }
            }

            return result;
        }

        public void SetMap()
        {
            map.Add(0, "");
            map.Add(1, "One");
            map.Add(2, "Two");
            map.Add(3, "Three");
            map.Add(4, "Four");
            map.Add(5, "Five");
            map.Add(6, "Six");
            map.Add(7, "Seven");
            map.Add(8, "Eight");
            map.Add(9, "Nine");
            map.Add(10, "Ten");
            map.Add(11, "Eleven");
            map.Add(12, "Twelve");
            map.Add(13, "Thirteen");
            map.Add(14, "Fourteen");
            map.Add(15, "Fifteen");
            map.Add(16, "Sixteen");
            map.Add(17, "Seventeen");
            map.Add(18, "Eighteen");
            map.Add(19, "Nineteen");
            map.Add(20, "Twenty");
            map.Add(30, "Thirty");
            map.Add(40, "Forty");
            map.Add(50, "Fifty");
            map.Add(60, "Sixty");
            map.Add(70, "Seventy");
            map.Add(80, "Eighty");
            map.Add(90, "Ninety");
        }

    }

    class MyClass : IComparable<MyClass>
    {
        public char ch;
        public int freq;

        public MyClass(char c, int f)
        {
            ch = c;
            freq = f;
        }

        public int CompareTo(MyClass other)
        {
            return this.freq.CompareTo(other.freq);
        }
    }
    class PositionPair
    {
        public int element, pos;
        public PositionPair(int e, int p)
        {
            element = e;
            pos = p;
        }
    }
    public class Pair
    {
        public int x, y, pos;

        public Pair(int start, int end, int pass)
        {
            x = start;
            y = end;
            pos = pass;
        }
    }

    public class Stock
    {
        public int Index;
        public int Value;

        public Stock(int i, int v)
        {
            Index = i;
            Value = v;
        }
    }
    class SortPair : IComparable<SortPair>
    {
        public int listNo;
        public int val;
        public int pos;

        public SortPair(int listNo, int val, int pos)
        {
            this.listNo = listNo;
            this.val = val;
            this.pos = pos;
        }

        public int CompareTo(SortPair other)
        {
            return this.val.CompareTo(other.val);
        }
    }
    public class Trie
    {
        public bool IsEnd;
        public Dictionary<string, Trie> next;
    }

    public class TweetCounts
    {
        Dictionary<string, List<int>> map = new Dictionary<string, List<int>>();

        public TweetCounts()
        {
            map = new Dictionary<string, List<int>>();
        }

        public void RecordTweet(string tweetName, int time)
        {
            if (map.ContainsKey(tweetName))
            {
                map[tweetName].Add(time);
            }
            else
            {
                map.Add(tweetName, new List<int>() { time });
            }
        }





        public IList<int> GetTweetCountsPerFrequency(string freq, string name, int startTime, int endTime)
        {
            List<int> result = new List<int>();
            int[] output;

            if (map.ContainsKey(name))
            {
                if (freq == "minute")
                {
                    output = new int[(endTime - startTime) / 60 + 1];

                    List<int> frequencies = new List<int>();

                    frequencies = map[name];

                    foreach (int fr in frequencies)
                    {
                        if (fr >= startTime && fr <= endTime)
                        {
                            output[(fr - startTime) / 60]++;
                        }
                    }

                    result = output.ToList();
                }


                else if (freq == "hour")
                {
                    output = new int[(endTime - startTime) / (60 * 60) + 1];

                    List<int> frequencies = new List<int>();

                    frequencies = map[name];

                    foreach (int fr in frequencies)
                    {
                        if (fr >= startTime && fr <= endTime)
                        {
                            output[(fr - startTime) / (60 * 60)]++;
                        }
                    }

                    result = output.ToList();
                }

                else
                {
                    output = new int[(endTime - startTime) / (60 * 60 * 24) + 1];

                    List<int> frequencies = new List<int>();

                    frequencies = map[name];

                    foreach (int fr in frequencies)
                    {
                        if (fr >= startTime && fr <= endTime)
                        {
                            output[(fr - startTime) / (60 * 60 * 24)]++;
                        }
                    }

                    result = output.ToList();
                }
            }

            return result;
        }
    }

    public class Program
    {

        static int MOD = 1000000007;
        public static int distinctMoves(string s, int n, int x, int y)
        {

            char[] str = s.ToCharArray();

            return solve(str, n, x, y);

        }

        public static int solve(char[] s, int n, int x, int y)
        {
            int[] prevSame = new int[s.Length];
            int idxL = -1;
            int idxR = -1;
            for (int i = 0; i < prevSame.Length; i++)
            {
                if (s[i] == 'l')
                {
                    prevSame[i] = idxL;
                    idxL = i;
                }
                else
                {
                    prevSame[i] = idxR;
                    idxR = i;
                }
            }

            long[][] dp = new long[s.Length + 1][];

            for (int i = 0; i < s.Length + 1; i++)
            {
                dp[i] = new long[n + 1];
            }

            dp[0][x] = 1;
            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    dp[i][j] = dp[i - 1][j];

                    if (s[i - 1] == 'l')
                    {
                        if (j + 1 <= n)
                        {
                            dp[i][j] += dp[i - 1][j + 1];
                        }
                        if (j + 1 <= n && prevSame[i - 1] >= 0)
                        {
                            dp[i][j] -= dp[prevSame[i - 1] + 1 - 1][j + 1];
                        }
                    }
                    else
                    {
                        if (j - 1 >= 0)
                        {
                            dp[i][j] += dp[i - 1][j - 1];
                        }
                        if (j - 1 >= 0 && prevSame[i - 1] >= 0)
                        {
                            dp[i][j] -= dp[prevSame[i - 1] + 1 - 1][j - 1];
                        }
                    }

                    dp[i][j] = (dp[i][j] + MOD) % MOD;
                }
            }

            return (int)dp[s.Length][y];
        }

        public static bool SearchMatrix(int[][] matrix, int target)
        {
            int rows = matrix.GetUpperBound(0) + 1;
            int cols = matrix[0].Length;

            int rs = 0;
            int cs = cols - 1;

            while (rs < rows && cs < cols)
            {
                if (target == matrix[rs][cs])
                {
                    return true;
                }
                else if (target < matrix[rs][cs])
                {
                    cs--;
                }
                else
                {
                    rs++;
                }
            }

            return false;
        }

        public static void NextraTest(int[] nums)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i]))
                {
                    map[nums[i]]++;
                }
                else
                {
                    map.Add(nums[i], 1);
                }
            }

            map = map.OrderByDescending(x => x.Value).ThenByDescending(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in map)
            {
                Console.WriteLine(item.Key);
            }
        }

        static void Main()
        {
            FirstMissingPositive(new int[] { 1, 2, 0 });
        }

        public static int FirstMissingPositive(int[] arr)
        {
            if (arr.Length == 0)
            {
                return 1;
            }

            int i = 0;
            //3,4,-1,1
            while (i < arr.Length)
            {
                if (arr[i] > 0 && arr[i] <= arr.Length && arr[i] != arr[arr[i] - 1])
                {
                    int otherIndex = arr[i] - 1;
                    int temp = arr[otherIndex];
                    arr[otherIndex] = arr[i];
                    arr[i] = temp;
                }
                else
                {
                    i++;
                }
            }

            for (int k = 0; k < arr.Length; k++)
            {
                if (arr[k] != k + 1)
                {
                    return k + 1;
                }
            }

            return arr.Length + 1;
        }

        public static int NumSquares(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 0;
            dp[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                int min = int.MaxValue;

                for (int j = 1; j <= i * i; j++)
                {
                    int temp = i - j * j;

                    min = Math.Min(dp[temp], min);

                }

                dp[i] = min + 1;
            }

            return dp[n];
        }

        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

            List<IList<string>> result = new List<IList<string>>();

            foreach (var str in strs)
            {
                string org = str;
                string sortted = new String(str.OrderBy(x => x).ToArray());


                if (map.ContainsKey(sortted))
                {
                    map[sortted].Add(org);
                }
                else
                {
                    map.Add(sortted, new List<string>() { org });
                }
            }

            foreach (var pair in map)
            {
                result.Add(pair.Value);
            }

            return result;
        }

        public static int Search(int[] nums, int target)
        {
            if (nums.Length == 0)
            {
                return -1;
            }

            int start = 0, end = nums.Length - 1;

            while (start < end)
            {
                int mid = (start) + (end - start) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[start] <= nums[mid])
                {
                    if (target >= nums[start] && target <= nums[mid])
                    {
                        end = mid - 1;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }

                else if (nums[mid] <= nums[end])
                {
                    if (target >= nums[mid] && target <= nums[end])
                    {
                        start = mid + 1;
                    }
                    else
                    {
                        end = mid - 1;
                    }
                }
            }

            return -1;
        }

        public static int BasicCalculator2(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            char sign = '+';
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    continue;
                }
                if (char.IsDigit(s[i]))
                {
                    int val = 0;

                    while (i < s.Length && char.IsDigit(s[i]))
                    {
                        val = val * 10 + s[i] - '0';
                        i++;
                    }

                    i--;

                    if (sign == '-')
                    {
                        stack.Push(val * -1);
                    }
                    else if (sign == '*')
                    {
                        stack.Push(stack.Pop() * val);
                    }
                    else if (sign == '/')
                    {
                        stack.Push(stack.Pop() / val);
                    }
                    else
                    {
                        stack.Push(val);
                    }

                    sign = '+';
                }
                else
                {
                    sign = s[i];
                }
            }

            return stack.Sum();
        }

        public static bool IsValid(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }

            if (s.Length == 1)
            {
                return false;
            }

            Stack<char> stack = new Stack<char>();
            List<char> ob = new List<char>() { '(', '{', '[' };
            List<char> cb = new List<char>() { ')', '}', ']' };

            foreach (char ch in s)
            {
                if (stack.Count() == 0)
                {
                    stack.Push(ch);
                }
                else if (ob.Contains(ch))
                {
                    stack.Push(ch);

                }
                else
                {
                    int index = cb.IndexOf(ch);
                    char tofind = ob[index];

                    if (stack.Peek() != tofind)
                    {
                        return false;
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
            }

            return true;

        }


        static void printDistinct(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {

                // Check if the picked element 
                // is already printed
                int j;
                for (j = 0; j < i; j++)
                {
                    if (arr[i] == arr[j])
                        break;
                }

                // If not printed earlier, 
                // then print it
                if (i == j)
                    Console.Write(arr[i] + " ");
            }
        }

        public static int Calculate(string s)
        {
            int sum = 0;
            int sign = 1;

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    continue;
                }

                if (char.IsDigit(s[i]))
                {
                    int val = 0;

                    while (i < s.Length && char.IsDigit(s[i]))
                    {
                        val = val * 10 + s[i] - '0';
                        i++;
                    }

                    i--;

                    if (sign == -1)
                    {
                        val = val * -1;
                    }

                    sum = sum + val;
                    sign = 1;
                }

                else if (s[i] == '-')
                {
                    sign = -1;
                }
                else if (s[i] == '(')
                {
                    stack.Push(sum);
                    stack.Push(sign);
                    sum = 0;
                    sign = 1;
                }
                else if (s[i] == ')')
                {
                    sum = sum * stack.Pop();
                    sum = sum + stack.Pop();
                }

            }

            return sum;
        }

        public static int NumPairsDivisibleBy60(int[] time)
        {
            //30,20,30,40,40
            int count = 0;
            int target = 60;
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < time.Length; i++)
            {


                if (map.ContainsKey((target - time[i]) % 60))
                {
                    count = count + map[(target - time[i]) % 60];

                    if (map.ContainsKey(time[i]))
                    {
                        map[time[i]]++;
                    }
                    else
                    {
                        map.Add(time[i], 1);
                    }

                }
                else
                {
                    if (map.ContainsKey(time[i]))
                    {
                        map[time[i]]++;
                    }
                    else
                    {
                        map.Add(time[i], 1);
                    }
                }
            }

            return count;


        }

        public static int MaximumUnits(int[][] boxTypes, int truckSize)
        {
            boxTypes = boxTypes.OrderByDescending(x => x[1]).ToArray();

            int result = 0;

            foreach (var arr in boxTypes)
            {
                if (arr[0] <= truckSize)
                {
                    result += arr[0] * arr[1];
                    truckSize = truckSize - arr[0];
                }
                else if (arr[0] > truckSize)
                {
                    result = result + truckSize * arr[1];

                    return result;
                }
            }

            return result;
        }

        public string[] ReorderLogFiles1(string[] logs)
        {
            //Input: logs = ["dig1 8 1 5 1","let1 art can","dig2 3 6","let2 own kit dig","let3 art zero"]
            //Output:["let1 art can","let3 art zero","let2 own kit dig","dig1 8 1 5 1","dig2 3 6"]
            List<string> digitsLogs = new List<string>();
            List<string> letterLogs = new List<string>();

            foreach (var log in logs)
            {
                string[] arr = log.Split(' ');

                if (arr[1][0] >= 0 && arr[1][0] <= 9)
                {
                    digitsLogs.Add(log);
                }
                else
                {
                    letterLogs.Add(log);
                }
            }

            letterLogs = letterLogs.OrderBy(x => x.Substring(x.IndexOf(' ') + 1)).ThenBy(x => x.Substring(0, x.IndexOf(' '))).ToList();

            letterLogs.AddRange(digitsLogs);

            return letterLogs.ToArray();

        }

        public static int Test(int n, int[][] mat, int num)
        {
            int row = 0;
            int col = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (mat[i][j] == num)
                    {
                        row = i;
                        col = j;
                        break;
                    }
                }
            }

            int index = row + col;
            int result = 0;

            if (index % 2 == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (mat[i][j] % 2 == 0)
                        {
                            result += DigitSum(mat[i][j]);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (mat[i][j] % 2 == 1)
                        {
                            result += DigitSum(mat[i][j]);
                        }
                    }
                }
            }

            return result;

        }

        public static int DigitSum(int n)
        {
            int sum = 0;
            while (n != 0)
            {
                sum += n % 10;
                n /= 10;
            }

            return sum;
        }

        public static int LongestIncreasingPath(int[][] matrix)
        {
            int result = int.MinValue;

            int rows = matrix.GetUpperBound(0) + 1;
            int cols = matrix[0].Length;
            int[,] mat = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result = Math.Max(result, Calculate(matrix, i, j, rows, cols, mat, int.MinValue));
                }
            }

            return result;
        }

        public static int Calculate(int[][] matrix, int start, int end, int rows, int cols, int[,] mat, int prev)
        {
            if (start < 0 || start >= rows || end < 0 || end >= cols || prev >= mat[start, end])
            {
                return 0;
            }


            if (mat[start, end] > 0)
            {
                return mat[start, end];
            }

            int max = 0;


            int one = Calculate(matrix, start + 1, end, rows, cols, mat, mat[start, end]);
            int two = Calculate(matrix, start - 1, end, rows, cols, mat, mat[start, end]);
            int three = Calculate(matrix, start, end + 1, rows, cols, mat, mat[start, end]);
            int four = Calculate(matrix, start, end - 1, rows, cols, mat, mat[start, end]);

            int result = Math.Max(Math.Max(Math.Max(one, two), three), four);

            max = Math.Max(max, result);






            return mat[start, end] = max + 1;
        }

        public static double CalculatePositive(double x, int n)
        {
            if (x == 0 || x == 1)
            {
                return x;
            }

            if (n == 1)
            {
                return x;
            }

            if (n == 0)
            {
                return 1;
            }

            double result = 0;

            double temp = CalculatePositive(x, n / 2);

            result = temp * x;

            if (n % 2 == 1)
            {
                result = result * temp;
            }

            return result;
        }

        public static double CalculateNegative(double x, int n)
        {
            if (x == 0)
            {
                return x;
            }

            if (n == -1)
            {
                return 1 / x;
            }

            if (n == 0)
            {
                return 1;
            }

            double result = 0;

            double temp = CalculateNegative(x, n / 2);

            result = temp * temp;

            if (n % 2 == 1)
            {
                result = result * temp;
            }

            return result;
        }

        public static int CoinChange(int[] coins, int amount)
        {
            int[,] mat = new int[coins.Length + 1, amount + 1];

            int rows = coins.Length + 1;
            int cols = amount + 1;

            for (int i = 0; i < rows; i++)
            {
                mat[i, 0] = 1;
            }

            for (int i = 0; i < cols; i++)
            {
                mat[0, i] = 0;
            }

            mat[0, 0] = 1;

            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    if (coins[i - 1] <= j)
                    {
                        mat[i, j] = Math.Min(mat[i, amount - j] + 1, mat[i - 1, j]);
                    }
                    else
                    {
                        mat[i, j] = mat[i - 1, j];
                    }

                }
            }

            return mat[rows - 1, cols - 1];
        }

        public static int FindPartition(string s, int start, int end)
        {
            if (s.Length == 0 || s.Length == 1 || CheckPalindrome(s, start, end))
            {
                return 0;
            }

            int result = int.MaxValue;

            for (int k = start; k <= end - 1; k++)
            {
                int temp = 1 + FindPartition(s, start, k) + FindPartition(s, k + 1, end);

                result = Math.Min(result, temp);

            }

            return result;
        }

        public static int PalindromePartition(string s)
        {
            if (s.Length == 0 || s.Length == 1 || CheckPalindrome(s, 0, s.Length - 1))
            {
                return 0;
            }

            return FindPartition(s, 0, s.Length - 1);
        }

        public static bool CheckPalindrome(string s, int start, int end)
        {
            //MADAM
            while (start <= end)
            {
                if (s[start] == s[end])
                {
                    start++;
                    end--;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }


        public static string[] ReorderLogFiles(string[] logs)
        {
            List<string> letterlogs = new List<string>();
            List<string> digitlogs = new List<string>();

            List<string> result = new List<string>();

            foreach (var log in logs)
            {
                string[] temp = log.Split(' ');

                if (temp[1][0] >= '0' && temp[1][0] <= '9')
                {
                    digitlogs.Add(log);
                }
                else
                {
                    letterlogs.Add(log);
                }
            }

            letterlogs = letterlogs.OrderBy(x => x.Substring(x.IndexOf(' ') + 1)).ThenBy(x => x.Substring(0, x.IndexOf(' '))).ToList();

            result.AddRange(letterlogs);
            result.AddRange(digitlogs);

            return result.ToArray();
        }

        public static IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            Array.Sort(products);

            List<IList<string>> result = new List<IList<string>>();

            string str = string.Empty;

            for (int i = 0; i < searchWord.Length; i++)
            {
                str = str + searchWord[i];

                List<string> temp = FindMatch(products, str, i + 1);

                if (temp.Count() > 0)
                {
                    result.Add(temp);
                }
            }

            return result;

        }

        public static List<string> FindMatch(string[] products, string str, int count)
        {
            List<string> result = new List<string>();
            foreach (string product in products)
            {
                if (product.Length < count)
                {
                    continue;
                }

                string subProductStr = product.Substring(0, count);

                if (str.Equals(subProductStr))
                {
                    if (result.Count() < 3)
                    {
                        result.Add(product);
                    }

                    if (result.Count == 3)
                    {
                        return result;
                    }
                }
            }

            return result;
        }

        //Input: boxTypes = [[1,3],[2,2],[3,1]], truckSize = 4



        public static string ReorganizeString(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            List<MyClass> list = new List<MyClass>();

            Dictionary<char, int> map = new Dictionary<char, int>();

            foreach (char ch in s)
            {
                if (map.ContainsKey(ch))
                {
                    map[ch]++;
                }
                else
                {
                    map.Add(ch, 1);
                }
            }

            foreach (var pair in map)
            {
                list.Add(new MyClass(pair.Key, pair.Value));
            }

            StringBuilder str = new StringBuilder();

            while (list.Count > 1)
            {
                MyClass first = list.Max();

                list.Remove(first);

                MyClass second = list.Max();

                list.Remove(second);

                str.Append(first.ch.ToString() + second.ch.ToString());

                if (first.freq > 1)
                {
                    list.Add(new MyClass(first.ch, first.freq - 1));
                }

                if (second.freq > 1)
                {
                    list.Add(new MyClass(second.ch, second.freq - 1));
                }
            }

            if (list.Count() > 0)
            {
                MyClass temp = list.Max();

                if (temp.freq > 1)
                {
                    return "";
                }
                else
                {
                    str.Append(temp.ch.ToString());
                }
            }

            return str.ToString();
        }

        public IList<string> LetterCombinations(string digits)
        {
            List<string> result = new List<string>();

            if (string.IsNullOrEmpty(digits))
            {
                return result;
            }

            Dictionary<char, List<string>> map = new Dictionary<char, List<string>>
        {
            {'2', new List<string> {"a","b","c"}},
             {'3', new List<string> {"d","e","f"}},
             {'4', new List<string> {"g","h","i"}},
             {'5', new List<string> {"j","k","l"}},
             {'6', new List<string> {"m","n","o"}},
             {'7', new List<string> {"p","q","r","s"}},
             {'8', new List<string> {"t","u","v"}},
             {'9', new List<string> {"w","x","y","z"}}

        };

            result = map[digits[0]];

            for (int i = 1; i <= digits.Length - 1; i++)
            {
                List<string> temp = new List<string>();

                foreach (string r in result)
                {
                    foreach (string str in map[digits[i]])
                    {
                        temp.Add(r + str);
                    }
                }

                result = temp;
            }

            return result;

        }

        public static string CountAndSay(int n)
        {
            if (n == 1)
            {
                return "1";
            }

            if (n == 2)
            {
                return "11";
            }

            string s = "11";
            //int count = 1;
            string t = string.Empty;

            for (int j = 3; j <= n; j++)
            {
                int count = 1;

                s = s + "$";

                for (int i = 1; i < s.Length; i++)
                {
                    if (s[i - 1] == s[i])
                    {
                        count++;
                    }
                    else
                    {
                        t += count.ToString() + s[i - 1].ToString();
                        count = 1;
                    }
                }

                s = t;
                t = string.Empty;
            }

            return s;


        }

        public static int MySqrt(int x)
        {

            if (x == 0)
            {
                return 0;
            }

            if (x == 1)
            {
                return 1;
            }

            int result = 0;

            int start = 0, end = x;
            int mid = 0;
            while (start <= end)
            {
                mid = start + (end - start) / 2;

                if (mid * mid == x)
                {
                    return mid;
                }

                else if (mid * mid < x)
                {
                    result = mid;
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return result;
        }


        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (nums.Length < 3)
            {
                return result;
            }

            Array.Sort(nums);

            List<int> curr = new List<int>();
            int start = 0, end = nums.Length - 1;

            for (int i = 0; i < nums.Length; i++)
            {
                end = nums.Length - 1;


                while (start < end)
                {
                    int sum = nums[i] + nums[start] + nums[end];

                    if (sum == 0)
                    {
                        curr.Add(nums[i]);
                        curr.Add(nums[start]);
                        curr.Add(nums[end]);

                        result.Add(curr);
                        start++;
                        end--;

                        curr = new List<int>();
                    }
                    else if (sum > 0)
                    {
                        end--;
                    }
                    else
                    {
                        start++;
                    }
                }
            }

            return result;

        }

        public string ReverseHelper(string str, int start, int end)
        {
            char[] arr = str.ToCharArray();

            for (int i = start; i <= (start + end) / 2; i++)
            {
                char temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
            }

            return new string(arr);
        }

        public static string ReverseStr(string s, int k)
        {
            if (s.Length == 0 && s.Length == 1)
            {
                return s;
            }

            string result = string.Empty;
            int count = k;
            string temp = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                if (count == 0)
                {
                    result += temp;
                    temp = string.Empty;
                    count = k;
                    temp = temp = s[i].ToString() + temp;
                }
                else
                {
                    temp = s[i].ToString() + temp;
                    count--;
                }
            }

            if (!string.IsNullOrEmpty(temp))
            {
                result = result + temp;
            }

            return result;

        }
        public static string ReverseWords3(string s)
        {

            //Input: s = "Let's take LeetCode contest"
            //Output: "s'teL ekat edoCteeL tsetnoc"
            if (s.Length == 0 || s.Length == 1)
            {
                return s;
            }

            string result = string.Empty;
            string temp = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    if (!string.IsNullOrEmpty(temp))
                    {
                        result = result + " " + temp;
                        temp = string.Empty;
                    }
                }
                else
                {
                    temp = s[i].ToString() + temp;
                }
            }

            if (!string.IsNullOrEmpty(temp))
            {
                result = result + " " + temp;
                temp = string.Empty;
            }

            return new String(result.Skip(1).ToArray());
        }

        public static void Test(char[] s)
        {
            //Input: s = "Let's take LeetCode contest"
            //Output: "s'teL ekat edoCteeL tsetnoc"
            if (s.Length == 0 || s.Length == 1)
            {
                return;
            }

            string result = string.Empty;
            string temp = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    if (!string.IsNullOrEmpty(temp))
                    {
                        result = temp + " " + result;
                        temp = string.Empty;
                    }
                }
                else
                {
                    temp = temp + s[i].ToString();
                }
            }

            if (!string.IsNullOrEmpty(temp))
            {
                result = temp + " " + result;
                temp = string.Empty;
            }

            s = result.Substring(0, result.Length - 1).ToCharArray();
        }

        public static bool IsMatch(string s, string p)
        {
            bool[][] mat = new bool[s.Length + 1][];

            for (int i = 0; i <= s.Length; i++)
            {
                mat[i] = new bool[p.Length + 1];
            }

            mat[0][0] = true;

            for (int i = 1; i <= s.Length; i++)
            {
                mat[i][0] = false;
            }

            for (int j = 1; j <= p.Length; j++)
            {
                if (p[j - 1] == '*')
                {
                    mat[0][j] = mat[0][j - 1];
                }
                else
                {
                    mat[0][j] = false;
                }
            }


            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 1; j <= p.Length; j++)
                {
                    if (s[i - 1] == p[j - 1] || p[j - 1] == '?')
                    {
                        mat[i][j] = mat[i - 1][j - 1];
                    }
                    else if (p[j - 1] == '*')
                    {
                        mat[i][j] = mat[i - 1][j] || mat[i][j - 1];
                    }
                    else
                    {
                        mat[i][j] = false;
                    }
                }
            }

            return mat[s.Length][p.Length];
        }

        //[100], [80], [60], [70], [60], [75], [85]
        public static List<int> StockSpanProblem(int[] prices)
        {
            List<int> result = new List<int>();
            Stack<Stock> stack = new Stack<Stock>();

            //100,80,60,70,60,75,85
            for (int i = 0; i < prices.Length; i++)
            {
                if (stack.Count() == 0)
                {
                    //100,80,60,70,60,75,85
                    stack.Push(new Stock(0, prices[i]));
                    result.Add(-1);
                }
                else if (stack.Count() > 0 && stack.Peek().Value >= prices[i])
                {
                    //100,80,60,70,60,75,85
                    stack.Push(new Stock(i, prices[i]));
                    result.Add(i - 1);
                }
                else
                {
                    while (stack.Count() > 0 && stack.Peek().Value < prices[i])
                    {
                        stack.Pop();
                    }

                    if (stack.Count() == 0)
                    {
                        result.Add(-1);
                    }
                    else
                    {
                        result.Add(stack.Peek().Index);
                    }

                    stack.Push(new Stock(i, prices[i]));
                }
            }

            int[] output = new int[result.Count];

            for (int i = 0; i < result.Count(); i++)
            {
                output[i] = i - result[i];
            }

            return output.ToList();
        }

        public static string RemoveOccurrences(string s, string part)
        {
            String str = string.Empty;

            for (int i = 0; i < s.Length; i++)
            {
                str = str + s[i];

                if (str.Length < part.Length)
                {
                    continue;
                }
                else
                {

                    while (true)
                    {
                        if (str.Length >= part.Length)
                        {
                            //"daabcbaabcbc", part = "abc"
                            string temp = str.Substring(str.Length - part.Length, part.Length);

                            if (temp.Equals(part))
                            {
                                for (int j = 0; j < part.Length; j++)
                                {
                                    str = str.Remove(str.Length - 1, 1);
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            return str;
        }

        public static int Trap(int[] height)
        {
            int[] leftmin = new int[height.Length];
            int[] rightmin = new int[height.Length];

            leftmin[0] = height[0];

            for (int i = 1; i < height.Length; i++)
            {
                leftmin[i] = Math.Max(leftmin[i - 1], leftmin[i]);
            }

            rightmin[height.Length - 1] = height[height.Length - 1];

            for (int i = height.Length - 2; i >= 0; i--)
            {
                rightmin[i] = Math.Max(rightmin[i + 1], rightmin[i]);
            }

            int result = 0;

            for (int i = 0; i < height.Length; i++)
            {
                result += Math.Min(leftmin[i], rightmin[i]) - height[i];
            }

            return result;
        }


        public static void AddCharacterToDictionary(Dictionary<char, int> keyValuePairs, char charcater)
        {
            if (!keyValuePairs.ContainsKey(charcater))
            {
                keyValuePairs.Add(charcater, 1);
            }
            else
            {
                keyValuePairs[charcater]++;
            }
        }

        public static int LengthOfLongestSubstringKDistinct(string s, int k)
        {
            int result = 0;

            Dictionary<char, int> map = new Dictionary<char, int>();
            int i = 0, j = 0;

            while (j < s.Length)
            {
                AddCharacterToDictionary(map, s[j]);

                while (map.Count() < k)
                {
                    j++;

                    if (j == s.Length)
                    {
                        j--;
                        break;
                    }
                    AddCharacterToDictionary(map, s[j]);
                }

                if (map.Count() <= k)
                {
                    result = Math.Max(result, j - i + 1);
                }


                while (map.Count() > k)
                {
                    if (map.ContainsKey(s[i]))
                    {
                        map[s[i]]--;

                        if (map[s[i]] == 0)
                        {
                            map.Remove(s[i]);
                        }
                    }

                    i++;
                }

                j++;
            }

            return result;
        }



        public static int SingleNonDuplicate(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }

            if (nums[0] != nums[1])
            {
                return nums[0];
            }

            if (nums[nums.Count() - 1] != nums[nums.Count() - 2])
            {
                return nums[nums.Count() - 1];
            }

            int start = 0, end = nums.Length - 1, mid = 0;

            while (start <= end)
            {
                mid = start + (end - start) / 2;

                if (nums[mid] != nums[mid - 1] && nums[mid] != nums[mid + 1])
                {
                    return nums[mid];
                }
                else if (mid % 2 == 0)
                {
                    if (nums[mid] == nums[mid] + 1)
                    {
                        start = mid + 1;
                    }
                    else
                    {
                        end = mid - 1;
                    }
                }
                else
                {
                    if (nums[mid] == nums[mid] - 1)
                    {
                        start = mid + 1;
                    }
                    else
                    {
                        end = mid - 1;
                    }
                }
            }

            return -1;
        }

        public static int MinKnightMoves(int x, int y)
        {
            int[] xaxis = new int[] { 2, -2, 1, -1, 2, -2, 1, -1, };
            int[] yaxis = new int[] { 1, -1, -2, 2, -1, 1, 2, -2 };
            HashSet<string> set = new HashSet<string>();

            Queue<int[]> queue = new Queue<int[]>();

            queue.Enqueue(new int[] { 0, 0 });
            set.Add("0" + ":" + "0");
            int result = 0;

            while (queue.Count() > 0)
            {

                int size = queue.Count();

                while (size > 0)
                {
                    int[] curr = queue.Dequeue();

                    if (curr[0] == x && curr[1] == y)
                    {
                        return result;
                    }

                    for (int i = 0; i < xaxis.Length; i++)
                    {
                        int xpt = curr[0] + xaxis[i];
                        int ypt = curr[1] + yaxis[i];

                        string str = xpt.ToString() + ":" + ypt.ToString();

                        if (!set.Contains(str))
                        {


                            set.Add(str);
                            queue.Enqueue(new int[] { xpt, ypt });
                        }
                    }

                    size--;
                }

                result++;
            }

            return -1;

        }

        public static int MaximalSquare(char[][] matrix)
        {

            //["1","1","1","1","1"],
            //["1","1","1","1","1"],
            //["0","0","0","0","0"],
            //["1","1","1","1","1"],
            //["1","1","1","1","1"]
            int ans = 0;

            int rows = matrix.GetUpperBound(0) + 1;
            int cols = matrix[0].Length;

            for (int i = 0; i < cols; i++)
            {
                if (matrix[0][i] - '0' == 1)
                {
                    ans = 1;
                    break;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                if (matrix[i][0] - '0' == 1)
                {
                    ans = 1;
                    break;
                }
            }

            int temp = 0;
            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i][j] - '0' == 1)
                    {
                        temp = Math.Min(matrix[i - 1][j - 1] - '0', matrix[i - 1][j] - '0');

                        temp = Math.Min(temp, matrix[i][j - 1] - '0');

                        temp = temp + 1;

                        matrix[i][j] = temp.ToString().ToCharArray()[0];

                        ans = Math.Max(ans, temp);

                        temp = 0;


                        //["1","1","1","1","1"],
                        //["1","1","1","1","1"],
                        //["0","0","0","0","0"],
                        //["1","1","1","1","1"],
                        //["1","1","1","1","1"]


                    }
                }


            }

            return ans * ans;
        }

        public static int KthFactor(int n, int k)
        {
            for (int i = 1; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    k--;
                }

                if (k == 0)
                {
                    return i;
                }
            }

            for (int i = (int)Math.Sqrt(n); i >= 1; i--)
            {
                if (n % i == 0)
                {
                    k--;
                }

                if (k == 0)
                {
                    return n / i;
                }
            }

            return -1;

        }

        public static int Jump(int[] nums)
        {
            if (nums.Length == 1)
            {
                return 0;
            }

            int[] arr = new int[nums.Length];

            arr[0] = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                arr[i] = int.MaxValue;
            }

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (i <= (j + nums[j]))
                    {
                        arr[i] = Math.Min(arr[i], arr[j] + 1);
                    }
                }
            }



            return arr[arr.Length - 1];
        }

        public static int[] DailyTemperatures(int[] temperatures)
        {
            Stack<PositionPair> stack = new Stack<PositionPair>();
            List<int> result = new List<int>();

            // [73,74,75,71,69,72,76,73]
            for (int i = temperatures.Length - 1; i >= 0; i--)
            {
                if (stack.Count() == 0)
                {
                    stack.Push(new PositionPair(temperatures[i], i));
                    result.Add(0);
                }
                else
                {
                    if (stack.Peek().element <= temperatures[i])
                    {
                        while (stack.Count() > 0 && stack.Peek().element <= temperatures[i])
                        {
                            stack.Pop();
                        }
                        //73, 74, 75, 71, 69, 72, 76, 73 
                        if (stack.Count() == 0)
                        {
                            result.Add(0);

                        }
                        else
                        {
                            result.Add(stack.Peek().pos - i);
                        }

                        stack.Push(new PositionPair(temperatures[i], i));
                    }
                    else
                    {
                        result.Add(stack.Peek().pos - i);
                        stack.Push(new PositionPair(temperatures[i], i));
                    }
                }
            }

            result.Reverse();

            return result.ToArray();
        }

        public static string FrequencySort(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();

            foreach (char ch in s)
            {
                if (map.ContainsKey(ch))
                {
                    map[ch]++;
                }
                else
                {
                    map.Add(ch, 1);
                }
            }

            List<char>[] arr = new List<char>[s.Length + 1];

            foreach (var pair in map)
            {
                if (arr[pair.Value] == null)
                {
                    arr[pair.Value] = new List<char>();
                    arr[pair.Value].Add(pair.Key);
                }
                else
                {
                    arr[pair.Value].Add(pair.Key);
                }
            }


            string result = string.Empty;

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] != null)
                {
                    foreach (var ch in arr[i])
                    {
                        for (int j = 1; j <= i; j++)
                        {
                            result = result + ch.ToString();
                        }
                    }
                }
            }

            return result;
        }

        public static int[][] Insert(int[][] intervals, int[] newInterval)
        {

            List<int[]> temp = intervals.ToList();

            temp.Add(newInterval);

            temp = temp.OrderBy(x => x[0]).ToList();

            List<int[]> result = new List<int[]>();

            if (intervals.Count() == 0)
            {
                result.Add(newInterval);

                return result.ToArray();
            }

            result.Add(temp[0]);


            //Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
            // Output:[[1,2],[3,10],[12,16]]

            for (int i = 1; i < temp.Count(); i++)
            {

                if (result[result.Count() - 1][1] >= temp[i][0])
                {
                    result[result.Count() - 1][1] = Math.Max(result[result.Count() - 1][1], temp[i][1]);
                }
                else
                {
                    result.Add(temp[i]);
                }
            }

            return result.ToArray();
        }

        public static int MaxFreq(String s, int maxLetters, int minsize, int maxSize)
        {

            int i = 0, j = 0;
            List<char> list = new List<char>();
            Dictionary<string, int> map = new Dictionary<string, int>();

            while (j < s.Length)
            {
                list.Add(s[j]);

                while (j - i + 1 < minsize)
                {
                    j++;
                    list.Add(s[j]);
                }

                // abcde
                if (j - i + 1 == minsize)
                {
                    if (list.Distinct().Count() <= maxLetters)
                    {
                        string str = new String(list.ToArray());

                        if (map.ContainsKey(str))
                        {
                            map[str]++;
                        }
                        else
                        {
                            map.Add(str, 1);
                        }
                    }
                }

                list.RemoveAt(0);
                i++;
                j++;
            }

            return map.Select(x => x.Value).Max();

        }



        public static int CountPrimes(int n)
        {
            bool[] primes = new bool[n + 1];

            for (int i = 0; i <= n; i++)
            {
                primes[i] = true;
            }

            primes[0] = false;
            primes[1] = false;

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (primes[i])
                {
                    for (int j = i * i; j <= n; j = j + i)
                    {
                        primes[j] = false;
                    }
                }
            }

            return primes.Where(x => x == true).Count();
        }

        public static int MinDeletions(string s)
        {
            if (s.Length == 1)
            {
                return 0;
            }

            Dictionary<char, int> map = new Dictionary<char, int>();

            foreach (char ch in s)
            {
                if (map.ContainsKey(ch))
                {
                    map[ch]++;
                }
                else
                {
                    map.Add(ch, 1);
                }
            }

            map = map.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            var item = map.First();

            int f = item.Value;
            int result = 0;

            foreach (var pair in map)
            {
                if (pair.Value > f)
                {
                    if (f == 0)
                    {
                        result += pair.Value;
                    }
                    else
                    {
                        result += pair.Value - f;
                    }
                }

                if (f != 0)
                    f = Math.Min(f - 1, pair.Value - 1);
            }

            return result;

        }

        public static int Compress(char[] chars)
        {
            string result = string.Empty;
            int count = 1;

            for (int i = 0; i < chars.Length - 1; i++)
            {
                if (chars[i] == chars[i + 1])
                {
                    count++;
                }
                else
                {
                    if (count > 1)
                    {
                        result = result + chars[i].ToString() + count.ToString();
                    }
                    else
                    {
                        result = result + chars[i].ToString();
                    }

                    count = 1;
                }
            }

            if (count > 1)
            {
                result = result + chars[chars.Length - 1].ToString() + count.ToString();
            }
            else
            {
                result = result + chars[chars.Length - 1].ToString();
            }


            chars = result.ToCharArray();

            return chars.Length;
        }

        public static string ReverseWords(string s)
        {
            s = s.Trim();
            Stack<string> stack = new Stack<string>();

            string[] arr = s.Split(' ');

            foreach (var str in arr)
            {
                if (string.IsNullOrEmpty(str))
                {
                    continue;
                }
                stack.Push(str.Trim());
            }

            string result = string.Empty;

            while (stack.Count() > 0)
            {
                result = result + stack.Pop();
                result = result + " ";
            }

            return result.Substring(0, result.Length - 1);

        }

        public static IList<IList<int>> FourSum(int[] nums, int target)
        {
            List<IList<int>> result = new List<IList<int>>();

            if (nums.Length < 4)
            {
                return result;
            }
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }
                int val = nums[i];

                var output = ThreeSum(nums, target - val, i);

                if (output.Count() != 0)
                {
                    foreach (var list in output)
                    {
                        list.Add(val);
                    }
                    result.AddRange(output);
                }

            }

            return result;

        }

        public static IList<IList<int>> ThreeSum(int[] nums, int target, int startIndex)
        {
            List<int> curr = new List<int>();
            List<IList<int>> output = new List<IList<int>>();
            HashSet<string> map = new HashSet<string>();

            if (nums.Length < 3)
            {
                return output;
            }

            Array.Sort(nums);
            int start = 0, end = nums.Length - 1;
            int sum = 0;
            for (int i = startIndex; i < nums.Length - 2; i++)
            {

                start = i + 1;
                end = nums.Length - 1;

                while (start < end)
                {
                    sum = nums[i] + nums[start] + nums[end];

                    if (sum == target)
                    {
                        curr.Add(nums[i]);
                        curr.Add(nums[start]);
                        curr.Add(nums[end]);

                        string num = nums[i].ToString() + nums[start] + nums[end];

                        if (!map.Contains(num))
                        {
                            output.Add(curr);
                            map.Add(num);
                        }


                        curr = new List<int>();
                        start++;
                        end--;
                    }

                    else if (sum < target)
                    {
                        start++;
                    }
                    else
                    {
                        end--;
                    }
                }


            }

            return output;
        }

        public static int ConnectSticks(int[] sticks)
        {
            int sum = 0;

            if (sticks.Length == 1)
            {
                return sticks[0];
            }

            List<int> sortedSticks = sticks.ToList();

            while (sortedSticks.Count() > 1)
            {
                int min1 = sortedSticks.Min();
                sortedSticks.Remove(min1);

                int min2 = sortedSticks.Min();
                sortedSticks.Remove(min2);

                sum = sum + min1 + min2;

                sortedSticks.Add(min1 + min2);
            }

            return sum;

        }

        public static IList<string> FindAllConcatenatedWordsInADict(string[] words)
        {
            string[] input = new string[] { "rfkqyuqfjkx", "", "vnrtysfrzrmzl", "gfve", "qfpd", "lqdqrrcrwdnxeuo", "q", "klaitgdphcspij", "hbsfyfv", "adzpbfudkklrw", "aozmixr", "ife", "feclhbvfuk", "yeqfqojwtw", "sileeztxwjl", "ngbqqmbxqcqp", "khhqr", "dwfcayssyoqc", "omwufbdfxu", "zhift", "kczvhsybloet", "crfhpxprbsshsjxd", "ilebxwbcto", "yaxzfbjbkrxi", "imqpzwmshlpj", "ta", "hbuxhwadlpto", "eziwkmg", "ovqzgdixrpddzp", "c", "wnqwqecyjyib", "jy", "mjfqwltvzk", "tpvo", "phckcyufdqml", "lim", "lfz", "tgygdt", "nhcvpf", "fbrpzlk", "shwywshtdgmb", "bkkxcvg", "monmwvytby", "nuqhmfj", "qtg", "cwkuzyamnerp", "fmwevhwlezo", "ye", "hbrcewjxvcezi", "tiq", "tfsrptug", "iznorvonzjfea", "gama", "apwlmbzit", "s", "hzkosvn", "nberblt", "kggdgpljfisylt", "mf", "h", "bljvkypcflsaqe", "cijcyrgmqirz", "iaxakholawoydvch", "e", "gttxwpuk", "jf", "xbrtspfttota", "sngqvoijxuv", "bztvaal", "zxbshnrvbykjql", "zz", "mlvyoshiktodnsjj", "qplci", "lzqrxl", "qxru", "ygjtyzleizme", "inx", "lwhhjwsl", "endjvxjyghrveu", "phknqtsdtwxcktmw", "wsdthzmlmbhjkm", "u", "pbqurqfxgqlojmws", "mowsjvpvhznbsi", "hdkbdxqg", "ge", "pzchrgef", "ukmcowoe", "nwhpiid", "xdnnl", "n", "yjyssbsoc", "cdzcuunkrf", "uvouaghhcyvmlk", "aajpfpyljt", "jpyntsefxi", "wjute", "y", "pbcnmhf", "qmmidmvkn", "xmywegmtuno", "vuzygv", "uxtrdsdfzfssmel", "odjgdgzfmrazvnd", "a", "rdkugsbdpawxi", "ivd", "bbqeonycaegxfj", "lrfkraoheucsvpi", "eqrswgkaaaohxx", "hqjtkqaqh", "berbpmglbjipnuj", "wogwczlkyrde", "aqufowbig", "snjniegvdvotu", "ocedkt", "bbufnxorixibbd", "rzuqsyr", "qghoy", "evcuanuujszitaoa", "wsx", "glafbwzdd", "znrvjqeyqi", "npitruijvyllsi", "objltu", "ryp", "nvybsfrxtlfmp", "id", "zoolzslgd", "owijatklvjzscizr", "upmsoxftumyxifyu", "xucubv", "fctkqlroq", "zjv", "wzi", "ppvs", "mflvioemycnphfjt", "nwedtubynsb", "repgcx", "gsfomhvpmy", "kdohe", "tyycsibbeaxn", "wjkfvabn", "llkmagl", "thkglauzgkeuly", "paeurdvexqlw", "akdt", "ihmfrj", "janxk", "rqdll", "cyhbsuxnlftmjc", "yybwsjmajbwtuhkk", "ovytgaufpjl", "iwbnzhybsx", "mumbh", "jqmdabmyu", "br", "lwstjkoxbczkj", "vhsgzvwiixxaob", "fso", "qnebmfl", "ooetjiz", "lq", "msxphqdgz", "mqhoggvrvjqrp", "xbhkkfg", "zxjegsyovdrmw", "jav", "mshoj", "ax", "biztkfomz", "hujdmcyxdqteqja", "gqgsomonv", "reqqzzpw", "lihdnvud", "lznfhbaokxvce", "fhxbldylqqewdnj", "rlbskqgfvn", "lfvobeyolyy", "v", "iwh", "fpbuiujlolnjl", "gvwxljbo", "ypaotdzjxxrsc", "mwrvel", "umzpnoiei", "ogwilaswn", "yw", "egdgye", "hsrznlzrf", "mwdgxaigmxpy", "yaqgault", "dtlg", "cyvfiykmkllf", "zxqyhvizqmamj", "lvvgoifltzywueyp", "abinmy", "ppzaecvmx", "qsmzc", "iddymnl", "uskihek", "evxtehxtbthq", "jvtfzddlgch", "czohpyewf", "ufzazyxtqxcu", "brxpfymuvfvs", "xrrcfuusicc", "aqhlswbzievij", "rv", "udvmara", "upityz", "fecd", "suxteeitxtg", "dfuydrtbfypbn", "cypqodxr", "wikfuxwjht", "jrliuaifpp", "vkmxys", "wvpfyfpkvgthq", "rmajxis", "jncxgviyu", "av", "nmhskodmidaj", "lkfrimprrhen", "uip", "hstyopbvuiqc", "p", "vwduwmjpblqo", "fnxwgqtvwztje", "xwnbcuggl", "iehimvoymyjasin", "spsqiu", "flhyfac", "mqrbq", "pstsxhplrrmbeddv", "hnegtuxx", "alsyxezjwtlwmxv", "jtxytykkcku", "bhhlovgcx", "xhhivxnutkx", "had", "aysulvk", "m", "anhsyxli", "jdkgfc", "potn", "lcibpxkidmwexp", "gwoxjicdkv", "tltienw", "ngiutnuqbzi", "o", "tzlyb", "vumnwehj", "os", "np", "lhv", "uzvgyeette", "ipfvr", "lpprjjalchhhcmh", "k", "pciulccqssaqgd", "tp", "dmzdzveslyjad", "wtsbhgkd", "eouxbldsxzm", "vhtonlampljgzyve", "xhnlcrldtfthul", "xhflc", "upgei", "rlaks", "yfqvnvtnqspyjbxr", "phouoyhvls", "voibuvbhhjcdflvl", "rgorfbjrofokggaf", "dqhqats", "zchpicyuawpovm", "yzwfor", "koat", "pybf", "fhdzsbiyjld", "gznfnqydisn", "xz", "po", "tcjup", "wygsnxk", "kqlima", "fgxnuohrnhg", "publurhztntgmimc", "zuufzphd", "iucrmmmjqtcey", "wnnbq", "rghzyz", "ukjqsjbmp", "mdtrgv", "vyeikgjdnml", "kxwldnmi", "apzuhsbssaxj", "tkbkoljyodlipof", "nkq", "ktwtj", "vgmkgjwle", "t", "agylw", "vomtuy", "jbtvitkqn", "vtdxwrclpspcn", "rdrls", "yxfeoh", "upj", "myctacn", "fdnor", "ahqghzhoqprgkym", "phiuvdv", "jp", "fdgpouzjwbq", "hqoyefmugjvewhxu", "qfzwuwe", "fnsbijkeepyxry", "oja", "qthkcij", "zpmqfbmnr", "ybaibmzonzqlnmd", "svo", "gjftyfehik", "jfrfgznuaytvaegm", "aljhrx", "odjq", "ogwaxrssjxgvnka", "zaqswwofedxj", "lugpktauixp", "dc", "odknlbvxrs", "jeobu", "vqythyvzxbcgrlbg", "hwc", "erpbaxq", "ujxcxck", "rrklkb", "wlrwyuy", "zmg", "yyhga", "xwdbycdu", "htedgvsrhchox", "wr", "suhesetv", "jonqwhkwezjvjgg", "sqqyrxtjkcalswq", "hvyimhe", "pjzdkmoue", "zbphmgoxq", "lbdlcumdgixjbcq", "ztzdjqmadthtdmv", "qcagsyqggcf", "if", "jpjxcjyi", "chyicqibxdgkqtg", "iwpdklhum", "wljmg", "micmun", "npdbamofynykqv", "ijsnfkpfy", "lmq", "oyjmeqvhcrvgm", "mqopusqktdthpvz", "fz", "r", "qbsqtipq", "nxtsnason", "xbpipyhh", "topsuqomfjrd", "islif", "gbndakaq", "bwnkxnwpzeoohlx", "hrtbfnq", "fguvomeepxoffg", "mat", "dzfpfnwbfuj", "onlvy", "cwcchvsasdylb", "rxfcztzqopdi", "ybrhodjn", "oqkijy", "ncvrjo", "dphbfaal", "xgtpdtkz", "sebevsopjvciwljf", "rcumyacqdapwczen", "mabkapuoud", "pbozezeygljfftvy", "bvazmzbndl", "vl", "qiaixdtbhqvlzd", "ffjfb", "svthrfmkoxbho", "cvet", "ucgqyvopafyttrh", "lbgihet", "naiqyufxffdw", "vruh", "uz", "ukffmudygjavem", "dccamymhp", "wofwgjkykm", "fbuujzxhln", "kmm", "lzandlltowjpwsal", "fapfvrmezbsjxs", "wiw", "sc", "soqlh", "hzaplclkwl", "gcdqbcdwbwa", "gadgt", "pgowefka", "juffuguqepwnfh", "nbuinl", "cpdxf", "sox", "fq", "lfnrhgsxkhx", "xrcorfygjxpi", "mwtqjwbhgh", "loc", "fkglorkkvx", "nlzdhucvayrz", "azefobxutitrf", "rlrstkcbtikklmh", "ggk", "sbphcejuylh", "nraoenhd", "zngyodiqlchxyycx", "rrbhfwohfv", "krzolrglgn", "cpjesdzy", "yoifoyg", "hqqevqjugi", "ahmv", "xgaujnyclcjq", "evhyfnlohavrj", "byyvhgh", "hyw", "kedhvwy", "ysljsqminajfipds", "rglnpxfqwu", "cibpynkxg", "su", "mbntqrlwyampdg", "nig", "ldhlhqdyjcfhu", "jfymrbafmyoc", "tyjmnhlfnrtz", "dlazixtlxyvm", "fbiguhsfuqo", "rhymsno", "rkbdlchs", "ocbbwwd", "astaiamnepwkya", "mplirup", "edkxjq", "g", "exlwulswtvot", "tlnc", "vnrrzerz", "ygeraoozbtt", "yyifkin", "eo", "ua", "qgztvqdolf", "rlzddjzcshvd", "khxkdxflwxme", "kk", "zylbhoaac", "cw", "iizic", "gcdxstpz", "kjwdqeg", "earjrncmmkdel", "kbesuhquepj", "nrzbllldgdmyrpgl", "hllwnqozf", "djpchowhwevbqvjj", "zsmhylnjpktb", "pxnktxkm", "fxwiaqqb", "qjwufmwresfsfaok", "aa", "d", "iobioqm", "svjgzk", "khbzp", "euexyudhrioi", "yqsj", "ngrwqpoh", "rwuvd", "eruffmlg", "bxzovyew", "faz", "pmvfvyguqdi", "jlxnoixsy", "hyfrdngjf", "ly", "eibcapetpmeaid", "tpnwwiif", "pfgsp", "kvhhwkzvtvlhhb", "pjxurgqbtldims", "rncplkeweoirje", "akyprzzphew", "wyvfpjyglzrmhfqp", "ubheeqt", "rmbxlcmn", "taqakgim", "apsbu", "khwnykughmwrlk", "vtdlzwpbhcsbvjno", "tffmjggrmyil", "schgwrrzt", "mvndmua", "nlwpw", "glvbtkegzjs", "piwllpgnlpcnezqs", "xkelind", "urtxsezrwz", "zechoc", "vfaimxrqnyiq", "ybugjsblhzfravzn", "btgcpqwovwp", "zgxgodlhmix", "sfzdknoxzassc", "wgzvqkxuqrsqxs", "dwneyqisozq", "fg", "vhfsf", "uspujvqhydw", "eadosqafyxbmzgr", "tyff", "blolplosqnfcwx", "uwkl", "puenodlvotb", "iizudxqjvfnky", "cjcywjkfvukvveq", "jrxd", "igwb", "dftdyelydzyummmt", "uvfmaicednym", "oai", "higfkfavgeemcgo", "naefganqo", "iqebfibigljbc", "ulicojzjfrc", "igxprunj", "cymbrl", "fqmwciqtynca", "zjyagi", "mzuejrttefhdwqc", "zyiurxvf", "wrjxffzbjexsh", "wrxw", "mhrbdxjwi", "htknfa", "wfrvxqdkhbwwef", "vqsghhhutdget", "cwupzrts", "hbjnb", "wpccoa", "nx", "howbzhaoscgyk", "bilt", "wqqatye", "zceuuwg", "jxzon", "kkfj", "bwsezd", "ifdegsyjtswselk", "xweimxlnzoh", "tqthlftjblnpht", "ww", "ss", "b", "jmruuqscwjp", "nxbk", "wd", "cqkrtbxgzg", "xhppcjnq", "cfq", "tkkolzcfi", "wblxki", "ijeglxsvc", "kcqjjwcwuhvzydm", "gubqavlqffhrzz", "hiwxrgftittd", "caybc", "ncsyjlzlxyyklc", "poxcgnexmaajzuha", "dhaccuualacyl", "mtkewbprs", "oncggqvr", "sqqoffmwkplsgbrp", "ioajuppvqluhbdet", "dzwwzaelmo", "afumtqugec", "wglucmugwqi", "zveswrjevfz", "nxlbkak", "pzcejvxzeoybb", "fd", "vewj", "ivws", "zjhudtpqsfc", "zcmukotirrxx", "zksmx", "umofzhhowyftz", "zbotrokaxaryxlk", "ueolqk", "dxmzhoq", "zvu", "cjl", "esfmqgvxwfy", "npbep", "vbgjtbv", "poeugoqynkbfiv", "fewjjscjrei", "yqssxzsydgllfzmo", "urxkwcypctjkabi", "wqtldwhjouas", "tovdtkr", "onzgeyddkqwuhnim", "ffxviyvsktqrfa", "qujhd", "pvcz", "hiyjlkxmeplnrvxg", "hdykehkefp", "vepcxhozpjxtreyn", "liguhuxudbnh", "f", "ordxzm", "klgohcmmbukz", "yrmooliaobbnlap", "dutnbetocxylcey", "ywdsjegd", "cr", "blbxhjsgcuoxmqft", "ngzdc", "srfyjjumcbxole", "dazwzwtdjoyuqeqj", "xazjarqgfm", "fxyfqbeoktcc", "qrsjchxp", "iltaqzawhgu", "sgenjcfxr", "yfikp", "dvwhbyumthkiktb", "walsx", "jyajrkcvysicisab", "brdeumb", "tviihjwxdcz", "dnrrgmem", "ydgxlrjzucxyid", "cdvdpvjlagwmg", "ngnpxjkxims", "gvyhnchlimsxc", "w", "jtizpezjl", "qe", "rjzv", "vhnqvi", "qm", "iedzqswrsnfmnn", "lt", "utqfcqyrrwm", "wtelvsqrru", "fjwrhjcrtbcytn", "qmqxceuohpiffaq", "rmoybqjjgdyo", "pmxttqftypfexlv", "tg", "qa", "iqbqjlnpbf", "kgaynkddbzllecd", "tccvslp", "curkxfoimnw", "fvnyqkzlheruxr", "iiygnzfov", "coqs", "oa", "eiu", "vzemmxtklis", "lxu", "nrwsjaxzwmh", "tdayz", "oxbbemejgosgcynf", "ykbcn", "hesvnctfvdsp", "ku", "rjhykpadahbhj", "at", "sxlngbtxmqr", "wqrom", "qzyabzrco", "rbbyklndcqdj", "cnsmgmwmpbgjq", "krvnaf", "qrwfajnfahyqocdb", "fnlaozmff", "vmoymbmytjvfcgt", "cijyy", "jdgwjbztl", "swmalgbgpaplqgz", "hfl", "typttkrpfvx", "tkzpzrscwbx", "bwfqqvjcukjbsg", "nxqmxr", "x", "eyavnz", "il", "dhthp", "eyelg", "npsoqsw", "reogbmveofvusdsx", "jvdrjkhxkq", "qzjbrpljwuzpl", "czqeevvbvcwh", "vzuszqvhlmapty", "yu", "yldwwgezlqur", "vorxwgdtgjilgydq", "pknt", "bgihl", "ckorgrm", "ixylxjmlfv", "bpoaboylced", "zea", "igfagitkrext", "ipvqq", "dmoerc", "oqxbypihdv", "dtjrrkxro", "rexuhucxpi", "bvmuyarjwqpcoywa", "qwdmfpwvamisns", "bhopoqdsref", "tmnm", "cre", "ktrniqwoofoeenbz", "vlrfcsftapyujmw", "updqikocrdyex", "bcxw", "eaum", "oklsqebuzeziisw", "fzgyhvnwjcns", "dybjywyaodsyw", "lmu", "eocfru", "ztlbggsuzctoc", "ilfzpszgrgj", "imqypqo", "fump", "sjvmsbrcfwretbie", "oxpmplpcg", "wmqigymr", "qevdyd", "gmuyytguexnyc", "hwialkbjgzc", "lmg", "gijjy", "lplrsxznfkoklxlv", "xrbasbznvxas", "twn", "bhqultkyfq", "saeq", "xbuw", "zd", "kng", "uoay", "kfykd", "armuwp", "gtghfxf", "gpucqwbihemixqmy", "jedyedimaa", "pbdrx", "toxmxzimgfao", "zlteob", "adoshnx", "ufgmypupei", "rqyex", "ljhqsaneicvaerqx", "ng", "sid", "zagpiuiia", "re", "oadojxmvgqgdodw", "jszyeruwnupqgmy", "jxigaskpj", "zpsbhgokwtfcisj", "vep", "ebwrcpafxzhb", "gjykhz", "mfomgxjphcscuxj", "iwbdvusywqlsc", "opvrnx", "mkgiwfvqfkotpdz", "inpobubzbvstk", "vubuucilxyh", "bci", "dibmye", "rlcnvnuuqfvhw", "oorbyyiigppuft", "swpksfdxicemjbf", "goabwrqdoudf", "yjutkeqakoarru", "wuznnlyd", "vfelxvtggkkk", "mxlwbkbklbwfsvr", "advraqovan", "smkln", "jxxvzdjlpyurxpj", "ssebtpznwoytjefo", "dynaiukctgrzjx", "irzosjuncvh", "hcnhhrajahitn", "vwtifcoqepqyzwya", "kddxywvgqxo", "syxngevs", "batvzmziq", "mjewiyo", "pzsupxoflq", "byzhtvvpj", "cqnlvlzr", "akvmxzbaei", "mwo", "vg", "ekfkuajjogbxhjii", "isdbplotyak", "jvkmxhtmyznha", "lqjnqzrwrmgt", "mbbhfli", "bpeohsufree", "ajrcsfogh", "lucidbnlysamvy", "tutjdfnvhahxy", "urbrmmadea", "hghv", "acnjx", "athltizloasimp", "gu", "rjfozvgmdakdhao", "iephs", "uztnpqhdl", "rfuyp", "crcszmgplszwfn", "zihegt", "xbspa", "cjbmsamjyqqrasz", "ghzlgnfoas", "ljxl", "cnumquohlcgt", "jm", "mfccj", "hfedli", "vtpieworwhyiucs", "tdtuquartspkotm", "pnkeluekvelj", "ugrloq", "zljmwt", "fkyvqguqq", "tpjidglpxqfxv", "l", "tvvimvroz", "yy", "opwyfovdz", "pwlumocnyuoume", "vjqpzkcfc", "ihicd", "dtttiixlhpikbv", "goblttgvmndkqgg", "gwsibcqahmyyeagk", "prtvoju", "lcblwidhjpu", "kbu", "pey", "gkzrpc", "bqajopjjlfthe", "bc", "lqs", "zkndgojnjnxqsoqi", "zyesldujjlp", "drswybwlfyzph", "xzluwbtmoxokk", "bedrqfui", "opajzeahv", "lehdfnr", "mnlpimduzgmwszc", "velbhj", "miwdn", "wruqc", "kscfodjxg", "wcbm" };
            string[] output = new string[] { "rfkqyuqfjkx", "vnrtysfrzrmzl", "gfve", "qfpd", "lqdqrrcrwdnxeuo", "q", "klaitgdphcspij", "hbsfyfv", "adzpbfudkklrw", "aozmixr", "ife", "feclhbvfuk", "yeqfqojwtw", "sileeztxwjl", "ngbqqmbxqcqp", "khhqr", "dwfcayssyoqc", "omwufbdfxu", "zhift", "kczvhsybloet", "crfhpxprbsshsjxd", "ilebxwbcto", "yaxzfbjbkrxi", "imqpzwmshlpj", "ta", "hbuxhwadlpto", "eziwkmg", "ovqzgdixrpddzp", "c", "wnqwqecyjyib", "jy", "mjfqwltvzk", "tpvo", "phckcyufdqml", "lim", "lfz", "tgygdt", "nhcvpf", "fbrpzlk", "shwywshtdgmb", "bkkxcvg", "monmwvytby", "nuqhmfj", "qtg", "cwkuzyamnerp", "fmwevhwlezo", "ye", "hbrcewjxvcezi", "tiq", "tfsrptug", "iznorvonzjfea", "gama", "apwlmbzit", "s", "hzkosvn", "nberblt", "kggdgpljfisylt", "mf", "h", "bljvkypcflsaqe", "cijcyrgmqirz", "iaxakholawoydvch", "e", "gttxwpuk", "jf", "xbrtspfttota", "sngqvoijxuv", "bztvaal", "zxbshnrvbykjql", "zz", "mlvyoshiktodnsjj", "qplci", "lzqrxl", "qxru", "ygjtyzleizme", "inx", "lwhhjwsl", "endjvxjyghrveu", "phknqtsdtwxcktmw", "wsdthzmlmbhjkm", "u", "pbqurqfxgqlojmws", "mowsjvpvhznbsi", "hdkbdxqg", "ge", "pzchrgef", "ukmcowoe", "nwhpiid", "xdnnl", "n", "yjyssbsoc", "cdzcuunkrf", "uvouaghhcyvmlk", "aajpfpyljt", "jpyntsefxi", "wjute", "y", "pbcnmhf", "qmmidmvkn", "xmywegmtuno", "vuzygv", "uxtrdsdfzfssmel", "odjgdgzfmrazvnd", "a", "rdkugsbdpawxi", "ivd", "bbqeonycaegxfj", "lrfkraoheucsvpi", "eqrswgkaaaohxx", "hqjtkqaqh", "berbpmglbjipnuj", "wogwczlkyrde", "aqufowbig", "snjniegvdvotu", "ocedkt", "bbufnxorixibbd", "rzuqsyr", "qghoy", "evcuanuujszitaoa", "wsx", "glafbwzdd", "znrvjqeyqi", "npitruijvyllsi", "objltu", "ryp", "nvybsfrxtlfmp", "id", "zoolzslgd", "owijatklvjzscizr", "upmsoxftumyxifyu", "xucubv", "fctkqlroq", "zjv", "wzi", "ppvs", "mflvioemycnphfjt", "nwedtubynsb", "repgcx", "gsfomhvpmy", "kdohe", "tyycsibbeaxn", "wjkfvabn", "llkmagl", "thkglauzgkeuly", "paeurdvexqlw", "akdt", "ihmfrj", "janxk", "rqdll", "cyhbsuxnlftmjc", "yybwsjmajbwtuhkk", "ovytgaufpjl", "iwbnzhybsx", "mumbh", "jqmdabmyu", "br", "lwstjkoxbczkj", "vhsgzvwiixxaob", "fso", "qnebmfl", "ooetjiz", "lq", "msxphqdgz", "mqhoggvrvjqrp", "xbhkkfg", "zxjegsyovdrmw", "jav", "mshoj", "ax", "biztkfomz", "hujdmcyxdqteqja", "gqgsomonv", "reqqzzpw", "lihdnvud", "lznfhbaokxvce", "fhxbldylqqewdnj", "rlbskqgfvn", "lfvobeyolyy", "v", "iwh", "fpbuiujlolnjl", "gvwxljbo", "ypaotdzjxxrsc", "mwrvel", "umzpnoiei", "ogwilaswn", "yw", "egdgye", "hsrznlzrf", "mwdgxaigmxpy", "yaqgault", "dtlg", "cyvfiykmkllf", "zxqyhvizqmamj", "lvvgoifltzywueyp", "abinmy", "ppzaecvmx", "qsmzc", "iddymnl", "uskihek", "evxtehxtbthq", "jvtfzddlgch", "czohpyewf", "ufzazyxtqxcu", "brxpfymuvfvs", "xrrcfuusicc", "aqhlswbzievij", "rv", "udvmara", "upityz", "fecd", "suxteeitxtg", "dfuydrtbfypbn", "cypqodxr", "wikfuxwjht", "jrliuaifpp", "vkmxys", "wvpfyfpkvgthq", "rmajxis", "jncxgviyu", "av", "nmhskodmidaj", "lkfrimprrhen", "uip", "hstyopbvuiqc", "p", "vwduwmjpblqo", "fnxwgqtvwztje", "xwnbcuggl", "iehimvoymyjasin", "spsqiu", "flhyfac", "mqrbq", "pstsxhplrrmbeddv", "hnegtuxx", "alsyxezjwtlwmxv", "jtxytykkcku", "bhhlovgcx", "xhhivxnutkx", "had", "aysulvk", "m", "anhsyxli", "jdkgfc", "potn", "lcibpxkidmwexp", "gwoxjicdkv", "tltienw", "ngiutnuqbzi", "o", "tzlyb", "vumnwehj", "os", "np", "lhv", "uzvgyeette", "ipfvr", "lpprjjalchhhcmh", "k", "pciulccqssaqgd", "tp", "dmzdzveslyjad", "wtsbhgkd", "eouxbldsxzm", "vhtonlampljgzyve", "xhnlcrldtfthul", "xhflc", "upgei", "rlaks", "yfqvnvtnqspyjbxr", "phouoyhvls", "voibuvbhhjcdflvl", "rgorfbjrofokggaf", "dqhqats", "zchpicyuawpovm", "yzwfor", "koat", "pybf", "fhdzsbiyjld", "gznfnqydisn", "xz", "po", "tcjup", "wygsnxk", "kqlima", "fgxnuohrnhg", "publurhztntgmimc", "zuufzphd", "iucrmmmjqtcey", "wnnbq", "rghzyz", "ukjqsjbmp", "mdtrgv", "vyeikgjdnml", "kxwldnmi", "apzuhsbssaxj", "tkbkoljyodlipof", "nkq", "ktwtj", "vgmkgjwle", "t", "agylw", "vomtuy", "jbtvitkqn", "vtdxwrclpspcn", "rdrls", "yxfeoh", "upj", "myctacn", "fdnor", "ahqghzhoqprgkym", "phiuvdv", "jp", "fdgpouzjwbq", "hqoyefmugjvewhxu", "qfzwuwe", "fnsbijkeepyxry", "oja", "qthkcij", "zpmqfbmnr", "ybaibmzonzqlnmd", "svo", "gjftyfehik", "jfrfgznuaytvaegm", "aljhrx", "odjq", "ogwaxrssjxgvnka", "zaqswwofedxj", "lugpktauixp", "dc", "odknlbvxrs", "jeobu", "vqythyvzxbcgrlbg", "hwc", "erpbaxq", "ujxcxck", "rrklkb", "wlrwyuy", "zmg", "yyhga", "xwdbycdu", "htedgvsrhchox", "wr", "suhesetv", "jonqwhkwezjvjgg", "sqqyrxtjkcalswq", "hvyimhe", "pjzdkmoue", "zbphmgoxq", "lbdlcumdgixjbcq", "ztzdjqmadthtdmv", "qcagsyqggcf", "if", "jpjxcjyi", "chyicqibxdgkqtg", "iwpdklhum", "wljmg", "micmun", "npdbamofynykqv", "ijsnfkpfy", "lmq", "oyjmeqvhcrvgm", "mqopusqktdthpvz", "fz", "r", "qbsqtipq", "nxtsnason", "xbpipyhh", "topsuqomfjrd", "islif", "gbndakaq", "bwnkxnwpzeoohlx", "hrtbfnq", "fguvomeepxoffg", "mat", "dzfpfnwbfuj", "onlvy", "cwcchvsasdylb", "rxfcztzqopdi", "ybrhodjn", "oqkijy", "ncvrjo", "dphbfaal", "xgtpdtkz", "sebevsopjvciwljf", "rcumyacqdapwczen", "mabkapuoud", "pbozezeygljfftvy", "bvazmzbndl", "vl", "qiaixdtbhqvlzd", "ffjfb", "svthrfmkoxbho", "cvet", "ucgqyvopafyttrh", "lbgihet", "naiqyufxffdw", "vruh", "uz", "ukffmudygjavem", "dccamymhp", "wofwgjkykm", "fbuujzxhln", "kmm", "lzandlltowjpwsal", "fapfvrmezbsjxs", "wiw", "sc", "soqlh", "hzaplclkwl", "gcdqbcdwbwa", "gadgt", "pgowefka", "juffuguqepwnfh", "nbuinl", "cpdxf", "sox", "fq", "lfnrhgsxkhx", "xrcorfygjxpi", "mwtqjwbhgh", "loc", "fkglorkkvx", "nlzdhucvayrz", "azefobxutitrf", "rlrstkcbtikklmh", "ggk", "sbphcejuylh", "nraoenhd", "zngyodiqlchxyycx", "rrbhfwohfv", "krzolrglgn", "cpjesdzy", "yoifoyg", "hqqevqjugi", "ahmv", "xgaujnyclcjq", "evhyfnlohavrj", "byyvhgh", "hyw", "kedhvwy", "ysljsqminajfipds", "rglnpxfqwu", "cibpynkxg", "su", "mbntqrlwyampdg", "nig", "ldhlhqdyjcfhu", "jfymrbafmyoc", "tyjmnhlfnrtz", "dlazixtlxyvm", "fbiguhsfuqo", "rhymsno", "rkbdlchs", "ocbbwwd", "astaiamnepwkya", "mplirup", "edkxjq", "g", "exlwulswtvot", "tlnc", "vnrrzerz", "ygeraoozbtt", "yyifkin", "eo", "ua", "qgztvqdolf", "rlzddjzcshvd", "khxkdxflwxme", "kk", "zylbhoaac", "cw", "iizic", "gcdxstpz", "kjwdqeg", "earjrncmmkdel", "kbesuhquepj", "nrzbllldgdmyrpgl", "hllwnqozf", "djpchowhwevbqvjj", "zsmhylnjpktb", "pxnktxkm", "fxwiaqqb", "qjwufmwresfsfaok", "aa", "d", "iobioqm", "svjgzk", "khbzp", "euexyudhrioi", "yqsj", "ngrwqpoh", "rwuvd", "eruffmlg", "bxzovyew", "faz", "pmvfvyguqdi", "jlxnoixsy", "hyfrdngjf", "ly", "eibcapetpmeaid", "tpnwwiif", "pfgsp", "kvhhwkzvtvlhhb", "pjxurgqbtldims", "rncplkeweoirje", "akyprzzphew", "wyvfpjyglzrmhfqp", "ubheeqt", "rmbxlcmn", "taqakgim", "apsbu", "khwnykughmwrlk", "vtdlzwpbhcsbvjno", "tffmjggrmyil", "schgwrrzt", "mvndmua", "nlwpw", "glvbtkegzjs", "piwllpgnlpcnezqs", "xkelind", "urtxsezrwz", "zechoc", "vfaimxrqnyiq", "ybugjsblhzfravzn", "btgcpqwovwp", "zgxgodlhmix", "sfzdknoxzassc", "wgzvqkxuqrsqxs", "dwneyqisozq", "fg", "vhfsf", "uspujvqhydw", "eadosqafyxbmzgr", "tyff", "blolplosqnfcwx", "uwkl", "puenodlvotb", "iizudxqjvfnky", "cjcywjkfvukvveq", "jrxd", "igwb", "dftdyelydzyummmt", "uvfmaicednym", "oai", "higfkfavgeemcgo", "naefganqo", "iqebfibigljbc", "ulicojzjfrc", "igxprunj", "cymbrl", "fqmwciqtynca", "zjyagi", "mzuejrttefhdwqc", "zyiurxvf", "wrjxffzbjexsh", "wrxw", "mhrbdxjwi", "htknfa", "wfrvxqdkhbwwef", "vqsghhhutdget", "cwupzrts", "hbjnb", "wpccoa", "nx", "howbzhaoscgyk", "bilt", "wqqatye", "zceuuwg", "jxzon", "kkfj", "bwsezd", "ifdegsyjtswselk", "xweimxlnzoh", "tqthlftjblnpht", "ww", "ss", "b", "jmruuqscwjp", "nxbk", "wd", "cqkrtbxgzg", "xhppcjnq", "cfq", "tkkolzcfi", "wblxki", "ijeglxsvc", "kcqjjwcwuhvzydm", "gubqavlqffhrzz", "hiwxrgftittd", "caybc", "ncsyjlzlxyyklc", "poxcgnexmaajzuha", "dhaccuualacyl", "mtkewbprs", "oncggqvr", "sqqoffmwkplsgbrp", "ioajuppvqluhbdet", "dzwwzaelmo", "afumtqugec", "wglucmugwqi", "zveswrjevfz", "nxlbkak", "pzcejvxzeoybb", "fd", "vewj", "ivws", "zjhudtpqsfc", "zcmukotirrxx", "zksmx", "umofzhhowyftz", "zbotrokaxaryxlk", "ueolqk", "dxmzhoq", "zvu", "cjl", "esfmqgvxwfy", "npbep", "vbgjtbv", "poeugoqynkbfiv", "fewjjscjrei", "yqssxzsydgllfzmo", "urxkwcypctjkabi", "wqtldwhjouas", "tovdtkr", "onzgeyddkqwuhnim", "ffxviyvsktqrfa", "qujhd", "pvcz", "hiyjlkxmeplnrvxg", "hdykehkefp", "vepcxhozpjxtreyn", "liguhuxudbnh", "f", "ordxzm", "klgohcmmbukz", "yrmooliaobbnlap", "dutnbetocxylcey", "ywdsjegd", "cr", "blbxhjsgcuoxmqft", "ngzdc", "srfyjjumcbxole", "dazwzwtdjoyuqeqj", "xazjarqgfm", "fxyfqbeoktcc", "qrsjchxp", "iltaqzawhgu", "sgenjcfxr", "yfikp", "dvwhbyumthkiktb", "walsx", "jyajrkcvysicisab", "brdeumb", "tviihjwxdcz", "dnrrgmem", "ydgxlrjzucxyid", "cdvdpvjlagwmg", "ngnpxjkxims", "gvyhnchlimsxc", "w", "jtizpezjl", "qe", "rjzv", "vhnqvi", "qm", "iedzqswrsnfmnn", "lt", "utqfcqyrrwm", "wtelvsqrru", "fjwrhjcrtbcytn", "qmqxceuohpiffaq", "rmoybqjjgdyo", "pmxttqftypfexlv", "tg", "qa", "iqbqjlnpbf", "kgaynkddbzllecd", "tccvslp", "curkxfoimnw", "fvnyqkzlheruxr", "iiygnzfov", "coqs", "oa", "eiu", "vzemmxtklis", "lxu", "nrwsjaxzwmh", "tdayz", "oxbbemejgosgcynf", "ykbcn", "hesvnctfvdsp", "ku", "rjhykpadahbhj", "at", "sxlngbtxmqr", "wqrom", "qzyabzrco", "rbbyklndcqdj", "cnsmgmwmpbgjq", "krvnaf", "qrwfajnfahyqocdb", "fnlaozmff", "vmoymbmytjvfcgt", "cijyy", "jdgwjbztl", "swmalgbgpaplqgz", "hfl", "typttkrpfvx", "tkzpzrscwbx", "bwfqqvjcukjbsg", "nxqmxr", "x", "eyavnz", "il", "dhthp", "eyelg", "npsoqsw", "reogbmveofvusdsx", "jvdrjkhxkq", "qzjbrpljwuzpl", "czqeevvbvcwh", "vzuszqvhlmapty", "yu", "yldwwgezlqur", "vorxwgdtgjilgydq", "pknt", "bgihl", "ckorgrm", "ixylxjmlfv", "bpoaboylced", "zea", "igfagitkrext", "ipvqq", "dmoerc", "oqxbypihdv", "dtjrrkxro", "rexuhucxpi", "bvmuyarjwqpcoywa", "qwdmfpwvamisns", "bhopoqdsref", "tmnm", "cre", "ktrniqwoofoeenbz", "vlrfcsftapyujmw", "updqikocrdyex", "bcxw", "eaum", "oklsqebuzeziisw", "fzgyhvnwjcns", "dybjywyaodsyw", "lmu", "eocfru", "ztlbggsuzctoc", "ilfzpszgrgj", "imqypqo", "fump", "sjvmsbrcfwretbie", "oxpmplpcg", "wmqigymr", "qevdyd", "gmuyytguexnyc", "hwialkbjgzc", "lmg", "gijjy", "lplrsxznfkoklxlv", "xrbasbznvxas", "twn", "bhqultkyfq", "saeq", "xbuw", "zd", "kng", "uoay", "kfykd", "armuwp", "gtghfxf", "gpucqwbihemixqmy", "jedyedimaa", "pbdrx", "toxmxzimgfao", "zlteob", "adoshnx", "ufgmypupei", "rqyex", "ljhqsaneicvaerqx", "ng", "sid", "zagpiuiia", "re", "oadojxmvgqgdodw", "jszyeruwnupqgmy", "jxigaskpj", "zpsbhgokwtfcisj", "vep", "ebwrcpafxzhb", "gjykhz", "mfomgxjphcscuxj", "iwbdvusywqlsc", "opvrnx", "mkgiwfvqfkotpdz", "inpobubzbvstk", "vubuucilxyh", "bci", "dibmye", "rlcnvnuuqfvhw", "oorbyyiigppuft", "swpksfdxicemjbf", "goabwrqdoudf", "yjutkeqakoarru", "wuznnlyd", "vfelxvtggkkk", "mxlwbkbklbwfsvr", "advraqovan", "smkln", "jxxvzdjlpyurxpj", "ssebtpznwoytjefo", "dynaiukctgrzjx", "irzosjuncvh", "hcnhhrajahitn", "vwtifcoqepqyzwya", "kddxywvgqxo", "syxngevs", "batvzmziq", "mjewiyo", "pzsupxoflq", "byzhtvvpj", "cqnlvlzr", "akvmxzbaei", "mwo", "vg", "ekfkuajjogbxhjii", "isdbplotyak", "jvkmxhtmyznha", "lqjnqzrwrmgt", "mbbhfli", "bpeohsufree", "ajrcsfogh", "lucidbnlysamvy", "tutjdfnvhahxy", "urbrmmadea", "hghv", "acnjx", "athltizloasimp", "gu", "rjfozvgmdakdhao", "iephs", "uztnpqhdl", "rfuyp", "crcszmgplszwfn", "zihegt", "xbspa", "cjbmsamjyqqrasz", "ghzlgnfoas", "ljxl", "cnumquohlcgt", "jm", "mfccj", "hfedli", "vtpieworwhyiucs", "tdtuquartspkotm", "pnkeluekvelj", "ugrloq", "zljmwt", "fkyvqguqq", "tpjidglpxqfxv", "l", "tvvimvroz", "yy", "opwyfovdz", "pwlumocnyuoume", "vjqpzkcfc", "ihicd", "dtttiixlhpikbv", "goblttgvmndkqgg", "gwsibcqahmyyeagk", "prtvoju", "lcblwidhjpu", "kbu", "pey", "gkzrpc", "bqajopjjlfthe", "bc", "lqs", "zkndgojnjnxqsoqi", "zyesldujjlp", "drswybwlfyzph", "xzluwbtmoxokk", "bedrqfui", "opajzeahv", "lehdfnr", "mnlpimduzgmwszc", "velbhj", "miwdn", "wruqc", "kscfodjxg", "wcbm" };
            string[] expected = new string[] { "gfve", "qfpd", "lqdqrrcrwdnxeuo", "hbsfyfv", "ife", "feclhbvfuk", "ngbqqmbxqcqp", "khhqr", "dwfcayssyoqc", "omwufbdfxu", "ilebxwbcto", "ta", "hbuxhwadlpto", "tpvo", "phckcyufdqml", "lfz", "tgygdt", "nhcvpf", "shwywshtdgmb", "bkkxcvg", "monmwvytby", "qtg", "cwkuzyamnerp", "ye", "tfsrptug", "gama", "nberblt", "mf", "gttxwpuk", "xbrtspfttota", "qxru", "phknqtsdtwxcktmw", "pbqurqfxgqlojmws", "hdkbdxqg", "ge", "ukmcowoe", "xdnnl", "yjyssbsoc", "uvouaghhcyvmlk", "pbcnmhf", "qmmidmvkn", "xmywegmtuno", "vuzygv", "uxtrdsdfzfssmel", "eqrswgkaaaohxx", "ocedkt", "qghoy", "wsx", "glafbwzdd", "ryp", "nvybsfrxtlfmp", "upmsoxftumyxifyu", "xucubv", "fctkqlroq", "ppvs", "nwedtubynsb", "repgcx", "gsfomhvpmy", "kdohe", "llkmagl", "thkglauzgkeuly", "paeurdvexqlw", "akdt", "rqdll", "mumbh", "br", "fso", "qnebmfl", "lq", "xbhkkfg", "ax", "gqgsomonv", "reqqzzpw", "rlbskqgfvn", "lfvobeyolyy", "mwrvel", "ogwilaswn", "yw", "egdgye", "yaqgault", "dtlg", "iddymnl", "evxtehxtbthq", "brxpfymuvfvs", "rv", "udvmara", "fecd", "dfuydrtbfypbn", "cypqodxr", "vkmxys", "wvpfyfpkvgthq", "av", "vwduwmjpblqo", "xwnbcuggl", "flhyfac", "mqrbq", "pstsxhplrrmbeddv", "hnegtuxx", "bhhlovgcx", "had", "aysulvk", "potn", "os", "np", "lhv", "uzvgyeette", "tp", "wtsbhgkd", "eouxbldsxzm", "xhnlcrldtfthul", "xhflc", "rlaks", "phouoyhvls", "dqhqats", "koat", "pybf", "po", "wygsnxk", "kqlima", "fgxnuohrnhg", "wnnbq", "mdtrgv", "nkq", "agylw", "vomtuy", "vtdxwrclpspcn", "rdrls", "yxfeoh", "myctacn", "fdnor", "qfzwuwe", "svo", "dc", "odknlbvxrs", "hwc", "erpbaxq", "rrklkb", "wlrwyuy", "yyhga", "xwdbycdu", "htedgvsrhchox", "wr", "suhesetv", "qcagsyqggcf", "wljmg", "npdbamofynykqv", "lmq", "oyjmeqvhcrvgm", "nxtsnason", "gbndakaq", "hrtbfnq", "fguvomeepxoffg", "mat", "onlvy", "cwcchvsasdylb", "dphbfaal", "mabkapuoud", "vl", "ffjfb", "svthrfmkoxbho", "cvet", "ucgqyvopafyttrh", "vruh", "ukffmudygjavem", "dccamymhp", "kmm", "sc", "soqlh", "gcdqbcdwbwa", "gadgt", "pgowefka", "cpdxf", "sox", "fq", "lfnrhgsxkhx", "loc", "fkglorkkvx", "ggk", "nraoenhd", "rrbhfwohfv", "yoifoyg", "ahmv", "byyvhgh", "hyw", "kedhvwy", "rglnpxfqwu", "su", "mbntqrlwyampdg", "jfymrbafmyoc", "rhymsno", "rkbdlchs", "ocbbwwd", "exlwulswtvot", "tlnc", "eo", "ua", "khxkdxflwxme", "kk", "cw", "pxnktxkm", "aa", "ngrwqpoh", "rwuvd", "eruffmlg", "bxzovyew", "hyfrdngjf", "ly", "pfgsp", "akyprzzphew", "ubheeqt", "rmbxlcmn", "apsbu", "khwnykughmwrlk", "mvndmua", "nlwpw", "btgcpqwovwp", "sfzdknoxzassc", "fg", "vhfsf", "tyff", "blolplosqnfcwx", "uwkl", "puenodlvotb", "naefganqo", "cymbrl", "wrxw", "htknfa", "wfrvxqdkhbwwef", "vqsghhhutdget", "wpccoa", "nx", "bilt", "wqqatye", "bwsezd", "ww", "ss", "jmruuqscwjp", "nxbk", "wd", "cfq", "gubqavlqffhrzz", "caybc", "dhaccuualacyl", "mtkewbprs", "oncggqvr", "sqqoffmwkplsgbrp", "afumtqugec", "nxlbkak", "fd", "ueolqk", "esfmqgvxwfy", "npbep", "yqssxzsydgllfzmo", "tovdtkr", "hdykehkefp", "ordxzm", "dutnbetocxylcey", "cr", "ngzdc", "fxyfqbeoktcc", "walsx", "brdeumb", "dnrrgmem", "gvyhnchlimsxc", "qe", "qm", "lt", "utqfcqyrrwm", "wtelvsqrru", "qmqxceuohpiffaq", "pmxttqftypfexlv", "tg", "qa", "tccvslp", "coqs", "oa", "lxu", "ykbcn", "hesvnctfvdsp", "ku", "at", "sxlngbtxmqr", "wqrom", "krvnaf", "hfl", "typttkrpfvx", "nxqmxr", "dhthp", "eyelg", "npsoqsw", "reogbmveofvusdsx", "yu", "pknt", "ckorgrm", "bpoaboylced", "dmoerc", "bhopoqdsref", "tmnm", "cre", "vlrfcsftapyujmw", "bcxw", "eaum", "dybjywyaodsyw", "lmu", "eocfru", "fump", "oxpmplpcg", "qevdyd", "gmuyytguexnyc", "lmg", "lplrsxznfkoklxlv", "twn", "bhqultkyfq", "saeq", "xbuw", "kng", "uoay", "kfykd", "armuwp", "gtghfxf", "pbdrx", "adoshnx", "rqyex", "ng", "sid", "re", "vep", "ebwrcpafxzhb", "opvrnx", "vubuucilxyh", "rlcnvnuuqfvhw", "goabwrqdoudf", "wuznnlyd", "vfelxvtggkkk", "mxlwbkbklbwfsvr", "advraqovan", "smkln", "kddxywvgqxo", "syxngevs", "mwo", "vg", "bpeohsufree", "lucidbnlysamvy", "urbrmmadea", "hghv", "gu", "uztnpqhdl", "rfuyp", "xbspa", "cnumquohlcgt", "tdtuquartspkotm", "ugrloq", "fkyvqguqq", "yy", "pwlumocnyuoume", "goblttgvmndkqgg", "lcblwidhjpu", "kbu", "pey", "bc", "lqs", "xzluwbtmoxokk", "lehdfnr", "wruqc", "wcbm" };

            Array.Sort(input);
            Array.Sort(output);
            Array.Sort(expected);

            List<string> result = new List<string>();

            if (words.Length == 0)
            {
                return result;
            }

            HashSet<string> map = new HashSet<string>();

            foreach (var word in words)
            {
                if (word.Length == 0)
                {
                    continue;
                }

                map.Add(word);
            }

            foreach (string word in words)
            {
                if (word.Length == 1)
                {
                    continue;
                }

                if (IsGoodString(word, map))
                {
                    result.Add(word);
                }
            }

            return result;

        }



        public static bool IsGoodString(string word, HashSet<string> map)
        {
            int length = word.Length;

            for (int i = 1; i < length; i++)
            {
                string prefix = word.Substring(0, i);
                string suffix = word.Substring(i);

                if (map.Contains(prefix) && (map.Contains(suffix) || IsGoodString(suffix, map)))
                {
                    return true;
                }
            }

            return false;
        }

        public static IList<IList<string>> SuggestedProducts1(string[] products, string searchWord)
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            List<IList<string>> output = new List<IList<string>>();

            Array.Sort(products);

            string str = string.Empty;


            for (int i = 0; i < searchWord.Length; i++)
            {
                str += searchWord[i].ToString();

                List<string> result = MatchProducts(products, str, i + 1);

                map.Add(str, result);

            }

            foreach (var pair in map)
            {
                output.Add(pair.Value);
            }

            return output;
        }

        public static List<string> MatchProducts(string[] products, string str, int length)
        {
            List<string> output = new List<string>();

            foreach (string product in products)
            {
                if (product.Length < length)
                {
                    continue;
                }

                string sub = product.Substring(0, length);

                if (sub.Equals(str))
                {
                    output.Add(product);
                }
            }

            if (output.Count() > 3)
            {
                output = output.Take(3).ToList();
            }

            return output;
        }

        public static int[] FindOrder(int numCourses, int[][] prerequisites)
        {

            if (numCourses == 1)
            {
                return new int[] { 0 };
            }

            int[,] graph = new int[numCourses, numCourses];

            foreach (int[] arr in prerequisites)
            {
                graph[arr[1], arr[0]] = 1;
            }

            Stack<int> courses = new Stack<int>();

            List<int> output = new List<int>();

            bool[] visited = new bool[numCourses];
            bool[] backtrack = new bool[numCourses];


            for (int i = 0; i < numCourses; i++)
            {
                if (visited[i] == false)
                {
                    if (DetectCycleInaGraph(graph, visited, i, backtrack))
                    {
                        return new int[] { };
                    }
                }
            }

            visited = new bool[numCourses];

            for (int i = 0; i < numCourses; i++)
            {
                if (visited[i] == false)
                {
                    DFS(graph, visited, i, courses);
                }
            }



            if (courses.Count() != numCourses)
            {
                return output.ToArray();
            }
            else
            {
                foreach (var course in courses)
                {
                    output.Add(course);
                }
            }

            return output.ToArray();
        }

        public static bool DetectCycleInaGraph(int[,] graph, bool[] visited, int start, bool[] backTrack)
        {
            visited[start] = true;
            backTrack[start] = true;

            for (int i = 0; i < visited.Length; i++)
            {
                if (graph[start, i] == 1 && visited[i] == false)
                {
                    if (DetectCycleInaGraph(graph, visited, i, backTrack))
                    {
                        return true;
                    }
                }
                else if (graph[start, i] == 1 && visited[i] == true)
                {
                    if (backTrack[i] == true)
                    {
                        return true;
                    }
                }
            }

            backTrack[start] = false;

            return false;
        }

        public static void DFS(int[,] graph, bool[] visited, int start, Stack<int> courses)
        {
            visited[start] = true;

            for (int i = 0; i < visited.Length; i++)
            {
                if (graph[start, i] == 1 && visited[i] == false)
                {
                    DFS(graph, visited, i, courses);
                }
            }

            courses.Push(start);
        }

        public static int GetFood(char[][] grid)
        {
            List<List<int>> dir = new List<List<int>>();
            dir.Add(new List<int>() { 0, -1 });
            dir.Add(new List<int>() { 0, 1 });
            dir.Add(new List<int>() { 1, 0 });
            dir.Add(new List<int>() { -1, 0 });

            int rows = grid.GetUpperBound(0) + 1;
            int cols = grid[0].Length;

            //bool[][] visited = new bool[grid.GetUpperBound(0) + 1][grid[0].Length];

            Queue<Pair> queue = new Queue<Pair>();
            int result = 0;

            for (int i = 0; i < grid.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == '*')
                    {
                        grid[i][j] = 'Z';
                        queue.Enqueue(new Pair(i, j, 1));
                        break;
                    }
                }
            }

            while (queue.Count() > 0)
            {
                int size = queue.Count();

                while (size > 0)
                {
                    Pair curr = queue.Dequeue();

                    result = Math.Max(result, curr.pos);

                    foreach (var list in dir)
                    {
                        int x = curr.x + list[0];
                        int y = curr.y + list[1];

                        if (IsValid(x, y, rows, cols, grid))
                        {
                            if (grid[x][y] == '#')
                            {
                                return result;
                            }

                            grid[x][y] = 'Z';
                            queue.Enqueue(new Pair(x, y, curr.pos + 1));
                        }
                    }

                    size--;
                }
            }

            return -1;
        }

        public static bool IsValid(int start, int end, int rows, int cols, char[][] grid)
        {
            if (start < 0 || start >= rows || end < 0 || end >= cols || grid[start][end] == 'X' || grid[start][end] == 'Z')
            {
                return false;
            }

            return true;
        }

        public static int FindCircleNum(int[][] isConnected)
        {

            int rows = isConnected.GetUpperBound(0);
            int cols = isConnected[0].Length;
            bool[] visited = new bool[cols];
            int result = 0;

            for (int i = 0; i < visited.Length; i++)
            {
                if (visited[i] == false)
                {
                    Helper(isConnected, visited, i, cols);
                    result++;
                }
            }

            return result;
        }

        public static void Helper(int[][] isConnected, bool[] visited, int node, int n)
        {
            visited[node] = true;

            for (int i = 0; i < n; i++)
            {
                if (isConnected[node][i] == 1 && !visited[i])
                    Helper(isConnected, visited, i, n);
            }
        }

        public static List<string> LadderLength2(string beginWord, string endWord, IList<string> wordList)
        {
            List<string> result = new List<string>();

            Dictionary<string, bool> map = new Dictionary<string, bool>();

            foreach (string word in wordList)
            {
                if (!map.ContainsKey(word))
                {
                    map.Add(word, false);
                }
            }

            Test(beginWord, endWord, wordList, map, result);

            return result;

        }

        public static void Test(string input, string endWord, IList<string> wordList, Dictionary<string, bool> map, List<string> result)
        {
            if (input == endWord)
            {
                return;
            }

            char c = (char)96;

            char[] strArray = input.ToCharArray();

            for (int i = 0; i < input.Length; i++)
            {

                for (int j = 0; j < 26; j++)
                {
                    c = (char)(c + 1);

                    strArray[i] = c;

                    string word = new String(strArray);

                    if (wordList.Contains(word) && map[word] == false)
                    {
                        map[word] = true;
                        result.Add(word);
                        Test(word, endWord, wordList, map, result);
                        result.RemoveAt(result.Count() - 1);
                        map[word] = false;
                    }
                }

                c = 'a';
                strArray = input.ToCharArray();
            }
        }

        public static List<string> LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            List<string> result = new List<string>();
            if (!wordList.Contains(endWord))
            {
                return result;
            }

            Dictionary<string, bool> map = new Dictionary<string, bool>();


            foreach (string word in wordList)
            {
                if (!map.ContainsKey(word))
                {
                    map.Add(word, false);
                }
            }

            Queue<string> queue = new Queue<string>();

            queue.Enqueue(beginWord);
            map[beginWord] = true;
            int length = 1;
            bool everFound = false;
            bool isFound = false;
            while (queue.Count() > 0)
            {
                int size = queue.Count();

                while (size > 0)
                {
                    string word = queue.Dequeue();

                    if (word == endWord)
                    {
                        return result;
                    }

                    if (Check(word, wordList, queue, map, result))
                    {
                        isFound = true;
                        everFound = true;
                    }

                    size--;
                }

                if (isFound)
                {
                    length++;
                }

                isFound = false;
            }

            return result;
        }

        public static bool Check(string input, IList<string> wordList, Queue<string> queue, Dictionary<string, bool> map, List<string> result)
        {
            char c = (char)96;
            bool Isfound = false;

            char[] strArray = input.ToCharArray();

            for (int i = 0; i < input.Length; i++)
            {

                for (int j = 0; j < 26; j++)
                {
                    c = (char)(c + 1);

                    strArray[i] = c;

                    string word = new String(strArray);

                    if (wordList.Contains(word) && map[word] == false)
                    {
                        queue.Enqueue(word);
                        map[word] = true;
                        Isfound = true;
                        result.Add(word);
                    }
                }

                c = 'a';
                strArray = input.ToCharArray();
            }

            return Isfound;
        }

        public static IList<int> FindDisappearedNumbers(int[] nums)
        {
            List<int> result = new List<int>();

            int i = 0;

            while (i < nums.Length)
            {
                if (i + 1 != nums[i] && nums[nums[i] - 1] != nums[i])
                {
                    int temp = nums[nums[i] - 1];
                    nums[nums[i] - 1] = nums[i];
                    nums[i] = temp;
                }
                else
                {
                    i++;
                }
            }

            for (int j = 0; i < nums.Length; j++)
            {
                if (j + 1 != nums[j])
                {
                    result.Add(j + 1);
                }
            }

            return result;
        }

        public static int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
        {
            int i = 0, j = 0;
            List<int[]> result = new List<int[]>();

            if (firstList.Length == 0 || secondList.Length == 0)
            {
                return result.ToArray();
            }

            while (i < firstList.Length && j < secondList.Length)
            {
                int startA = firstList[i][0];
                int endA = firstList[i][1];
                int startB = secondList[i][0];
                int endB = secondList[i][1];

                if (startB > endA)
                {
                    i++;
                }
                else if (startA > endB)
                {
                    j++;
                }
                else
                {

                    int x = Math.Max(startA, startB);
                    int y = Math.Min(endA, endB);


                    result.Add(new int[] { x, y });


                    if (endA < endB)
                    {
                        i++;
                    }
                    else
                    {
                        j++;
                    }
                }
            }

            return result.ToArray();
        }

        public static int[] ProductExceptSelf(int[] nums)
        {
            int[] lprod = new int[nums.Length];
            int[] rprod = new int[nums.Length];

            int[] result = new int[nums.Length];

            lprod[0] = nums[0];
            rprod[rprod.Length - 1] = nums[nums.Length - 1];

            for (int i = 1; i < nums.Length; i++)
            {
                lprod[i] = lprod[i - 1] * nums[i];
            }

            for (int i = nums.Length - 2; i >= 0; i--)
            {
                rprod[i] = rprod[i + 1] * nums[i];
            }


            result[0] = rprod[1];
            result[nums.Length - 1] = lprod[lprod.Length - 2];

            for (int i = 1; i < nums.Length - 1; i++)
            {
                result[i] = lprod[i - 1] * rprod[i + 1];
            }

            return result;



        }

        public static string AddStrings(string num1, string num2)
        {
            if (string.IsNullOrEmpty(num1) && string.IsNullOrEmpty(num2))
            {
                return string.Empty;
            }

            if (string.IsNullOrEmpty(num2))
            {
                return num1;
            }

            if (string.IsNullOrEmpty(num1))
            {
                return num2;
            }

            int num1Length = num1.Length;
            int num2Length = num2.Length;

            int length = Math.Max(num1Length, num2Length);

            int i = 0, result = 0, carry = 0;
            int a = 0, b = 0, temp = 0;
            string output = string.Empty;

            while (i < length)
            {
                if (i < num1Length)
                {
                    a = num1[num1Length - 1 - i] - 48;
                }

                if (i < num2Length)
                {
                    b = num2[num2Length - 1 - i] - 48;
                }

                temp = a + b + carry;

                result = result + temp % 10 * (int)Math.Pow(10, i);

                carry = temp / 10;

                a = 0; b = 0;
                i++;
            }

            if (carry == 1)
            {
                output = "1" + result.ToString();
            }

            if (output == string.Empty)
            {
                return result.ToString();
            }
            return output;



        }

        public static IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            Dictionary<string, string> emailNameMap = new Dictionary<string, string>();
            Dictionary<string, HashSet<string>> graph = new Dictionary<string, HashSet<string>>();

            List<IList<string>> result = new List<IList<string>>();

            foreach (var account in accounts)
            {
                string email = account[0];

                if (account.Count() == 1)
                {
                    result.Add(new List<string>() { email });
                    continue;
                }
                else
                {
                    for (int i = 1; i < account.Count(); i++)
                    {
                        if (!emailNameMap.ContainsKey(account[i]))
                        {
                            emailNameMap.Add(account[i], account[0]);
                        }

                        string firstEmail = account[1];

                        string emailtemp = account[i];

                        if (!graph.ContainsKey(firstEmail))
                        {
                            graph.Add(firstEmail, new HashSet<string>() { emailtemp });
                        }
                        else
                        {
                            graph[firstEmail].Add(emailtemp);
                        }

                        if (!graph.ContainsKey(emailtemp))
                        {
                            graph.Add(emailtemp, new HashSet<string>() { firstEmail });
                        }
                        else
                        {
                            graph[emailtemp].Add(firstEmail);
                        }
                    }
                }
            }

            List<string> output = new List<string>();
            HashSet<string> hashset = new HashSet<string>();

            foreach (var pair in graph)
            {
                if (!hashset.Contains(pair.Key))
                {
                    DFS(pair.Key, graph, output, hashset);

                    output.Sort();
                    output.Insert(0, emailNameMap[pair.Key]);
                    result.Add(output);
                    output = new List<string>();
                }
            }

            return result;

        }

        public static void DFS(string start, Dictionary<string, HashSet<string>> graph, List<string> output, HashSet<string> hashset)
        {
            if (hashset.Contains(start))
            {
                return;
            }

            hashset.Add(start);
            output.Add(start);

            foreach (string str in graph[start])
            {
                DFS(str, graph, output, hashset);
            }
        }



        public static bool CheckInclusion(string s1, string s2)
        {
            List<string> result = new List<string>();
            List<char> curr = new List<char>();

            GeneratePermutions(result, curr, s1);

            foreach (string str in result)
            {
                if (s2.Contains(str))
                {
                    return true;
                }
            }

            return false;

        }

        public static void GeneratePermutions(List<string> result, List<char> curr, string s1)
        {
            if (curr.Count() == s1.Length)
            {
                result.Add(new String(curr.ToArray()));
                return;
            }

            for (int i = 0; i < s1.Length; i++)
            {
                if (!curr.Contains(s1[i]))
                {
                    curr.Add(s1[i]);
                    GeneratePermutions(result, curr, s1);
                    curr.RemoveAt(curr.Count() - 1);

                }
            }
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            int start = 0, end = nums.Length - 1;
            int[] result = new int[2];
            int sum = 0;
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i]))
                {
                    map[nums[i]].Add(i);
                }
                else
                {
                    map.Add(nums[i], new List<int>() { i });
                }
            }

            Array.Sort(nums);

            while (start < end)
            {
                sum = nums[start] + nums[end];

                if (sum == target)
                {
                    result[0] = nums[start];
                    result[1] = nums[end];

                    break;
                }
                else if (sum < target)
                {
                    start++;
                }
                else
                {
                    end--;
                }
            }


            for (int i = 0; i <= 1; i++)
            {
                if (map.ContainsKey(result[i]))
                {
                    int temp = result[i];
                    result[i] = map[result[i]][0];
                    map[temp].Remove(result[i]);
                }
            }

            return result;
        }



        public static void PermutationBySameChar(HashSet<string> result, List<char> curr, bool[] visited, string s1)
        {
            if (curr.Count() == s1.Length)
            {
                result.Add(new string(curr.ToArray()));
                return;
            }

            for (int i = 0; i < s1.Length; i++)
            {
                if (visited[i])
                {
                    continue;
                }

                visited[i] = true;
                curr.Add(s1[i]);
                PermutationBySameChar(result, curr, visited, s1);
                curr.RemoveAt(curr.Count() - 1);
                visited[i] = false;

            }
        }

        public static int CatalanNumber(int n)
        {
            return CatalanHelper(1, 3);
        }

        public static int CatalanHelper(int start, int end)
        {
            if (start >= end)
            {
                return 1;
            }

            int answer = 0;

            for (int i = start; i <= end; i++)
            {
                answer += CatalanHelper(start, i - 1) * CatalanHelper(i + 1, end);
            }

            return answer;
        }

        public static int CompareStrings(string a, string b)
        {
            string first = a + b;
            string second = b + a;

            return second.CompareTo(first);
        }

        public static string LargestNumber(int[] nums)
        {
            string[] strNums = new string[nums.Length];

            int i = 0;
            foreach (var num in nums)
            {
                strNums[i++] = num.ToString();
            }

            Array.Sort(strNums, CompareStrings);

            string str = string.Empty;

            foreach (var itemStr in strNums)
            {
                str += itemStr;
            }

            if (strNums[0] == "0")
            {
                return "0";
            }

            return str;
        }

        public static int[][] MatrixReshape(int[][] mat, int r, int c)
        {
            int rows = mat.GetUpperBound(0) + 1;
            int cols = mat[0].Length;
            List<int> nums = new List<int>();

            if (rows * cols != r * c)
            {
                return mat;
            }


            int[][] result = new int[r][];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    nums.Add(mat[i][j]);
                }
            }

            int count = 0;
            for (int i = 0; i < r; i++)
            {
                result[i] = new int[c];
                for (int j = 0; j < c; j++)
                {

                    result[i][j] = nums[count++];
                }
            }

            return result;
        }

        public static int MeetingRooms2(int[][] intervals)
        {
            //[[2,15],[36,45],[9,29],[16,23],[4,9]]
            int[][] mat = new int[2][];
            mat[0] = new int[2] { 2, 15 };
            mat[1] = new int[2] { 4, 9 };
            mat[3] = new int[2] { 9, 29 };
            mat[4] = new int[2] { 16, 23 };
            mat[5] = new int[2] { 36, 45 };

            intervals = mat;

            intervals = intervals.OrderBy(x => x[0]).ToArray();
            int end = intervals[0][1];
            int roomCount = 1;

            for (int i = 1; i <= mat.GetUpperBound(0); i++)
            {
                if (mat[i][0] < end)
                {
                    roomCount++;
                    end = Math.Min(end, mat[i][1]);
                }
                else
                {
                    end = mat[i][1];
                }
            }

            return roomCount;
        }

        public static int[][] MergeIntervals(int[][] intervals)
        {
            intervals = intervals.OrderBy(x => x[0]).ToArray();

            List<int[]> merge = new List<int[]>();
            merge.Add(intervals[0]);

            for (int i = 1; i < intervals.Length; i++)
            {
                //[[1,4][4,5]
                if (merge[merge.Count - 1][1] >= intervals[i][0])
                {
                    merge[merge.Count - 1][1] = Math.Max(merge[merge.Count - 1][1], intervals[i][1]);
                }
                else
                {
                    merge.Add(intervals[i]);
                }
            }

            return merge.ToArray();


        }

        public static int MeetingRoom2(int[][] intervals)
        {
            if (intervals.Length == 0)
            {
                return 0;
            }

            intervals = intervals.OrderBy(x => x[0]).ToArray();
            List<int> times = new List<int>();

            foreach (var interval in intervals)
            {
                if (times.Count == 0)
                {
                    times.Add(interval[1]);
                }
                else
                {
                    int minTime = times.Min();

                    if (minTime <= interval[0])
                    {
                        times.Remove(minTime);
                    }

                    times.Add(interval[1]);
                }
            }

            return times.Count();


        }

        public static void SieveOfErosethesus(int number)
        {
            bool[] primes = new bool[number + 1];

            for (int i = 2; i < primes.Length; i++)
            {
                primes[i] = true;
            }

            for (int i = 2; i < primes.Length; i++)
            {
                if (!primes[i])
                {
                    continue;
                }
                else
                {
                    for (int j = i * i; j <= number; j = j + i)
                    {
                        primes[j] = false;
                    }
                }
            }


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

        /*
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

        */

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




















