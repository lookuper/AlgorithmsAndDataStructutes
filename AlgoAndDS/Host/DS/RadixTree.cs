using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.DS
{
    public class RadixTree
    {
        public class Node
        {
            public String Label { get; set; }
            public List<Node> SubNodes { get; set; }

            public Node()
            {
                Label = String.Empty;
                SubNodes = new List<Node>();
            }

            public Node(string l)
            {
                Label = l;
                SubNodes = new List<Node>();
            }
        }

        private Node root;

        public RadixTree()
        {
            root = new Node();
        }

        public void Insert(string word)
        {
            InsertRec(word, root);
        }

        private void InsertRec(string wordPart, Node curNode)
        {
            var matches = MatchingConsecutiveCharacters(wordPart, curNode);

            if ((matches == 0) || curNode == root || (matches > 0 && matches< wordPart.Length) && (matches >= curNode.Label.Length))
            {
                bool inserted = false;
                var newWordPart = wordPart.Substring(matches, wordPart.Length - matches);

                foreach (var  child in curNode.SubNodes)
                {
                    if (child.Label.StartsWith(newWordPart[0].ToString()))
                    {
                        inserted = true;
                        InsertRec(newWordPart, child);
                    }
                }

                if (inserted == false)
                {
                    curNode.SubNodes.Add(new Node(newWordPart));
                }
            } else if (matches < wordPart.Length)
            {
                string commonRoot = wordPart.Substring(0, matches);
                string branchPreviousLabel = curNode.Label.Substring(matches, curNode.Label.Length - matches);
                string branchNewLabel = wordPart.Substring(matches, wordPart.Length - matches);

                curNode.Label = commonRoot;

                var newNodePreviousLabel = new Node(branchPreviousLabel);
                newNodePreviousLabel.SubNodes.AddRange(curNode.SubNodes);

                curNode.SubNodes.Clear();
                curNode.SubNodes.Add(newNodePreviousLabel);
            } else if (matches == curNode.Label.Length)
            {

            } else if (matches > curNode.Label.Length)
            {
                var newNodeLabel = curNode.Label.Substring(curNode.Label.Length, wordPart.Length);
                var newNode = new Node(newNodeLabel);
                curNode.SubNodes.Add(newNode);
            }           
        }

        private int MatchingConsecutiveCharacters(string word, Node curNode)
        {
            int matches = 0;
            int minLengt = 0;

            if (curNode.Label.Length >= word.Length)
            {
                minLengt = word.Length;
            } else if (curNode.Label.Length < word.Length)
            {
                minLengt = curNode.Label.Length;
            }

            if (minLengt > 0)
            {
                for (int i = 0; i < minLengt; i++)
                {
                    if (word[i] == curNode.Label[i])
                        matches++;
                    else
                        break;
                }
            }

            return matches;
        }

        public bool Lookup(string word)
        {
            return LookupRec(word, root);
        }

        private bool LookupRec(string wordPart, Node curNode)
        {
            var matches = MatchingConsecutiveCharacters(wordPart, curNode);

            if (matches == 0 || curNode == root || (matches > 0 && matches < wordPart.Length && matches >= curNode.Label.Length))
            {
                var newLabel = wordPart.Substring(matches, wordPart.Length - matches);
                foreach (var child in curNode.SubNodes)
                {
                    if (child.Label.StartsWith(newLabel[0].ToString()))
                        return LookupRec(newLabel, child);
                }

                return false;
            }
            else if (matches == curNode.Label.Length)
            {
                return true;
            }
            else return false;
        }

        public void Delete(string label)
        {
            DeleteRec(label, root);
        }

        private void DeleteRec(string wordPart, Node curNode)
        {
            var matches = MatchingConsecutiveCharacters(wordPart, curNode);

            if (matches == 0 || curNode == root || (matches > 0 && matches < wordPart.Length && matches >= curNode.Label.Length))
            {
                var newLabel = wordPart.Substring(matches, wordPart.Length - matches);
                foreach (var child in curNode.SubNodes)
                {
                    if (child.Label.StartsWith(newLabel[0].ToString()))
                    {
                        if (newLabel == child.Label)
                        {
                            if (child.SubNodes.Count == 0)
                            {
                                curNode.SubNodes.Remove(child);
                                return;
                            }
                        }

                        DeleteRec(newLabel, child);
                    }
                }
            }
        }
    }
}
