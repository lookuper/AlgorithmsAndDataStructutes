using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Host
{
    public class TreeStuff
    {
        private static TreeListNode prev = null;

        internal static TreeListNode KthNode(TreeListNode root, ref int k)
        {
            TreeListNode target = null;

            if (root.Left != null)
                target = KthNode(root.Left, ref k);

            if (target == null)
            {
                if (k == 1)
                    target = root;
                --k;
            }

            if (target == null && root.Right != null)
                target = KthNode(root.Right, ref k);

            return target;
        }

        internal static bool IsBST(TreeListNode root)
        {
            prev = null;

            if (root != null)
            {
                if (!IsBST(root.Left))
                    return false;

                if (prev != null && root.Data < prev.Data)
                    return false;

                prev = root;
                return IsBST(root.Right);
            }

            return true;
        }
    }
}
