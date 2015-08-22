using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.DS
{
    public class RedBlackTree<T> where T : IComparable<T>
    {
        public Node Root { get; set; }
        public int NumberElements { get; private set; }

        private Node insertedNode;
        private Node nodeBeingDeleted;
        private bool siblingToRight;
        private bool parentToRight;
        private bool nodeToDeleteRed;

        public void Add(T item)
        {
            Root = InsertNode(Root, item, null);
            NumberElements++;

            if (NumberElements > 2)
            {
                Node parent, grandParent, greatGrandParent;
                GetNodesAbove(insertedNode, out parent, out grandParent, out greatGrandParent);
                FixTreeAfterInsertion(insertedNode, parent, grandParent, greatGrandParent);
            }
        }

        private Node InsertNode(Node node, T item, Node parent)
        {
            if (node == null)
            {
                var newNode = new Node(item, parent);

                if (NumberElements > 0)
                    newNode.Red = true;
                else
                    newNode.Red = false;

                insertedNode = newNode;
                return newNode;
            }

            if (item.CompareTo(node.Item) < 0)
            {
                node.Left = InsertNode(node.Left, item, node);
                return node;
            }

            if (item.CompareTo(node.Item) > 0)
            {
                node.Right = InsertNode(node.Right, item, node);
                return node;
            }

            throw new InvalidOperationException("Cannot add duplicate");
        }

        private void GetNodesAbove(Node curNode, out Node parent, out Node grandParent, out Node greatGrandParent)
        {
            parent = grandParent = greatGrandParent = null;

            if (curNode != null)
                parent = curNode.Parent;

            if (parent != null)
                grandParent = parent.Parent;

            if (grandParent != null)
                greatGrandParent = grandParent.Parent;
        }

        private void FixTreeAfterInsertion(Node insertedNode, Node parent, Node grandParent, Node greatGrandParent)
        {
            throw new NotImplementedException();
        }







        private void LeftRotate(ref Node node)
        {
            var parent = node.Parent;
            var right = node.Right;
            var temp = node.Left;

            right.Left = node;
            node.Parent = right;
            node.Right = temp;

            if (temp != null)
                temp.Parent = node;
            if (right != null)
                right.Parent = parent;

            node = right;
        }

        public class Node
        {
            public T Item { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node Parent { get; set; }
            public bool Red { get; set; }

            public Node(T item, Node parent)
            {
                Item = item;
                Parent = parent;
                Left = Right = null;
                Red = true;
            }
        }
    }
}
