using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllClasses
{
    class Student
    {
        public string name;
        public DateTime dateOfBirth;
        public double cgpa;
        public string address;

        public void UpdateCgpa(double newCgpa)
        {
            cgpa = newCgpa;
        }
    }
}
