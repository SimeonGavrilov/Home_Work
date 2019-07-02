using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            AllTasks obj = new AllTasks();
            int NumOfString;
            Console.WriteLine("Значение количества строк для ёлки");
            string numOfString = Console.ReadLine();
            if (int.TryParse(numOfString, out NumOfString)) NumOfString = int.Parse(numOfString);
            else
            {
                Console.WriteLine("Валидация провалилась!");
                Console.ReadKey();
                return;
            }
            int Lenght;
            Console.WriteLine("Требуется ввод длины");
            string EnterLenght = Console.ReadLine();
            if (int.TryParse(EnterLenght, out Lenght)) Lenght = int.Parse(EnterLenght);
            else
            {
                Console.WriteLine("Валидация провалилась!");
                Console.ReadKey();
                return;
            }
            int Width;
            Console.WriteLine("Требуется ввод ширины");
            string EnterWidth = Console.ReadLine();
            if (int.TryParse(EnterWidth, out Width)) Width = int.Parse(EnterWidth);
            else
            {
                Console.WriteLine("Валидация провалилась!");
                Console.ReadKey();
                return;
            }
            if (Lenght <= 0 | Width <= 0)
            {
                Console.WriteLine("Вводимые параметры должны быть больше нуля!");
                return;
            }
            obj.WriteSquare(Lenght, Width);
            Console.WriteLine("Задание №1 завершено, для продолжения ввести любое значение");
            Console.ReadKey();
            Console.WriteLine();
            obj.WriteHalfTree(NumOfString);
            Console.WriteLine();
            Console.WriteLine("Задание №2 закончено, для продолжения введите любое значение");
            Console.ReadKey();
            obj.GetTree(NumOfString);
            Console.WriteLine("Задание №3 закончено, для продолжения введите любое значение");
            Console.WriteLine();
            Console.ReadKey();
            obj.TreeOfTree(NumOfString);
            Console.WriteLine();
            Console.WriteLine("Задание №4 закончено, для продолжения введите любое значение");
            Console.ReadKey();
        }
        class AllTasks
        {
            public void WriteSquare(int a, int b) //метод площади
            {
                Console.WriteLine("Площадь прямоугольника равна {0}", a * b);
            }

            public void WriteHalfTree(int n) //половинчатая ёлка
            {
                for (int i = 1; i <= n; i++)
                {
                    Console.WriteLine();
                    for (int j = 1; j <= i; j++)
                    {
                        Console.Write("*");
                    }
                }
            }

            public void GetTree(int n) //полная ёлка
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine();
                    for (int j = 1; j < n - i; j++)
                    {
                        Console.Write(" ");
                    }

                    for (int j = n - 2 * i; j <= n; j++)
                    {
                        Console.Write("*");
                    }
                }
            }
            public void TreeOfTree(int n) //ёлка из ёлок
            {
            n = n + 1; //при добавление в верхний цилк уловия k <= n+1 - появляется лишняя звезда в последнем треугольнике. Проще так.
            for (int k = 1; k <= n; k++)
            {
                for (int i = 0; i < k; i++)
                {
                    Console.WriteLine();
                    for (int j = 1; j < n - i; j++)
                    {
                        Console.Write(" ");
                    }

                    for (int j = n - 2 * i; j <= n; j++)
                    {
                        Console.Write("*");
                    }
                }
            }

            }
        }
    }
}
