using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.DS
{
    public class SuffixTree
    {
        public class Node
        {
            public int Index = -1;
            public IDictionary<char, Node> Children = new Dictionary<char, Node>();

        }

        public Node Root = new Node();
        public string Text;

        public SuffixTree(string s)
        {
            Text = s;
            for (int i = s.Length-1; i >= 0; i--)
            {
                InsertSuffix(s, i);
            }
        }

        public void InsertSuffix(string s, int from)
        {
            var cur = Root;
            for (int i = from; i < s.Length; i++)
            {
                var c = s[i];
                if (!cur.Children.ContainsKey(c))
                {
                    var n = new Node() { Index = from };
                    cur.Children.Add(c, n);
                    return;
                }

                cur = cur.Children[c];
            }
            throw new InvalidOperationException("Suffix tree corruption");
        }

        public IEnumerable<int> Find(string s)
        {
            var n = FindNode(s);
            if (n == null)
                yield break;

            foreach (var n2 in VisitTree(n))
            {
                yield return n2.Index;
            }
        }

        private IEnumerable<Node> VisitTree(Node n)
        {
            foreach (var n1  in n.Children.Values)
            {
                foreach (var n2 in VisitTree(n1))
                {
                    yield return n2;
                }
            }
            yield return n;
        }

        private Node FindNode(string s)
        {
            var cur = Root;
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (!cur.Children.ContainsKey(c))
                {
                    for (int j = i; j < s.Length; j++)
                    {
                        if (Text[cur.Index + j] != s[j])
                            return null;

                        return cur;
                    }
                }
                cur = cur.Children[c];
            }

            return cur;
        }
        
    }
}
