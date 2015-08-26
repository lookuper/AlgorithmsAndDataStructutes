using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.DS
{
    /// <summary>
    /// Recursive implementation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AVLTree<T> where T : IComparable<T>
    {
        private Node root;

        public void Add(T data)
        {
            var newItem = new Node(data);

            if (root == null)
                root = newItem;
            else
                root = RecursiveInsert(root, newItem);
        }

        private Node RecursiveInsert(Node current, Node newNode)
        {
            if (current == null)
            {
                current = newNode;
                return current;
            }
            else if (newNode.Data.CompareTo(current.Data) < 0)
            {
                current.Left = RecursiveInsert(current.Left, newNode);
                current = BalanceTree(current);
            }
            else if (newNode.Data.CompareTo(current.Data) > 0)
            {
                current.Right = RecursiveInsert(current.Right, newNode);
                current = BalanceTree(current);
            }

            return current;
        }

        private Node BalanceTree(Node current)
        {
            int balanceFactor = BalanceFactor(current);
            if (balanceFactor > 1)
            {
                if (BalanceFactor(current.Left) > 0)
                    current = RotateLL(current);
                else
                    current = RotateLR(current);
            } else if (balanceFactor < -1)
            {
                if (BalanceFactor(current.Right) > 0)
                    current = RotateRL(current);
                else
                    current = RotateRR(current);
            }

            return current;
        }

        private Node RotateRR(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;

            return pivot;
        }

        private Node RotateRL(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = RotateLL(pivot);

            return RotateRR(parent);
        }

        private Node RotateLR(Node parent)
        {
            Node pivot = parent.Left;
            parent.Left = RotateRR(pivot);

            return RotateLL(parent);
        }

        private Node RotateLL(Node parent)
        {
            Node pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;

            return pivot;
        }

        private int BalanceFactor(Node current)
        {
            int left = GetHeight(current.Left);
            int right = GetHeight(current.Right);
            int balanceFactor = left - right;

            return balanceFactor;
        }

        private int GetHeight(Node current)
        {
            int height = 0;

            if (current != null)
            {
                int left = GetHeight(current.Left);
                int right = GetHeight(current.Right);
                int max = Math.Max(left, right);
                height = max + 1;
            }

            return height;
        }

        class Node
        {
            public T Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(T data)
            {
                Data = data;
            }
        }
    }
}
