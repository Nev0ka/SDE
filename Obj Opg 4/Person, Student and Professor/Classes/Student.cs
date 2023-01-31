using System;

namespace Person__Student_and_Professor.Classes
{
    internal class Student : Person
    {
        public string Study()
        {
            return "I'm studying";
        }

        public string ShowAge()
        {
            Person howOld = new Person();
            return $"I am: {howOld.SetAge(21)} years old";
        }
    }
}
