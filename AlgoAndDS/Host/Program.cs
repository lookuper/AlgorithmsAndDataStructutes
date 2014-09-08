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
            LinkedListStuff.Sort(notSortedList);
        }
    }
}
