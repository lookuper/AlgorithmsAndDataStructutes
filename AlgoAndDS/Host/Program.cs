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
            //var circle = new List<Generic.PetrolTank>()
            //{
            //    new Generic.PetrolTank(9, 10),
            //    new Generic.PetrolTank(8, 3),
            //    new Generic.PetrolTank(10, 5),
            //    new Generic.PetrolTank(1, 1),
            //};

            //int startingPoint = ArrayStuff.NPetrolProblem(circle.ToArray());

            // swap Kth node from beginning and Kth node from end
            //LinkedListStuff.SwapBeginningEnd(head, 2);

            // is target present in BST as node sum
            //bool res = TreeStuff.IsPairPresent(tree, 5);

            // given sequence of words pring all anagrams together
            //var words = new List<String>{ "cat", "dog", "tac", "god", "act" };
            //ArrayStuff.PringAnagramsTogether(words);

            // convert sorted array to balanced bst
            //var input = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            //TreeListNode balancedTreeRoot = TreeStuff.ConvertToBalancedBST(input, 0, input.Length-1);

            // calculate angle between hour and minute hand
            //int res = Generic.CalculateAngle(hour:6, minute:0);

            // check if rectangles overlap
            //var l1 = new Common.Generic.Point(20, 20);
            //var l2 = new  Common.Generic.Point(20, 40);
            //var r1 = new Common.Generic.Point(20, 20);
            //var r2 = new Common.Generic.Point(20, 40);
            //bool res = Generic.IsRectanglesOverlap(l1, r1, l2, r2);

            // maximum path sum between leaves in binary tree
            //int rest = 0;
            //int res = TreeStuff.MaxPathSum(tree, ref rest);

            // merge two sorted arrays into new ordered array
            //int[] res = ArrayStuff.MergeArrays(new int[] { 1, 3, 5, 7 }, new int[] { 2, 4, 6, 8 });

            // merge two sorted list into new 
            //ListNode mergedHead = LinkedListStuff.MergeTwoLists(head1, head2);

            // print tree in vertical order
            //TreeStuff.PrintTreeVertical(tree);

            // find if list has a loop
            //head.Next.Next.Next = head.Next;
            //bool res = LinkedListStuff.FindLoop(head);
            
            // find start loop node in list
            //ListNode res = LinkedListStuff.FindEntyLoopNode(head);
            //bool res = TreeStuff.IsBST(tree, int.MinValue, int.MaxValue);

            // find turning number in array
            //int res = ArrayStuff.TurningNumber(new int[] { 3, 4, 5, 6, 7, 1, 2 });

            // get majority element from array
            //int res = ArrayStuff.GetMarority(new int[] { 1, 2, 3, 2, 3, 1, 1 });

            // find next node in binary tree wihtout parent node
            // TreeListNode nextNode = TreeStuff.GetNextNode(tree, tree.Right);
        }
    }
}
