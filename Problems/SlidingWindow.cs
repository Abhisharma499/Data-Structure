using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    class SlidingWindow
    {
        public static int SlidingWindowMaxSum(int[] numbers, int windowSize)
        {
            ////2,3,5,2,9,7,1

            int result = int.MinValue;
            int sum = 0;
            int j;
            int i;
           
            for(i=0;i<windowSize;i++)
            {
                sum += numbers[i];
            }

            result = sum;

            i = 0;
            j = windowSize;

            while(j< numbers.Length)
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
            while(j< numbers.Length)
            {
                sum = sum + numbers[j];

                while(j-i+1< windowSize)
                {
                    j++;
                    sum = sum + numbers[j];
                    continue;
                }

                if(j-i+1 == windowSize)
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

                    if(j == numbers.Length)
                    {
                        break;
                    }

                    sum = sum + numbers[j];

                }

                if (sum == k)
                {
                    result = Math.Max(j-i+1, result);
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
            if(numbers.Length == 0)
            {
                return;
            }

            int i = 0, j = 0;

            List<int> maxNumbers = new List<int>();
             
            //1 3 -1 -3 5 3 6 7
            while(j<numbers.Length)
            {               
                if(j-i+1 < k)
                {
                    if(maxNumbers.Count==0)
                    {
                        maxNumbers.Add(numbers[j]);
                    } 
                    else 
                    {
                        if(maxNumbers.Max()< numbers[j])
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

                if(numbers[i] == maxNumbers.Max())
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

        public static int LongestSubstringWithKUniqueCharacters(char [] characters, int k)
        {
            int result = 0;
            int i = 0, j = 0;
            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();

            while(j< characters.Length)
            {
                AddCharacterToDictionary(keyValuePairs, characters[j]);
                while(keyValuePairs.Count() < k)
                {
                    j++;

                    if(j == characters.Length)
                    {
                        break;
                    }

                    AddCharacterToDictionary(keyValuePairs, characters[j]);
                }

                if (keyValuePairs.Count() == k)
                {
                    result = Math.Max(result, j - i + 1);
                }

                while(keyValuePairs.Count() > k)
                {
                    if (keyValuePairs.ContainsKey(characters[i]))
                    {
                        keyValuePairs[characters[i]]--;
                    }

                    if(keyValuePairs[characters[i]] == 0)
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
            
            if(string.IsNullOrEmpty(mystring))
            {
                return 0;
            }

            if(mystring.Length == 1)
            {
                return 1;
            }

            //PWWKEW
            while (j< mystring.Length)
            {
                AddCharacterToDictionary(map, mystring[j]);

                //while(map.Count < j - i + 1)
                //{
                //    j++;

                //    AddCharacterToDictionary(map, mystring[j]);
                //}

                if(map.Count == j - i + 1)
                {
                    result = Math.Max(result, j - i + 1);
                }

                if(j-i+1> map.Count)
                {
                    while(j - i + 1 > map.Count)
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

        public static int CountOccuranceOfAnagram(string input, int k, Dictionary<char,int> patternmap,string sample)
        {
            int i=0, j=0,count=0, resultCount=0;
            Dictionary<char, int> sourceMap = new Dictionary<char, int>();
           

            foreach(char ch in sample)
            {
                if(patternmap.ContainsKey(ch))
                {
                    patternmap[ch]++;
                }
                else
                {
                    patternmap.Add(ch, 1);
                    count++;
                }        
            }

            while(j< input.Length)
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
                while ((j - i + 1)!=k)
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
                    if(CompareMaps(patternmap,sourceMap))
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

        public static bool CompareMaps(Dictionary<char, int> patternMap, Dictionary<char,int> sourceMap)
        {
            if(patternMap.Count!= sourceMap.Count)
            {
                return false;
            }

            foreach(KeyValuePair<char,int> pair in patternMap)
            {
                if(patternMap[pair.Key]!= sourceMap[pair.Key])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool InsertIntoMap(char ch, Dictionary<char,int> map)
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
