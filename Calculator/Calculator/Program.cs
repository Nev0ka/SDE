using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Calculator());
            Console.Read();
        }

        static double Calculator()
        {
            double result = 0;
            Console.WriteLine("What is your equation:");
            string equation = Console.ReadLine();
            List<string> spilt = equation.Split(' ').ToList();
            List<string> spiltwow = equation.Split(' ').ToList();


            foreach (string item in spiltwow)
            {
                if (spilt.Contains("*"))
                {
                    int index = spilt.IndexOf("*");
                    result = Multiply(Convert.ToDouble(spilt[index - 1]), Convert.ToDouble(spilt[index + 1]));
                    spilt[index - 1] = " ";
                    spilt[index] = " ";
                    spilt[index + 1] = result.ToString();
                }
                else if (spilt.Contains("/"))
                {
                    int index = spilt.IndexOf("/");
                    result = Divide(Convert.ToDouble(spilt[index - 1]), Convert.ToDouble(spilt[index + 1]));
                    spilt[index - 1] = " ";
                    spilt[index] = " ";
                    spilt[index + 1] = result.ToString();
                }
                for (int i = 0; i < spilt.Count; i++)
                {
                    spilt.Remove(" ");
                }
            }

            foreach (string item in spiltwow)
            {
                if (item == "+" || item == "-")
                {
                    int index = 1;
                    switch (item)
                    {
                        case "+":
                            {
                                result = Add(Convert.ToDouble(spilt[index - 1]), Convert.ToDouble(spilt[index + 1]));
                                spilt[index - 1] = " ";
                                spilt[index] = " ";
                                spilt[index + 1] = result.ToString();
                                break;
                            }
                        case "-":
                            {
                                result = Minus(Convert.ToDouble(spilt[index - 1]), Convert.ToDouble(spilt[index + 1]));
                                spilt[index - 1] = " ";
                                spilt[index] = " ";
                                spilt[index + 1] = result.ToString();
                                break;
                            }
                        default:
                            break;
                    }
                    for (int i = 0; i < spilt.Count; i++)
                    {
                        spilt.Remove(" ");
                    }
                }
            }
            return result;
        }

        static double Add(double first, double second)
        {
            return first + second;
        }

        static double Minus(double first, double second)
        {
            return first - second;
        }

        static double Multiply(double first, double second)
        {
            return first * second;
        }

        static double Divide(double first, double second)
        {
            if (second == 0)
            {
                throw new ArgumentException("Don't divide with 0");
            }
            return first / second;
        }
    }
}
