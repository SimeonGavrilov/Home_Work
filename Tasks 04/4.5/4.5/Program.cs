using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._5
{
    delegate bool Num(char a);
    class Program
    {
        static void Main(string[] args)
        {
            string str = "-2.1";
            Console.WriteLine(IsCorrect(str)); 
            Console.ReadKey();
        }
        static bool IsCorrect(string str)// I do not know what else to add. The conditions of the problem are met.
        {
            foreach (var item in str)
            {
                if (!char.IsDigit(item))
                    return false;
            }
            return true;
        }
    }
}
