using System;
using System.Text.RegularExpressions;

namespace _7._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку с датой для распознания в формате (dd-mm-yyyy).");
            string str = Console.ReadLine();
            string re = @"[0-3][0-9]-[0-1][0-9]-[1-2][0-9][0-9][0-9]";
            var end = Regex.Matches(str, re);
            Console.WriteLine("В строке обнаружена дата(ы):");
            for (int i = 0; i < end.Count; i++)
            {
                Console.WriteLine(end[i]);
            }
        }
    }
}
