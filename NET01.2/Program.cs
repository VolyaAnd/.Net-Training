namespace NET01._2
{
    class Program
    {
        public static void MyFunction(int i, int j, int oldValue)
        {
            Console.WriteLine($"row = {i}, column = {j}, old value = {oldValue}");
        }
        static void Main(string[] args)
        {
            try
            {
                DiagonalMatrix<int> dMatrix1 = new DiagonalMatrix<int>(4);
                dMatrix1.ValueChanged += MyFunction;
                dMatrix1[2, 2] = 3;
                int dVal = dMatrix1[2, 2];
                Console.WriteLine(dVal);

                SquareMatrix<int> sMatrix1 = new SquareMatrix<int>(3);
                sMatrix1.ValueChanged += MyFunction;
                sMatrix1[1, 2] = 8;
                int sVal = sMatrix1[1, 2];
                int sVal1 = sMatrix1[1, 1];
                Console.WriteLine(sVal); //8
                Console.WriteLine(sVal1); //0
            }
            catch(IndexOutOfRangeException ex)
            {
                System.Console.WriteLine(ex.Message);
            }

        }
    }
}
