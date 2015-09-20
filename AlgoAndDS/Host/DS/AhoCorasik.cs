using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.DS
{
    public class AhoCorasik : Trie<String>
    {
        public void Add(string input)
        {
            Add(input, input);
        }

        public void Add(IEnumerable<String> strings)
        {
            foreach (var item in strings)
            {
                Add(item);
            }
        }
    }

    public class Trie<T> : Trie<char, T>
    {

    }
    public class Trie<T, TValue>
    {
        private readonly Node<T, TValue> root = new Node<T, TValue>();

        public void Add(IEnumerable<T> word, TValue value)
        {
            var node = root;
            foreach (T c in word)
            {
                var child = node[c];
                if (child == null)
                    child = node[c] = new Node<T, TValue>(c, node);

                node = child;
            }

            node.Values.Add(value);
        }

        public void Build()
        {
            var queue = new Queue<Node<T, TValue>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                foreach (var child in node)
                {
                    queue.Enqueue(child);
                }

                if (node == root)
                {
                    root.Fail = root;
                    continue;
                }

                var fail = node.Parent.Fail;

                while (fail[node.Word] == null && fail != root)
                {
                    fail = fail.Fail;
                }

                node.Fail = fail[node.Word] ?? root;
                if (node.Fail == node)
                    node.Fail = root;
            }
        }

        public IEnumerable<TValue> Find(IEnumerable<T> text)
        {
            var node = root;

            foreach (T c in text)
            {
                while (node[c] == null && node != root)
                {
                    node = node.Fail;
                }

                node = node[c] ?? root;

                for (var t = node; t != root; t = t.Fail)
                {
                    foreach (TValue v in t.Values)
                    {
                        yield return v;
                    }
                }
            }
        }


        class Node<T, TValue> : IEnumerable<Node<T, TValue>>
        {
            private readonly T word;
            private readonly Node<T, TValue> parent;
            private readonly IDictionary<T, Node<T, TValue>> children = new Dictionary<T, Node<T, TValue>>();
            private readonly List<TValue> values = new List<TValue>();

            public T Word { get { return this.word; } }
            public Node<T, TValue> Parent { get { return this.parent; } }
            public Node<T, TValue> Fail { get; set; }
            public List<TValue> Values { get { return this.values; } }

            public Node<T, TValue> this[T c]
            {
                get { return children.ContainsKey(c) ? children[c] : null; }
                set { children[c] = value; }
            }

            public IEnumerator<Node<T,TValue>> GetEnumerator()
            {
                return children.Values.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public override string ToString()
            {
                return Word.ToString();
            }

            public Node()
            {

            }

            public Node(T word, Node<T, TValue> parent)
            {
                this.word = word;
                this.parent = parent;
            }
        }
    }
}
