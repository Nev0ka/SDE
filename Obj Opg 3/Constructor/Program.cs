using System;

namespace Constructor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[3];
            Console.WriteLine("Input 3 names:");
            string[] Names = Console.ReadLine().Split(' ', ',');
            people[0] = new Person(Names[0]);
            people[1] = new Person(Names[1]);
            people[2] = new Person(Names[2]);

            Console.WriteLine(people[0].ToString());
            Console.WriteLine(people[1].ToString());
            Console.WriteLine(people[2].ToString());
            Console.Read();
        }
    }
}
