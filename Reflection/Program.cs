using System;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var specialProduct = Test<SpecialProduct>();
            specialProduct.Price = 500;
            Console.WriteLine(specialProduct.PriceAfterDiscount(20));


            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();

            var sr = 1;
            Console.WriteLine("Please select a product");
            foreach(var type in types)
            {
                if(type.Name.Contains("Product"))
                    Console.WriteLine($"{sr++} {type.Name}");
            }

            var selectedProduct = Console.ReadLine();

            Console.WriteLine("Please provide price & discount");
            var price = double.Parse(Console.ReadLine());
            var discount = double.Parse(Console.ReadLine());

            foreach(var type in types)
            {
                if(type.Name == selectedProduct)
                {
                    ConstructorInfo constructor = type.GetConstructor(new Type[] { });
                    var item = constructor.Invoke(new object[] { });

                    PropertyInfo p = type.GetProperty("Price");
                    p.SetValue(item, price);

                    MethodInfo method = type.GetMethod("PriceAfterDiscount", new Type[] { typeof(double) });
                    var priceAfterDiscount = method.Invoke(item, new object[] { discount });
                    //BindingFlags.Public | BindingFlags.Instance
                    Console.WriteLine(priceAfterDiscount);
                    break;
                }
            }


            //Type T = Type.GetType("Reflection.Customer");
            //Type T = typeof(Customer);
            //Customer c1 = new Customer();
            //Type T = c1.GetType();
            //Console.WriteLine("Full Name = " + T.FullName);
            //Console.WriteLine("Just the Name = " + T.Name);
            //Console.WriteLine("Just the Namespace = " + T.Namespace);
            //Console.WriteLine();

            #region Properties
            //Console.WriteLine("Properties in Customers");
            //PropertyInfo[] properties = T.GetProperties();
            //foreach(PropertyInfo property in properties)
            //{
            //    //Console.WriteLine(property.PropertyType.Name + " " + property.Name);
            //}
            #endregion
            #region Methods
            //Console.WriteLine("Methods in Customers class");
            //MethodInfo[] methods = T.GetMethods();
            //foreach(MethodInfo method in methods)
            //{
            //    Console.WriteLine(method.ReturnType.Name + " " + method.Name);
            //}
            #endregion
            #region Constructors
            //Console.WriteLine("Constructors in Customers class");
            //ConstructorInfo[] constructors = T.GetConstructors();
            //foreach (ConstructorInfo constructor in constructors)
            //{
            //    Console.WriteLine(constructor.ToString());
            //}
            #endregion

        }

        public static T Test<T>()
        {
            Type t = typeof(T);
            ConstructorInfo constructor = t.GetConstructor(new Type[] { });
            var item = constructor.Invoke(new object[] { });
            return (T)item;
        }

    }

    
}
