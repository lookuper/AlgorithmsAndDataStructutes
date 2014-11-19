using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Generic
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point()
            {

            }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public class PetrolTank
        {
            public int Petrol { get; set; }
            public int Distance { get; set; }

            public PetrolTank(int petrol, int distance)
            {
                Petrol = petrol;
                Distance = distance;
            }
        }

        public static int CalculateAngle(int hour, int minute)
        {
            if (hour < 0 || minute < 0 || hour > 12 || minute > 60)
                throw new ArgumentException();

            if (hour == 12)
                hour = 0;
            if (minute == 60)
                minute = 0;

            double hourAngle = 0.5 * (hour * 60 + minute);
            double minuteAngle = 6 * minute;
            double angle = Math.Abs(hourAngle - minuteAngle);
            angle = Math.Min(360 - angle, angle);

            return (int)angle;
        }

        public static bool IsRectanglesOverlap(Point l1, Point r1, Point l2, Point r2)
        {
            // if one rectangle is on left side of other
            if (l1.X > r2.X || l2.X > r1.X)
                return false;

            // if one above other
            if (l1.Y < r2.Y || l2.Y < r1.Y)
                return false;

            return true;
        }

        public class IntStackWithMinOption
        {
            private readonly Stack<int> data = new Stack<int>();
            private int? min = null;

            public void Push(int val)
            {
                if (data.Count == 0)
                {
                    data.Push(val);
                    min = val;
                }
                else
                {
                    if (val >= min)
                        data.Push(val);
                    else
                    {
                        data.Push(2 * val - min.Value);
                        min = val;
                    }
                }
            }

            public int Pop()
            {
                if (data.Count <= 0)
                    throw new InvalidOperationException("0 items in stack");

                if (data.Peek() < min)
                    min = 2 * min - data.Peek();

                return data.Pop();
            }

            public int Min()
            {
                int top = data.Peek();

                if (top < min)
                    top = min.Value;

                return top;
            }
        }

        public static string GenerateAllPossibleBrackets(string str, int limit)
        {
            if (str.Length == 2 * limit)
                return str;

            int open = 0;
            int close = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '{')
                    open++;
                else
                    if (str[i] == '}')
                        close++;
            }

            if (open == close)
            {
                str += "{";
                return GenerateAllPossibleBrackets(str, limit);
            }
            else
            {
                if (open == limit)
                {
                    str += "}";
                    return GenerateAllPossibleBrackets(str, limit);
                }
                else
                {
                    var str1 = str + "{";
                    var str2 = str + "}";
                    return GenerateAllPossibleBrackets(str1, limit) + Environment.NewLine + GenerateAllPossibleBrackets(str2, limit);
                }
            }
        }

        public static int NumberBetween1AndN(int n)
        {
            int number = 0;

            for (int i = 0; i <= n; i++)
            {
                number += NumberOf1(i);
            }

            return number;
        }

        private static int NumberOf1(int n)
        {
            int number = 0;
            while (n > 0)
            {
                if (n % 10 == 1)
                    number++;
                n = n / 10;
            }

            return number;
        }

        public static void PrintProbability(int number)
        {
            if (number < 1)
                return;

            int maxValue = 6;
            var probabilities = new List<int[]>();
            probabilities.Add(new int[maxValue * number + 1]);
            probabilities.Add(new int[maxValue * number + 1]);
            int flag = 0;

            for (int i = 1; i <= maxValue; i++)
            {
                probabilities[flag][i] = 1;
            }

            for (int k = 2; k <= number; k++)
            {
                for (int i = 0; i < k; i++)
                {
                    probabilities[1 - flag][i] = 0;
                }
                for (int i = k; i <= maxValue*k; i++)
                {
                    probabilities[1 - flag][i] = 0;
                    for (int j = 1; j <= i && j<=maxValue; j++)
                    {
                        probabilities[1 - flag][i] += probabilities[flag][i - j];
                    }
                }

                flag = 1 - flag;
            }

            double total = Math.Pow(maxValue, number);
            for (int i = number; i <= maxValue*number; i++)
            {
                double ratio = probabilities[flag][i] / total;
                Console.WriteLine("{0} {1}", i, ratio);
            }
        }

        public static int LastRemaning(int n, int m)
        {
            if (n < 1 || m < 1)
                return -1;

            int last = 0;
            for (int i = 2; i <= n; i++)
            {
                last = (last + m) % 1;
            }

            return last;
        }
    }
}
