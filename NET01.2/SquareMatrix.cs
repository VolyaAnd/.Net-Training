using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace NET01._2
{ 
    /// <summary>
    /// This is a generic class for working with square martices
    /// </summary>
    /// <typeparam name="T"> This is a type parameter for generic class</typeparam>
    public class SquareMatrix<T>: Matrix<T>
    {
        public delegate void Notify(int i, int j, T oldValue);  //should I move to the matrix
        public event Notify ValueChanged;
        //private T[] squareMatrixArray;

        /// <summary>
        /// This is an indexer for working with square matrix for reading and writing the matrix elements.
        /// </summary>
        /// <param name="row">i = row</param>
        /// <param name="column">j = column</param>
        /// <returns></returns>
        public T this[int row, int column] 
        {

            get 
            {
                int i = GetIndex(row, column);
                return MatrixArray[i]; 
            }
            set 
            {
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
            int i = row * size + column;

            if (row > size)
                throw new IndexOutOfRangeException("Row can't be greater than matrix size.");

            if (column > size)
                throw new IndexOutOfRangeException("Column can't be greater than matrix size.");

            if (i >= MatrixArray.Length)
                throw new IndexOutOfRangeException($"The collection can hold only {MatrixArray.Length} elements.");
            return i;
        }

        public SquareMatrix(int sSize)
        {
            if (sSize < 0)
                throw new IndexOutOfRangeException("Matrix size can't be negative."); 
            size = sSize;
            MatrixArray = new T[size * size];
        }

        protected SquareMatrix()
        {

        }
    }
}
