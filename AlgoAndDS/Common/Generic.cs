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
    }
}
