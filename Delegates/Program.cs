using System;

namespace Delegates
{
    class Program
    {
        public delegate int Operation(int x, int y);
        public delegate void MyDelegate(string msg);

        public static int Addition(int a, int b)
        {
            return a + b;
        }

        public static int Subtraction(int a, int b)
        {
            return Math.Abs(a - b);
        }

        public static void Main(string[] args)
        {
            #region Passing Delegate as a Parameter
            //Operation newOperationAddition = new Operation(Addition);
            Operation newOperationAddition = Addition;
            //newOperationAddition = (int a, int b) => a + b;
            //Console.WriteLine($"Addition: {newOperationAddition.Invoke(5, 2)}");

            //Operation newOperationSubtration = new Operation(Subtraction);
            Operation newOperationSubtration = Subtraction;
            //newOperationSubtration = (int a, int b) => a - b;
            //Console.WriteLine($"Subtration: {newOperationSubtration.Invoke(5, 2)}");
            #endregion
            #region Delegate


            #endregion



        }
    }
}
