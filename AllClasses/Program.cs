using System;

namespace AllClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
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

        }
    }
}
