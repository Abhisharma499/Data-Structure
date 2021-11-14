using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject.Problems
{
    public static class KnapSackProblem
    {
        public static bool CanPartition(int[] nums)
        {
            if (nums.Sum() % 2 == 1)
            {
                return false;
            }

            int length = nums.Length;
            int target = nums.Sum() / 2;

            bool[,] mat = new bool[length + 1, target+1];
            //int target = nums.Sum() / 2;

            mat[0, 0] = true;
            for (int j = 1; j <= target; j++)
            {
                mat[0, j] = false;
            }

            for (int i = 1; i <= length; i++)
            {
                mat[i, 0] = true;
            }

            for (int i = 1; i <= length; i++)
            {
                for (int j = 1; j <= target; j++)
                {
                    if (nums[i - 1] <= j)
                    {
                        mat[i, j] = mat[i - 1, j - nums[i - 1]] || mat[i - 1, j];
                    }
                    else
                    {
                        mat[i, j] = mat[i - 1, j];
                    }
                }
            }

            return mat[length, target];
        }
        public static bool IsSubsetPresent(int[] array, int sum)
        {
            int rows = array.Length + 1;
            int columns = sum + 1;
            bool[,] T = new bool[array.Length + 1, sum + 1];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == 0)
                    {
                        T[i, j] = false;
                    }

                    if (j == 0)
                    {
                        T[i, j] = true;
                    }

                }
            }

            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < columns; j++)
                {
                    if (array[i - 1] <= j)
                    {
                        T[i, j] = T[i - 1, j - array[i - 1]] || T[i - 1, j];
                    }
                    else
                    {
                        T[i, j] = T[i - 1, j];
                    }

                }
            }

            return T[rows - 1, columns - 1];
        }

        public static int CountSubsetPresent(int[] array, int sum)
        {
            int rows = array.Length + 1;
            int columns = sum + 1;
            int[,] T = new int[array.Length + 1, sum + 1];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == 0)
                    {
                        T[i, j] = 0;
                    }

                    if (j == 0)
                    {
                        T[i, j] = 1;
                    }

                }
            }

            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < columns; j++)
                {
                    if (array[i - 1] <= j)
                    {
                        T[i, j] = T[i - 1, j - array[i - 1]] + T[i - 1, j];
                    }
                    else
                    {
                        T[i, j] = T[i - 1, j];
                    }

                }
            }

            //int count = 0;

            //for(int i=0;i<rows;i++)
            //{
            //    for(int j=0;j<columns;j++)
            //    {

            //        if(T[i,j]==true)
            //        {
            //            Console.Write("T  ");
            //        }
            //        else
            //        {
            //            Console.Write("F  ");
            //        }
            //        if(j==columns-1)
            //        {
            //            if(T[i,j] ==true)
            //            {
            //                count++;
            //            }
            //        }
            //    }

            //    Console.WriteLine();
            //}



            return T[rows - 1, columns - 1];
        }

        public static bool SubSetSum(int[] array, int sum)
        {
            bool[,] resultTable = new bool[array.Length + 1, sum + 1];

            for (int i = 0; i < array.Length + 1; i++)
            {
                for (int j = 0; j < sum + 1; j++)
                {
                    if (i == 0)
                    {
                        resultTable[i, j] = false;
                    }

                    if (j == 0)
                    {
                        resultTable[i, j] = true;
                    }
                }
            }

            for (int i = 1; i < array.Count() + 1; i++)
            {
                for (int j = 1; j < sum + 1; j++)
                {
                    if (array[i - 1] <= j)
                    {
                        resultTable[i, j] = resultTable[i - 1, j - array[i - 1]] || resultTable[i - 1, j];
                    }
                    else
                    {
                        resultTable[i, j] = resultTable[i - 1, j];
                    }

                }
            }



            return resultTable[array.Length, sum];
        }

        public static int NumWaterBottles(int numBottles, int numExchange)
        {
            int result = numBottles;
            int exchangeReturn = 0;
            int remainder = 0;

            while (numBottles > 0)
            {
                exchangeReturn = numBottles / numExchange;
                remainder = numBottles % numExchange;
                numBottles = exchangeReturn + remainder;
                result += exchangeReturn;

                if (numBottles < numExchange)
                {
                    return result;
                }
            }

            return result;


        }

        public static int MinimumSubsetSumDifference(int[] array)
        {

            int sumOfArray = array.Sum();

            int rows = array.Length + 1;
            int columns = sumOfArray + 1;

            bool[,] T = new bool[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == 0)
                    {
                        T[i, j] = false;
                    }
                    if (j == 0)
                    {
                        T[i, j] = true;
                    }
                }
            }

            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < columns; j++)
                {
                    if(array[i-1]<= j)
                    {
                        T[i, j] = T[i - 1, j - array[i - 1]] || T[i - 1, j];
                    }
                    else
                    {
                        T[i, j] = T[i - 1, j];
                    }
                }
            }

            List<int> SumOfFirstSet = new List<int>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (T[i, j])
                    {
                        if (i == rows - 1 && j <= sumOfArray / 2)
                        {
                            SumOfFirstSet.Add(j);
                        }
                    }
                }
            }

            int minimum = Int32.MaxValue;
            int sumSetTwoSum = 0;

            foreach(int item in SumOfFirstSet)
            {
                sumSetTwoSum = sumOfArray - item;
                minimum = Math.Min(minimum, Math.Abs(sumSetTwoSum- item));
            }

            return minimum;
        }

        public static int CountSubsetWithGivenDifference(int[] array, int difference)
        {

            int sumOfArray = array.Sum();

            int rows = array.Length + 1;
            int columns = sumOfArray + 1;

            bool[,] T = new bool[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == 0)
                    {
                        T[i, j] = false;
                    }
                    if (j == 0)
                    {
                        T[i, j] = true;
                    }
                }
            }

            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < columns; j++)
                {
                    if (array[i - 1] <= j)
                    {
                        T[i, j] = T[i - 1, j - array[i - 1]] || T[i - 1, j];
                    }
                    else
                    {
                        T[i, j] = T[i - 1, j];
                    }
                }
            }

            List<int> SumOfFirstSet = new List<int>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (T[i, j])
                    {
                        if (i == rows - 1 && j <= sumOfArray)
                        {
                            SumOfFirstSet.Add(j);
                        }
                    }
                }
            }

            int countSubsets = 0;
            int sumOfSecondSet = 0;

            foreach (int item in SumOfFirstSet)
            {
                sumOfSecondSet = sumOfArray - item;
                if (Math.Abs(item - sumOfSecondSet)== difference )
                {
                    countSubsets++;
                }
            
            }

            return countSubsets;
        }

        private  static void PrintArray(bool [,] T,int rows, int columns)
        {
            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {

                    if (T[i, j] == true)
                    {
                        Console.Write("T  ");
                    }
                    else
                    {
                        Console.Write("F  ");
                    }
                    if (j == columns - 1)
                    {
                        if (T[i, j] == true)
                        {
                            count++;
                        }
                    }
                }

                Console.WriteLine();
            }
        }

        public static int LongestCommonSubsequence(string s1, string s2)
        {
            if(s1.Length== 0 || s2.Length==0)
            {
                return 0;
            }

            if(s1[s1.Length-1]== s2[s2.Length-1])
            {
                return 1 + LongestCommonSubsequence(s1.Substring(0, s1.Length - 1), s2.Substring(0, s2.Length - 1));
            }
            else
            {
                return Math.Max(LongestCommonSubsequence(s1.Substring(0, s1.Length - 1), s2.Substring(0, s2.Length)), LongestCommonSubsequence(s1.Substring(0, s1.Length), s2.Substring(0, s2.Length - 1)));
            }
        }
    }
}
