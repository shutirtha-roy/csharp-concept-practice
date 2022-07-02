﻿using System;
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
                //Console.WriteLine(digit);
            }

        }
        public void Excercise4()
        {
            //Write a program in C# Sharp to display the number
            //and frequency of number from giving array.
            //Expected Output:
            //The number and the Frequency are :
            //Number 5 appears 3 times
            //Number 9 appears 2 times
            //Number 1 appears 1 times

            int[] digits = new int[] { 1, 9, 5, 9, 5, 5 };

            var countDigits = from digit in digits
                              group digit by digit into g
                              orderby g.Count() descending
                              select new
                              {
                                  Digit = g.Key,
                                  CountDigit = g.Count()
                              };

            //foreach(var digit in countDigits)
            //{
            //    Console.WriteLine($"Number {digit.Digit} appears {digit.CountDigit} times");
            //}

        }
        public void Excercise5()
        {
            string fruit = "apple";

            var getCharacters = from character in fruit
                                group character by character into g
                                select new
                                {
                                    FruitCharacter = g.Key,
                                    FruitCharacterCount = g.Count()
                                };

            Console.WriteLine("The frequency of the characters are");
            foreach(var fruitCharacter in getCharacters)
            {
                Console.WriteLine(fruitCharacter);
            }

        }
        public void Excercise6()
        {
            //6.Write a program in C# Sharp to display
            //the name of the days of a week. 
            //Expected Output:
            //Sunday
            //Monday
            //Tuesday
            //Wednesday
            //Thursday
            //Friday
            //Saturday

            string[] weeks = new string[] { "Sunday", "Monday", "Tuesday"
                , "Wednesday", "Thursday", "Friday", "Saturday" };

            //var weekQuery1 = from week in weeks
            //                 select week;

            var weekQuery = weeks.Select(i => i );
            
            foreach(var week in weekQuery)
            {
                Console.WriteLine(week);
            }
        }
        public void Excercise7()
        {
            //7.Write a program in C# Sharp to display numbers, multiplication of number with frequency and frequency of a number of giving array. Go to the editor
            //Test Data:
            //The numbers in the array are:
            //5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2
            //Expected Output :
            //Number Number*Frequency Frequency
            //------------------------------------------------
            //5 15 3
            //1 1 1
            //9 9 1
            //2 4 2
            int[] arr = new int[] { 5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2 };
            var outputQuery = from value in arr
                              group value by value into g
                              select new
                              {
                                  Number = g.Key,
                                  Times = g.Key * g.Count(),
                                  Frequency = g.Count()
                              };

            foreach (var frequencyArray in outputQuery)
            {
                Console.WriteLine($"{frequencyArray.Number} {frequencyArray.Times} {frequencyArray.Frequency}");
            }
        }
        public void Excercise8()
        {
            //8.Write a program in C# Sharp to find the string which starts and ends with a specific character. Go to the editor
            //Test Data:
            //The cities are: 'ROME','LONDON','NAIROBI','CALIFORNIA','ZURICH','NEW DELHI','AMSTERDAM','ABU DHABI','PARIS'
            //Input starting character for the string : A
            //Input ending character for the string : M
            //Expected Output :
            //The city starting with A and ending with M is : AMSTERDAM
            string[] cities = new string[] 
            { 
                "ROME", "LONDON", "NAIROBI", "CALIFORNIA", "ZURICH", "NEW DELHI", "AMSTERDAM", "ABU DHABI", "PARIS" 
            };

            var cityQuery = from city in cities
                            where city.StartsWith('A') && city.EndsWith('M')
                            select city;

            Console.WriteLine(string.Join(" ", cityQuery));
        }
        public void Excercise9()
        {
            //9.Write a program in C# Sharp to create a list of numbers and display the numbers greater than 80 as output. Go to the editor
            //Test Data:
            //The members of the list are :
            //55 200 740 76 230 482 95
            //Expected Output :
            //The numbers greater than 80 are:
            //200
            //740
            //230
            //482
            //95
            int[] members = new int[] { 55, 200, 740, 76, 230, 482, 95 };

            var greaterMembers = from member in members
                                 where member > 80
                                 select member;

            foreach(var number in greaterMembers)
            {
                Console.WriteLine(number);
            }
        }
        public void Excercise10()
        {
            //10.Write a program in C# Sharp to accept the members of a list through the keyboard and display the members more than a specific value. Go to the editor
            //Test Data:
            //Input the number of members on the List : 5
            //Member 0 : 10
            //Member 1 : 48
            //Member 2 : 52
            //Member 3 : 94
            //Member 4 : 63
            //Input the value above you want to display the members of the List: 59
            //Expected Output :
            //The numbers greater than 59 are:
            //94
            //63

            Console.Write("Input the number of members on the List: ");
            var num = int.Parse(Console.ReadLine());
            int[] arr = new int[num];

            for(var i = 0; i < num; i++)
            {
                Console.Write($"Member {i} : ");
                arr[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("Input the value above you want to display the members of the List : ");
            var centerNum = int.Parse(Console.ReadLine());

            var nineteryQuery = from value in arr
                                where value > centerNum
                                select value;

            Console.WriteLine(string.Join(" ", nineteryQuery));
        }
    }
}
