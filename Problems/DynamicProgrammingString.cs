using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
   public class DynamicProgrammingString
    {
      public  static int[,] T;
        public static int LongestCommonSubsequenceRecursive(string s1, string s2, int n, int m)
        {
            if (n == 0 || m == 0)
            {
                return 0;
            }

            if (T[n, m] != -1)
            {
                return T[n, m];
            }

            if (s1[n - 1] == s2[m - 1])
            {
                return T[n, m] = 1 + LongestCommonSubsequenceRecursive(s1, s2, n - 1, m - 1);
            }
            else
            {
                return T[n, m] = Math.Max(LongestCommonSubsequenceRecursive(s1, s2, n - 1, m), LongestCommonSubsequenceRecursive(s1, s2, n, m - 1));
            }
        }

        public static int LongestCommonSubsequenceIterative(string s1, string s2, int n, int m)
        {
            if (n == 0 || m == 0)
            {
                return 0;
            }

            int rows = n + 1;
            int columns = m + 1;

            int[,] T = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        T[i, j] = 0;
                    }
                }
            }

            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < columns; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        T[i, j] = 1 + T[i - 1, j - 1];
                    }
                    else
                    {
                        T[i, j] = Math.Max(T[i - 1, j], T[i, j - 1]);
                    }
                }
            }

            return T[rows - 1, columns - 1];
        }

        public static int LongestCommonSubstringIterative(string s1, string s2, int n, int m)
        {
            if (n == 0 || m == 0)
            {
                return 0;
            }

            int rows = n + 1;
            int columns = m + 1;

            int[,] T = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        T[i, j] = 0;
                    }
                }
            }

            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < columns; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        T[i, j] = 1 + T[i - 1, j - 1];
                    }
                    else
                    {
                        T[i, j] = 0;
                    }
                }
            }

            int max = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (T[i, j] > max)
                    {
                        max = T[i, j];
                    }
                }
            }

            return max;
        }

        public static int LongestCommonSubstringRecurive(string s1, string s2, int n, int m, int count)
        {
            if (n == 0 || m == 0)
            {
                return count;
            }

            if (s1[n - 1] == s2[m - 1])
            {
                 count = LongestCommonSubstringRecurive(s1, s2, n - 1, m - 1, count + 1);
            }
            else
            {
                count = Math.Max(count, Math.Max(LongestCommonSubstringRecurive(s1, s2, n - 1, m, 0), LongestCommonSubstringRecurive(s1, s2, n, m - 1, 0)));

            }

            return count;
        }
    }
}
