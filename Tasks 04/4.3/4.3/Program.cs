using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _4._3
{
    public delegate void CallBack(string result);
    delegate bool StrCheck(string str1, string str2);
    class Program
    {
        static void Main(string[] args)
        {
            string[] mass = new string[] { "aaca", "aaaa", "aab", "aaa", "aaaaa", "aa", "az", "aaz", "abaaa", "aabaa", "1aa", "a1a"};
            MyCheckArray obj = new MyCheckArray(mass);
            Thread th1 = new Thread(obj.SortByLength);
            th1.Start();
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();
            obj.PrintMass();
            Console.ReadKey();
        }
    }
    public class MyCheckArray
    {
        public static void Print(CallBack callback)
        {
            callback("Done! Press any key to write array.");
        }
        public void TestCallBack(string result)
        {
            Console.WriteLine(result);
        }



        private string[] _array;
        public MyCheckArray(string[] mass)
        {
            _array = mass;
        }
        StrCheck del1 = StringChecker; // assign delegate method
        public void SortByLength()
        {
            CallBack callback = TestCallBack;
            Console.WriteLine("Sorting in progress...");
            for (int i = 0; i < _array.Length; i++)
            {
                for (int j = 0; j < _array.Length - 1; j++)
                {
                    if (_array[j].Length > _array[j + 1].Length)
                    {
                        string str = _array[j];
                        _array[j] = _array[j + 1];
                        _array[j + 1] = str;
                    }
                    if (del1/*?*/.Invoke(_array[j], _array[j + 1]))//
                    {
                        string str = _array[j];
                        _array[j] = _array[j + 1];
                        _array[j + 1] = str;
                    }
                }
            }
            Thread.Sleep(TimeSpan.FromSeconds(2)); //stretching time, so that you can respond
            Print(callback);
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
