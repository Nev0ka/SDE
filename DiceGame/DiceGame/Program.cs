using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    internal class Program
    {
        static Random ran = new Random();
        static List<int> numbers = new List<int>();
        static int count = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("How many dices do you want to throw?");
            int throws = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(dice(throws));
            Console.Read();
        }

        public static long dice(int throws)
        {
            while (true) {
                numbers.Clear();
                for (int i = 0; i < throws; i++)
                {
                    numbers.Add(ran.Next(1, 7));
                }
                //set numbers to false if x is true, and if x is false set numbers to true
                if (!numbers.Any(x => x != 6))
                {
                    break;
                }
                count++;
            }
            return count;
        }
    }
}
