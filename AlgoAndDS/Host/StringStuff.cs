using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
