﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Host.DS;

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
            //var intersectNode = LinkedListStuff.FindIntersectionNode(head1, head2);

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

            // quick sort
            //ArrayStuff.QuickSort(new int[] {2,5,3,7,11,5,2,0}, 0, 7);

            // minimal number of coins to charge
            //int res = ArrayStuff.MinCharge(15, new int[] {1,3,4,5,10 });

            // delete duplicates from list\
            //head.Data = 2;
            //LinkedListStuff.DeleteDuplicates(head);

            // reorder odd / even
            //ArrayStuff.ReorderOddEven(new int[] { 1,2,3,4,5,6});

            // remove all instances of value from array
            //int[] res = ArrayStuff.RemoveValue(new int[] { 1, 2, 3, 1, 4, 1, 5, 1, }, 1);

            // check if one tree is subtree of another tree
            //bool res = TreeStuff.HasSubTree(tree, tree);

            // mirror tree
            //TreeStuff.MirrorTree(tree);

            // check if binary tree is symetric
            //bool res = TreeStuff.IsSymetric(tree, tree);

            // print matrix in spiral order
            //int[,] numbers = new int[,]
            //{
            //    {1,2,3},
            //    {4,5,6},
            //    {7,8,9},
            //};
            //ArrayStuff.PrintMatrixInSpiralOrder(numbers);

            // print tree from top to bottom
            //TreeStuff.PrintTreeFromTopToBottom(tree);

            // print tree from top to bottom each level in line
            //TreeStuff.PrintTopDownLevelByLevel(tree);

            // clone complex linked list with sibling pointer
            //head.Sibling = head.Next;
            //head.Next.Next.Sibling = head.Next.Next.Next.Next;
            //ListNode res = LinkedListStuff.CloneComplexList(head);

            // print tree in zig-zag order
            //TreeStuff.PrintTreeZigZagOrder(tree);

            // find path in binary tree
            //TreeStuff.PathInBinaryTree(root:tree, expectedSum: 13);

            // stack with min function
            //var stack = new Generic.IntStackWithMinOption();
            //stack.Push(2);
            //stack.Push(3); 
            //stack.Push(1);

            // build binary tree with preorder and inorder
            //var pre = new int[] {3,2,1,4,5 };
            //var inorder = new int[] {1,2,3,4,5 };
            //TreeListNode root =  TreeStuff.ConstructTree(pre, inorder);

            // check if array is post-order sequence of bst
            //bool res = TreeStuff.VerifyPostOrderSequence(new int[] {2,3,7,8,5 });

            // convert bst to double-linked list
            //TreeListNode res = TreeStuff.ConvertToDoubleLinkedList(tree);

            //generate all possible pairs of brackets
            //string res = Generic.GenerateAllPossibleBrackets(String.Empty, 12);
            //Console.WriteLine(res);

            // generate string permutations
            //StringStuff.Permutations(String.Empty, "ABC");

            // generate all arrays permutations
            //var input = new List<int[]>
            //{
            //    new int[] {1,2},
            //    new int[] {4,5},
            //};
            //ArrayStuff.AllPermutations(input);

            // generate all string permutation on each char
            //StringStuff.Combination("ABC");

            // intersection of two sorted arrays
            //List<int> res;
            //ArrayStuff.Intersection(new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 5, 6, 7 }, out res);

            // get maximum sum of sub-array
            //int res = ArrayStuff.GetGretestSumOfSubArray(numbers: new int[] { 4, 7, 2, -3, 3, 2 });

            // digit 1 appears in number sequence
            //int res = Generic.NumberBetween1AndN(n:49);

            // concatuate an array to get minimum numbers
            //ArrayStuff.GetMinFromConcatuatedArray(numbers: new int[] { 2, 5, 3, 1, 7, 0 });

            // check if two english word is anagrams
            //bool res = StringStuff.IsAnagrams(s1: "lisa", s2: "aaaa");

            // count reversed pairs in array
            //int res = ArrayStuff.ReversedPairs(new int[] { 4, 5, 6, 2, 3, 1 });

            // find depth of binary tree
            // int res = TreeStuff.TreeDepth(tree);

            // check if a binary tree is balanced
            //bool res = TreeStuff.IsBalanced(root: tree);

            // sum in sorted sequence
            //bool res = ArrayStuff.HasPairWithSum(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, sum: 10);

            // check wheter array contains three numbers whose sum is 0
            //bool res = ArrayStuff.HasTripleSum(input:new int[] {2,3,5,1,6,7,-5});

            // print all sequence with continius numbers into sum s
            //ArrayStuff.FindContiniusSequence(sum: 15);

            // reverse order of words in sequence
            // string res = StringStuff.ReverseWordsInSentence(data: "reverse order of words in sequence");

            // string left rotation
            //StringStuff.LeftRotation(str: "abcde", n: 2);

            // probability of dice points
            //Generic.PrintProbability(number: 2);

            // last number in list of n in m
            //int res = Generic.LastRemaning(n:1, m:20);

            // swap every pair of nodes
            //ListNode res = LinkedListStuff.SwapEveryPair(head);

            // move all zeros to the end of array
            //var input = new int[] { 1, 0, 2, 0 };
            //ArrayStuff.PushZerosToEnd(input);

            // DS part
            // MaxHeap / MinHeap
            //BinaryHeap<int> heap = new MinHeap<int>();
            //heap.Add(2);
            //heap.Add(4);
            //heap.Add(1);
            //heap.Add(3);
            //var min = heap.Pop();

            // Huffman tree
            //string input = "AAABBC";
            //var hTree = new HuffmanTree();
            //hTree.Build(input);
            //var encoded = hTree.Encode(input);
            //var decoded = hTree.Decode(encoded);

            // Union Find #1
            //var union = new UnionFind<int>();
            //union.Add(1);
            //union.Add(3);
            //union.Add(4);
            //union.IsSameGroup(3, 5);

            // Disjoin set
            //var disSet = new DisjointSets();
            //disSet.AddElements(5);
            //disSet.Union(2, 3);
            //var setId = disSet.FindSet(3);

            //Trie (simple)
            //Trie trie = new Trie();
            //var tRoot = new Trie.TrieNode();
            //trie.InsertString(tRoot, "ABC");
            //trie.PrintSorted(tRoot, "");

            // Trie (complex)
            //Trie2 trie = new Trie2();
            //trie.Add("Call");
            //trie.Add("Cat");
            //trie.Add("Catter");
            //trie.Add("Bat");
            //trie.Add("Bake");
            //var res = trie.Match("ga", int.MaxValue);

            // Ternary Tree
            //var tTree = new TernaryTree();
            //tTree.Add("ABC");
            //tTree.Add("AB");
            //var res = tTree.Contains("ABC");

            // Red-Black Tree
            //var rbTree = new RedBlackTree<int>();
            //rbTree.Add(1);
            //rbTree.Add(2);
            //rbTree.Add(3);
            //rbTree.Add(7);
            //rbTree.Add(9);
            //rbTree.Add(10);
            //rbTree.Remove(7);

            // recursive AVL tree
            //var avlTree = new AVLTree<int>();
            //avlTree.Add(1);
            //avlTree.Add(2);
            //avlTree.Add(3);
            //avlTree.Delete(2);

            // Segment tree
            //int[] elements = { 1, 2, 3};
            //var segmentTree = new SegmentTree(elements.Length);
            //segmentTree.ConstructSegmentTree(elements);
            //var sum = segmentTree.GetSum(0, 2);

            // Binary Indexed Tree
            //var elements = new[] { 1, 2, 3, 0};
            //var biTree = new BinaryIndexedTree(elements);
            //var sum = biTree.Sum(0, 2);

            // Suffix Array
            //var input = "mississippi";
            //var suffixArray = SuffixArray.Build(input);
            //var pattern = "i";
            //var result = suffixArray.Search(pattern);

            // Sparse Matrix
            //var matrix = new SparseMatrix<int>(512, 512);
            //matrix[1, 1] = 1;

            // Compress duplicates
            //ArrayStuff.CompressDuplicates(new[] { 1, 1, 1, 1 });

            // Convert number into words
            //var res = StringStuff.ConvertNumberToWords(1234556);

            // Suffix tree
            //var suffixTree = new SuffixTree("mississipi");
            //var res = suffixTree.Find("ss").ToList();

            // Treap
            //var treap = new Treap<int>();
            //treap.Add(1);
            //treap.Add(2);
            //treap.Add(3);
            //treap.Add(4);
            //treap.Contains(4);

            // Aho-Corasik
            //var ac = new AhoCorasik();
            //ac.Add("hello");
            //ac.Add("world");
            //ac.Build();

            // Kd-Tree
            //var comparer = Comparer<int>.Default;
            //var data = new[]
            //{
            //    new KeyValuePair<Key<int>, int>(new Key<int>(new[] {1,2 }),1),
            //    new KeyValuePair<Key<int>, int>(new Key<int>(new[] {3,4 }),2),
            //};
            //var kdTree = KdTree<int, int>.Build(comparer, data);
            //var res = kdTree.Search(data.First().Key, data.Last().Key);

            // LinkCut Tree
            //var lcTree = new LinkCutTree();
            //LinkCutTree.Start();

            // Radix Tree
            var radixTree = new RadixTree();
            radixTree.Insert("banana");
            radixTree.Insert("bananaBomb");
    }
    }
}
