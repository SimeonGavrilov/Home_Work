using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int MaxValue;
            double sum;
            //Console.WriteLine("Значение количества строк для ёлки");
            //string maxValue = Console.ReadLine();
            //if (int.TryParse(maxValue, out MaxValue)) MaxValue = int.Parse(maxValue);
            //else
            //{
            //    Console.WriteLine("Валидация провалилась!");
            //    Console.ReadKey();
            //    return;
            //}
            MaxValue = 1000;
            sum = 0;
            for (double i = 1; i < MaxValue; i++ )
            {
                if ((i % 3 == 0) | (i % 5 == 0)) sum += i;
            }
            Console.WriteLine("Сумма всех числе до {0}, кратных {1} и {2} = {3}", MaxValue, 3, 5, sum); //простор для полиморфизма на будущее. Полиморфизм же - универсальность?
            Console.ReadKey();
        }
    }
}
