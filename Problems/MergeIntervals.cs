using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    public static class MergeIntervals
    {
        //[[1,3],[2,6],[8,10],[15,18]]
        public static int[][] Merge(int[][] intervals)
        {
            List<int[]> mergedIntervals = new List<int[]>();

            if(intervals.Length <2)
            {
                return intervals;
            }

            Array.Sort(intervals, (a, b) =>
            {
                return a[0] - b[0];
            });

            mergedIntervals.Add(intervals[0]);          

            for(int i=1;i<=intervals.Length-1;i++)
            {
                if(mergedIntervals[mergedIntervals.Count()-1][1]>= intervals[i][0])
                {
                    mergedIntervals[mergedIntervals.Count() - 1][1] = Math.Max(mergedIntervals[mergedIntervals.Count() - 1][1], intervals[i][1]);

                }
                else
                {
                    mergedIntervals.Add(intervals[i]);
                }
            }


            return mergedIntervals.ToArray();
        }
    }
}
