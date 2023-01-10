using System;
using System.Linq;

namespace Opgave_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = { 2, 7, 12 };
            int[] sort = { 1, 10, 3};

            Console.WriteLine(AbsoluteValue(-20));
            Console.WriteLine(DivisbleBy2Or3(15, 30));
            Console.WriteLine(CheckForUppercase("pog"));
            Console.WriteLine(GreaterThan(ints));
            Console.WriteLine(CheckIfEven(10));
            Console.WriteLine(SortedAscending(sort));
            Console.WriteLine(PosZeNeg(0));
            Console.WriteLine(IfLeapYear(2021));
            Console.ReadLine();
        }

        public static int AbsoluteValue(int firstNumber)
        {
            firstNumber = Math.Abs(firstNumber);
            return firstNumber;
        }

        public static int DivisbleBy2Or3(int firstNumber, int secondNumber)
        {
            if((firstNumber % 2) == 0 && (secondNumber % 2) == 0)
            {
                return (firstNumber * secondNumber);
            } else if((firstNumber % 3) == 0 && (secondNumber % 3) == 0)
            {
                return (firstNumber * secondNumber);
            }

            return firstNumber + secondNumber;
        }

        public static bool CheckForUppercase(string word)
        {
            return word.Any(char.IsUpper);
        }

        public static bool GreaterThan(int[] numbers)
        {
            int sum = numbers[0] + numbers[1];
            int multiply = numbers[0] * numbers[1];

            if(sum <= numbers[2])
            {
                return true;
            } else if(sum > numbers[2])
            {
                return false;
            } else if(multiply <= numbers[2])
            {
                return true;
            } else {
                return false;
            }
        }

        public static bool CheckIfEven(int number)
        {
            if(number % 2 == 0)
            {
                return true;
            }
            return false;
        }

        public static bool SortedAscending(int[] numbers)
        {
            int last = int.MinValue;
            foreach(int x in numbers)
            {
                if(x < last)
                {
                    return false;
                }
                last = x;
            }
            return true;
        }

        public static string PosZeNeg(int number)
        {
            if (number < 0)
            {
                return "Negative";
            }
            else if (number == 0)
            {
                return "Zero";
            }
            else
            {
                return "Positive";
            }
        }

        public static bool IfLeapYear(int year)
        {
            return year % 4 == 0;
        }
    }
}
