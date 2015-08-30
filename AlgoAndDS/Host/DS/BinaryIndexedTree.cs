using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.DS
{
    public class BinaryIndexedTree
    {
        private int[] elements;
        private int size;

        public BinaryIndexedTree(IList<int> source)
        {
            size = source.Count;
            elements = new int[size];

            for (int i = 0; i < source.Count; i++)
            {
                Inc(i, source[i]);
            }
        }

        public int Sum(int l, int r)
        {
            return Sum(r) - Sum(l - 1);
        }

        private int Sum(int r)
        {
            int result = 0;
            for (; r >= 0 ;  r = (r & (r+1))-1)
            {
                result += elements[r];               
            }

            return result;
        }

        private void Inc(int i, int delta)
        {
            for (; i < size; i = (i | (i+1)))
            {
                elements[i] += delta;
            }
        }    
    }
}
