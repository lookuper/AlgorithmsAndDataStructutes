using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.DS
{
    public class SegmentTree
    {
        private int[] tree;
        private int maxSize;
        private int height;

        private int startIndex;
        private int endIndex;
        private int root;

        public SegmentTree(int size)
        {
            height = (int)(Math.Ceiling(Math.Log(size) / Math.Log(2)));
            maxSize = 2 * (int)Math.Pow(2, height) - 1;
            tree = new int[maxSize];
            endIndex = size - 1;
        }

        public void ConstructSegmentTree(int[] source)
        {
            ConstructSegmentTreeUtil(source, startIndex, endIndex, root);
        }

        private int ConstructSegmentTreeUtil(int[] source, int startIndex, int endIndex, int current)
        {
            if (startIndex == endIndex)
            {
                tree[current] = source[startIndex];
                return tree[current];
            }

            int mid = Mid(startIndex, endIndex);
            tree[current] = ConstructSegmentTreeUtil(source, startIndex, mid, LeftChild(current))
                + ConstructSegmentTreeUtil(source, mid + 1, endIndex, RightChild(current));

            return tree[current];
        }

        public int GetSum(int queryStart, int queryEnd)
        {
            if (queryStart < 0 || queryEnd > tree.Length)
            {
                return -1;
            }
            return GetSumUtil(startIndex, endIndex, queryStart, queryEnd, root);
        }

        private int GetSumUtil(int startIndex, int endIndex, int queryStart, int queryEnd, int current)
        {
            if (queryStart <= startIndex && queryEnd >= endIndex)
            {
                return tree[current];
            }
            if (endIndex < queryStart || startIndex > queryEnd)
            {
                return 0;
            }
            int mid = Mid(startIndex, endIndex);
            return GetSumUtil(startIndex, mid, queryStart, queryEnd, LeftChild(current))
                     + GetSumUtil(mid + 1, endIndex, queryStart, queryEnd, RightChild(current));
        }

        public void Update(int update, int updatePosition, int[] elements)
        {
            int updateDiff = update - elements[updatePosition];
            elements[updatePosition] = update;
            UpdateTreeUtil(startIndex, endIndex, updatePosition, updateDiff, root);
        }

        private void UpdateTreeUtil(int startIndex, int endIndex, int updatePosition, int update, int current)
        {
            if (updatePosition < startIndex || updatePosition > endIndex)
                return;

            tree[current] = tree[current] + update;
            if (startIndex != endIndex)
            {
                int mid = Mid(startIndex, endIndex);
                UpdateTreeUtil(startIndex, mid, updatePosition, update, LeftChild(current));
                UpdateTreeUtil(mid + 1, endIndex, updatePosition, update, RightChild(current));
            }

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
