using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ;
using System.Collections;

namespace LINQ
{
    public class LINQProblemw3
    {
        public void Excercise1()
        {
            //Write a program in C# Sharp to shows how the three parts
            //of a query operation execute. Go to the editor
            //Expected Output:
            //The numbers which produce the remainder 0 after divided by 2 are:
            //0 2 4 6 8

            IList<int> values = new List<int>() { 0, 1, 2, 3, 4, 5 };
            //Console.WriteLine($"Excercise 1: {string.Join(" ", values.Where(value => value % 2 == 0))}");

            Console.WriteLine(string.Join(" ",from value in values 
                              where value % 2 == 0 
                              select value)
                             );
        }
        public void Excercise2()
        {
            //Write a program in C# Sharp to find the +ve numbers from a
            //list of numbers using two where conditions in LINQ Query.
            //Expected Output:
            //The numbers within the range of 1 to 11 are:
            //1 3 6 9 10
            IList<int> values = Enumerable.Range(-11, 20).ToList();
            //Console.WriteLine($"Excercise 2: {string.Join(" ", values.Where(value => value > 0).ToList())}");
            Console.WriteLine(string.Join(" ", from value in values
                                               where value > 0
                                               select value));
        }
        public void Excercise3()
        {
            //Write a program in C# Sharp to find the number of an array 
            //and the square of each number. Go to the editor
            //Expected Output:
            //{ Number = 9, SqrNo = 81 }
            //{ Number = 8, SqrNo = 64 }
            //{ Number = 6, SqrNo = 36 }
            //{ Number = 5, SqrNo = 25 }
            int[] digits = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var newDigits = from digit in digits
                            select new
                            {
                                Number = digit,
                                SqrNo = (digit << 2)
                            };

            //foreach(var digit in newDigits)
            //{
            //    Console.WriteLine(digit);
            //}

            var newDigits1 = from digit in digits
                                let SqrNo = (digit << 2)
                                //let index = digit - 1
                                select new 
                                {
                                    digit, 
                                    SqrNo ,
                                    //index
                                };

            foreach (var digit in newDigits1)
            {
                Console.WriteLine(digit);
            }

        }
    }
}
