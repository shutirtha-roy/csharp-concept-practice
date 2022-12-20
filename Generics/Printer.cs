using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public static class Printer<X>
    {
        public static void Print<T>(T item) where T : struct
        {
            T x = default(T);
            X a = default(X);
            Console.WriteLine(item.ToString());
        }

        public static void Revert()
        {
            //T t = default(T);
            X x = default(X);
        }
    }
}
