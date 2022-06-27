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
    }
}
