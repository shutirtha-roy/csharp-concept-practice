﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllClasses
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        protected readonly string idPrefix;
        public string GenerateId()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                return $"{idPrefix}-{Name.Substring(0, 2)}";
            }
            else
            {
                return null;
            }
        }

        public Person(string idPrefix)
        {
            this.idPrefix = idPrefix;
        }
    }
}
