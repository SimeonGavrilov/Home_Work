using System;
using System.Text.RegularExpressions;

namespace _7._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write your string");
            string str = Console.ReadLine();
            string re = @"\s[a-z0-9]+([_\.\-][a-z0-9]+)*@[a-z0-9]+([\.\-][a-z0-9])*\.[a-z]{2,6}";
            var end = Regex.Matches(str, re);
            Console.WriteLine();
            Console.WriteLine("Ok, i see there this e-mail(s):");
            for (int i = 0; i < end.Count; i++)
            {
                Console.Write(end[i]);
                Console.WriteLine();
            }
        }
    }
}
