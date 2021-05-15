using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
   public static class MatrixMultiplication
    {
        public  static void Multiply()
        {
            int rows = 0, columns = 0;
            Console.WriteLine("Enter number of rows for matrix");
            rows=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter number of columns for matrix");
            columns = Convert.ToInt32(Console.ReadLine());

            int[,] matrix1 = new int[rows, columns];
            int[,] matrix2 = new int[rows, columns];
           

            if(matrix1.GetLength(1)!= matrix2.GetLength(0))
            {
                throw new Exception("Matrix cant be multiplied");
            }

            int[,] result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];

            Console.WriteLine("Enter values for matrix 1");
            for (int i=0;i<rows;i++)
            {
                for(int j=0;j<columns;j++)
                {

                  matrix1[i,j]= Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.WriteLine("Enter values for matrix 2");

            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {

                    matrix2[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {

                   for(int k=0;k< matrix1.GetLength(1); k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(result[i, j]+ " ");
                }
                Console.WriteLine();

            }




        }
    }
}
