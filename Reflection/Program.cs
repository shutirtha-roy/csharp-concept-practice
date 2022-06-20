using System;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //Type T = Type.GetType("Reflection.Customer");
            //Type T = typeof(Customer);
            Customer c1 = new Customer();
            Type T = c1.GetType();
            Console.WriteLine("Full Name = " + T.FullName);
            Console.WriteLine("Just the Name = " + T.Name);
            Console.WriteLine("Just the Namespace = " + T.Namespace);
            Console.WriteLine();

            #region Properties
            Console.WriteLine("Properties in Customers");
            PropertyInfo[] properties = T.GetProperties();
            foreach(PropertyInfo property in properties)
            {
                Console.WriteLine(property.PropertyType.Name + " " + property.Name);
            }
            #endregion
            #region Methods
            Console.WriteLine("Methods in Customers class");
            MethodInfo[] methods = T.GetMethods();
            foreach(MethodInfo method in methods)
            {
                Console.WriteLine(method.ReturnType.Name + " " + method.Name);
            }
            #endregion
            #region Constructors
            Console.WriteLine("Constructors in Customers class");
            ConstructorInfo[] constructors = T.GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
            {
                Console.WriteLine(constructor.ToString());
            }
            #endregion
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
