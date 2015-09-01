using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.DS
{
    public class SparseMatrix<T>
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public long Size { get; private set; }

        private readonly IDictionary<long, T> cells = new Dictionary<long, T>();

        public SparseMatrix(int width, int height)
        {
            Width = width;
            Height = height;
            Size = Width * Height;
        }

        public bool IsCellEmpty(int row, int col)
        {
            long index = row * Width + col;
            return cells.ContainsKey(index);
        }

        public T this[int row, int col]
        {
            get
            {
                long index = row * Width + col;
                T result;
                cells.TryGetValue(index, out result);
                return result;
            }
            set
            {
                long index = row * Width + col;
                cells[index] = value;
            }
        }
    }
}
