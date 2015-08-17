using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.DS
{
    public class UnionFind<T>
    {
        private readonly IDictionary<T, int> dict = new Dictionary<T, int>();
        private int _key = 0;

        public bool Add(T param)
        {
            if (dict.ContainsKey(param))
            {
                return false;
            }
            else
            {
                dict.Add(param, _key++);
                return true;
            }
        }

        public bool Unite(T param1, T param2)
        {
            if (!dict.ContainsKey(param1) || !dict.ContainsKey(param2))
                return false;
            else
            {
                dict[param2] = dict[param1] = Math.Min(dict[param2], dict[param1]);
                return true;
            }
        }

        public bool IsSameGroup(T param1, T param2)
        {
            if (!dict.ContainsKey(param1) || (!dict.ContainsKey(param2)))
                return false;
            else
                return dict[param2] == dict[param1];
        }
    }
}
