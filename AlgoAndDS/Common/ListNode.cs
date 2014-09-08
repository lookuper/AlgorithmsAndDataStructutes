using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ListNode
    {
        public Int32 Data { get; set; }
        public ListNode Next { get; set; }

        public ListNode(Int32 data, ListNode next = null)
        {
            Data = data;
        }
    }
}
