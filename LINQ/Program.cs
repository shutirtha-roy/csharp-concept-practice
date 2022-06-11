using System;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //Basic Concepts
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };


            //LINQ Query Syntax
            Console.WriteLine("Query Syntax");
            var evenNumbers = (from num in numbers
                               where num % 2 == 0
                               select num).ToArray();
            Console.WriteLine($"Even numbers are {string.Join(" ", evenNumbers)}");

            //LINQ Method Syntax
            Console.WriteLine("Method Syntax");
            var oddNumbers = numbers.Where(num => num % 2 == 1).ToArray();
            Console.WriteLine($"Odd numbers are {string.Join(" ", oddNumbers)}");
        }
    }
}
