using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject.Problems
{
    class Coordinates
    {
        public int x, y, pass;

        public Coordinates(int x, int y, int pass)
        {
            this.x = x;
            this.y = y;
            this.pass = pass;
        }
    }
    class RottingOranges
    {

        public static int MinTimeToRotOranges(int[][] grid)
        {
            int count = 0;
            int freshOrangeCount = 0;
            int rottenOrangesCount = 0;
            int rows = grid.GetUpperBound(0) + 1;
            int cols = grid[0].Length;

            Queue<Coordinates> Oranges = new Queue<Coordinates>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        Oranges.Enqueue(new Coordinates(i, j, 0));
                        rottenOrangesCount++;
                    }
                    else if (grid[i][j] == 1)
                    {
                        freshOrangeCount++;
                    }
                }
            }

            while (Oranges.Count() > 0)
            {
                Coordinates currentRottenOrange = Oranges.Dequeue();

                count =  Math.Max(count, currentRottenOrange.pass);

                if (CheckIfIndexValid(currentRottenOrange.x + 1, currentRottenOrange.y, rows, cols) && grid[currentRottenOrange.x + 1][currentRottenOrange.y] == 1)
                {
                    grid[currentRottenOrange.x + 1][currentRottenOrange.y] = 2;

                    Oranges.Enqueue(new Coordinates(currentRottenOrange.x + 1, currentRottenOrange.y, currentRottenOrange.pass + 1));
                }
                if (CheckIfIndexValid(currentRottenOrange.x - 1, currentRottenOrange.y, rows, cols) && grid[currentRottenOrange.x - 1][currentRottenOrange.y] == 1)
                {
                    grid[currentRottenOrange.x - 1][currentRottenOrange.y] = 2;

                    Oranges.Enqueue(new Coordinates(currentRottenOrange.x - 1, currentRottenOrange.y, currentRottenOrange.pass + 1));
                }

                if (CheckIfIndexValid(currentRottenOrange.x, currentRottenOrange.y + 1, rows, cols) && grid[currentRottenOrange.x][currentRottenOrange.y + 1] == 1)
                {
                    grid[currentRottenOrange.x][currentRottenOrange.y + 1] = 2;

                    Oranges.Enqueue(new Coordinates(currentRottenOrange.x, currentRottenOrange.y + 1, currentRottenOrange.pass + 1));
                }

                if (CheckIfIndexValid(currentRottenOrange.x, currentRottenOrange.y - 1, rows, cols) && grid[currentRottenOrange.x][currentRottenOrange.y - 1] == 1)
                {
                    grid[currentRottenOrange.x][currentRottenOrange.y - 1] = 2;

                    Oranges.Enqueue(new Coordinates(currentRottenOrange.x, currentRottenOrange.y - 1, currentRottenOrange.pass + 1));
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        return -1;
                    }
                }
            }

            return count;
        }
        public static int NumberOfRounds(int[][] grid)
        {
            int result = 0;
            if (grid.Length == 0)
            {
                return 0;
            }

            Queue<Coordinates> Oranges = new Queue<Coordinates>();
            int rows = grid.GetUpperBound(0) + 1;
            int col = grid[0].Length;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        Oranges.Enqueue(new Coordinates(i, j, 0));
                    }
                }
            }

            while (Oranges.Count() > 0)
            {
                Coordinates currentOrange = Oranges.Dequeue();

                result = Math.Max(result, currentOrange.pass);

                if (CheckIfIndexValid(currentOrange.x + 1, currentOrange.y, rows, col) && grid[currentOrange.x + 1][currentOrange.y] == 1)
                {
                    grid[currentOrange.x + 1][currentOrange.y] = 2;
                    Oranges.Enqueue(new Coordinates(currentOrange.x + 1, currentOrange.y, currentOrange.pass + 1));

                }

                if (CheckIfIndexValid(currentOrange.x - 1, currentOrange.y, rows, col) && grid[currentOrange.x - 1][currentOrange.y] == 1)
                {
                    grid[currentOrange.x - 1][currentOrange.y] = 2;
                    Oranges.Enqueue(new Coordinates(currentOrange.x - 1, currentOrange.y, currentOrange.pass + 1));

                }

                if (CheckIfIndexValid(currentOrange.x, currentOrange.y + 1, rows, col) && grid[currentOrange.x][currentOrange.y + 1] == 1)
                {
                    grid[currentOrange.x][currentOrange.y + 1] = 2;
                    Oranges.Enqueue(new Coordinates(currentOrange.x, currentOrange.y + 1, currentOrange.pass + 1));

                }

                if (CheckIfIndexValid(currentOrange.x, currentOrange.y - 1, rows, col) && grid[currentOrange.x][currentOrange.y - 1] == 1)
                {
                    grid[currentOrange.x][currentOrange.y - 1] = 2;
                    Oranges.Enqueue(new Coordinates(currentOrange.x, currentOrange.y - 1, currentOrange.pass + 1));

                }
            }


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        return -1;
                    }
                }
            }

            return result;
        }
        public static int NumberOfRoundsNeeded(int[][] array)
        {
            Queue<Coordinates> items = new Queue<Coordinates>();
            int rows = array.Length;
            int columns = array[0].Length;
            int numberOfPasses = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (array[i][j] == 1)
                    {
                        items.Enqueue(new Coordinates(i, j, 0));
                    }
                }

            }


            while (items.Count() > 0)
            {
                Coordinates coordinate = items.Dequeue();

                numberOfPasses = Math.Max(numberOfPasses, coordinate.pass);

                if (CheckIfIndexValid(coordinate.x - 1, coordinate.y, rows, columns))
                {
                    if (array[coordinate.x - 1][coordinate.y] != 1)
                    {
                        array[coordinate.x - 1][coordinate.y] = 1;
                        items.Enqueue(new Coordinates(coordinate.x - 1, coordinate.y, ++coordinate.pass));
                    }
                }

                if (CheckIfIndexValid(coordinate.x + 1, coordinate.y, rows, columns))
                {
                    if (array[coordinate.x + 1][coordinate.y] != 1)
                    {
                        array[coordinate.x + 1][coordinate.y] = 1;
                        items.Enqueue(new Coordinates(coordinate.x + 1, coordinate.y, ++coordinate.pass));
                    }
                }

                if (CheckIfIndexValid(coordinate.x, coordinate.y + 1, rows, columns))
                {
                    if (array[coordinate.x][coordinate.y + 1] != 1)
                    {
                        array[coordinate.x][coordinate.y + 1] = 1;
                        items.Enqueue(new Coordinates(coordinate.x, coordinate.y + 1, ++coordinate.pass));
                    }
                }

                if (CheckIfIndexValid(coordinate.x, coordinate.y - 1, rows, columns))
                {
                    if (array[coordinate.x][coordinate.y - 1] != 1)
                    {
                        array[coordinate.x][coordinate.y - 1] = 1;
                        items.Enqueue(new Coordinates(coordinate.x, coordinate.y - 1, ++coordinate.pass));
                    }
                }

            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (array[i][j] == 0)
                    {
                        return -1;
                    }
                }

            }



            return numberOfPasses;
        }

        public static bool CheckIfIndexValid(int i, int j, int rows, int col)
        {
            if ((i == -1 || i >= rows) || (j == -1) || (j >= col))
            {
                return false;
            }
            return true;
        }


    }
}
