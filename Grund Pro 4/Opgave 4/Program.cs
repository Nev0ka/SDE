using System;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;

namespace Opgave_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AddSeperator("ABCD", "*"));
            Console.WriteLine(Palindrome("eye"));
            Console.WriteLine(LengthOfStr("Ice Cream"));
            Console.WriteLine(ReverseString("qwerty"));
            Console.WriteLine(CountWords("This is sample sentence"));
            Console.WriteLine(RevertWords("A, B. C"));
            Console.WriteLine(Occurrences("do it now do", "do"));
            Console.WriteLine(CharDescending("fohjwf42os"));
            Console.WriteLine(CompressStr("kkkktttrrrrrrrrrr"));
            Console.ReadLine();
        }

        public static string AddSeperator(string word, string separator)
        {
            string newWord = string.Empty;
            for (int i = 0; i < word.Length; i++)
            {
                newWord += word[i] + separator;
            }
            return newWord;
        }

        public static bool Palindrome(string word)
        {
            string first = word.Substring(0, word.Length / 2);
            char[] Palin = word.ToCharArray();

            Array.Reverse(Palin);

            string newWord = new string(Palin);
            string second = newWord.Substring(0, newWord.Length / 2);

            return first.Equals(second);
        }

        public static int LengthOfStr(string word)
        {
            //return word.Length;

            int counter = 0;
            foreach (char c in word.ToCharArray())
            {
                counter++;
            }
            return counter;
        }

        public static string ReverseString(string word)
        {
            char[] chars = word.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        public static int CountWords(string word)
        {
            return word.Trim().Split(' ').Length;
        }

        public static string RevertWords(string word)
        {
            bool punctum = false;
            if (word[word.Length - 1] == '.')
            {
                punctum = true;
            }

            string[] order = word.Trim().TrimEnd('.').Split(' ');
            int length = order.Length;
            Array.Reverse(order);
            word = string.Empty;

            for (int i = 0; i < length; i++)
            {
                word += order[i] + " ";
            }
            if (punctum)
            {
                word = word.Trim();
                word += ".";
            }
            return word;
        }

        public static int Occurrences(string str, string subStr)
        {
            int count = Regex.Matches(str, subStr).Count;
            return count;
        }

        public static string CharDescending(string word)
        {
            char[] sortedWord = word.ToCharArray();
            Array.Sort(sortedWord);
            Array.Reverse(sortedWord);
            return new string(sortedWord);
        }

        public static string CompressStr(string str)
        {
            char[] chars = str.ToCharArray();
            int counter = 1;
            string result = string.Empty;
            
            for (int i = 0; i < chars.Length;i++)
            {
                if (i == chars.Length - 1)
                {
                    result += (string)chars[i].ToString() + counter;
                    break;
                }
                if (chars[i] == chars[i + 1])
                {
                    counter++;
                }
                if (chars[i] != chars[i + 1])
                {
                    result += (string)chars[i].ToString() + counter;
                    counter = 1;
                }
            }
            return result;
        }
    }
}
