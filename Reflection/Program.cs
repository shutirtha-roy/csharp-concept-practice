using System;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Type T = Type.GetType("Reflection.Customer");
            Console.WriteLine("Full Name " + T.FullName);
            Console.WriteLine("Just the Name " + T.Name);
            Console.WriteLine("Just the Namespace " + T.Namespace);

            PropertyInfo[] properties = T.GetProperties();

            foreach(PropertyInfo property in properties)
            {
                Console.WriteLine(property.PropertyType.Name + " " + property.Name);
            }
        }

    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Customer(int ID, string Name)
        {
            this.Id = ID;
            this.Name = Name;
        }

        public Customer()
        {
            this.Id = -1;
            this.Name = string.Empty;
        }

        public void PrintID()
        {
            Console.WriteLine("ID = {0}", this.Id);
        }

        public void PrintName()
        {
            Console.WriteLine("Name = {0}", this.Name);
        }
    }
}
