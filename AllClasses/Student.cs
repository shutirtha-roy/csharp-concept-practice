using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllClasses
{
    class Student
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        private double cgpa;
        public string Address { get; set; }
        public double Cgpa
        {
            get
            {
                return cgpa;
            }
            set
            {
                if (value >= 0)
                    cgpa = value;
            }
        }
    }
}
