using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
   public class BinaryHeapMax
    {
       public static List<int> MaxHeap = new List<int>() {41,39,33,18,27,12};

        public static void Insert(int value)
        {
            MaxHeap.Add(value);
            BubbleUp();
        }

        public static void BubbleUp()
        {
           
            int elementIndex = MaxHeap.Count - 1;

            while (elementIndex > 0)
            {
                int parentIndex = (elementIndex - 1) / 2;
                int elementVlaue = MaxHeap[elementIndex];
                int parentVlaue = MaxHeap[parentIndex];

                if (MaxHeap[elementIndex] > MaxHeap[parentIndex])
                {
                    MaxHeap[parentIndex] = elementVlaue;
                    MaxHeap[elementIndex] = parentVlaue;

                    elementIndex = parentIndex;

                }
                else
                {
                    break;
                }
            }
        }
    }
}
