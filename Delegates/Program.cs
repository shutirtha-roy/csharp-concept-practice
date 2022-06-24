using System;

namespace Delegates
{
    class Program
    {
        #region Delegates

        public delegate int Operation(int x, int y);
        public delegate void MyDelegate(string msg);
        public delegate int MyDelegateInt();
        public delegate T magic<T>(T param1, T param2);

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

        public static int Sub(int numOne, int numTwo)
        {
            return numOne + numTwo;
        }

        public static string LinkString(string strOne, string strTwo)
        {
            return strOne + strTwo;
        }

        #endregion
        #region Func Delegate 
        public static int Division(int x, int y)
        {
            return x / y;
        }

        #endregion
        #region Action Delegate
        
        public static void PrintValue(string value)
        {
            Console.WriteLine(value);
        }

        #endregion

        public static void Main(string[] args)
        {
            #region Delegates

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
            //Console.WriteLine(threeHundred.Invoke());

            #endregion
            #region Generic Delegate
            magic<int> subtract = Sub;
            //Console.WriteLine(subtract.Invoke(1, 2));

            magic<string> concatOne = LinkString;
            //Console.WriteLine(concatOne("Hello ", "World"));
            #endregion

            #endregion
            #region Func Delegate
            Func<int, int, int> div = Division;
            int output = div(10, 2);
            //Console.WriteLine(output);

            //Func with Anonymous Method
            Func<int> getHundred = delegate ()
                                {
                                    return 100;
                                };

            //Console.WriteLine(getHundred());


            //Func with Lambda Expression
            Func<int> getTwoHundred = () => 200;
            //Console.WriteLine(getTwoHundred());


            #endregion

            #region Action Delegate
            //Action<string> voidValue = new Action<string>(PrintValue);
            Action<string> voidValue = PrintValue;
            //voidValue("Hello");

            //Anonymous method with Action delegate
            Action<string> laughOutput = delegate (string value)
                                        {
                                            Console.WriteLine(value);
                                        };

            //laughOutput("Hahaha");

            //Lambda expression with Action delegate
            Action<string> cryOutput = (string value) => Console.WriteLine(value);
            //cryOutput("Owa owa");

            #endregion
        }
    }
}
