namespace TestProject.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Pair
    {
       public int x, y, pass;

        public Pair(int x,int y, int pass)
        {
            this.x = x;
            this.y = y;
            this.pass = pass;
        }
    }

    class OrangesRotting
    {
        public int OrangesRottingMethod(int[][] grid)
        {
            Queue<Pair> queue = new Queue<Pair>();

            int rows = grid.GetUpperBound(0) + 1;
            int cols = grid[0].Length;
            int result = 0;

            int[] x = new int[] {0,1,0,-1 };
            int[] y = new int[] {1,0,-1,0};

            for (int i=0;i<rows;i++)
            {
                for(int j=0;j<cols;j++)
                {
                    if(grid[i][j]==2)
                    {
                        queue.Enqueue(new Pair(i, j, 0));
                    }
                }
            }

            while(queue.Count()>0)
            {
                Pair curr = queue.Dequeue();

                result = Math.Max(result, curr.pass);

                for(int i=0;i<x.Length;i++)
                {
                    int xcor = curr.x + x[i];
                    int ycor = curr.y + y[i];

                    if((xcor>=0 && xcor<rows) && (ycor>=0 && ycor<cols) && grid[xcor][ycor]==1)
                    {
                        grid[xcor][ycor] = 2;

                        queue.Enqueue(new Pair(xcor, ycor, curr.pass + 1));
                    }
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

            return result;

        }
    }
}
