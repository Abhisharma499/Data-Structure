using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
   public static class BackTrackingProblems
    {
        static bool[,] VisitedArray = new bool[4, 4];
        public static int NumberOfPaths = 0;
        public static void RatInAMaze(int [,] array, int sx,int sy, int dx,int dy)
        {
            if(sx>array.GetUpperBound(0) || sx<0 || sy> array.GetUpperBound(1) || sy<0)
            {
                return;
            }

            if (array[sx, sy] == 0 || VisitedArray[sx, sy] == true)
            {
                return;
            }

            if (sx==dx && sy==dy)
            {
                NumberOfPaths++;
            }

            VisitedArray[sx, sy] = true;

            RatInAMaze(array, sx + 1, sy, dx, dy);


            RatInAMaze(array, sx - 1, sy, dx, dy);


            RatInAMaze(array, sx, sy + 1, dx, dy);


            RatInAMaze(array, sx, sy - 1, dx, dy);

            VisitedArray[sx, sy] = false;

        }

    }
}
