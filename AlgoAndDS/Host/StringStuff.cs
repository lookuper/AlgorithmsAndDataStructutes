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
    }
}
