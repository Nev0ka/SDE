using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Opgave_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = { 5, 1, 8, -1 };
            int[] seven = { 7, 7, 1, 8, 3, 7, 7, 7, 9 };
            int[] adjacent = { 7, 3, 5, 8, 9, 3, 1, 4 };

            MultiplyTable();
            Console.WriteLine(BiggestNumber(ints));
            Console.WriteLine(Two7sNextToEachOther(seven));
            Console.WriteLine(CheckAdjacent(adjacent));
            foreach (var i in Sieve(50))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(ExtractSub("++##--##++"));
            Console.WriteLine(FullSequences("bn"));
            Console.WriteLine(SumAndAverage(11, 66));
            DrawTriangle();
            Console.WriteLine(ToThePowerOf(-2, 3));
            Console.ReadLine();
        }

        public static void MultiplyTable()
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Console.Write((i * j).ToString() + "\t");
                }
                Console.WriteLine();
            }
        }

        public static int BiggestNumber(int[] number)
        {
            return number.Max();
        }

        public static int Two7sNextToEachOther(int[] number)
        {
            int first = 0;
            int counter = 0;
            foreach (int item in number)
            {
                if (item == 7 && first == 7)
                {
                    counter++;
                }
                first = item;
            }
            return counter;
        }

        public static bool CheckAdjacent(int[] numbers)
        {
            for(int i = 0; i <= numbers.Length -3; i++)
            {
                if (numbers[i] == numbers[i + 1] -1 && numbers[i] == numbers[i + 2] -2)
                {
                    return true;
                }
            }
            return false;
        }

        public static List<int> Sieve(int numbers)
        {
            List<int> prime = new List<int> { };
            for (int i = 2; i <= numbers; i++)
            {
                int isPrime = 1;

                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = 0;
                    }
                }

                if (isPrime == 1)
                {
                    prime.Add(i);
                }
            }
            return prime;
        }

        public static string ExtractSub(string str)
        {
            int first = str.IndexOf("##") + 2;
            int second = str.IndexOf("##", first);
            string sub = str.Substring(first, second - first);
            return sub;
        }

        public static string FullSequences(string letter)
        {
            string alpahabet = "abcdefghijklmnopqrstuvwxyz";
            int first = alpahabet.IndexOf(letter[0]);
            int sec = alpahabet.IndexOf(letter[1]);
            return alpahabet.Substring(first, sec - first + 1);
        }

        public static string SumAndAverage(int first, int sec)
        {
            int sum = 0;
            float average = 0;
            int count = 0;

            for(int i = first; i <= sec; i++)
            {
                sum += i;
                count++;
            }

            average = (float)sum / count;

            return $"Sum: {sum}, and average: {average}";
        }

        public static void DrawTriangle()
        {
            string star = "*";
            int i;
            for (i = 1; i <= 10; i++)
            {
                Console.WriteLine(star);
                star += "*";
            }
        }

        public static double ToThePowerOf(float first, float second)
        {
            return (double) Math.Pow(first, second);
        }
    }
}
