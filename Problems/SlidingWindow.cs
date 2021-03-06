using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace TestProject.Problems
{
    class SlidingWindow
    {
        public static string MinWindow(string s, string t)
        {
        Dictionary<char,int> rs = new Dictionary<char,int>();
        Dictionary<char,int> ps = new Dictionary<char,int>();
            int startIndex=-1,endIndex =-1;

        foreach(char ch in t)
        {
            if(ps.ContainsKey(ch))
            {
                ps[ch]++;
            }
            else
            {
                ps.Add(ch,1);
            }
        }

        int i=0,j=0, result = int.MaxValue;

        while(j<s.Length)
        {
            if(rs.ContainsKey(s[j]))
            {
                rs[s[j]]++;
            }
            else
            {
                rs.Add(s[j],1);
            }

            //s = "ADOBECODEBANC", t = "ABC"
            while(!Test(rs,ps))
            {
                j++;

                if(j==s.Length)
                {
                    j--;
                    break;
                }

                if(rs.ContainsKey(s[j]))
               {
                rs[s[j]]++;
                }
                else
                {
                rs.Add(s[j],1);
               }
            }

            if(Test(rs,ps))
            {
                result = Math.Min(result, j-i+1);
            }

            while(Test(rs,ps))
            {
                 if(Test(rs,ps))
                 {
                    result = Math.Min(result, j-i+1);
                        startIndex=i;
                        endIndex=j;
                 }
                if(rs.ContainsKey(s[i]))
                {
                    rs[s[i]]--;
                }

                if(rs[s[i]]==0)
                {
                    rs.Remove(s[i]);
                }

                i++;
            }

            j++;
        }

        return s.Substring(startIndex,endIndex-startIndex+1);
    }

    public static bool Test(Dictionary<char,int> rs,Dictionary<char,int> ps)
    {
        foreach(var pair in ps)
        {
            if(!rs.ContainsKey(pair.Key))
            {
                return false;
            }
            else
            {
                if(rs[pair.Key]<pair.Value)
                {
                    return false;
                }
            }
        }

        return true;
    }
        public static int LengthOfLongestSubstringKDistinct(string s, int k)
    {
        Dictionary<char,int> map = new Dictionary<char,int>();

        int i=0,j=0, result = int.MinValue;

        while(j<s.Length)
        {
            if(map.ContainsKey(s[j]))
            {
                map[s[j]]++;
            }
            else
            {
                map.Add(s[j],1);
            }

            while(map.Count()<k)
            {
                j++;

                if(j==s.Length)
                {
                    break;
                }
                if(map.ContainsKey(s[j]))
                 {
                   map[s[j]]++;
                 }
                 else
                 {
                map.Add(s[j],1);
                 }
            }

            if(map.Count()<=k)
            {
                result = Math.Max(result, j-i+1);
            }

            while(map.Count()>k)
            {
                if(map.ContainsKey(s[i]))
                {
                    map[s[i]]--;

                    if(map[s[i]]==0)
                    {
                        map.Remove(s[i]);
                    }

                    i++;
                }
            }

             if(map.Count()<=k)
            {
                result = Math.Max(result, j-i+1);
            }

            j++;
        }

        return result;
    }
        public static int MaxWinSizeOfSumK(int [] nums, int k)
        {
            int i=0,j=0,result = int.MinValue,sum=0;

            while(j<nums.Length)
            {
                sum = sum + nums[j];

                while(sum<k)
                {
                    j++;

                    if(j==nums.Length)
                    {
                        break;
                    }

                    sum = sum + nums[j];
                }

                if(sum == k)
                {
                    result = Math.Max(result, j-i+1);
                }

                while(sum>k)
                {
                    sum = sum - nums[i];
                    i++;
                }

                if(sum == k)
                {
                    result = Math.Max(result, j-i+1);
                }

                j++;
            }

            return result;
        }

        public static int MaxSumWithSizeK(int[] nums, int k)
        {
            int result = int.MinValue;
            int sum =0;

            int i=0,j=0;

            while(j<nums.Length)
            {
                sum = sum + nums[j];

                while(j-i+1<k)
                {
                    j++;
                    sum = sum + nums[j];
                }

                if(j-i+1==k)
                {
                    result = Math.Max(sum,result);
                }

                sum = sum - nums[i];
                i++;
                j++;
            }

            return result;
        }

        public static void PrintNeg(int[] nums, int k)
        {
            int i=0,j=0;
            List<int> negative = new List<int>();

            //12,-1,7,8,-15,30,16,28
            while(j<nums.Length)
            {
                if(nums[j]<0)
                {
                    negative.Add(nums[j]);
                }

                while(j-i+1<k)
                {
                    j++;
                    if(nums[j]<0)
                    {
                        negative.Add(nums[j]);
                    }
                }

                if(j-i+1==k)
                {
                    if(negative.Count()>0)
                    {
                        Console.WriteLine(negative[0]);
                    }
                    else
                    {
                        Console.WriteLine("A");
                    }
                }

                if(nums[i]<0)
                {
                    negative.Remove(negative[0]);
                }

                i++;
                j++;
            }
        }

        //Input: s = "aabcbcdbca", t = "dbca"

        public static string MinWindowDistinct(string str)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();

            //aabcbcdbca
            foreach (char c in str)
            {
                if(!map.ContainsKey(c))
                {
                    map.Add(c, 1);
                }
                else
                {
                    map[c]++;
                }
            }

            //aabcbcdbca
            Dictionary<char, int> map2 = new Dictionary<char, int>();

            int i = 0, j = 0;

            string result = string.Empty;
            int min = int.MaxValue;

            //aabcbcdbca
            while (j<str.Length)
            {
                if(map2.ContainsKey(str[j]))
                {
                    map2[str[j]]++;
                }
                else
                {
                    map2.Add(str[j], 1);
                }

                //aabcbcdbca
                if (CompreMaps(map,map2))
                {
                    if (j - i + 1 < min)
                    {
                        result = str.Substring(i, j - i + 1);
                        min = j - i + 1;
                    }
                }

                //aabcbcdbca
                while (j-1+1> map2.Count() && map.Count() == map2.Count())
                {
                    if(map2.ContainsKey(str[i]))
                    {
                        map2[str[i]]--;

                        if(map2[str[i]]==0)
                        {
                            map2.Remove(str[i]);
                        }

                        i++;

                        //aabcbcdbca
                        if (CompreMaps(map, map2))
                        {
                            if (j - i + 1 < min)
                            {
                                result = str.Substring(i, j - i + 1);
                                min = j - i + 1;
                            }
                        }
                    }
                }

                j++;
            }

            return result;
        }

        public static bool CompreMaps(Dictionary<char,int> map, Dictionary<char,int> map2)
        {
            if(map.Count()!=map2.Count())
            {
                return false;
            }

            foreach(var pair in map)
            {
                if(!map2.ContainsKey(pair.Key))
                {
                    return false;
                }
            }

            return true;
        }

        public static string MinWindow2(string s, string t)
        {
            int minLength = int.MaxValue;
            string result = string.Empty;
            Dictionary<char, int> map = new Dictionary<char, int>();
            Dictionary<char, int> helper = new Dictionary<char, int>();

            if (s.Length < t.Length)
            {
                return string.Empty;
            }

            int startIndex = -1, endIndex = -1, i = 0, j = 0;

            foreach (var ch in t)
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

            while (j < s.Length)
            {
                if (helper.ContainsKey(s[j]))
                {
                    helper[s[j]]++;
                }
                else
                {
                    helper.Add(s[j], 1);
                }

                while (!CompareDictionary(helper, map))
                {
                    j++;

                    if (j == s.Length)
                    {
                        break;
                    }

                    if (helper.ContainsKey(s[j]))
                    {
                        helper[s[j]]++;
                    }
                    else
                    {
                        helper.Add(s[j], 1);
                    }
                }

                if (CompareDictionary(helper, map))
                {
                    if (j - i + 1 < minLength)
                    {
                        minLength = Math.Min(minLength, j - i + 1);
                        startIndex = i;
                        endIndex = j;
                    }
                }

                //Input: s = "ADOBECODEBANC", t = "ABC"
                while (CompareDictionary(helper, map))
                {
                    if (CompareDictionary(helper, map))
                    {
                        if (j - i + 1 < minLength)
                        {
                            minLength = Math.Min(minLength, j - i + 1);
                            startIndex = i;
                            endIndex = j;
                        }
                    }

                    if (helper.ContainsKey(s[i]))
                    {
                        if (helper[s[i]] > 0)
                        {
                            helper[s[i]]--;
                        }
                        if (helper[s[i]] == 0)
                        {
                            helper.Remove(s[i]);
                        }
                    }

                    i++;
                }

                j++;
            }

            if (startIndex == -1 || endIndex == -1)
            {
                return string.Empty;
            }

            return s.Substring(startIndex, endIndex - startIndex + 1);
        }

        public static string MinWindowEfficient(string s, string t)
        {
            int minLength = int.MaxValue;
            string result = string.Empty;
            Dictionary<char, int> map = new Dictionary<char, int>();
            int count = 0;
            int startIndex = -1, endIndex = -1, i = 0, j = 0;
            if (s.Length < t.Length)
            {
                return string.Empty;
            }

            foreach (var ch in t)
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

            // Input: s = "ADOBECODEBANC", t = "ABC"
            while (j < s.Length)
            {
                if (map.ContainsKey(s[j]))
                {
                    if (map[s[j]] > 0)
                    {
                        count++;
                    }

                    map[s[j]]--;
                }

                //Input: s = "ADOBECODEBANC", t = "ABC"
                while (count != t.Length)
                {
                    j++;

                    if (j == s.Length)
                    {
                        break;
                    }
                    if (map.ContainsKey(s[j]))
                    {
                        if (map[s[j]] > 0)
                        {
                            count++;
                        }

                        map[s[j]]--;
                    }
                }

                //Input: s = "ADOBECODEBANC", t = "ABC"
                if (t.Length == count)
                {
                    if (j - i + 1 < minLength)
                    {
                        minLength = Math.Min(minLength, j - i + 1);
                        startIndex = i;
                        endIndex = j;
                    }
                }

                //Input: s = "ADOBECODEBANC", t = "ABC"
                while (count == t.Length)
                {
                    if (t.Length == count)
                    {
                        if (j - i + 1 < minLength)
                        {
                            minLength = Math.Min(minLength, j - i + 1);
                            startIndex = i;
                            endIndex = j;
                        }
                    }

                    if (map.ContainsKey(s[i]))
                    {
                        if (map[s[i]] >= 0)
                        {
                            count--;
                        }

                        map[s[i]]++;
                    }

                    i++;
                }

                j++;
            }

            if (startIndex == -1 || endIndex == -1)
            {
                return string.Empty;
            }

            return s.Substring(startIndex, endIndex - startIndex + 1);
        }

        public static bool CompareDictionary(Dictionary<char, int> created, Dictionary<char, int> original)
        {
            if (created.Count() < original.Count)
            {
                return false;
            }
            foreach (var pair in original)
            {
                if (!created.ContainsKey(pair.Key))
                {
                    return false;
                }
                else
                {
                    if (created[pair.Key] < pair.Value)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public static int LargestSubarraywith0sum(int[] nums, int k)
        {
            /*Input: arr [] = { 15, -2, 2, -8, 1, 7, 10, 23};
            Output: 5
Explanation: The longest sub-array with
elements summing up-to 0 is { -2, 2, -8, 1, 7}
            */
            int sum = 0;
            int result = 0;

            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            keyValuePairs.Add(0, -1);

            for (int i = 0; i < nums.Length; i++)
            {
                sum = sum + nums[i];

                if (keyValuePairs.ContainsKey(sum - k))
                {
                    result = Math.Max(result, i - keyValuePairs[sum - k]);
                    if (!keyValuePairs.ContainsKey(sum))
                    {
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
        public static int subarraySum2(int[] nums, int k)
        {
            //Input: nums = [1,1,1], k = 2
            // Output: 2
            int count = 0;
            for (int start = 0; start < nums.Length; start++)
            {
                int sum = 0;

                for (int end = start; end < nums.Length; end++)
                {
                    sum += nums[end];
                    if (sum == k)
                        count++;
                }
            }
            return count;
        }
        public static int subarraySum(int[] nums, int k)
        {
            //Input: nums = [1,1,1], k = 2
            //Output: 2
            int count = 0;
            int sum = 0;

            Dictionary<int, int> cumulativeSumDictionary = new Dictionary<int, int>();
            cumulativeSumDictionary.Add(0, 1);

            for (int i = 0; i < nums.Length; i++)
            {
                sum = sum + nums[i];

                if (cumulativeSumDictionary.ContainsKey(sum - k))
                {
                    count = count + cumulativeSumDictionary[sum - k];

                    if (cumulativeSumDictionary.ContainsKey(sum))
                    {
                        cumulativeSumDictionary[sum]++;
                    }
                    else
                    {
                        cumulativeSumDictionary.Add(sum, 1);
                    }
                }
                else
                {
                    if (cumulativeSumDictionary.ContainsKey(sum))
                    {
                        cumulativeSumDictionary[sum]++;
                    }
                    else
                    {
                        cumulativeSumDictionary.Add(sum, 1);
                    }
                }
            }

            return count;
        }
        public static string MinimumWindowSubstring(string large, string small)
        {
            if (small.Length > large.Length)
            {
                return string.Empty;
            }
            //time to practice
            //toc

            //tim
            int i = 0, j = 0;
            int result = int.MaxValue;
            Dictionary<char, int> smallDictionary = new Dictionary<char, int>();
            Dictionary<char, int> largeDictionary = new Dictionary<char, int>();
            int start = 0, end = 0;

            foreach (char ch in small)
            {
                if (smallDictionary.ContainsKey(ch))
                {
                    smallDictionary[ch]++;
                }
                else
                {
                    smallDictionary.Add(ch, 1);
                }
            }

            while (j < large.Length)
            {
                ///time to practice
                  //toc
                if (largeDictionary.ContainsKey(large[j]))
                {
                    largeDictionary[large[j]]++;
                }
                else
                {
                    largeDictionary.Add(large[j], 1);
                }

                while (!CheckOneDictionaryParentOfOther(largeDictionary, smallDictionary))
                {
                    if (j < large.Length - 1)
                    {
                        j++;
                    }
                    else
                    {
                        break;
                    }

                    if (largeDictionary.ContainsKey(large[j]))
                    {
                        largeDictionary[large[j]]++;
                    }
                    else
                    {
                        largeDictionary.Add(large[j], 1);
                    }
                }

                if (CheckOneDictionaryParentOfOther(largeDictionary, smallDictionary))
                {
                    result = Math.Min(result, j - i + 1);
                    start = i; end = j;
                }

                //time to practice
                //toc
                while (CheckOneDictionaryParentOfOther(largeDictionary, smallDictionary))
                {
                    if (largeDictionary.ContainsKey(large[i]))
                    {
                        largeDictionary[large[i]]--;
                    }

                    if (largeDictionary[large[i]] == 0)
                    {
                        largeDictionary.Remove(large[i]);
                    }

                    i++;
                }

                if (result > j - i + 2)
                {
                    result = j - i + 2;
                    start = i == 0 ? i : i - 1;
                    end = j;
                }

                j++;
            }

            if (result == int.MaxValue)
            {
                return string.Empty;
            }
            return large.Substring(start, end - start + 1);
        }

        public static bool CheckOneDictionaryParentOfOther(Dictionary<char, int> large, Dictionary<char, int> small)
        {
            foreach (var keyValuePair in small)
            {
                if (!large.ContainsKey(keyValuePair.Key))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool CompareHashset(HashSet<char> a, HashSet<char> b)
        {
            if (a == null && b == null)
            {
                return true;
            }

            if (a == null || b == null)
            {
                return false;
            }
            if (a.Count != b.Count)
            {
                return false;
            }

            foreach (char ch in a)
            {
                if (!b.Contains(ch))
                {
                    return false;
                }
            }

            return true;
        }

        public static int LongestSubstringWithoutRepeating(string input)
        {
            int result = 0;
            int i = 0, j = 0;
            //abcabcbb
            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();

            //"pwwkew"  //abcabcbb
            while (j < input.Length)
            {
                if (!keyValuePairs.ContainsKey(input[j]))
                {
                    keyValuePairs.Add(input[j], 1);
                }
                else
                {
                    keyValuePairs[input[j]]++;
                }

                if (keyValuePairs.Count == (j - i + 1))
                {
                    result = Math.Max(result, j - i + 1);
                }

                while (keyValuePairs.Count < (j - i + 1))
                {
                    if (keyValuePairs.ContainsKey(input[i]))
                    {
                        keyValuePairs[input[i]]--;
                    }

                    if (keyValuePairs[input[i]] == 0)
                    {
                        keyValuePairs.Remove(input[i]);
                    }

                    i++;
                }

                j++;
            }

            return result;
        }
        public static int LongestSubArrayOfSumK(int[] numbers, int sum)
        {
            int i = 0, j = 0;
            int result = 0;
            int csum = 0;

            while (j < numbers.Length)
            {
                csum = csum + numbers[j];

                while (csum < sum)
                {
                    j++;
                    csum = csum + numbers[j];
                }

                if (csum == sum)
                {
                    result = Math.Max(j - i + 1, result);
                }

                csum -= numbers[i];
                i++;
                j++;
            }

            return result;
        }
        public static int MaxSubArrayWithSizeK(int[] numbers, int windowSize)
        {
            int i = 0, j = 0;
            int result = 0;
            int maxSum = 0;

            while (j < numbers.Length)
            {
                result = result + numbers[j];

                while ((j - i + 1) < windowSize)
                {
                    j++;
                    result = result + numbers[j];
                }

                if (j - i + 1 == windowSize)
                {
                    maxSum = Math.Max(maxSum, result);
                }

                result = result - numbers[i];

                i++;
                j++;
            }

            return maxSum;
        }

        public static void FirstNegativeNumberInWindow(int[] numbers, int windowSize)
        {
            int i = 0, j = 0;
            Queue<int> negatives = new Queue<int>();

            while (j < numbers.Length)
            {
                if (numbers[j] < 0)
                {
                    negatives.Enqueue(numbers[j]);
                }

                while ((j - i + 1) < windowSize)
                {
                    j++;

                    if (numbers[j] < 0)
                    {
                        negatives.Enqueue(numbers[j]);
                    }
                }

                if ((j - i + 1) == windowSize)
                {
                    if (negatives.Count > 0)
                    {
                        Console.WriteLine(negatives.Peek());
                    }
                    else
                    {
                        Console.WriteLine("T");
                    }
                }

                //12 -8 -7 8 -15 30 16 28

                //-8,-8,-7,-15,-15,T
                if (numbers[i] < 0)
                {
                    negatives.Dequeue();
                }

                i++;
                j++;
            }
        }

        public static void MaxOfAllSubArrayOfSizeK(int[] numbers, int windowSize)
        {
            int i = 0, j = 0;
            List<int> maxNumbers = new List<int>();
            List<int> result = new List<int>();

            //[1,3,1,2,0,5]
            //3
            while (j < numbers.Length)
            {
                while (maxNumbers.Count() > 0 && maxNumbers[maxNumbers.Count() - 1] < numbers[j])
                {
                    if (maxNumbers.Count() > 0)
                    {
                        maxNumbers.RemoveAt(maxNumbers.Count() - 1);
                    }
                }

                maxNumbers.Add(numbers[j]);

                while ((j - i + 1) < windowSize)
                {
                    j++;
                    //[1,3,1,2,0,5]
                    //3
                    while (maxNumbers.Count() > 0 && maxNumbers[maxNumbers.Count() - 1] < numbers[j])
                    {
                        if (maxNumbers.Count() > 0)
                        {
                            maxNumbers.RemoveAt(maxNumbers.Count() - 1);
                        }
                    }

                    maxNumbers.Add(numbers[j]);
                }

                //[1,3,1,2,0,5]
                //3
                if ((j - i + 1) == windowSize)
                {
                    if (maxNumbers.Count > 0)
                    {
                        result.Add(maxNumbers[0]);
                    }
                }

                if (maxNumbers.Count > 0)
                {
                    if (numbers[i] == maxNumbers[0])
                    {
                        maxNumbers.RemoveAt(0);
                    }

                    i++;
                }

                j++;
            }
        }
        public static int SlidingWindowMaxSum(int[] numbers, int windowSize)
        {
            ////2,3,5,2,9,7,1

            int result = int.MinValue;
            int sum = 0;
            int j;
            int i;

            for (i = 0; i < windowSize; i++)
            {
                sum += numbers[i];
            }

            result = sum;

            i = 0;
            j = windowSize;

            while (j < numbers.Length)
            {
                sum = sum - numbers[i] + numbers[j];
                result = Math.Max(result, sum);
                i++;
                j++;
            }

            return result;
        }

        public static List<int> MaximumOfWindowSizeK(int[] numbers, int k)
        {
            List<int> maxResult = new List<int>();
            List<int> tempResult = new List<int>();
            int i = 0, j = 0;

            while (j <= numbers.Length - 1)
            {
                AddNumberToMaxList(numbers, tempResult, j);

                while (j - i + 1 < k)
                {
                    j++;
                    AddNumberToMaxList(numbers, tempResult, j);
                }

                if (j - i + 1 == k)
                {
                    if (tempResult.Count() > 0)
                    {
                        maxResult.Add(tempResult[0]);
                    }
                }

                if (numbers[i] == tempResult[0])
                {
                    tempResult.RemoveAt(0);
                }

                i++;
                j++;
            }

            return maxResult;
        }

        private static void AddNumberToMaxList(int[] numbers, List<int> tempResult, int j)
        {
            if (tempResult.Count() == 0)
            {
                tempResult.Add(numbers[j]);
            }
            else if (tempResult[tempResult.Count() - 1] < numbers[j])
            {
                while (tempResult.Count > 0 && tempResult[tempResult.Count() - 1] < numbers[j])
                {
                    tempResult.RemoveAt(tempResult.Count() - 1);
                }

                tempResult.Add(numbers[j]);
            }
            else
            {
                tempResult.Add(numbers[j]);
            }
        }

        public static List<int> FirstNegativeNumberInWindowSizeOfK(int[] nums, int k)
        {
            List<int> result = new List<int>();
            int i = 0, j = 0;
            Queue<int> negativeNumbers = new Queue<int>();

            while (j <= nums.Length - 1)
            {
                if (nums[j] < 0)
                {
                    negativeNumbers.Enqueue(nums[j]);
                }

                while (j - i + 1 < k)
                {
                    j++;

                    if (nums[j] < 0)
                    {
                        negativeNumbers.Enqueue(nums[j]);
                    }
                }

                if (j - i + 1 == k)
                {
                    if (negativeNumbers.Count() > 0)
                    {
                        result.Add(negativeNumbers.Peek());
                    }
                    else
                    {
                        result.Add(1);
                    }
                }

                if (nums[i] < 0)
                {
                    if (negativeNumbers.Count > 0)
                    {
                        negativeNumbers.Dequeue();
                    }
                }

                i++;
                j++;
            }

            return result;
        }

        private static int MaxInWindowSizeOfK(int[] nums, int k)
        {
            int i = 0, j = 0;
            int result = int.MinValue;
            int sum = 0;

            //2, 5, 1, 8, 2, 9, 1
            while (j <= nums.Length - 1)
            {
                sum = sum + nums[j];

                while ((j - i + 1) < k)
                {
                    j++;
                    sum = sum + nums[j];
                }

                if ((j - i + 1) == k)
                {
                    result = Math.Max(result, sum);
                }

                sum = sum - nums[i];
                i++;
                j++;
            }

            return result;
        }

        private static int LargestSubArrayOfGivenSumVariableSizeWindow(int[] numbers, int sum)
        {
            int i = 0, j = 0;
            int result = int.MinValue;
            int tempSum = 0;

            while (j <= numbers.Length - 1)
            {
                tempSum += numbers[j];

                while (tempSum < sum)
                {
                    j++;

                    tempSum += numbers[j];
                }

                if (tempSum == sum)
                {
                    result = Math.Max(result, j - i + 1);
                }

                while (tempSum > sum)
                {
                    tempSum = tempSum - numbers[i];
                    i++;
                }

                if (tempSum == sum)
                {
                    result = Math.Max(result, j - i + 1);
                }

                j++;
            }

            return result;
        }

        public static int SlidingWindowMaxSum3(int[] numbers, int windowSize)
        {
            int result = 0;
            int i = 0, j = 0, sum = 0;

            //2518297
            while (j < numbers.Length)
            {
                sum = sum + numbers[j];

                while (j - i + 1 < windowSize)
                {
                    j++;
                    sum = sum + numbers[j];
                    continue;
                }

                if (j - i + 1 == windowSize)
                {
                    result = Math.Max(sum, result);
                }

                sum = sum - numbers[i];

                i++;
                j++;
            }

            return result;
        }

        public static int SlidingWindowVariableSizeMaxWithSum(int[] numbers, int k)
        {
            int result = 0;
            int i = 0, j = 0, sum = 0;

            //2518297
            while (j < numbers.Length)
            {
                sum = sum + numbers[j];

                while (sum < k)
                {
                    j++;

                    if (j == numbers.Length)
                    {
                        break;
                    }

                    sum = sum + numbers[j];
                }

                if (sum == k)
                {
                    result = Math.Max(j - i + 1, result);
                }

                while (sum > k)
                {
                    sum = sum - numbers[i];
                    i++;
                }

                j++;
            }

            return result;
        }

        public static int SlidingWindowMaxSum2(int[] numbers, int windowSize)
        {
            ////2,3,5,2,9,7,1

            int end = windowSize - 1;
            int maxSum = 0;
            int j;

            for (int i = 0; i <= end; i++)
            {
                maxSum = maxSum + numbers[i];
            }

            for (int i = 1; i <= numbers.Length - 1 - windowSize; i++)
            {
                j = i + windowSize - 1;
                maxSum = Math.Max(maxSum, maxSum - numbers[i - 1] + numbers[j]);
            }

            return maxSum;
        }

        public static void PrintFirstNegativeNumberInWindowSizeOfK(int[] numbers, int k)
        {
            if (numbers.Length == 0)
            {
                return;
            }

            Queue<int> negativeNumbers = new Queue<int>();
            int i = 0, j = 0;

            while (j < numbers.Length)
            {
                if (numbers[j] < 0)
                {
                    negativeNumbers.Enqueue(numbers[j]);
                }

                //12 -1 -7 8 -15 30 16 28
                while (j - i + 1 < k)
                {
                    j++;

                    if (numbers[j] < 0)
                    {
                        negativeNumbers.Enqueue(numbers[j]);
                    }
                }

                if (j - i + 1 == k)
                {
                    if (negativeNumbers.Count() > 0)
                    {
                        Console.WriteLine(negativeNumbers.Peek());
                    }
                    else
                    {
                        Console.WriteLine(0);
                    }
                }

                if (numbers[i] < 0)
                {
                    if (negativeNumbers.Count() > 0)
                    {
                        negativeNumbers.Dequeue();
                    }
                }

                i++;
                j++;
            }
        }

        public static void MaximumOfAllSubArrayOfSizeK(int[] numbers, int k)
        {
            if (numbers.Length == 0)
            {
                return;
            }

            int i = 0, j = 0;

            List<int> maxNumbers = new List<int>();

            //1 3 -1 -3 5 3 6 7
            while (j < numbers.Length)
            {
                if (j - i + 1 < k)
                {
                    if (maxNumbers.Count == 0)
                    {
                        maxNumbers.Add(numbers[j]);
                    }
                    else
                    {
                        if (maxNumbers.Max() < numbers[j])
                        {
                            maxNumbers.Add(numbers[j]);
                        }
                    }

                    j++;
                    continue;
                }

                //1 3 -1 -3 5 3 6 7
                if (maxNumbers.Max() < numbers[j])
                {
                    maxNumbers.Add(numbers[j]);
                }

                if (numbers[i] == maxNumbers.Max())
                {
                    Console.WriteLine(numbers[i]);
                    maxNumbers.Remove(maxNumbers.Max());
                }
                else
                {
                    Console.WriteLine(maxNumbers.Max());
                }

                i++;
                j++;
            }
        }

        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            List<int> result = new List<int>();

            if(nums.Length==0)
            {
                return result.ToArray();
            }

            List<int> maxList = new List<int>();

            int i = 0, j = 0;

            while(j<nums.Length)
            {
                while(maxList.Count()>0 && maxList[maxList.Count-1]<nums[j])
                {
                    int toremove = maxList[maxList.Count - 1];

                    maxList.Remove(toremove);
                }

                maxList.Add(nums[j]);

                while(j-i+1<k)
                {
                    j++;

                    while (maxList.Count() > 0 && maxList[maxList.Count - 1] < nums[j])
                    {
                        int toremove = maxList[maxList.Count - 1];

                        maxList.Remove(toremove);
                    }

                    maxList.Add(nums[j]);
                }

                if(j-i+1==k)
                {
                    if(maxList.Count()>0)
                    {
                        result.Add(maxList[0]);
                    }
                }

                if(maxList.Count()>0)
                {
                    if(maxList[0]==nums[i])
                    {
                        int temp = maxList[0];

                        maxList.Remove(temp);
                    }
                }

                i++;
                j++;
            }

            return result.ToArray();
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

        public static bool CheckIfRepeatingCharacterFound(Dictionary<char, int> keyValuePairs)
        {
            return keyValuePairs.Where(x => x.Value > 1).Count() > 0;
        }

        public static int LongestSubstringWithKUniqueCharacters(char[] characters, int k)
        {
            int result = 0;
            int i = 0, j = 0;
            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();

            while (j < characters.Length)
            {
                AddCharacterToDictionary(keyValuePairs, characters[j]);

                while (keyValuePairs.Count() < k)
                {
                    j++;

                    if (j == characters.Length)
                    {
                        break;
                    }

                    AddCharacterToDictionary(keyValuePairs, characters[j]);
                }

                if (keyValuePairs.Count() == k)
                {
                    result = Math.Max(result, j - i + 1);
                }

                while (keyValuePairs.Count() > k)
                {
                    if (keyValuePairs.ContainsKey(characters[i]))
                    {
                        keyValuePairs[characters[i]]--;
                    }

                    if (keyValuePairs[characters[i]] == 0)
                    {
                        keyValuePairs.Remove(characters[i]);
                    }

                    i++;
                }

                j++;
            }

            return result;
        }

        public static int LongestSubstringWithWithOutRepeatingCharacter(char[] characters)
        {
            int result = 0;
            int i = 0, j = 0;
            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();

            while (j < characters.Length)
            {
                AddCharacterToDictionary(keyValuePairs, characters[j]);

                while (!CheckIfRepeatingCharacterFound(keyValuePairs))
                {
                    j++;

                    if (j == characters.Length)
                    {
                        j--;
                        return Math.Max(result, j - i + 1);
                    }

                    if (characters[j] > 0)
                    {
                        j--;
                        break;
                    }

                    AddCharacterToDictionary(keyValuePairs, characters[j]);
                }

                if (!CheckIfRepeatingCharacterFound(keyValuePairs))
                {
                    result = Math.Max(result, j - i + 1);
                }

                if (CheckIfRepeatingCharacterFound(keyValuePairs))
                {
                    while (CheckIfRepeatingCharacterFound(keyValuePairs))
                    {
                        if (keyValuePairs.ContainsKey(characters[i]))
                        {
                            keyValuePairs[characters[i]]--;
                        }

                        if (keyValuePairs[characters[i]] == 0)
                        {
                            keyValuePairs.Remove(characters[i]);
                        }

                        i++;
                    }
                }

                j++;
            }

            return result;
        }

        public static int LongestSubstringWithWithOutRepeatingCharacter2(string mystring)
        {
            int result = 0, i = 0, j = 0;

            Dictionary<char, int> map = new Dictionary<char, int>();

            if (string.IsNullOrEmpty(mystring))
            {
                return 0;
            }

            if (mystring.Length == 1)
            {
                return 1;
            }

            //PWWKEW
            while (j < mystring.Length)
            {
                AddCharacterToDictionary(map, mystring[j]);

                //while(map.Count < j - i + 1)
                //{
                //    j++;

                //    AddCharacterToDictionary(map, mystring[j]);
                //}

                if (map.Count == j - i + 1)
                {
                    result = Math.Max(result, j - i + 1);
                }

                if (j - i + 1 > map.Count)
                {
                    while (j - i + 1 > map.Count)
                    {
                        if (map.ContainsKey(mystring[i]))
                        {
                            map[mystring[i]]--;
                        }

                        if (map[mystring[i]] == 0)
                        {
                            map.Remove(mystring[i]);
                        }

                        i++;
                    }
                }

                j++;
            }

            return result;
        }

        public static int CountOccuranceOfAnagram(string input, int k, Dictionary<char, int> patternmap, string sample)
        {
            int i = 0, j = 0, count = 0, resultCount = 0;
            Dictionary<char, int> sourceMap = new Dictionary<char, int>();

            foreach (char ch in sample)
            {
                if (patternmap.ContainsKey(ch))
                {
                    patternmap[ch]++;
                }
                else
                {
                    patternmap.Add(ch, 1);
                    count++;
                }
            }

            while (j < input.Length)
            {
                if (sourceMap.ContainsKey(input[j]))
                {
                    sourceMap[input[j]]++;
                }
                else
                {
                    sourceMap.Add(input[j], 1);
                }

                //aabaabaa //aaba
                while ((j - i + 1) != k)
                {
                    j++;

                    if (sourceMap.ContainsKey(input[j]))
                    {
                        sourceMap[input[j]]++;
                    }
                    else
                    {
                        sourceMap.Add(input[j], 1);
                    }
                }

                //aabaabaa //aaba
                if ((j - i + 1) == k)
                {
                    if (CompareMaps(patternmap, sourceMap))
                    {
                        resultCount++;
                    }
                }

                //aabaabaa //aaba
                if (sourceMap.ContainsKey(input[i]))
                {
                    sourceMap[input[i]]--;

                    if (sourceMap[input[i]] == 0)
                    {
                        sourceMap.Remove(input[i]);
                    }
                }

                i++;
                j++;
            }

            return resultCount;
        }

        public static bool CompareMaps(Dictionary<char, int> patternMap, Dictionary<char, int> sourceMap)
        {
            if (patternMap.Count != sourceMap.Count)
            {
                return false;
            }

            foreach (KeyValuePair<char, int> pair in patternMap)
            {
                if (patternMap[pair.Key] != sourceMap[pair.Key])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool InsertIntoMap(char ch, Dictionary<char, int> map)
        {
            if (map.ContainsKey(ch))
            {
                map[ch]--;
                return true;
            }

            return false;
        }
    }
}
