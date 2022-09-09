using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
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
                MatrixArray[i] = value; 
            }
        }
        public SquareMatrix(int sSize)
        {
            if (sSize < 0)
                throw new IndexOutOfRangeException("Matrix size can't be negative."); 
            size = sSize;
            MatrixArray = new T[size * size];
        }
    }
}
