using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllClasses
{
    public static class AreaCalculator
    {
        public static int count;
        public static string Name { get; set; }

        public static double GetCircleArea(double radius)
        {
            return Math.PI * radius * radius;
        }

        public static double GetRectangle(double width, double height)
        {
            return width * height;
        }
    }
}
