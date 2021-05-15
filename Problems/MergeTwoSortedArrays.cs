using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    public static class MergeTwoSortedArrays
    {

        static int count = 0;

        public  static int  BubbleSort()
        {
            int[] arr = { 5,4,3,2,1,0,-1,9,-5};
            int temp;
            for (int j = 0; j <= arr.Length - 2; j++)
            {
                for (int i = 0; i <= arr.Length - 2; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                        count++;
                    }
                }
            }

            return count;
        }

        public static int Test()
        {
            count = 0;
            MergeSort(new int[] { 5, 4,1,2});

            return count-1;
        }

        
        public static int[] MergeSort(int[] arr1)
        {
            if(arr1.Length<=1)
            {
                return arr1;
            }
            else
            {
                int mid = arr1.Length / 2;
                int[] left = arr1.Take(mid).ToArray();
                int[] right = arr1.Skip(mid).Take(arr1.Length - mid).ToArray();
                left= MergeSort(left);
                right = MergeSort(right);
                return Merge(left, right);
            }
        }
        public static int[] Merge(int[] arr1, int[] arr2)
        {
            int arr1Length = arr1.Length;
            int arr2Length = arr2.Length;
            int[] result = new int[arr1Length + arr2Length];
            int i = 0, j = 0;
            int index = 0;

            while(i<arr1Length && j< arr2Length)
            {
                if(arr1[i]<=arr2[j])
                {
                    result[index] = arr1[i];
                    i++;
                }
                else
                {
                    count++;
                    result[index] = arr2[j];
                    j++;
                }

                index++;
            }

            if(i<arr1Length)
            {
                while(i<arr1Length)
                {
                    result[index] = arr1[i];
                    index++;
                    i++;
                    count++;
                }
            }

            if (j < arr2Length)
            {
                while (j < arr2Length)
                {
                    result[index] = arr2[j];
                    index++;
                    j++;
                }
            }

            return result;
        }
    }
}
