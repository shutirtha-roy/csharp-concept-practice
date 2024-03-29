﻿using System;
using AllClasses;
using CommonCode;

namespace AllClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Calling class with constructor parameters and properties
            Student student = new Student("Antu", 3.6, "Dhaka", new DateTime(1989, 2, 4));
            student.Name = "Roy";
            student.Cgpa = 3.3;
            student.Address = "Dhaka";
            student.DateOfBirth = new DateTime(1999, 2, 2);

            student.Cgpa = 3.76;

            Console.WriteLine(student.Cgpa);

            Student student2 = new Student();
            student.Cgpa = 3.2;
            student2.Name = "Samin";
            student2.Cgpa = 3.99;
            #endregion

            #region Static class and alternative instance of static

            var circleArea = AreaCalculator.GetCircleArea(20.5);
            var rectangleArea = AreaCalculator.GetRectangle(24, 12);

            Circle c = new Circle();
            c.Radius = 5;
            Console.WriteLine(c.GetArea());
            #endregion

            #region Calling Class Library
            //Course can only be accessed if it is public
            Course course = new Course();
            course.Title = "C++";
            Console.WriteLine(course.Title);
            #endregion
        }
    }
}




namespace Something
{
    public class Test
    {
        public static void TestMethod()
        {
            Student s1 = new Student();
        }
    }
}
