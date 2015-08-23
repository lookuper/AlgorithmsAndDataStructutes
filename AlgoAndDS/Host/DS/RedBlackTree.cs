using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.DS
{
    public class RedBlackTree<T> where T : IComparable<T>
    {
        public Node Root;
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

        public void Remove(T item)
        {
            if (NumberElements > 1)
            {
                Root = DeleteNode(Root, item, null);
                NumberElements--;

                if (NumberElements == 0)
                    Root = null;

                Node curNode = null;
                if (nodeBeingDeleted.Red != null)
                    curNode = nodeBeingDeleted.Right;

                Node parent, sibling, grandParent;
                if (curNode == null)
                    parent = nodeBeingDeleted.Parent;
                else
                    parent = curNode.Parent;

                GetParentGrandParentSibling(curNode, parent, out sibling, out grandParent);

                if (curNode != null && curNode.Red)
                    curNode.Red = false;
                else if (!nodeToDeleteRed && !nodeBeingDeleted.Red)
                {
                    FixTreeAfterDeletion(curNode, parent, sibling, grandParent);
                }

                Root.Red = true;
            }
        }

        private void FixTreeAfterDeletion(Node curNode, Node parent, Node sibling, Node grandParent)
        {
            Node siblingLeftChild = null;
            Node siblingRightChild = null;

            if (sibling != null && sibling.Left != null)
                siblingLeftChild = sibling.Left;

            if (sibling != null && sibling.Right != null)
                siblingRightChild = sibling.Right;

            bool siblingRed = sibling != null && sibling.Red;
            bool siblingLeftRed = siblingLeftChild != null && siblingLeftChild.Red;
            bool siblingRightRed = siblingRightChild != null && siblingRightChild.Red;

            if (parent != null && !parent.Red && siblingRed && !siblingLeftRed && !siblingRightRed)
            {
                Case1(curNode, parent, sibling, grandParent);
            } else if (parent != null && !parent.Red && !siblingRed && !siblingLeftRed && !siblingRightRed)
            {
                Case2A(curNode, parent, sibling, grandParent);
            } else if (parent != null && parent.Red && !siblingRed  && !siblingLeftRed && !siblingRightRed)
            {
                Case2B(curNode, parent, sibling, grandParent);
            } else if (siblingToRight && !siblingRed && siblingLeftRed && !siblingRightRed)
            {
                Case3(curNode, parent, sibling, grandParent);
            } else if (!siblingToRight && !siblingRed && !siblingLeftRed && siblingRightRed)
            {
                Case3P(curNode, parent, sibling, grandParent);
            } else if (siblingToRight && !siblingRed && ! siblingRightRed)
            {
                Case4(curNode, parent, sibling, grandParent);
            } else if (!siblingToRight && !siblingRed && siblingLeftRed)
            {
                Case4P(curNode, parent, sibling, grandParent);
            }
        }

        private void Case1(Node curNode, Node parent, Node sibling, Node grandParent)
        {
            if (siblingToRight)
            {
                parent.Red = !parent.Red;
                sibling.Red = !sibling.Red;

                if (grandParent != null)
                {
                    if (parentToRight)
                    {
                        LeftRotate(ref parent);
                        grandParent.Right = parent;
                    } else if (!parentToRight)
                    {
                        LeftRotate(ref parent);
                        grandParent.Left = parent;
                    }
                    else
                    {
                        LeftRotate(ref parent);
                        Root = parent;
                    }

                    grandParent = sibling;
                    parent = parent.Left;
                    parentToRight = false;
                } else if (!siblingToRight)
                {
                    parent.Red = !parent.Red;
                    sibling.Red = !sibling.Red;
                    if (grandParent != null)
                    {
                        if (parentToRight)
                        {
                            RightRotate(ref parent);
                            grandParent.Right = parent;
                        } else if (!parentToRight)
                        {
                            RightRotate(ref parent);
                            grandParent.Left = parent;
                        }
                    } else
                    {
                        RightRotate(ref parent);
                        Root = parent;
                    }

                    grandParent = sibling;
                    parent = parent.Right;
                    parentToRight = true;
                }

                if (parent.Right == curNode)
                {
                    sibling = parent.Left;
                    siblingToRight = false;
                } else if (parent.Left == curNode)
                {
                    sibling = parent.Right;
                    siblingToRight = true;
                }

                Node siblingLeftChild = null;
                Node siblingRightChild = null;

                if (sibling != null && sibling.Left != null)
                    siblingLeftChild = sibling.Left;
                if (sibling != null && sibling.Right != null)
                    siblingRightChild = sibling.Right;

                bool siblingRed = sibling != null && sibling.Red;
                bool siblingLeftRed = siblingLeftChild != null && siblingLeftChild.Red;
                bool siblingRightRed = siblingRightChild != null && siblingRightChild.Red;

                if (parent.Red && !siblingRed && !siblingLeftRed && !siblingRightRed)
                {
                    Case2B(curNode, parent, sibling, grandParent);
                } else if (siblingToRight && !siblingRed && siblingLeftRed && !siblingRightRed)
                {
                    Case3(curNode, parent, sibling, grandParent);
                } else if (!siblingToRight && !siblingRed && !siblingLeftRed && siblingRightRed)
                {
                    Case3P(curNode, parent, sibling, grandParent);
                } else if (siblingToRight && !siblingRed && siblingRightRed)
                {
                    Case4(curNode, parent, sibling, grandParent);
                } else if (!siblingToRight && !siblingRed && siblingLeftRed)
                {
                    Case4P(curNode, parent, sibling, grandParent);
                }
            }
        }

        private Node DeleteNode(Node node, T item, Node parent)
        {
            if (node == null)
                throw new InvalidOperationException("item not in search tree");

            if (item.CompareTo(node.Item) > 0)
            {
                node.Left = DeleteNode(node.Left, item, node);
            } else if (item.CompareTo(node.Item) > 0)
            {
                node.Right = DeleteNode(node.Right, item, node);
            } else if (item.CompareTo(node.Item) == 0)
            {
                nodeToDeleteRed = node.Red;
                nodeBeingDeleted = node;

                if (node.Left == null)
                {
                    node = node.Right;
                    if (node != null)
                        node.Parent = parent;
                } else if (node.Right == null)
                {
                    node = node.Left;
                    node.Parent = parent;
                }
                else
                {
                    T replaceWithValue = LeftMost(node.Right);
                    node.Right = DeleteLeftMost(node.Right, node);
                    node.Item = replaceWithValue;
                }
            }
            return node;
        }

        private Node DeleteLeftMost(Node node, Node parent)
        {
            if (node.Left == null)
            {
                nodeBeingDeleted = node;
                if (node.Right != null)
                    node.Parent = parent;
                return node.Right;
            }
            else
            {
                node.Left = DeleteLeftMost(node.Left, node);
                return node;
            }
        }

        private T LeftMost(Node node)
        {
            if (node.Left == null)
                return node.Item;
            else
                return LeftMost(node.Left);
        }

        private void GetParentGrandParentSibling(Node curNode, Node parent, out Node sibling, out Node grandParent)
        {
            sibling = null;
            grandParent = null; 

            if (parent != null)
            {
                if (parent.Right == curNode)
                {
                    siblingToRight = false;
                    sibling = parent.Left;
                }
                if (parent.Left == curNode)
                {
                    siblingToRight = true;
                    sibling = parent.Right;
                }
            }
            if (parent != null)
                grandParent = parent.Parent;
            if (grandParent != null)
            {
                if (grandParent.Right == parent)
                    parentToRight = true;
                if (grandParent.Left == parent)
                    parentToRight = false;
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

        private void FixTreeAfterInsertion(Node child, Node parent, Node grandParent, Node greatGrandParent)
        {
            if (grandParent != null)
            {
                var uncle = grandParent.Right == parent ? grandParent.Left : grandParent.Right;

                if (uncle != null && parent.Red && uncle.Red)
                {
                    uncle.Red = false;
                    parent.Red = false;
                    grandParent.Red = true;
                    Node higher = null;
                    Node stillHigher = null;

                    if (greatGrandParent != null)
                        higher = greatGrandParent.Parent;
                    if (higher != null)
                        stillHigher = higher.Parent;

                    FixTreeAfterInsertion(grandParent, greatGrandParent, higher, stillHigher);
                }
                else if (uncle == null || parent.Red && !uncle.Red)
                {
                    if (grandParent.Right == parent && parent.Right == child)
                    {
                        parent.Red = false;
                        grandParent.Red = true;

                        if (greatGrandParent != null)
                        {
                            if (greatGrandParent.Right == grandParent)
                            {
                                LeftRotate(ref grandParent);
                                greatGrandParent.Right = grandParent;
                            }
                            else
                            {
                                LeftRotate(ref grandParent);
                                greatGrandParent.Left = grandParent;
                            }
                        }
                        else
                        {
                            LeftRotate(ref Root);
                        }
                    } else if (grandParent.Left == parent && parent.Left == child)
                    {
                        parent.Red = false;
                        grandParent.Red = true;

                        if (greatGrandParent != null)
                        {
                            if (greatGrandParent.Right == grandParent)
                            {
                                RightRotate(ref grandParent);
                                greatGrandParent.Right = grandParent;
                            }
                            else
                            {
                                RightRotate(ref grandParent);
                                greatGrandParent.Left = grandParent;
                            }
                        }
                        else
                        {
                            RightRotate(ref Root);
                        }
                    } else if (grandParent.Right == parent && parent.Left == child)
                    {
                        child.Red = false;
                        grandParent.Red = true;
                        RightRotate(ref parent);
                        grandParent.Right = parent;

                        if (greatGrandParent != null)
                        {
                            if (greatGrandParent.Right == grandParent)
                            {
                                LeftRotate(ref grandParent);
                                greatGrandParent.Right = grandParent;
                            }
                            else
                            {
                                LeftRotate(ref grandParent);
                                greatGrandParent.Left = grandParent;
                            }
                        }
                        else
                        {
                            LeftRotate(ref Root);
                        }
                    } else if (grandParent.Left == parent && parent.Right == child)
                    {
                        child.Red = false;
                        grandParent.Red = true;
                        LeftRotate(ref parent);
                        grandParent.Left = parent;

                        if (greatGrandParent != null)
                        {
                            if (greatGrandParent.Right == grandParent)
                            {
                                RightRotate(ref grandParent);
                                greatGrandParent.Right = grandParent;
                            }
                            else
                            {
                                RightRotate(ref grandParent);
                                greatGrandParent.Left = grandParent;
                            }
                        }
                        else
                        {
                            RightRotate(ref Root);
                        }
                    }
                }
                if (Root.Red)
                    Root.Red = false;
            }
        }

        private void RightRotate(ref Node grandParent)
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
