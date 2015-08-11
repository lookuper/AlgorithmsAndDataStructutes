using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.DS
{
    public abstract class BinaryHeap<T> where T : IComparable<T>
    {
        protected IList<T> _elements = new List<T>();

        public void Add(T item)
        {
            _elements.Add(item);
            Heapify();
        }


        public void Delete(T item)
        {
            int i = _elements.IndexOf(item);
            int last = _elements.Count - 1;

            _elements[i] = _elements[last];
            _elements.RemoveAt(last);

            Heapify();
        }

        public T Pop()
        {
            if (_elements.Count < 0)
                throw new IndexOutOfRangeException();

            T item = _elements.First();
            Delete(item);

            return item;
        }


        protected void SwapElements(int firstIndex, int secondIndex)
        {
            var temp = _elements[firstIndex];
            _elements[firstIndex] = _elements[secondIndex];
            _elements[secondIndex] = temp;
        }

        protected abstract void Heapify();
    }

    public class MaxHeap<T> : BinaryHeap<T> where T : IComparable<T>
    {      
        protected override void Heapify()
        {
            for (int i = _elements.Count-1; i > 0; i--)
            {
                int parentPosition = (i + 1) / 2 - 1;
                parentPosition = parentPosition >= 0 ? parentPosition : 0;
                
                var res = _elements[parentPosition].CompareTo(_elements[i]);
                if(_elements[parentPosition].CompareTo(_elements[i]) < 0)
                {
                    SwapElements(parentPosition, i);
                }
            }
        }
    }

    public class MinHeap<T> : BinaryHeap<T> where T : IComparable<T>
    {
        protected override void Heapify()
        {
            for (int i = _elements.Count - 1; i > 0; i--)
            {
                int parentPosition = (i + 1) / 2 - 1;
                parentPosition = parentPosition >= 0 ? parentPosition : 0;

                var res = _elements[parentPosition].CompareTo(_elements[i]);
                if (_elements[parentPosition].CompareTo(_elements[i]) > 0)
                {
                    SwapElements(parentPosition, i);
                }
            }
        }
    }
}
