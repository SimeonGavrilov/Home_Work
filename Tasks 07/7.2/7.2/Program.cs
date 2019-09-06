using System;
using System.Text.RegularExpressions;

namespace _7._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string with HTML");
            string str = Console.ReadLine();
            string re = @"<[^<>]+>";
            string rep = "_";
            string end = Regex.Replace(str, re, rep);
            Console.WriteLine("Result is:");
            Console.WriteLine(end);
        }
    }
}
