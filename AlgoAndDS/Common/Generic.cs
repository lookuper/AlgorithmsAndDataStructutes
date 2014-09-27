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
    }
}
