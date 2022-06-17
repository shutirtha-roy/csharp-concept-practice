using System;

namespace Delegates
{
    class Program
    {
        public delegate int Operation(int x, int y);
        public delegate void MyDelegate(string msg);
        public delegate int MyDelegateInt();

        public static int Addition(int a, int b)
        {
            return a + b;
        }

        public static int Subtraction(int a, int b)
        {
            return Math.Abs(a - b);
        }

        public static void FunnyMessageMethod(string msg)
        {
            Console.WriteLine("Let's Laugh: " + msg);
        }

        public static void AngryMessageMethod(string msg)
        {
            Console.WriteLine("You are angry: " + msg);
        }

        public static int HundredMethod()
        {
            return 100;
        }

        public static int TwoHundredMethod()
        {
            return 200;
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
            #region Multicast Delegate
            MyDelegate deligateFunnyMessage = FunnyMessageMethod;
            MyDelegate deligateAngryMessage = AngryMessageMethod;

            MyDelegate deligateFunnyAngryMessage = deligateFunnyMessage + deligateAngryMessage;
            //deligateFunnyAngryMessage("Roy");

            MyDelegate deligateCoolMessage = (string msg) =>
            {
                Console.WriteLine("Cool");
                Console.WriteLine("It is fun");
            };

            deligateFunnyAngryMessage += deligateCoolMessage;
            //deligateFunnyAngryMessage("Roy");

            deligateFunnyAngryMessage -= deligateFunnyMessage;
            //deligateFunnyAngryMessage("Roy");
            #endregion
            #region Multicast Delegate Returning a Value
            MyDelegateInt hundred = HundredMethod;
            MyDelegateInt twoHundred = TwoHundredMethod;

            MyDelegateInt threeHundred = hundred + twoHundred;
            Console.WriteLine(threeHundred());


            #endregion


        }
    }
}
