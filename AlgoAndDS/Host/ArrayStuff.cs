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
    }
}
