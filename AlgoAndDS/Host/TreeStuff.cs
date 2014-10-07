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

        internal static bool IsLeavesOnSameLevel(TreeListNode node, ref int level, ref int leafLevel)
        {
            if (node == null)
                return true;

            if (node.Left == null && node.Right == null)
            {
                if (leafLevel == 0)
                {
                    leafLevel = level;
                    return true;
                }

                return level == leafLevel;
            }
            level += 1;

            return IsLeavesOnSameLevel(node.Left, ref level, ref leafLevel) &&
                   IsLeavesOnSameLevel(node.Right, ref level, ref leafLevel);
        }

        internal static bool IsPairPresent(TreeListNode tree, int target)
        {
            var s1 = new Stack<TreeListNode>();
            var s2 = new Stack<TreeListNode>();
            bool done1 = false, done2 = false;
            int val1 = 0, val2 = 0;
            TreeListNode cur1 = tree, cur2 = tree;

            while (true)
            {
                // inorder strainght
                while (done1 == false)
                {
                    if (cur1 != null)
                    {
                        s1.Push(cur1);
                        cur1 = cur1.Left;
                    }
                    else
                    {
                        if (s1.Count == 0)
                            done1 = true;
                        else
                        {
                            cur1 = s1.Pop();
                            val1 = cur1.Data;
                            cur1 = cur1.Right;
                            done1 = true;
                        }
                    }
                }

                // reverse inorder traversal
                while (done2 == false)
                {
                    if (cur2 != null)
                    {
                        s2.Push(cur2);
                        cur2 = cur2.Right;
                    }
                    else
                    {
                        if (s2.Count == 0)
                            done2 = true;
                        else
                        {
                            cur2 = s2.Pop();
                            val2 = cur2.Data;
                            cur2 = cur2.Left;
                            done2 = true;
                        }
                    }
                }

                if (val1 != val2 && val1 + val2 == target)
                    return true;
                else
                {
                    if (val1 + val2 < target)
                        done1 = false;
                    else
                        if (val1 + val2 > target)
                            done2 = false;
                }
            }

            throw new ArgumentException("tree or target");
        }

        internal static TreeListNode ConvertToBalancedBST(int[] input, int start, int end)
        {
            if (start > end)
                return null;

            int mid = (start + end) / 2;

            var root = new TreeListNode(input[mid]);
            root.Left = ConvertToBalancedBST(input, start, mid - 1);
            root.Right = ConvertToBalancedBST(input, mid + 1, end);

            return root;
        }

        internal static int MaxPathSum(TreeListNode root, ref int rest)
        {
            if (root == null)
                return 0;

            int lSum = MaxPathSum(root.Left, ref rest);
            int rSum = MaxPathSum(root.Right, ref rest);
            int curSum = Math.Max(lSum + rSum + root.Data, Math.Max(lSum, rSum));

            if (rest < curSum)
                rest = curSum;

            return Math.Max(lSum, rSum) + root.Data;
        }

        internal static void PrintTreeVertical(TreeListNode tree)
        {
            if (tree == null)
                throw new ArgumentNullException();

            int hd = 0;
            var map = new Dictionary<int, List<int>>();
            GetVerticalOrder(tree, hd, map);

            foreach (var kv in map)
            {
                foreach (var listItem in kv.Value)
                {
                    Console.Write(listItem + " ");
                }
                Console.WriteLine();
            }
        }

        private static void GetVerticalOrder(TreeListNode root, int hd, Dictionary<int, List<int>> map)
        {
            if (root == null)
                return;

            if (!map.ContainsKey(hd))
                map[hd] = new List<int>();

            map[hd].Add(root.Data);

            GetVerticalOrder(root.Left, hd - 1, map);
            GetVerticalOrder(root.Right, hd + 1, map);
        }
    }
}
