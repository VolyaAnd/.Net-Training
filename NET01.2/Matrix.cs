using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._2
{
    /// <summary>
    /// This is a base class for working with matrices
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Matrix<T>
    {
        protected int size;
        protected T[] MatrixArray;

        
        public Matrix()
        {
           
        }
        

        /// <summary>
        /// This is a method which calculares the value's index in the array and checks if passed parameters are correct
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"> Throwing an exception when incorrect parameters are passed to the method.</exception>
        protected int GetIndex(int row, int column)
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
    }
}
