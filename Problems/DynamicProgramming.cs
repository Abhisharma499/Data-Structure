using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    class DynamicProgramming
    {
        public static int CoinChangeMaxNumberOfWays(int[] coins, int amount)
        {
            int rows = coins.Length + 1;
            int columns = amount + 1;
            int[,] result = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == 0)
                    {
                        result[i, j] = 0;
                    }
                    if (j == 0)
                    {
                        result[i, j] = 1;
                    }
                }
            }

            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < columns; j++)
                {
                    if (coins[i - 1] <= j)
                    {
                        result[i, j] = result[i, j - coins[i - 1]] + result[i - 1, j];
                    }
                    else
                    {
                        result[i, j] = result[i - 1, j];
                    }
                }
            }

            return result[rows - 1, columns - 1];
        }
        public static int CoinChangeMinimumNumberOfCoins(int[] coins, int amount)
        {
            int rows = coins.Length + 1;
            int columns = amount + 1;
            int[,] result = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == 0)
                    {
                        result[i, j] = int.MaxValue;
                    }
                    if (j == 0)
                    {
                        result[i, j] = 0;
                    }
                }
            }

            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < columns; j++)
                {
                    if (coins[i - 1] <= j)
                    {
                        result[i, j] = Math.Min(result[i, j - coins[i - 1]] + 1, result[i - 1, j]);
                    }
                    else
                    {
                        result[i, j] = result[i - 1, j];
                    }
                }
            }
            if (result[rows - 1, columns - 1] == 0 || result[rows - 1, columns - 1] == int.MaxValue)
            {
                return -1;
            }

            return result[rows - 1, columns - 1];
        }

        public static List<string> palindromes = new List<string>();
        public static bool SubsetSum(int[] numbers, int sum)
        {
            bool[,] resultTable = new bool[numbers.Length + 1, sum + 1];

            for (int i = 0; i <= numbers.Length; i++)
            {
                for (int j = 0; j <= sum; j++)
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

            for (int i = 1; i <= numbers.Length; i++)
            {
                for (int j = 1; j <= sum; j++)
                {
                    if (numbers[i - 1] <= j)
                    {
                        resultTable[i, j] = resultTable[i - 1, j - numbers[i - 1]] || resultTable[i - 1, j];
                     }
                    else
                    {
                        resultTable[i, j] = resultTable[i - 1, j];
                    }

                }
            }

            return resultTable[numbers.Length, sum];
        }

        public static int CountSubsetWithSum(int[] numbers, int sum)
        {
            int[,] resultTable = new int[numbers.Length + 1, sum + 1];

            for (int i = 0; i <= numbers.Length; i++)
            {
                for (int j = 0; j <= sum; j++)
                {
                    if (i == 0)
                    {
                        resultTable[i, j] = 0;
                    }
                    if (j == 0)
                    {
                        resultTable[i, j] = 1;
                    }
                }
            }

            for (int i = 1; i <= numbers.Length; i++)
            {
                for (int j = 1; j <= sum; j++)
                {
                    if (numbers[i - 1] <= j)
                    {
                        resultTable[i, j] = resultTable[i - 1, j - numbers[i - 1]] + resultTable[i - 1, j];
                    }
                    else
                    {
                        resultTable[i, j] = resultTable[i - 1, j];
                    }

                }
            }

            return resultTable[numbers.Length, sum];
        }

        public static int MinimumCutPalindromePartition(string s, int i,int j)
        {
            int mincut = int.MaxValue;

            if(s.Length==0 || s.Length==1)
            {
                return 0;
            }

            if (IsPalindrome(s.Substring(i,j-i+1)))
            {
                if (!palindromes.Contains(s.Substring(i, j - i + 1)))
                {
                    palindromes.Add(s.Substring(i, j - i + 1));
                }

                return 0;
            }

            if (i>=j)
            {
                return 0;
            }

            for(int k=i;k<=j-1;k++)
            {
                int temp = MinimumCutPalindromePartition(s, i, k) + MinimumCutPalindromePartition(s, k + 1, j) + 1;

                mincut = Math.Min(temp, mincut);
            }

            return mincut;
        }

        public static bool IsPalindrome(string s)
        {
            int end = s.Length - 1;
            if(s.Length==0 || s.Length==1)
            {
                return true;
            }

            for(int i=0;i<=(s.Length/2)-1;i++)
            {
                if(s[i]==s[end])
                {
                    end--;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
