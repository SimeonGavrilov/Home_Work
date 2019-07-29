using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _4._1
{
    delegate string[] MySort(string[] mass); //delegete just for training
    delegate bool StrCheck(string str1, string str2);
    class Program
    {
        static void Main(string[] args)
        {
            string[] mass = new string[] { "aaca", "aaaa", "aab", "aaa", "aaaaa", "aa", "az", "aaz", "abaaa", "aabaa", "1aa", "a1a"};
            MyCheckArray obj = new MyCheckArray();
            Thread th1 = new Thread(obj.PrintMass);
            th1.Start();
            MySort del = obj.SortByLength;
            del/*?*/.Invoke(mass);
            //obj.SortByLength(mass);
            // obj.SortByAlphabet(mass);
            del/*?*/.Invoke(mass); //with "?" dosn't work
            Console.ReadKey();
            
        }
    }
    public class MyCheckArray
    {
        StrCheck del1 = StringChecker; // assign delegate method
        private string[] _array;
        public string[] SortByLength(string[] mass)
        {
            for (int i = 0; i < mass.Length; i++)
            {
                for (int j = 0; j < mass.Length - 1; j++)
                {
                    if (mass[j].Length > mass[j + 1].Length)
                    {
                        string str = mass[j];
                        mass[j] = mass[j + 1];
                        mass[j + 1] = str;
                    }
                    if (del1/*?*/.Invoke(mass[j], mass[j + 1]))//
                    {
                        string str = mass[j];
                        mass[j] = mass[j + 1];
                        mass[j + 1] = str;
                    }
                }
            }
            _array = mass;
            return mass;
        }

        public void PrintMass()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                Console.WriteLine(_array[i]);
            }
        }

        protected static bool StringChecker(string str1, string str2)
        {
            if (str1.Length == str2.Length)
            {
                for (int i = 0; i < (str1.Length > str2.Length ? str2.Length : str1.Length); i++)
                {
                    if (str1.ToCharArray()[i] < str2.ToCharArray()[i]) return false;
                    if (str1.ToCharArray()[i] > str2.ToCharArray()[i]) return true;
                }
            }
                return false;
        }
    }
}
