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

        internal static int MaxRepeatingElement(int[] input, int k)
        {
            for (int i = 0; i < input.Length; i++)
            {
                input[input[i] % k] += k;
            }

            int max = input[0];
            int result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > max)
                {
                    max = input[i];
                    result = i;
                }
            }

            return result;
        }

        internal static int NPetrolProblem(Generic.PetrolTank[] petrolPump)
        {
            int start = 0;
            int end = 1;
            int petrol = petrolPump[start].Petrol - petrolPump[start].Distance;

            while (end != start || petrol < 0)
            {
                while (petrol < 0 && start != end)
                {
                    petrol = petrol - petrolPump[start].Petrol - petrolPump[start].Distance;
                    start = (start + 1) % petrolPump.Length;

                    if (start == 0)
                        return -1;
                }

                petrol = petrol + petrolPump[end].Petrol - petrolPump[end].Distance;
                end = (end + 1) % petrolPump.Length;
            }

            return start;
        }

        internal static void PringAnagramsTogether(List<string> words)
        {
            var duplicateWords = new KeyValuePair<int, string>[words.Count];
            for (int i = 0; i < words.Count; i++)
            {
                var arr = words[i].ToArray();
                Array.Sort(arr);
                var kv = new KeyValuePair<int, string>(i, new String(arr));

                duplicateWords[i] = kv;
            }

            Array.Sort(duplicateWords, (x, y) => x.Value.CompareTo(y.Value));

            for (int i = 0; i < words.Count; i++)
            {
                Console.WriteLine(words[duplicateWords[i].Key]);
            }
        }

        internal static int[] MergeArrays(int[] ar1, int[] ar2)
        {
            if (ar1 == null || ar2 == null)
                throw new ArgumentNullException();

            int index1 = 0;
            int index2 = 0;
            int mergedIndex = 0;
            int[] mergedArray = new int[ar1.Length +ar2.Length];

            while (index1 < ar1.Length && index2 < ar2.Length)
            {
                if (ar1[index1] <= ar2[index2])
                    mergedArray[mergedIndex++] = ar1[index1++];
                else
                    mergedArray[mergedIndex++] = ar2[index2++];
            }

            while (index2 < ar2.Length)
            {
                mergedArray[mergedIndex++] = ar2[index2++];
            }

            return mergedArray;
        }

        internal static int TurningNumber(int[] numbers)
        {
            if (numbers == null || numbers.Length <= 2)
                throw new ArgumentException("numbers");

            int left = 0;
            int right = numbers.Length - 1;

            while (right > left + 1)
            {
                int middle = (left + right) / 2;
                if (middle == 0 || middle == numbers.Length - 1)
                    return -1;
                if (numbers[middle] > numbers[middle - 1] && numbers[middle] > numbers[middle + 1])
                    return middle;
                else
                {
                    if (numbers[middle] > numbers[middle - 1] && numbers[middle] < numbers[middle + 1])
                        left = middle;
                    else
                        right = middle;
                }
            }

            return -1;
        }

        internal static int GetMarority(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                throw new ArgumentException();

            int result = numbers[0];
            int times = 1;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (times == 0)
                {
                    result = numbers[i];
                    times = 1;
                }
                else
                {
                    if (numbers[i] == result)
                        times++;
                    else
                        times--;
                }
            }

            // check majority existance
            return result;
        }

        internal static void QuickSort(int[] input, int start, int end)
        {
            if (start == end)
                return;

            int pivotIndex = Patrition(input, 0, input.Length-1);
            QuickSort(input, start, pivotIndex);
            QuickSort(input, pivotIndex+1, end);
        }

        private static int Patrition(int[] input, int start, int end)
        {
            var random = new Random();
            int pivot = random.Next((start + end) / 2);
            Generic.Swap(ref input[pivot], ref input[end]);
            int small = start - 1;

            for (int i = start; i <= end; i++)
            {
                if (input[i] < input[end])
                {
                    small++;
                    if (i != small)
                        Generic.Swap(ref input[small], ref input[i]);
                }
            }
            small++;
            if (small != end)
                Generic.Swap(ref input[small], ref input[end]);

            return small;
        }

        internal static int MinCharge(int total, int[] coins)
        {
            if (total <= 0 || coins == null || coins.Length == 0)
                throw new ArgumentException();

            int[] counts = new int[total + 1];
            counts[0] = 0;
            int max = Int32.MaxValue;

            for (int i = 0; i <= total; i++)
            {
                int count = max;
                for (int j = 0; j < coins.Length; j++)
                {
                    if (i - coins[j] >= 0 && count > counts[i - coins[j]])
                        count = counts[i - coins[j]];
                }

                if (count < max)
                    counts[i] = count + 1;
                else
                    counts[i] = max;
            }

            return counts[total];
        }

        internal static void ReorderOddEven(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                throw new ArgumentException();

            int begin = 0;
            int end = nums.Length - 1;

            while (begin < end)
            {
                while (begin < end && nums[begin] % 2 != 0)
                    begin++;

                while (begin < end && nums[end] % 2 == 0)
                    end--;

                Generic.Swap(ref nums[begin], ref nums[end]);
            }
        }

        internal static int[] RemoveValue(int[] num, int n)
        {
            if (num == null || num.Length == 0)
                throw new ArgumentException();

            int p1 = 0;
            while (p1 < num.Length && num[p1] != n)
                p1++;
            int p2 = num.Length - 1;

            while (p1 < p2)
            {
                while (p1 < num.Length && num[p1] != n)
                    ++p1;
                while (p2 > 0 && num[p2] == n)
                    p2--;

                if (p1 < p2)
                    Generic.Swap(ref num[p1], ref num[p2]);
            }

            return num.Take(p1).ToArray();
        }

        internal static void PrintMatrixInSpiralOrder(int[,] numbers)
        {
            int rows = (int)numbers.GetLength(0);
            int columns = (int)numbers.GetLongLength(0);

            int start = 0;
            while (columns > start*2 && rows > start * 2)
            {
                PrintRing(numbers, start);
                start++;
            }
        }

        private static void PrintRing(int[,] num, int start)
        {
                //{1,2,3},
                //{4,5,6},
                //{7,8,9},
            int rows = num.GetLength(0);
            int columns = (int)num.GetLongLength(0);
            int endX = columns - 1 - start;
            int endY = rows - 1 - start;

            // from left to right
            for (int i = start; i <= endX; i++)
                Console.WriteLine(num[start,i]);

            // top down
            if (start < endY)
                for (int i = start + 1; i <= endY; i++)
                {
                    Console.WriteLine(num[i, endX]);
                }

            //// from right to left
            if (start < endX && start < endY)
                for (int i = endX - 1; i >= start; i--)
                    Console.WriteLine(num[endY, i]);

            //// bottom up
            if (start < endX && start < endY - 1)
                for (int i = endY - 1; i >= start + 1; i--)
                    Console.WriteLine(num[i, start]);
        }

        internal static void AllPermutations(List<int[]> input)
        {
            var permutations = new Stack<int>();
            PermuteCore(input, permutations);
        }

        private static void PermuteCore(List<int[]> arrays, Stack<int> permutations)
        { 
            if (permutations.Count == arrays.Count)
            {
                foreach (var item in permutations)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
                return;
            }

            int[] array = arrays[permutations.Count];
            for (int i = 0; i < array.Length; i++)
            {
                permutations.Push(array[i]);
                PermuteCore(arrays, permutations);
                permutations.Pop();
            }
        }

        internal static void Intersection(int[] ar1, int[] ar2, out List<int> res)
        {
            int index1 = 0;
            int index2 = 0;
            res = new List<int>();

            while (index1 != ar1.Length-1 && index2 != ar1.Length-1)
            {
                if (ar1[index1] == ar2[index2])
                {
                    res.Add(ar1[index1]);
                    index1++;
                    index2++;
                }
                else
                {
                    if (ar1[index1] < ar2[index2])
                        index1++;
                    else
                        index2++;
                }
            }
        }

        internal static int GetGretestSumOfSubArray(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                throw new ArgumentException();

            int curSum = 0;
            int greatestSum = int.MinValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (curSum <= 0)
                    curSum = numbers[i];
                else
                    curSum += numbers[i];

                if (curSum > greatestSum)
                    greatestSum = curSum;
            }

            return greatestSum;
        }
    }
}
