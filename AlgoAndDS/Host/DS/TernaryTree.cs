using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.DS
{
    public class TernaryTree
    {
        private Node Root;

        public void Add(string s)
        {
            if (String.IsNullOrEmpty(s))
                throw new ArgumentException();

            Add(s, 0, ref Root);
        }

        public bool Contains(string s)
        {
            if (String.IsNullOrEmpty(s))
                throw new ArgumentException();

            int pos = 0;
            Node node = Root;

            while (node != null)
            {
                int cmp = s[pos] - node.Char;

                if (s[pos] < node.Char)
                    node = node.Left;
                else
                {
                    if (s[pos] > node.Char)
                        node = node.Right;
                    else
                    {
                        if (++pos == s.Length)
                            return node.WordEnd;

                        node = node.Center;
                    }
                }
            }

            return false;
        }

        private void Add(string s, int pos, ref Node node)
        {
            if (node == null)
            {
                node = new Node(s[pos], false);
            }

            if (s[pos] < node.Char)
            {
                Add(s, pos, ref Root.Left);
            }
            else
                if (s[pos] > node.Char)
                {
                    Add(s, pos, ref node.Right);
                }
                else
                {
                if (pos + 1 == s.Length)
                    node.WordEnd = true;
                else
                    Add(s, pos + 1, ref node.Center);
                }
        }


        public class Node
        {
            internal char Char;
            internal Node Left;
            internal Node Center;
            internal Node Right;
            internal bool WordEnd;

            public Node(char ch, bool wordEnd)
            {
                Char = ch;
                WordEnd = wordEnd;
            }
        }

    }
}
