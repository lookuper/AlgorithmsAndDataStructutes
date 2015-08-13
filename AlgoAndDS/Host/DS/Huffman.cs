using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.DS
{
    public class HuffmanNode
    {
        public char Symbol { get; set; }
        public int Frequency { get; set; }
        public HuffmanNode Left { get; set; }
        public HuffmanNode Right { get; set; }

        public List<bool> Traverse(char symbol, List<bool> data)
        {
            // leaf
            if (Right == null && Left == null)
            {
                if (symbol.Equals(Symbol))
                    return data;
                else
                    return null;
            }
            else
            {
                List<bool> left = null;
                List<bool> right = null;

                if (Left != null)
                {
                    List<bool> leftPath = new List<bool>();
                    leftPath.AddRange(data);
                    leftPath.Add(false);

                    left = Left.Traverse(symbol, leftPath);
                }
                if (Right != null)
                {
                    List<bool> rightPath = new List<bool>();
                    rightPath.AddRange(data);
                    rightPath.Add(true);

                    right = Right.Traverse(symbol, rightPath);
                }

                if (left != null)
                    return left;
                else
                    return right;
            }
        }
    }

    public class HuffmanTree
    {
        private IList<HuffmanNode> nodes = new List<HuffmanNode>();
        public HuffmanNode Root { get; set; }
        public IDictionary<char, int> Frequencies = new Dictionary<char, int>();

        public void Build(string source)
        {
            throw new NotImplementedException();
        }

        public BitArray Encode(string source)
        {
            throw new NotImplementedException();
        }

        public string Decode(BitArray bits)
        {
            throw new NotImplementedException();
        }

        public bool IsLeaf(HuffmanNode node)
        {
            throw new NotImplementedException();
        }
    }
}
