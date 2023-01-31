using Person__Student_and_Professor.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person__Student_and_Professor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person people = new Person();
            Console.WriteLine(people.Greet());
            Student stu = new Student();
            Console.WriteLine(stu.Greet());
            Console.WriteLine(stu.ShowAge());
            Professor teacher = new Professor();
            Console.WriteLine(teacher.Greet());
            Console.WriteLine(teacher.Explain());
            Console.Read();
        }
    }
}
