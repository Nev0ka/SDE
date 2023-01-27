using Opgave_7.Class;

namespace Opgave_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Yatzy yatzy = new();
            yatzy.StartGame();
            Console.Read();
        }
    }
}