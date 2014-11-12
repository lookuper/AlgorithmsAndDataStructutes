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

        internal static bool IsBST(TreeListNode root, int min, int max)
        {
            if (root == null)
                return true;

            if (root.Data < min || root.Data > max)
                return false;

            return IsBST(root.Left, min, root.Data) && IsBST(root.Right, root.Data, max);
        }

        internal static TreeListNode GetNextNode(TreeListNode root, TreeListNode node)
        {
            if (node == null)
                return null;

            if (node.Right !=null)
            {
                var right = node.Right;
                while (right.Left != null)
                    right = right.Left;
                return right;
            }
            else
            {
                TreeListNode succ = null;
                while (root != null)
                {
                    if (node.Data < root.Data)
                    {
                        succ = root;
                        root = root.Left;
                    }
                    else
                    {
                        if (node.Data > root.Data)
                            root = root.Right;
                        else
                            break;
                    }
                }
                return succ;
            }
        }

        internal static bool HasSubTree(TreeListNode root1, TreeListNode root2)
        {
            bool res = false;

            if (root1 != null && root2 != null)
            {
                if (root1.Data == root2.Data)
                    res = DoesTree1HasTree2(root1, root2);
                if (!res)
                    res = HasSubTree(root1.Left, root2);
                if (!res)
                    res = HasSubTree(root1.Right, root2);
            }

            return res;
        }

        private static bool DoesTree1HasTree2(TreeListNode root1, TreeListNode root2)
        {
            if (root2 == null)
                return true;
            if (root1 == null)
                return false;

            if (root1.Data != root2.Data)
                return false;

            return DoesTree1HasTree2(root1.Left, root2.Left) && DoesTree1HasTree2(root1.Right, root2.Right);
        }

        internal static void MirrorTree(TreeListNode root)
        {
            if (root == null)
                return;

            if (root.Left == null && root.Right == null)
                return;

            var temp = root.Left;
            root.Left = root.Right;
            root.Right = temp;

            if (root.Left != null)
                MirrorTree(root.Left);
            if (root.Right != null)
                MirrorTree(root.Right);
        }

        internal static bool IsSymetric(TreeListNode root1, TreeListNode root2)
        {
            if (root1 == null && root2 == null)
                return true;
            if (root1 == null || root2 == null)
                return false;

            return IsSymetric(root1.Left, root2.Right) && IsSymetric(root1.Right, root1.Left);
        }

        internal static void PrintTreeFromTopToBottom(TreeListNode root)
        {
            if (root == null)
                throw new NotImplementedException();

            var queue = new Queue<TreeListNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                Console.WriteLine(node.Data);

                if (node.Left != null)
                    queue.Enqueue(node.Left);
                if (node.Right != null)
                    queue.Enqueue(node.Right);
            }
        }

        internal static void PrintTopDownLevelByLevel(TreeListNode root)
        {
            if (root == null)
                throw new ArgumentNullException();

            var queue = new Queue<TreeListNode>();
            queue.Enqueue(root);
            int nextLevel = 0;
            int toBePrinted = 1;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                Console.Write(node.Data + " ");

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                    nextLevel++;
                }
                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                    nextLevel++;
                }

                toBePrinted--;
                if (toBePrinted == 0)
                {
                    Console.WriteLine();
                    toBePrinted = nextLevel;
                    nextLevel = 0;
                }
            }
        }

        internal static void PrintTreeZigZagOrder(TreeListNode root)
        {
            if (root == null)
                throw new ArgumentNullException();

            var levels = new Stack<TreeListNode>[2] { new Stack<TreeListNode>(), new Stack<TreeListNode>() };
            int current = 0;
            int next = 1;
            levels[current].Push(root);

            while (levels[current].Count > 0 && levels[next] != null)
            {
                var node = levels[current].Pop();
                Console.Write(node.Data + " ");

                if (current == 0)
                {
                    if (node.Left != null)
                        levels[next].Push(node.Left);
                    if (node.Right != null)
                        levels[next].Push(node.Right);
                }
                else
                {
                    if (node.Right != null)
                        levels[next].Push(node.Right);
                    if (node.Left != null)
                        levels[next].Push(node.Left);
                }

                if (levels[current].Count == 0)
                {
                    Console.WriteLine();
                    current = 1 - current;
                    next = 1 - next;
                }
            }
        }

        internal static void PathInBinaryTree(TreeListNode root, int expectedSum)
        {
            if (root == null)
                throw new ArgumentNullException();

            var path = new List<int>();
            int currentSum = 0;
            FindPath(root, expectedSum, path, currentSum);
        }

        private static void FindPath(TreeListNode root, int expectedSum, List<int> path, int currentSum)
        {
            currentSum += root.Data;
            path.Add(root.Data);
            bool isLeaf = root.Left != null && root.Right != null;
            
            if (currentSum == expectedSum && isLeaf)
            {
                Console.Write("Path found: ");
                foreach (var item in path)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }

            if (root.Left != null)
                FindPath(root.Left, expectedSum, path, currentSum);
            if (root.Right != null)
                FindPath(root.Right, expectedSum, path, currentSum);

            if (path.Count > 0)
                path.RemoveAt(path.Count - 1);
        }

        internal static TreeListNode ConstructTree(int[] pre, int[] inorder)
        {
            if (pre == null || inorder == null)
                throw new ArgumentNullException();
            if (pre.Length == 0 || inorder.Length == 0)
                throw new ArgumentException();

            return ConstructTreeCore(pre, inorder, 0, pre.Length-1, 0, inorder.Length-1);
        }

        private static TreeListNode ConstructTreeCore(int[] pre, int[] inorder, int startPre, int endPre, int startIn, int endIn)
        {
            int rootValue = pre[0];
            var root = new TreeListNode(rootValue);

            if (startPre == endPre)
            {
                if (startIn == endIn && startPre == startIn)
                    return root;
                else
                    throw new ArgumentException();
            }

            int rootIn = inorder[0];
            while (rootIn <= endIn && rootIn != rootValue)
            {
                rootIn++;
            }

            if (rootIn == endIn && rootIn != rootValue)
                throw new ArgumentException();

            int left = rootIn - startIn;
            int preOrderLeftEndLeft = startPre + left;
            if (preOrderLeftEndLeft > 0)
                root.Left = ConstructTreeCore(pre, inorder, ++startPre, endPre, startIn, rootIn - 1);

            if (preOrderLeftEndLeft < endPre - startPre)
                root.Right = ConstructTreeCore(pre, inorder, preOrderLeftEndLeft + 1, endPre, rootIn + 1, endIn);

            return root;
        }

        internal static bool VerifyPostOrderSequence(int[] seq, int start=0)
        {
            if (seq == null || seq.Length == 0)
                throw new ArgumentException();

            int root = seq[seq.Length - 1];
            int i = 0;
            for (; i < seq.Length-1; i++)
            {
                if (seq[i] > root)
                    break;
            }

            int j = i;
            for (; j < seq.Length-1; j++)
            {
                if (seq[j] < root)
                    return false;
            }

            bool left = true;
            if (i > 0)
                left = VerifyPostOrderSequence(seq, i);

            bool right = true;
            if (i < seq.Length - 1)
                right = VerifyPostOrderSequence(seq, seq.Length - 1 - i);

            return left && right;
        }

        internal static TreeListNode ConvertToDoubleLinkedList(TreeListNode root)
        {
            TreeListNode lastNode = null;
            ConvertNode(root, lastNode);

            TreeListNode head = root;
            while (head != null && head.Left != null)
            {
                head = head.Left;
            }

            return head;
        }

        private static void ConvertNode(TreeListNode node, TreeListNode last)
        {
            if (node == null)
                return;

            var current = node;
            if (current.Left != null)
                ConvertNode(current.Left, last);

            current.Left = last;
            if (last != null)
                last.Right = current;

            last = current;

            if (current.Right != null)
                ConvertNode(current.Right, last);
        }

        internal static int TreeDepth(TreeListNode root)
        {
            if (root == null)
                return 0;

            int left = TreeDepth(root.Left);
            int right = TreeDepth(root.Right);

            return left > right ? left + 1 : right + 1;
        }
    }
}
