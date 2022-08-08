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
        private double cgpa;
        public string address;
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
