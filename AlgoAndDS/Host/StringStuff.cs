using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Host
{
    public class StringStuff
    {
        internal static String FirstNonRepeatingChar(string input)
        {
            var dict = new OrderedDictionary();
            foreach (var ch in input)
            {
                var s = ch.ToString();
                if (dict.Contains(s))
                {
                    int val = (int)dict[s];
                    dict[s] = val + 1;
                }
                else
                    dict.Add(s, 1);
            }

            foreach (DictionaryEntry item in dict)
            {
                if ((int)item.Value == 1)
                    return item.Key.ToString();
            }

            throw new ArgumentException();
        }

        internal static string DivisionToString(int num1, int num2)
        {
            int before = num1 / num2;
            int after = num1 % num2;

            if (after == 0)
                return before.ToString();

            var sb = new StringBuilder();
            sb.Append(before);
            sb.Append(".");

            int counter = -1;
            while (after < num2)
            {
                after = after * 10;
                counter++;
                if (counter > 0)
                    sb.Append("0");
            }

            int pre = after;
            while (after != 0)
            {
                int temp = after / num2;
                after = (after % num2) * 10;

                if(pre == after)
                {
                    sb.Append("(");
                    sb.Append(temp);
                    sb.Append(")");
                    break;
                }
                else
                {
                    pre = after;
                    sb.Append(temp);
                }
            }

            return sb.ToString();
        }

        internal static String FirstNonRepeatingCharInStream(string input)
        {
            var dict = new OrderedDictionary();

            foreach (var x in input)
            {
                string ch = x.ToString();
                if (dict.Contains(ch))
                    dict[ch] = true;
                else
                    dict.Add(ch, false);
            }

            foreach (DictionaryEntry  de in dict)
            {
                if (!(bool)de.Value)
                    return de.Key as String;
            }

            throw new ApplicationException();
            //var inDLL = new LinkedListNode<char>[1000];
            //var repeated = new bool?[1000];

            //foreach (var ch in input.ToCharArray())
            //{
            //    if (repeated[ch] != null)
            //    {
            //        if (inDLL[ch] == null)
            //        {
            //            inDLL[ch] = new LinkedListNode<char>(ch);
            //            repeated[ch] = true;
            //        }
            //        else
            //        {
            //            inDLL[ch] = null;
            //            repeated[ch] = true;
            //        }
            //    }
            //    else
            //    {
            //        repeated[ch] = false;
            //        inDLL[ch] = new LinkedListNode<char>(ch);
            //    }
            //}

            //return inDLL.First(x => x != null).Value;
        }

        internal static bool Match(string first, int firstIndex, string second, int secondIndex)
        {
            if (firstIndex >= first.Length || secondIndex >= second.Length)
                return true;

            if (first[firstIndex] == '*' && firstIndex + 1 != first.Length && secondIndex == second.Length-1)
                return false;

            if (first[firstIndex] == '?' || first[firstIndex] == second[secondIndex])
                return Match(first, firstIndex + 1, second, secondIndex + 1);

            if (first[firstIndex] == '*')
                return Match(first, firstIndex + 1, second, secondIndex) || Match(first, firstIndex, second, secondIndex + 1);

            return false;
        }

        internal static void Permutations(string prefix, string str)
        {
            if (str.Length == 0)
                Console.WriteLine(prefix);
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    var pre = prefix + str[i];
                    var post = str.Substring(0, i) + str.Substring(i + 1, str.Length - 1 - i);

                    Permutations(pre, post);
                }
            }

        }

        internal static void Combination(string str)
        {
            if (String.IsNullOrEmpty(str))
                throw new ArgumentException();

            var result = new Stack<char>();
            for (int i = 1; i <= str.Length; i++)
            {
                Combination(str, 0, i, result);
            }
        }

        private static void Combination(string str, int index, int number, Stack<char> result)
        {
            if (number == 0)
            {
                foreach (var item in result)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
                return;
            }

            if (index == str.Length)
                return;

            result.Push(str[index]);
            Combination(str, index + 1, number - 1, result);
            result.Pop();

            // ignore char at str[index]
            Combination(str, index + 1, number, result);
        }

        internal static bool IsAnagrams(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;

            var times = new Dictionary<char, int>();
            for (int i = 0; i < s1.Length; i++)
            {
                char ch = s1[i];
                if (times.ContainsKey(ch))
                    times.Add(ch, times[ch] + 1);
                else
                    times.Add(ch, 1);
            }
            for (int i = 0; i < s2.Length; i++)
            {
                char ch = s2[i];
                if (!times.ContainsKey(ch))
                    return false;
                if (times[ch] == 0)
                    return false;

                times[ch] = times[ch] - 1;
            }

            return true;
        }

        internal static string ReverseWordsInSentence(string data)
        {
            if (String.IsNullOrEmpty(data))
                throw new ArgumentException();

            Reverse(ref data, 0, data.Length-1);
            int begin = 0;
            int end = 0;

            while (begin != data.Length)
            {
                if (Char.IsWhiteSpace(data[begin]))
                {
                    begin++;
                    end++;
                }
                else
                {
                    if (Char.IsWhiteSpace(data[end]) || end == data.Length-1)
                    {
                        Reverse(ref data, begin, end);
                        begin = ++end;
                    }
                    else
                    {
                        end++;
                    }
                }
            }

            return data;
        }

        private static void Reverse(ref string data, int start, int end)
        {
            var input = data.ToCharArray();
            while (start < end)
            {
                Generic.Swap<Char>(ref input[start], ref input[end]);
                start++;
                end--;
            }

            data = new String(input);
        }

        internal static void LeftRotation(string str, int n)
        {
            if (str == null)
                throw new ArgumentNullException();

            int length = str.Length;
            if (length > 0 && n > 0 && n < length)
            {
                int firstStart = 0;
                int firstEnd = n - 1;
                int secondStart = n;
                int secondEnd = length - 1;

                // reverse first n chars
                Reverse(ref str, firstStart, firstEnd);

                // reverse other chars
                Reverse(ref str, secondStart, secondEnd);

                // reverse whole string
                Reverse(ref str, firstStart, secondEnd);
            }
        }
    }
}
