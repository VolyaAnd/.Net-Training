using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._2
{
    /// <summary>
    /// This is a generic class for working with diagonal martices
    /// </summary>
    /// <typeparam name="T"> This is a type parameter for generic class</typeparam>
    public class DiagonalMatrix<T>: SquareMatrix<T>
    {
        public delegate void Notify(int i, int j, T oldValue);  //should I move to the matrix
        public event Notify ValueChanged;

        //private T[] diagonalMatrixArray;

        /// <summary>
        /// This is an indexer for working with diagonal matrix for reading and writing the matrix elements.
        /// </summary>
        /// <param name="row">i = row</param>
        /// <param name="column">j = column</param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException">This exception is thrown when you are trying to set a value which is not diagonal.</exception>
        public T this[int row, int column] 
        {

            get
            {
                int i = GetIndex(row, column);
                if (row != column)
                {
                    return default(T);
                }
                return MatrixArray[i];
            }
            set
            {
                if (row != column)
                {
                    throw new IndexOutOfRangeException("You can set only diagonal value.");
                }
                int i = GetIndex(row, column);
                T old = MatrixArray[i];
                MatrixArray[i] = value;
                if (!value.Equals(old))
                {
                    ValueChanged?.Invoke(i, i, old);
                }
            }
        }

        protected override int GetIndex(int row, int column)
        {
            int i = row;

            if (row > size)
                throw new IndexOutOfRangeException("Row can't be greater than matrix size.");

            if (column > size)
                throw new IndexOutOfRangeException("Column can't be greater than matrix size.");

            if (i >= MatrixArray.Length)
                throw new IndexOutOfRangeException($"The collection can hold only {MatrixArray.Length} elements.");
            return i;
        }

        public DiagonalMatrix(int dSize): base() 
        {
            if (dSize < 0)
                throw new IndexOutOfRangeException("Matrix size can't be negative."); 
            size = dSize;
            MatrixArray = new T[size];  //without multiplication
        }
    }
}
