using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            // reverse list
            ListNode head = new ListNode(1) { Next = new ListNode(2) { Next = new ListNode(3) { Next = new ListNode(4) { Next = new ListNode(5) } } } };
            //LinkedListStuff.ReverseList(head);

            // find intersect node
            var tail = new ListNode(5) { Next = new ListNode(6) { Next = new ListNode(7) } };
            var head1 = new ListNode(1) { Next = tail };
            var head2 = new ListNode(2) { Next = new ListNode(3) { Next = tail } };
            var intersectNode = LinkedListStuff.FindIntersectionNode(head1, head2);

            // find Kth node in tree
            var tree = new TreeListNode(5)
            {
                Left = new TreeListNode(3) { Left = new TreeListNode(2), Right = new TreeListNode(4) },
                Right = new TreeListNode(7) { Right = new TreeListNode(8), Left = new TreeListNode(6) },
            };
            //int k = 0;
            //TreeListNode kNode = TreeStuff.KthNode(tree, ref k);

            //// find first duplicate in array with values n-1
            //var array = new[] { 2, 3, 1, 0, 2, 5, 3 };
            //int duplicate = ArrayStuff.FirstDuplicate(array);

            //// sort linked list
            //var notSortedList = new ListNode(2) { Next = new ListNode(1) { Next = new ListNode(3) } };
            ////LinkedListStuff.Sort(notSortedList);

            //// minimum in sorted and rotated array
            //array = new int[] { 3, 4, 1, 2 };
            //int min = ArrayStuff.MinimumInSortedAndRotatedArray(array, 0, array.Length);

            //// find missing number in array without duplicate
            //array = new int[] { 1, 2, 3, 4, 5, 7, 8 };
            //int missing = ArrayStuff.MissingNumber(array);

            //// check if binary tree is BST
            //bool isBst = TreeStuff.IsBST(tree);

            //// find first non repeating character in string
            //var output = StringStuff.FirstNonRepeatingChar("abcdacb");

            //// sort array of 1 0 2 into 0 1 2
            //array = new int[] { 1, 2, 0, 1, 2 };
            //ArrayStuff.DeutscheFlagSort(array);

            //// division two numbers to string
            //output = StringStuff.DivisionToString(10, 4);

            //// count number of occurens in sorted array
            //array = new int[] {0, 1, 2, 2, 2, 3, 4, 5};
            //int count = ArrayStuff.OccurensInSortedArray(array, 2);

            //// convert flatten list to one demensional list
            //var flattenList = new ListNode(1) { Child = new ListNode(5), Next = new ListNode(2) { Child = new ListNode(6){Child = new ListNode(8), Next = new ListNode(7)}, Next = new ListNode(3) } };
            //LinkedListStuff.FlattenList(flattenList);

            //// convert tree to linked list
            ////var fromTree = TreeStuff.ConvertToLinkedList(tree);

            //// maximum of all subarray of size k
            //ArrayStuff.PrintMaxSubArraysSizeK(new[] { 1, 2, 3, 4, 5, 6}, 3);

            //// remove keys outside the range in BST
            //TreeStuff.RemoveKeysOutsideRange(tree, 4, 10);

            // find largest sum of continius numbers in array
            //int result = ArrayStuff.LongestContiniusSum(new[] { 1, 2, -3, 4, 5 });

            // minimum length from root to leaf with sum
            //int len = TreeStuff.MinLenSum(tree, 18, 0);

            // first non repeating char in stream of chars
            //var s = StringStuff.FirstNonRepeatingCharInStream("google");

            // BST to double linked list
            //TreeListNode last = null;
            //TreeListNode head = null;
            //TreeStuff.ToDoubliLinkedList(tree, ref last, ref head);

            // reverse list in groups by k -- not working
            //LinkedListStuff.ReverseByKGroups(head, 2);

            // regular expression matching
            //bool match = StringStuff.Match("g*ks", 0, "geeks", 0);
            //match = StringStuff.Match("ge?ks*", 0, "geeksforgeeks", 0);
            //match = StringStuff.Match("g*k", 0, "gee", 0);

            // find max repeating number in arrray
            //int element = ArrayStuff.MaxRepeatingElement(new[] { 2, 3, 3, 5, 4, 3, 4 }, 8);

            // add two list with reversed numbers
            //var number1 = new ListNode(2) { Next = new ListNode(1) };
            //var number2 = new ListNode(3) { Next = new ListNode(1) };
            ////ListNode result = LinkedListStuff.AdTwoLists(number1, number2);
            //ListNode result = LinkedListStuff.AddTwoListsSameSize(number1, number2, 0);

            // check if leaves at the same level
            //int level = 0;
            //int leafLevel = 0;
            //tree.Left.Right = null;
            //tree.Left.Left = null;
            //bool sameLevel = TreeStuff.IsLeavesOnSameLevel(tree, ref level, ref leafLevel);

            // re-arrange alternate nodes and append to end
            //LinkedListStuff.ReArrangeAlternateNodes(head);

            // connect all nodes at the same level (just on bst)
            //LinkedListStuff.ConnectNodesAtTheSameLevel(tree);

            // N-petrol bank problem
            var circle = new List<Generic.PetrolTank>()
            {
                new Generic.PetrolTank(9, 10),
                new Generic.PetrolTank(8, 3),
                new Generic.PetrolTank(10, 5),
                new Generic.PetrolTank(1, 1),
            };

            int startingPoint = ArrayStuff.NPetrolProblem(circle.ToArray());
        }
    }
}
