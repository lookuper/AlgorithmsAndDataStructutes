using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.DS
{
    public class Trie2
    {
        public Node RootNode { get; private set; }

        public Trie2()
        {
            RootNode = new Node { Letter = Node.Root };
        }

        public void Add(string word)
        {
            word = word.ToLower() + Node.Eow;
            var currentNode = RootNode;
            foreach (var c in word)
            {
                currentNode = currentNode.AddChild(c);
            }
        }

        public List<string> Match(string prefix, int? maxMatches)
        {
            prefix = prefix.ToLower();

            var set = new HashSet<string>();

            _MatchRecursive(RootNode, set, "", prefix, maxMatches);
            return set.ToList();
        }

        private static void _MatchRecursive(Node node, ISet<string> rtn, string letters, string prefix, int? maxMatches)
        {
            if (maxMatches != null && rtn.Count == maxMatches)
                return;

            if (node == null)
            {
                if (!rtn.Contains(letters)) rtn.Add(letters);
                return;
            }

            letters += node.Letter.ToString();

            if (prefix.Length > 0)
            {
                if (node.ContainsKey(prefix[0]))
                {
                    _MatchRecursive(node[prefix[0]], rtn, letters, prefix.Remove(0, 1), maxMatches);
                }
            }
            else
            {
                foreach (char key in node.Keys)
                {
                    _MatchRecursive(node[key], rtn, letters, prefix, maxMatches);
                }
            }
        }
    }

        public class Node
        {
            public const char Eow = '$';
            public const char Root = ' ';

            public char Letter { get; set; }
            public HybridDictionary Children { get; private set; }

            public Node() { }

            public Node(char letter)
            {
                this.Letter = letter;
            }

            public Node this[char index]
            {
                get { return (Node)Children[index]; }
            }

            public ICollection Keys
            {
                get { return Children.Keys; }
            }

            public bool ContainsKey(char key)
            {
                return Children.Contains(key);
            }

            public Node AddChild(char letter)
            {
                if (Children == null)
                    Children = new HybridDictionary();

                if (!Children.Contains(letter))
                {
                    var node = letter != Eow ? new Node(letter) : null;
                    Children.Add(letter, node);
                    return node;
                }

                return (Node)Children[letter];
            }

            public override string ToString()
            {
                return this.Letter.ToString();
            }
        }    

    public class Trie
    {
        public class TrieNode
        {
            public TrieNode[] children = new TrieNode[128];
            public bool IsLeaf { get; set; }
        }

        public void InsertString(TrieNode root, string s)
        {
            var node = root;
            foreach (var ch in s)
            {
                TrieNode next = null;
                try
                {
                    next = node.children[ch];
                    if (next == null)
                        node.children[ch] = next = new TrieNode();
                }
                catch (ArgumentOutOfRangeException)
                {
                    node.children[ch] = next = new TrieNode();
                }

                node = next;
            }

            node.IsLeaf = true;
        }

        public void PrintSorted(TrieNode node, string s)
        {
            for (int ch = 0; ch < node.children.Length; ch++)
            {
                TrieNode child = node.children[ch];
                if (child != null)
                    PrintSorted(child, s + ch);
            }

            if (node.IsLeaf)
                Console.WriteLine(s);
        }
    }
}
