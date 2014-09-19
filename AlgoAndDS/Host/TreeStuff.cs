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


        /// <summary>
        /// NotWorking
        /// </summary>
        internal static ListNode ConvertToLinkedList(TreeListNode node)
        {
            if (node == null)
                throw new ArgumentNullException();

            var queue = new Queue<TreeListNode>();
            TreeListNode last = null;
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                
                if (node.Left != null)
                    queue.Enqueue(node.Left);
                if (node.Right != null)
                    queue.Enqueue(node.Right);

                if (last != null)
                    last.Right = node;

                node.Left = last;
                last = node;
                //queue.Dequeue();
            }


            throw new NotImplementedException();
        }

        internal static TreeListNode RemoveKeysOutsideRange(TreeListNode root, int min, int max)
        {
            if (root == null)
                return null;

            root.Left = RemoveKeysOutsideRange(root.Left, min, max);
            root.Right = RemoveKeysOutsideRange(root.Right, min, max);

            if (root.Data < min)
            {
                var child = root.Right;
                root = null;                
                return child;
            }

            if (root.Data > max)
            {
                var child = root.Left;
                root = null;
                return child;
            }

            return root;
        }

        internal static int MinLenSum(TreeListNode root, int sum, int len)
        {
            if (root == null)
                return int.MaxValue;

            int remaning = sum - root.Data;
            if (remaning == 0)
                return len+1;
            else
            {
                if (remaning <= root.Data)
                    return MinLenSum(root.Left, remaning, len + 1);
                else
                    return MinLenSum(root.Right, remaning, len + 1);
            }
        }

        internal static void ToDoubliLinkedList(TreeListNode node, ref TreeListNode last, ref TreeListNode head)
        {
            if (node == null)
                return;

            if (node.Left != null)
                ToDoubliLinkedList(node.Left, ref last, ref head);

            if (last != null)
                last.Right = node;
            else
                head = node;

            node.Left = last;
            last = node;

            if (node.Right != null)
                ToDoubliLinkedList(node.Right, ref last, ref head);

        }
    }
}
