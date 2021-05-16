using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject.Problems
{
    public class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
        public int val;
    }
   public class Microsoft_Latetst_Questions
    {
        public int GoodNodes(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            return DFS(root, int.MinValue);
        }

        public int DFS(TreeNode root, int max)
        {
            if (root == null)
            {
                return 0;
            }

            int result = 0;

            if (root.val >= max)
            {
                result++;
                max = root.val;
            }

            return result + DFS(root.left, max) + DFS(root.right, max);
        }

        public static int Calculate(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            int total = 0;
            int last = 0;
            int pow = 0;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ' ')
                {
                    continue;
                }
                else if (s[i] == '+')
                {
                    total = total + last;
                    pow = 0;
                    last = 0;
                }
                else if (s[i] == '-')
                {
                    total = total - last;
                    pow = 0;
                    last = 0;
                }
                else
                {
                    last += (int)((s[i] - '0') * Math.Pow(10, pow));
                    pow++;
                }
            }

            return total + last;
        }

        public static int MaxNumberByAdding5(int number)
        {
            if (number == 0)
            {
                return 50;
            }

            bool isNegative = number < 0;

            if (isNegative)
            {
                number = number * -1;
            }

            List<int> digits = new List<int>();
            digits.Add(5);

            while (number > 0)
            {
                digits.Add(number % 10);
                number = number / 10;
            }

            //5578
            //8755
            digits = digits.OrderByDescending(x => x).ToList();
            int multplier = 1;
            int answer = 0;
            for (int i = digits.Count - 1; i >= 0; i--)
            {

                answer = answer + digits[i] * multplier;
                multplier = multplier * 10;

            }

            if (isNegative)
            {
                return -1 * answer;
            }

            return answer;

        }

        public static int WaysToMakeFairIndex(int[]numbers)
        {
            int[] evenCumulativeSum = new int[numbers.Length];
            int[] oddCumulativeSum = new int[numbers.Length];
            int evenTemp = 0;
            int oddTemp = 0;
            int i = 0;

            for (i=0;i<numbers.Length;i++)
            {
                if(i % 2 == 0)
                {
                    evenTemp += numbers[i];
                    evenCumulativeSum[i]= evenTemp;
                    if (i > 1)
                        evenCumulativeSum[i-1] = evenCumulativeSum[i - 2];
                }
                else
                {
                    oddTemp += numbers[i];
                    oddCumulativeSum[i]= oddTemp;
                    if (i > 1)
                        oddCumulativeSum[i-1] = oddCumulativeSum[i - 2];
                }
            }

            if((i-1)%2==0)
            {
                oddCumulativeSum[i - i] = oddCumulativeSum[i - 2];
            }
            else
            {
                evenCumulativeSum[i - 1] = evenCumulativeSum[i - 2];
            }

            

            int evensumRunning, oddsumRunning;
            int result = 0;
            for (i = 0; i < numbers.Length; i++)
            {
                if(i % 2 == 0)
                {
                    evensumRunning = evenCumulativeSum[i] - numbers[i] + oddCumulativeSum[oddCumulativeSum.Length - 1] - oddCumulativeSum[i];
                    oddsumRunning = oddCumulativeSum[i] + evenCumulativeSum[evenCumulativeSum.Length - 1] - numbers[i];
                }
                else
                {
                    evensumRunning = evenCumulativeSum[i] + oddCumulativeSum[oddCumulativeSum.Length - 1] - numbers[i];
                    oddsumRunning = oddCumulativeSum[i] - numbers[i] + evenCumulativeSum[evenCumulativeSum.Length - 1] - evenCumulativeSum[i];
                }

                if(evensumRunning == oddsumRunning)
                {
                    result++;
                }
            }
                
            return result;
        }

        public static int MinimumDeletionstoMakeCharacterFrequenciesUnique(string input)
        {
            Dictionary<char, int> frequencies = new Dictionary<char, int>();

            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            foreach (char ch in input)
            {
                if (frequencies.ContainsKey(ch))
                {
                    frequencies[ch]++;
                }
                else
                {
                    frequencies.Add(ch, 1);
                }
            }

            List<int> counts = frequencies.Select(x => x.Value).ToList();

            counts = counts.OrderByDescending(x => x).ToList();

            int maxAllowed = counts[0];
            int result = 0;

            //"bbcebab"

            //a 4
            //c 1
            //e 1
            //a = 1
            for (int i = 0; i < counts.Count(); i++)
            {
                if (counts[i] <= maxAllowed)
                {
                    maxAllowed = Math.Min(counts[i] - 1, maxAllowed - 1);
                }
                else
                {
                    if (maxAllowed == 0)
                    {
                        result += counts[i];
                    }
                    else
                    {
                        result += counts[i] - maxAllowed;

                        maxAllowed = Math.Min(counts[i] - 1, maxAllowed - 1);
                    }
                }
            }

            return result;

        }

        //public int largestUinquePathUtil(Node node, Dictionary<int, int> m)
        //{
        //    if (node == null)
        //        return m.Count;

        //    // put this node into hash
        //    if (m.ContainsKey(node.data))
        //    {
        //        m[node.data] = m[node.data] + 1;
        //    }
        //    else
        //    {
        //        m.Add(node.data, 1);
        //    }

        //    int max_path = Math.Max(largestUinquePathUtil(node.left, m),
        //                            largestUinquePathUtil(node.right, m));

        //    // remove current node from path "hash"
        //    if (m.ContainsKey(node.data))
        //    {
        //        m[node.data] = m[node.data] - 1;
        //    }

        //    // if we reached a condition where all 
        //    // duplicate value of current node is deleted
        //    if (m[node.data] == 0)
        //        m.Remove(node.data);

        //    return max_path;
        //}

        public int MinCost(string s, int[] cost)
        {
            int sum = 0;

            //abaaac
            //1,2,4,3,5,6
            for (var i = 1; i < s.Length; i++)
            {
                if (s[i - 1] != s[i])
                {
                    continue;
                }

                sum += Math.Min(cost[i], cost[i - 1]);
                cost[i] = Math.Max(cost[i], cost[i - 1]);

            }

            return sum;
        }

        public static int SumOfFraction(int[] numerator, int[] denominator)
        {
            int count = 0;
            Dictionary<int, List<int>> keyValuePairs = new Dictionary<int, List<int>>();

            for (int i = 0; i < denominator.Length; i++)
            {
                if (keyValuePairs.ContainsKey(denominator[i]))
                {
                    keyValuePairs[denominator[i]].Add(numerator[i]);
                }
                else
                {
                    keyValuePairs.Add(denominator[i], new List<int> { numerator[i] });
                }
            }

            foreach (var keypair in keyValuePairs)
            {
                if (keypair.Key == keypair.Value.Sum())
                {
                    count++;
                }
            }

            return count;
        }

        public static List<int> PairsofPositiveNegativevaluesinanarray(int[] numbers)
        {
            // { 1, -3, 2, 3, 6, -1 }
            List<int> result = new List<int>();

            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    if (keyValuePairs.ContainsKey(numbers[i]))
                    {
                        keyValuePairs[numbers[i]]++;
                    }
                    else
                    {
                        keyValuePairs.Add(numbers[i], 1);
                    }
                }
            }

            List<int> positives = numbers.Where(x => x > 0).Select(x => x).ToList();
            positives.Sort();

            for (int i = 0; i < positives.Count; i++)
            {
                if (keyValuePairs.ContainsKey(positives[i] * -1))
                {
                    result.Add(positives[i]);
                    result.Add(positives[i]);
                    keyValuePairs[positives[i] * -1]--;
                    if (keyValuePairs[positives[i] * -1] == 0)
                    {
                        keyValuePairs.Remove(positives[i] * -1);
                    }

                }
            }

            for (int i = 0; i < result.Count(); i = i + 2)
            {
                result[i] = result[i] * -1;
            }


            return result;

        }

        public static int LongestSemiAlternatingSubstring(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                return 0;
            }

            if(input.Length < 2)
            {
                return input.Length;
            }

            //baaabbabbb

            int result = 2;
            int runningCount = 2;

            for(int i=2;i<input.Length;i++)
            {
                if(input[i]==input[i-1] && input[i] == input[i - 2])
                {
                    
                    result = Math.Max(result, runningCount);
                    runningCount = 2;
                }
                else
                {
                    runningCount++;
                    result = Math.Max(result, runningCount);
                }
            }

            result = Math.Max(result, runningCount);

            return result;
        }

        public static int StringWithout3IdenticalConsecutiveLetters(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            if (input.Length < 3)
            {
                return 0;
            }

            int count = 0;

            string output = input[0].ToString() + input[1].ToString();

            for (int i = 2; i < input.Length; i++)
            {
                if (input[i] != input[i - 1] || input[i] != input[i - 2])
                {
                    output = output + input[i].ToString();
                }
                else
                {
                    count++;
                }
            }

            return count;
        }

        public int MinimumDeletionCosttoAvoidRepeatingLetters(string s, int[] cost)
        {
      
            // Input: s = "abaaac", cost = [1, 2, 3, 4,3, 5]
            var sum = 0;
            for (var i = 1; i < s.Length; i++)
            {
                if (s[i - 1] != s[i])
                    continue;

                if (cost[i - 1] < cost[i])
                {
                    sum += cost[i - 1];
                }
                else
                {
                    sum += cost[i];
                    cost[i] = cost[i - 1];
                }
            }

            return sum;
        }

        public int FindLargestByInsertingDigit(int N)
        {
            int digit = 5;
            if (N == 0) return digit * 10;
            int neg = N / Math.Abs(N);
            N = Math.Abs(N);
            int n = N;
            int ctr = 0;
            while (n > 0)
            {
                ctr++;
                n = n / 10;
            }
            int pos = 1;
            int maxVal = int.MinValue;
            for (int i = 0; i <= ctr; i++)
            {
                int newVal = ((N / pos) * (pos * 10)) + (digit * pos) + (N % pos);
                if (newVal * neg > maxVal)
                {
                    maxVal = newVal * neg;
                }
                pos = pos * 10;
            }
            return maxVal;
        }

        public static int FindSignOfProductMultiplied(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                return 0;
            }

            int numberOfNegatives = 0;
            List<int> numbersList = numbers.ToList();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 0)
                {
                    return 0;
                }
                else if (numbers[i] < 0)
                {
                    numberOfNegatives++;
                }
            }

            return numberOfNegatives % 2 == 0 ? 1 : -1;

            //if(numbersList.Any(x=>x==0))
            //{
            //    return 0;
            //}
            //else
            //{             
            //    numberOfNegatives = numbersList.Where(x => x < 0).Count();

            //    if(numberOfNegatives % 2 == 0)
            //    {
            //        return 1;
            //    }
            //    else
            //    {
            //        return -1;
            //    }
            //} 
        }

        public static bool GenerateDocument(string characters, string document)
        {
            //"characters": "aheaollabbhb",
            // "document": "hello"

            if (string.IsNullOrEmpty(characters) || string.IsNullOrEmpty(document.Trim()))
            {
                return true;
            }

            Dictionary<char, int> charactersMap = new Dictionary<char, int>();
            Dictionary<char, int> documentMap = new Dictionary<char, int>();

            foreach (char ch in characters)
            {
                if (charactersMap.ContainsKey(ch))
                {
                    charactersMap[ch]++;
                }
                else
                {
                    charactersMap.Add(ch, 1);

                }
            }

            foreach (char ch in document)
            {
                if (documentMap.ContainsKey(ch))
                {
                    documentMap[ch]++;
                }
                else
                {
                    documentMap.Add(ch, 1);

                }
            }

            foreach (var pair in documentMap)
            {
                if (charactersMap.ContainsKey(pair.Key))
                {
                    if (charactersMap[pair.Key] < documentMap[pair.Key])
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private static int FindMaxIslandSize(int[][] arr, int row, int col)
        {
            if (row < 0 || row > 3 || col < 0 || col > 4)
            {
                return 0;
            }

            if (arr[row][col] == 0)
            {
                return 0;
            }

            arr[row][col] = 0;

            int count1 = FindMaxIslandSize(arr, row, col - 1); //x, y-1

            int count2 = FindMaxIslandSize(arr, row, col + 1); // x, y+1

            int count3 = FindMaxIslandSize(arr, row + 1, col + 1); //x+1 y+1

            int count4 = FindMaxIslandSize(arr, row + 1, col); //x+1 y

            int count5 = FindMaxIslandSize(arr, row + 1, col - 1);//x+1 y-1

            int count6 = FindMaxIslandSize(arr, row - 1, col);// x-1 y

            int count7 = FindMaxIslandSize(arr, row - 1, col - 1);//x-1 y-1

            int count8 = FindMaxIslandSize(arr, row - 1, col + 1);//x-1 y+1

            return 1 + count1 + count2 + count3 + count4 + count5 + count6 + count7 + count8;
        }

        public static int MinimumWaitingTime(int[] queries)
        {
            // Write your code here.
            Array.Sort(queries);

            int result = 0;
            int output = 0;
            List<int> waitTimes = new List<int>();
            output += result;

            //1,2,2,3,6
            for (int i = 0; i < queries.Length - 1; i++)
            {
                result = result + queries[i];
                output += result;
            }

            return output;
        }

        public static int TandemBicycle(int[] redShirtSpeeds, int[] blueShirtSpeeds, bool fastest)
        {
            int total = 0;
            Array.Sort(redShirtSpeeds);
            Array.Sort(blueShirtSpeeds);

            int redStart = 0, blueStart = 0, redEnd = redShirtSpeeds.Length - 1, blueEnd = blueShirtSpeeds.Length - 1;

            if (fastest)
            {
                while (redEnd >= 0 && blueStart <= blueEnd)
                {
                    total += Math.Max(redShirtSpeeds[redEnd], blueShirtSpeeds[blueStart]);
                    redEnd--;
                    blueStart++;
                }

            }
            else
            {
                while (redEnd >= 0 && blueEnd >= 0)
                {
                    total += Math.Max(redShirtSpeeds[redEnd], blueShirtSpeeds[blueEnd]);
                    redEnd--;
                    blueEnd--;
                }
            }

            return total;
        }
    }
}
