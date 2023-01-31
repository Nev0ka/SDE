namespace Constructor
{
    internal class Person
    {
        public string name { get; set; }

        public Person(string peopleName)
        {
            name = peopleName;
        }

        public override string ToString()
        {
            return $"Hello! My name is {name}";
        }
    }
}
