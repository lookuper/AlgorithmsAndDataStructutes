﻿using System;
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
            ListNode head = new ListNode(1) {Next = new ListNode(2) };
            LinkedListStuff.ReverseList(head);

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
            int k = 0;
            TreeListNode kNode = TreeStuff.KthNode(tree, ref k);

            // find first duplicate in array with values n-1
            var array = new[] { 2, 3, 1, 0, 2, 5, 3 };
            int duplicate = ArrayStuff.FirstDuplicate(array);

            // sort linked list
            var notSortedList = new ListNode(2) { Next = new ListNode(1) { Next = new ListNode(3) } };
            //LinkedListStuff.Sort(notSortedList);

            // minimum in sorted and rotated array
            array = new int[] { 3, 4, 1, 2 };
            int min = ArrayStuff.MinimumInSortedAndRotatedArray(array, 0, array.Length);

            // find missing number in array without duplicate
            array = new int[] { 1, 2, 3, 4, 5, 7, 8 };
            int missing = ArrayStuff.MissingNumber(array);

            // check if binary tree is BST
            bool isBst = TreeStuff.IsBST(tree);

            // find first non repeating character in string
            var output = StringStuff.FirstNonRepeatingChar("abcdacb");

            // sort array of 1 0 2 into 0 1 2
            array = new int[] { 1, 2, 0, 1, 2 };
            ArrayStuff.DeutscheFlagSort(array);

            // division two numbers to string
            output = StringStuff.DivisionToString(10, 4);

            // count number of occurens in sorted array
            array = new int[] {0, 1, 2, 2, 2, 3, 4, 5};
            int count = ArrayStuff.OccurensInSortedArray(array, 2);
        }
    }
}
