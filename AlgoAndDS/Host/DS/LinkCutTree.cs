using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.DS
{
    public class LinkCutTree
    {
        public class Node
        {
            public Node Left;
            public Node Right;
            public Node Parent;
            public bool Revert;

            public bool IsRoot()
            {
                return Parent == null || (Parent.Left != this && Parent.Right != this);
            }

            public void Push()
            {
                if (Revert)
                {
                    Revert = false;
                    Node t = Left;
                    Left = Right;
                    Right = t;

                    if (Left != null)
                        Left.Revert = !Left.Revert;
                    if (Right != null)
                        Right.Revert = !Right.Revert;
                }
            }
        }

        public static void Connect(Node ch, Node p, bool isLeftChild)
        {
            if (ch != null)
                ch.Parent = p;

            if (isLeftChild)
                p.Left = ch;
            else
                p.Right = ch;
        }

        public static void Rotate(Node x)
        {
            Node p = x.Parent;
            Node g = p.Parent;
            var isRootP = p.IsRoot();
            var isLeftChildX = (x == p.Left);

            Connect(isLeftChildX ? x.Right : x.Left, p, isLeftChildX);
            Connect(p, x, !isLeftChildX);
            Connect(x, g, !isRootP ? p == g.Left : false);
        }

        public static void Splay(Node x)
        {
            while (!x.IsRoot())
            {
                Node p = x.Parent;
                Node g = p.Parent;

                if (!p.IsRoot())
                    g.Push();

                p.Push();
                x.Push();

                if (!p.IsRoot())
                    Rotate((x == p.Left) == (p == g.Left) ? p : x);
                Rotate(x);
            }

            x.Push();
        }

        public static Node Expose(Node x)
        {
            Node last = null;

            for (Node y = x; y != null; y = y.Parent)
            {
                Splay(y);
                y.Left = last;
                last = y;
            }
            Splay(x);

            return last;
        }

        public static void MakeRoot(Node x)
        {
            Expose(x);
            x.Revert = !x.Revert;
        }

        public static bool Connected(Node x, Node y)
        {
            if (x == y)
                return true;
            Expose(x);
            Expose(y);

            return x.Parent != null;
        }

        public static void Link(Node x, Node y)
        {
            if (Connected(x, y))
                throw new InvalidOperationException("x and y already connected");

            MakeRoot(x);
            x.Parent = y;
        }

        public static void Cut(Node x, Node y)
        {
            MakeRoot(x);
            Expose(y);

            if (y.Right != x || x.Left != null || x.Right != null)
                throw new InvalidOperationException("no edge for x and y");

            y.Right.Parent = null;
            y.Right = null;
        }

        public static bool Connected(bool[][] g, int u, int v, int p)
        {
            if (u == v)
                return true;

            for (int i = 0; i < g.Length; i++)
            {
                if (i != p && g[u][i] && Connected(g, i, v, u))
                    return true;
            }

            return false;
        }
    }
}
