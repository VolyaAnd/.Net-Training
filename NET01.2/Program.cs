namespace NET01._2
{
    class Program
    {
        static void Main(string[] args)
        {

            DiagonalMatrix<int> dMatrix1 = new DiagonalMatrix<int>(4);
            dMatrix1[2, 2] = 3;
            int dVal = dMatrix1[2, 2];
            Console.WriteLine(dVal);

            SquareMatrix<int> sMatrix1 = new SquareMatrix<int>(3);
            sMatrix1[1, 2] = 8;  
            int sVal = sMatrix1[1,2];
            int sVal1 = sMatrix1[1,1];
            Console.WriteLine(sVal);
            Console.WriteLine(sVal1);

        }
    }
}
