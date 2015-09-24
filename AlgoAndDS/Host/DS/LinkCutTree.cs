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

        public static bool Connected(bool[,] g, int u, int v, int p)
        {
            if (u == v)
                return true;

            for (int i = 0; i < g.Length-1; i++)
            {
                if (i != p && g[u,i] && Connected(g, i, v, u))
                    return true;
            }

            return false;
        }

        public static void Start()
        {
            var random = new Random();

            for (int step = 0; step < 1000; step++)
            {
                int n = random.Next(50) + 1;
                var g = new bool[n, n];
                Node[] nodes = new Node[n];

                for (int i = 0; i < n; i++)
                {
                    nodes[i] = new Node();
                }

                for (int query = 0; query < 2000; query++)
                {
                    int cmd = random.Next(10);
                    int u = random.Next(n);
                    int v = random.Next(n);
                    Node x = nodes[u];
                    Node y = nodes[v];

                    if (cmd == 0)
                    {
                        MakeRoot(x);
                        Expose(y);

                        if ((y.Right == x && x.Left == null && x.Right == null) != g[u, v])
                            throw new InvalidOperationException();
                        if (y.Right == x && x.Left == null && x.Right == null)
                        {
                            Cut(x, y);
                            g[u, v] = g[v, u] = false;
                        }
                    }
                    else if (cmd == 1)
                    {
                        if (Connected(x, y) != Connected(g, u, v, -1))
                            throw new InvalidOperationException();
                    } else
                    {
                        Expose(x);
                        if (Connected(x, y) != Connected(g, u, v, -1))
                            throw new InvalidOperationException();
                        if (!Connected(x, y))
                        {
                            Link(x, y);
                            g[u, v] = g[v, u] = true;
                        }
                    }
                }
            }
        }
    }
}
