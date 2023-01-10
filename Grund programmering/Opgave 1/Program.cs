using System;

namespace Opgave_1
{
    internal class Program
    {
        const float FahrenheitConversion = 1.8f;
        static void Main(string[] args)
        {
            Console.WriteLine(AddandMultiplyThreeNumber(2, 4, 5));
            Console.WriteLine(FromCelsiusToFahrenheit(40));
            Console.WriteLine(CheckIfTrue(2 + 2, 2 * 2));
            Console.WriteLine(Modelo(8, 5, 2));
            Console.WriteLine(CubeOf(2));
            Console.WriteLine(swapper(87, 45));
            Console.ReadLine();
        }

        public static int AddandMultiplyThreeNumber(int firstNumber, int secondNumber, int thirdNumber)
        {
            int output = (firstNumber + secondNumber) * thirdNumber;
            return output;
        }

        public static float FromCelsiusToFahrenheit(float Celsius)
        {
            return (FahrenheitConversion * Celsius + 32);
        }

        public static bool CheckIfTrue(int firstNumber, int secondNumber)
        {
            if(firstNumber != secondNumber)
            {
                return false;
            }

            return true;
        }

        public static int Modelo(int firstNumber, int secondNumber, int thirdNumber)
        {
            return firstNumber % secondNumber % thirdNumber;
        }

        public static double CubeOf(int firstNumber)
        {
            return (double) Math.Pow(firstNumber, 3);
        }

        public static string swapper(int firstNumber, int secondNumber)
        {
            string result = "Before a= " + firstNumber + " b= " + secondNumber;
            int swap = firstNumber;
            firstNumber = secondNumber;
            secondNumber = swap;
            return result += " After a= " + firstNumber + " b= " + secondNumber;
        }
    }
}