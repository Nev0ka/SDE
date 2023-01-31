using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[3];
            Console.WriteLine("Input 3 random names:");
            string[] Names = Console.ReadLine().Split(' ', ',');
            people[0] = new Person() { name = Names[0] };
            people[1] = new Person() { name = Names[1] };
            people[2] = new Person() { name = Names[2] };

            Console.WriteLine(people[0].ToString());
            Console.WriteLine(people[1].ToString());
            Console.WriteLine(people[2].ToString());
            Console.Read();
        }
    }
}
