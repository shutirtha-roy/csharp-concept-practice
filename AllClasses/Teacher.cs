using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllClasses
{
    public class Teacher : Person
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Teacher()
        {
            IdPrefix = "TC";
        }
        
    }
}
