using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Describe the event that occurs after changing the element of the matrix with indices (i, j).

namespace NET01._2
{
    /// <summary>
    /// This is a base class for working with matrices
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Matrix<T>
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
        
        protected abstract int GetIndex(int row, int column);
    }
}
