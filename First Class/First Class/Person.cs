using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Class
{
    internal class Person
    {
        public string name { get; set; }

        public override string ToString()
        {
            return $"Hello! My name is {name}";
        }
    }
}
