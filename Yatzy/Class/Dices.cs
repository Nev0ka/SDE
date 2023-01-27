using System;
using System.Diagnostics.Metrics;

namespace Opgave_7.Class
{
    internal class Dices
    {
        public Dices()
        {
            numberOfSides = 6;
        }

        public Dices(int sides)
        {
            numberOfSides = sides;
        }

        public static int numberOfSides { get; set; }

        public static List<int> RollTheDices(int Dices)
        {
            List<int> Throws = new();
            Throws.Clear();
            Random rnd = new();
            if (Dices == 0)
            {
                return Throws;
            }

            for (int i = 0; i < Dices; i++)
            {
                Thread.Sleep(5);
                Throws.Add(rnd.Next(1, numberOfSides + 1));
            }

            return Throws;
        }

        
    }
}
