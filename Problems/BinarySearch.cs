using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
   public class BinarySearch
    {
       // [1,2,3,4,5]  2
        public static bool SearchElement(int[]arr, int element)
        {
            int min = 0;
            int max = arr.Length - 1;
            int middle = (min + max) / 2;

            while (min <= max)
            {
                middle = (min + max) / 2;
                if (arr[middle] == element)
                {
                    return true;
                }
                else if (arr[middle] > element)
                {
                    max = middle - 1;
                }
                else
                {
                    min = middle + 1;
                }
            }

            return false;
        }
        public static int BinarySearchBasic(List<int> items, int searchItem)
        {
            int start = 0;
            int end = items.Count - 1;
            int mid = 0;

            if (items.Count == 0)
            {
                return -1;
            }

            while (start <= end)
            {
                mid = start + (end - start) / 2;

                if (items[mid] == searchItem)
                {
                    return mid;
                }
                else if (items[mid] > searchItem)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return -1;
        }
        public static int BinarySearchFirstOccurence(List<int> items, int searchItem)
        {
            int start = 0;
            int end = items.Count - 1;
            int mid = 0;
            int firstOccurenceIndex = int.MaxValue; ;

            if (items.Count == 0)
            {
                return -1;
            }

            while (start <= end)
            {
                mid = start + (end - start) / 2;

                if (items[mid] == searchItem)
                {
                    if (mid < firstOccurenceIndex)
                    {
                        firstOccurenceIndex = mid;
                    }

                    end = mid - 1;
                }
                else if (items[mid] > searchItem)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            if (firstOccurenceIndex != int.MaxValue)
            {
                return firstOccurenceIndex;

            }

            return -1;

        }
        public static int BinarySearchLastOccurence(List<int> items, int searchItem)
        {
            int start = 0;
            int end = items.Count - 1;
            int mid = 0;
            int lastOccurenceIndex = int.MinValue; ;

            if (items.Count == 0)
            {
                return -1;
            }

            while (start <= end)
            {
                mid = start + (end - start) / 2;

                if (items[mid] == searchItem)
                {
                    if (mid > lastOccurenceIndex)
                    {
                        lastOccurenceIndex = mid;
                    }

                    start = mid + 1;
                }
                else if (items[mid] > searchItem)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            if (lastOccurenceIndex != int.MaxValue)
            {
                return lastOccurenceIndex;

            }

            return -1;

        }
        public static int BinarySeachNumberOfRotations(List<int> items)
        {
            if (items.Count == 0)
            {
                return -1;
            }

            int start = 0;
            int end = items.Count - 1;

            int mid = start + (end - start) / 2;

            while (start <= end)
            {
                mid = start + (end - start) / 2;

                if (items[mid] < items[(mid - 1 + items.Count) % items.Count] && items[mid] < items[(mid + 1) % items.Count])
                {

                    if (mid == 0)
                    {
                        return -1;
                    }

                    return items.Count - mid;
                }
                else if (items[end] < items[mid])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return -1;
        }
        public static int BinarySeachFindElementInRotatedArray(List<int> items, int start, int end, int item)
        {
            if (items.Count == 0)
            {
                return -1;
            }

            int mid = start + (end - start) / 2;

            while (start <= end)
            {
                mid = start + (end - start) / 2;

                if (item == items[mid])
                {
                    return mid;
                }

                if (items[mid] < items[(mid - 1 + items.Count) % items.Count] && items[mid] < items[(mid + 1) % items.Count])
                {

                    //if (mid == 0)
                    //{
                    //    return -1;
                    //}

                    int left = BinarySeachFindElementInRotatedArray(items, 0, mid - 1, item);
                    int right = BinarySeachFindElementInRotatedArray(items, mid + 1, items.Count - 1, item);
                    if (left == -1 && right == -1)
                    {
                        return -1;
                    }
                    else
                    {
                        if (left == -1)
                        {
                            return right;
                        }

                        return left;

                    }
                }
                else if (items[end] < items[mid])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return -1;
        }
        public static int BinarySearchNeralySortedArray(List<int> items, int searchItem)
        {
            int start = 0;
            int end = items.Count - 1;
            int mid = 0;
            int count = items.Count;

            if (items.Count == 0)
            {
                return -1;
            }

            while (start <= end)
            {
                mid = start + (end - start) / 2;

                if (items[mid] == searchItem)
                {
                    return mid;
                }
                else if (items[(mid - 1 + count) % count] == searchItem)
                {
                    return mid - 1;
                }
                else if (items[(mid + 1) % count] == searchItem)
                {
                    return mid + 1;
                }
                else if (items[mid] > searchItem)
                {
                    end = mid - 2;
                }
                else
                {
                    start = mid + 2;
                }
            }

            return -1;
        }
    }
}
