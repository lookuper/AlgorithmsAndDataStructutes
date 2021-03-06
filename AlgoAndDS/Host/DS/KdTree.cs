﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.DS
{
    public interface IKdTree<TKey, out TValue>
    {
        IEnumerable<TValue> Search(Key<TKey> low, Key<TKey> high);
    }

    public class Key<T>
    {
        private readonly T[] coords;

        public Key(T[] coords)
        {
            this.coords = coords;
        }

        public int Demensions { get { return coords.Length; } }
        public T[] Coords { get { return this.coords; } }
    }

    public class EmptyTree<TKey, TValue> : IKdTree<TKey, TValue>
    {
        public IEnumerable<TValue> Search(Key<TKey> low, Key<TKey> high)
        {
            return Enumerable.Empty<TValue>();
        }
    }

    public class KdTree<TKey, TValue> : IKdTree<TKey, TValue>
    {
        private readonly IComparer<TKey> comparer;
        private readonly int depth;
        private readonly Key<TKey> key;
        private readonly TValue value;
        private readonly IKdTree<TKey, TValue> left;
        private readonly IKdTree<TKey, TValue> right;

        internal KdTree(int depth, IComparer<TKey> comparer, Key<TKey> key, TValue value, IKdTree<TKey, TValue> left, IKdTree<TKey, TValue> right)
        {
            this.depth = depth;
            this.comparer = comparer;
            this.key = key;
            this.value = value;
            this.left = left;
            this.right = right;
        }

        public static IKdTree<TKey, TValue> Build<TKey, TValue>(IComparer<TKey> comparer, IEnumerable<KeyValuePair<Key<TKey>, TValue>> data, int depth = 0)
        {
            if (!data.Any())
                return new EmptyTree<TKey, TValue>();

            int k = data.First().Key.Demensions;
            int axis = depth % k;
            var sortedData = data.OrderBy(x => x.Key.Coords[axis]);
            int medianIndex = sortedData.Count() / 2;
            var median = sortedData.ElementAt(medianIndex);

            var leftTree = Build(comparer, data.Take(medianIndex), depth + 1);
            var rightTree = Build(comparer, data.Skip(medianIndex + 1), depth + 1);

            return new KdTree<TKey, TValue>(depth, comparer, median.Key, median.Value, leftTree, rightTree);            
        }

        public IEnumerable<TValue> Search(Key<TKey> low, Key<TKey> high)
        {
            int k = key.Demensions;
            int axis = depth % k;

            if (comparer.Compare(low.Coords[axis], key.Coords[axis]) <= 0)
            {
                foreach (var point in left.Search(low,high))
                {
                    yield return point;
                }

                var keyWithinRange = key.Coords
                    .Select((coord, i) => new { coord, i })
                    .All(x => comparer.Compare(low.Coords[x.i], x.coord) <= 0 &&
                              comparer.Compare(high.Coords[x.i], x.coord) >= 0);

                if (keyWithinRange)
                    yield return value;

                if (comparer.Compare(high.Coords[axis], key.Coords[axis]) > 0)
                {
                    foreach (var point in right.Search(low, high))
                    {
                        yield return point;
                    }
                }
            }

        }
    }
}
