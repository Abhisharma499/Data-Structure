using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
   public static class UnBoundedKnapsack
    {

        public static int MaximumRodCuttingProfit(int [] length,int []price, int rodLength)
        {
            int rows = length.Length + 1;
            int columns = rodLength + 1;
            int[,] T = new int[rows,columns];

            for(int i=0;i<rows;i++)
            {
                for(int j=0;j<columns;j++)
                {
                    if(i==0 || j==0)
                    {
                        T[i, j] = 0;
                    }
                }
            }

            for(int i=1;i<rows;i++)
            {
                for(int j=1;j<columns;j++)
                {
                    if (length[i - 1] <= j)
                    {
                        T[i, j] = Math.Max(price[i - 1] + T[i, j - length[i - 1]], T[i - 1, j]);
                    }
                    else
                    {
                        T[i, j] = T[i - 1, j];
                    }
                }
            }

            return T[rows - 1, columns - 1];
        }

        public static int MaximumRodCuttingProfitPractice(int[] length, int[] price, int rodLength)
        {
            int rows = length.Length + 1;
            int cols = rodLength + 1;

            int[,] T = new int[rows, cols];

            for(int i=0;i<rows;i++)
            {
                for(int j=0;j<cols;j++)
                {
                    if (i == 0||j==0)
                    {
                        T[i,j] = 0;
                    }
                }
            }

            for(int i=1;i<rows;i++)
            {
                for(int j=1;j<cols;j++)
                {
                    if (length[i - 1] <= j)
                    {
                        T[i, j] = Math.Max(price[i - 1] + T[i - 1, j - length[i - 1]], T[i - 1, j - length[i - 1]]);
                    }
                    else
                    {
                      T[i,j]=  T[i - 1, j - length[i - 1]];
                    }
                }
            }

            return T[rows - 1, cols - 1];

        }

        public static int MaximumNumberOfWaysCoinChange(int[] coins, int sum)
        {
            int rows = coins.Length + 1;
            int columns = sum + 1;
            int[,] T = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == 0)
                    {
                        T[i, j] = 0;
                    }
                    if(j==0)
                    {
                        T[i, j] = 1;
                    }
                }
            }

            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < columns; j++)
                {
                    if (coins[i - 1] <= j)
                    {
                        T[i, j] =  T[i, j - coins[i - 1]]+ T[i - 1, j];
                    }
                    else
                    {
                        T[i, j] = T[i - 1, j];
                    }
                }
            }

            return T[rows - 1, columns - 1];
        }
    }
}
