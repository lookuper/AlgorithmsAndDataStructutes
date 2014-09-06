using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class TreeListNode
    {
        public Object Data { get; set; }
        public TreeListNode Left { get; set; }
        public TreeListNode Right { get; set; }

        public TreeListNode(int data, TreeListNode left = null, TreeListNode right = null)
        {
            Data = data;
            Left = left;
            Right = right;
        }
    }
}
