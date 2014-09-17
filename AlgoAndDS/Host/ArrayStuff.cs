using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Host
{
    public class ArrayStuff
    {
        internal static int FirstDuplicate(int[] array)
        {
            if (array == null || array.Length == 0)
                throw new ArgumentException();

            for (int i = 0; i < array.Length; i++)
            {
                while (i != array[i])
                {
                    if (array[i] == array[array[i]])
                        return array[i]; // duplicate
                    else
                        Generic.Swap(ref array[i], ref array[array[i]]);
                }
            }

            throw new ArgumentException("no duplicates in array");
        }

        internal static int MinimumInSortedAndRotatedArray(int[] array, int low, int high)
        {
            if (array == null || array.Length == 0)
                throw new ArgumentException();

            if (high < low) // only one element left
                return array[0];

            if (high == low) // one element left
                return array[low];

            int mid = low + (high - low) / 2;

            // check if mid+1 is minimum element
            if (mid < high && array[mid + 1] < array[mid])
                return array[mid + 1];

            // check if mid is min element
            if (mid > low && array[mid] < array[mid - 1])
                return array[mid];

            if (array[high] > array[mid])
                return MinimumInSortedAndRotatedArray(array, low, mid - 1);

            return MinimumInSortedAndRotatedArray(array, mid + 1, high);
        }

        internal static int MissingNumber(int[] array)
        {
            if (array == null || array.Length == 0)
                throw new ArgumentException();

            int total = (array.Length + 1) * (array.Length + 2) / 2;

            for (int i = 0; i < array.Length; i++)
            {
                total -= array[i];
            }

            return total;
        }

        internal static void DeutscheFlagSort(int[] array)
        {
            int lo = 0;
            int high = array.Length - 1;
            int mid = 0;

            while (mid <= high)
            {
                switch (array[mid])
                {
                    case 0:
                        Generic.Swap(ref array[lo++], ref array[mid++]);
                        break;
                    case 1:
                        mid++;
                        break;
                    case 2:
                        Generic.Swap(ref array[mid], ref array[high--]);
                        break;
                    default:
                        throw new ArgumentException();
                }
            }
        }

        internal static int OccurensInSortedArray(int[] array, int x)
        {
            int start = 0;
            int end = 0;
            start = First(array, 0, array.Length-1, x);
            
            if (start == -1)
                throw new ArgumentException("No such value in array");

            end = Last(array, 0, array.Length-1, x);

            return end - start + 1;
        }

        private static int First(int[] array, int low, int high, int x)
        {
            if (high >= low)
            {
                int mid = (low + high) / 2;
                if (mid == 0 || x > array[mid - 1] && array[mid] == x)
                    return mid;
                else
                {
                    if (x > array[mid])
                        return First(array, mid + 1, high, x);
                    else
                        return First(array, low, mid - 1, x);
                }
            }

            return -1;
        }

        private static int Last(int[] array, int low, int high, int x)
        {
            if (high > low)
            {
                int mid = (low + high) / 2;
                if (mid == array.Length - 1 || x < array[mid + 1] && array[mid] == x)
                    return mid;
                else
                {
                    if (x < array[mid])
                        return Last(array, low, mid - 1, x);
                    else
                        return Last(array, mid + 1, high, x);
                }
            }

            return low;
        }

        internal static void PrintMaxSubArraysSizeK(int[] input, int k)
        {
            int j, max;
            for (int i = 0; i < input.Length-k; i++)
            {
                max = input[i];
                for (j = 0; j < k; j++)
                {
                    if (input[i + j] > max)
                        max = input[i + j];
                }
                Console.WriteLine(max);
            }
        }

        /// <summary>
        /// Double check, may be incorrect
        /// </summary>
        internal static int LongestContiniusSum(int[] input)
        {
            int maxSoFar = 0;
            int maxUpToHere = 0;
            int largestElement = input[0];
            bool allNegative = true;

            foreach (var elem in input)
            {
                maxUpToHere = Math.Max(0, maxUpToHere);
                maxSoFar = Math.Max(maxUpToHere, maxSoFar);
                largestElement = Math.Max(largestElement, elem);
                if (elem > 0)
                    allNegative = false;
            }

            if (allNegative)
                return largestElement;

            return maxSoFar;
        }
    }
}
