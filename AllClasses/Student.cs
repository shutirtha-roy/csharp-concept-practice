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
        private readonly string studentId;
        public const double MAX_CGPA = 4.0;
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

        //When there is no constructor it can be called invisible default constructor

        //Empty Constructor
        public Student()
            : this (string.Empty, 0, string.Empty, DateTime.MinValue)
            //this (parameters) is called constructor chaining
        {
        }

        public Student(string name, double cgpa, string address, DateTime dateofBirth)
        {
            Name = name;
            Address = address;
            DateOfBirth = dateofBirth;
            studentId = name.ToUpper().Substring(0, 2) + dateofBirth.Year;
        }

        //Destructor
        ~Student()
        {

        }

        //Method overloading
        public void UpdateDetails(DateTime dateOfBirth)
        {
            DateOfBirth = dateOfBirth;
        }
        public void UpdateDetails(string name, string address)
        {

        }
        public void UpdateDetails(string name, DateTime dateOfBirth)
        {

        }
        public void UpdateDetails(DateTime dateOfBirth, string name)
        {

        }

        //More Examples
        //We can add one product or multiple products
        //public void AddProduct(Product product)
        //{

        //}
        //public void AddProduct(Product[] products)
        //{

        //}
    }
}
