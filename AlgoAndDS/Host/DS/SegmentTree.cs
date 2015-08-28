using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.DS
{
    public class SegmentTree<T> where T : IComparable<T>
    {
        private int[] tree;
        private int maxSize;
        private int height;

        private readonly int startIndex;
        private readonly int endIndex;
        private readonly int root;

        public SegmentTree(int size)
        {
            height = (int)Math.Ceiling(Math.Log(size) / Math.Log(2));
            maxSize = 2 * (int)Math.Pow(2, height) - 1;
            tree = new int[maxSize];
            endIndex = size - 1;
        }

        public int GetSum(int start, int end)
        {
            if (start < 0 || end > tree.Length)
                throw new ArgumentOutOfRangeException();

            return GetSumUtil(startIndex, endIndex, start, end, root);
        }

        private int GetSumUtil(int startIndex, int endIndex, int start, int end, int current)
        {
            if (start <= startIndex && end >= endIndex)
                return tree[current];

            if (endIndex < start || startIndex > end)
                return 0;

            int mid = Mid(start, end);
            return GetSumUtil(startIndex, mid, start, end, LeftChild(current))
                + GetSumUtil(mid + 1, endIndex, start, end, RightChild(current));
        }

        private int LeftChild(int pos)
        {
            return 2 * pos + 1;
        }

        private int RightChild(int pos)
        {
            return 2 * pos + 2;
        }

        private int Mid(int start, int end)
        {
            return (start + (end - start) / 2);
        }
    }
}
