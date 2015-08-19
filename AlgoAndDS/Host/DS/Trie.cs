using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.DS
{
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
