using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._6
{
    delegate void MessageHandler(int[] mass1);
    public delegate void ReturnMinMax(int[]mass);
    delegate int Func(int[] x);
    class Program
    {
        static void Main(string[] args)
        {
            int[] mass = new int[] { -1, 2, 3 - 5, 1, 6, 10, -11 };


            MessageHandler handler = delegate(int[] mass1) //anon delegate(3)
            {
                int min = mass[0];
                int max = mass[0];

                for (int i = 0; i < mass.Length; i++)
                {
                    if (mass[i] > max)
                    {
                        max = mass[i];
                    }
                    if (mass[i] < min)
                    {
                        min = mass[i];
                    }
                }
                Console.WriteLine("min - ({0}), max - ({1})", min, max);
            };
                                        handler(mass);
                                        ReturnMinMax del = MinMax; //delegate(2)
                                        del(mass);
            //MinMax(mass); //standart(1)

            Func<int[], int> ResultMax = x => x.Max(); //lambda expressions(4)
            Func<int[], int> ResultMin = x => x.Min();
            Console.WriteLine(ResultMax(mass));
            Console.WriteLine(ResultMin(mass));

            var LINQ_Result_Max = from x in mass//LINQ(5)
                                  where x == mass.Max()
                                  select x;
            var LINQ_Result_Min = from x in mass
                                  where x == mass.Min()
                                  select x;
            Console.WriteLine();
            foreach (var item in LINQ_Result_Max)
            {
                Console.WriteLine(item);
            }
            foreach (var item in LINQ_Result_Min)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
            
           
        }
        public static void MinMax(int[] mass)
        {
            int min = mass[0];
            int max = mass[0];

            for (int i = 0; i < mass.Length; i++)
			{
                if (mass[i] > max)
                {
                    max = mass[i];
                }
                if (mass[i] < min)
                {
                    min = mass[i];
                }
			}
            Console.WriteLine("min - ({0}), max - ({1})", min,max);
        }
    }
}
