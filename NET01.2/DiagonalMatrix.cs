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
    public class DiagonalMatrix<T>: Matrix<T>
    {

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
                MatrixArray[i] = value;
            }
        }

        public DiagonalMatrix(int dSize)
        {
            if (dSize < 0)
                throw new IndexOutOfRangeException("Matrix size can't be negative."); 
            size = dSize;
            MatrixArray = new T[size];  //without multiplication
        }
    }
}
