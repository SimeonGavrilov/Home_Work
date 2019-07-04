using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._12
{
    class Program
    {
        static void Main(string[] args)
        {
            string FirstString = "написать программу, которая";
            string SecondString = "описание";
            string OutString = "";
            foreach (char x in FirstString) //пробегаемся по строке
                if (!SecondString.Contains(x)) //если совпадения нет - просто добавляем один символ
                    OutString += x;
                else //при совпадении дублируем этот символ
                {
                    OutString += x;
                    OutString += x;
                }
            Console.WriteLine();
            Console.WriteLine(OutString);
            Console.ReadKey();
        }
    }
}
