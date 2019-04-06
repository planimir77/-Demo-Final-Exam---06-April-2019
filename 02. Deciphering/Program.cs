using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string[] inOut = Console.ReadLine()
                             .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                             .ToArray();
            string firstSing = inOut[0];
            string secondSing = inOut[1];

            Regex regex = new Regex(@"([d-z]|\||#|{|})");
            MatchCollection match = regex.Matches(message);
            StringBuilder sb = new StringBuilder();

            foreach (Match item in match)
            {
                sb.Append((char)(Char.Parse(item.ToString())-3));
            }

            if (!(sb.ToString().Length ==  message.Length))
            {
                Console.WriteLine("This is not the book you are looking for.");
                return;
            }

            sb = sb.Replace(firstSing,secondSing);
            Console.WriteLine(sb);
        }
    }
}
