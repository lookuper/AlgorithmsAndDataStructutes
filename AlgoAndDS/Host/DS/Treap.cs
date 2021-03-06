﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.DS
{
    public class Treap<T> : ICollection<T>
    {
        interface IComparer<U,T>
        {
            int Compare(U x, T y);
        }

        class TreapNode<T>
        {
            public T Value { get; set; }
            public int Priority { get; set; }
            public TreapNode<T> Left;
            public TreapNode<T> Right;

            public TreapNode(T v, int p)
            {
                Value = v;
                Priority = p;
            }
        }

        class LikeComparer<T> : IComparer<T, T>
        {
            IComparer<T> comparer;

            public LikeComparer(IComparer<T> comparer)
            {
                this.comparer = comparer;
            }

            public int Compare(T x, T y)
            {
                return comparer.Compare(x, y);
            }
        }

        private IComparer<T> comparer;
        private TreapNode<T> root;
        private Random random;
        LikeComparer<T> likeComparer;

        public int Count { get; private set; }
        public bool IsReadOnly { get { return false; } }

        public Treap() : this(Comparer<T>.Default)
        {

        }

        public Treap(IComparer<T> comparer)
        {
            this.comparer = comparer;
            this.random = new Random(int.MaxValue);
            this.likeComparer = new LikeComparer<T>(comparer);
        }

        public void Add(T item)
        {
            Add(ref root, item);
        }

        private void Add(ref TreapNode<T> node, T item)
        {
            if (node == null)
            {
                node = new TreapNode<T>(item, random.Next());
                Count++;
                return;
            }

            var c = comparer.Compare(item, node.Value);
            if (c < 0)
            {
                Add(ref node.Left, item);
                if (node.Left.Priority > node.Priority)
                {
                    var x = node.Left;
                    node.Left = x.Right;
                    node = x;
                }
            }
            else if (c > 0)
            {
                Add(ref node.Right, item);
                if (node.Priority < node.Right.Priority)
                {
                    var x = node.Right;
                    node.Right = x.Left;
                    x.Left = node;
                    node = x;
                }
            }
            else
                node.Value = item;
        }

        public void Clear()
        {
            this.root = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return Contains(root, item);
        }

        private bool Contains(TreapNode<T> node, T item)
        {
            if (node == null)
                return false;

            var c = comparer.Compare(item, node.Value);
            if (c < 0)
                return Contains(node.Left, item);
            if (c > 0)
                return Contains(node.Right, item);

            return true;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var item in this)
            {
                array[arrayIndex++] = item;
            }
        }

        public bool Remove(T item)
        {
            return Remove(ref root, item);
        }

        static void Reorder(ref TreapNode<T> node, TreapNode<T> left, TreapNode<T> right)
        {
            if (left == null)
            {
                node = right;
                return;
            }
            if (right == null)
            {
                node = left;
                return;
            }

            if (left.Priority > right.Priority)
            {
                node = left;
                Reorder(ref node.Right, node.Right, right);
            }
            else
            {
                node = right;
                Reorder(ref node.Left, left, node.Left);
            }

        }

        private bool Remove(ref TreapNode<T> node, T item)
        {
            if (node == null)
                return false;

            var c = comparer.Compare(item, node.Value);
            if (c < 0)
                return Remove(ref node.Left, item);
            if (c > 0)
                return Remove(ref node.Right, item);

            if (node.Left != null)
                if (node.Right != null)
                    Reorder(ref node, node.Left, node.Right);
                else
                    node = node.Left;
            else
                node = node.Right;

            Count--;
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Next(root).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<T> Next(TreapNode<T> node)
        {
            if (node == null)
                yield break;

            foreach (var t in Next(node.Left))
            {
                yield return t;
            }
            yield return node.Value;

            foreach (var t in Next(node.Right))
            {
                yield return t;
            }
        }
    }
}
