using System;

namespace AllClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            student.name = "Roy";
            student.cgpa = 3.4;
            student.address = "Dhaka";
            student.dateOfBirth = new DateTime(1999, 2, 2);

            student.UpdateCgpa(3.76);


            Student student2 = new Student();
            student2.cgpa = 3.5;
            student2.name = "Samin";
            student2.UpdateCgpa(3.99);

        }
    }
}
